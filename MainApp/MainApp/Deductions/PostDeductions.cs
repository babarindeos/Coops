using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace MainApp
{
    public partial class PostDeductions : Form
    {
        int memberID;
        decimal totalSavings;
        decimal monthlyLoanRepayment;
        int numOfRows;
        int errorflag = 0;
        string repaymentLoanType;
        bool servicingLoan = false;
        bool loanMoreThanSavings = false;



        public PostDeductions()
        {
            InitializeComponent();

            //LstDeduction Properties
            lstDeductions.View = View.Details;
            lstDeductions.FullRowSelect = true;

            //LstDeductions Columns
            lstDeductions.Columns.Add("SN", 60);
            lstDeductions.Columns.Add("MemberID", 0);
            lstDeductions.Columns.Add("File No", 80);
            lstDeductions.Columns.Add("Name", 200);
            lstDeductions.Columns.Add("Savings", 150);
            lstDeductions.Columns.Add("Loans", 150);
            lstDeductions.Columns.Add("Total", 200);
            lstDeductions.Columns.Add("Action", 100);


            //LstDeductions Alignment
            lstDeductions.Columns[4].TextAlign = HorizontalAlignment.Right;
            lstDeductions.Columns[5].TextAlign = HorizontalAlignment.Right;
            lstDeductions.Columns[6].TextAlign = HorizontalAlignment.Right;


            //populate cboMonth and cboYear
            populateCboMonth();
            populateCboYear();
           
        }

        

        private void populateCboMonth()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select MonthID,Month from MonthByName";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "MonthByName");
                DataTable dt = ds.Tables["MonthByName"];
                cboMonth.DataSource = dt;
                cboMonth.DisplayMember = "Month";
                cboMonth.ValueMember = "MonthID";

                /*
                DataRow row = dt.NewRow();
                row["Month"] = "Select Month";
                dt.Rows.InsertAt(row, 0);
                 * */

                cboMonth.DataSource = dt;

                DateTime dtTime = DateTime.Now;
                int thisMonth = dtTime.Month;
                cboMonth.SelectedValue = thisMonth;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void populateCboYear()
        {
            DateTime myDate = DateTime.Now;
            int thisYear = myDate.Year;
            int startYear = 1990;

            int countforward = 40;
            int loop = 0;
            while (loop <= countforward)
            {
                cboYear.Items.Add(startYear++);
                loop++;
            }

            cboYear.SelectedItem = thisYear;
        }


        private void PostDeductions_Load(object sender, EventArgs e)
        {
            decimal loanMonthlyRepayment;
            int memberID;
            int counter;
            decimal totalDeduction;

            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select m.MemberID, m.FileNo, m.Title + ' ' + m.LastName + ' ' + m.FirstName + ' ' + m.MiddleName as Name, " +
                "SUM(s.Amount) as Amount from Members m inner join MemberSavingsTypeAcct s on m.MemberID=s.MemberID group by m.MemberID,m.FileNo,m.Title,m.FirstName,m.LastName,m.MiddleName";

            SqlCommand cmd = new SqlCommand(strQuery, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    counter = 0;
                    while (reader.Read())
                    {
                        counter++;

                        memberID = Convert.ToInt32(reader["MemberID"].ToString());

                        //Total Monthly Savings
                        totalSavings = Convert.ToDecimal(reader["Amount"]);

                        //check for loan records
                        loanMonthlyRepayment = getMonthlyLoan(memberID);

                        //calculate monthly total deduction using the total savings plus monthly loan repayment
                        totalDeduction = loanMonthlyRepayment + totalSavings;

                        //add data to the lstDeductions
                        String[] row = {counter.ToString(),reader["MemberID"].ToString(), reader["FileNo"].ToString(), 
                                           reader["Name"].ToString(),CheckForNumber.formatCurrency2(totalSavings.ToString()),
                                           CheckForNumber.formatCurrency2(loanMonthlyRepayment.ToString()), CheckForNumber.formatCurrency(totalDeduction.ToString())};
                        ListViewItem item = new ListViewItem(row);
                        lstDeductions.Items.Add(item);

                    }
                    reader.Close();
                    lblRecordNo.Text = "No. of Records: " + counter.ToString();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Post Deductions: - " + ex.Message);
            }
            finally
            {
                conn.Close();
            }


        }


        private decimal getMonthlyLoan(int memberID)
        {
            decimal monthlyRepayment = 0;
            SqlConnection conn2 = ConnectDB.GetConnection();

            string strQuery = "Select a.MonthlyRepayment, l.OutstandingAmount, t.Type as LoanType from LoanApplication a " +
                "inner join Loans l on a.LoanApplicationID = l.LoanApplicationID " +
                "inner join LoanType t on a.LoanTypeID=t.LoanTypeID where a.MemberID=@MemberID and l.OutstandingAmount<>0";

            SqlCommand cmdLoan = new SqlCommand(strQuery, conn2);
            cmdLoan.Parameters.Add("@MemberID", SqlDbType.Int);
            cmdLoan.Parameters["@MemberID"].Value = memberID;

            try
            {
                conn2.Open();

                SqlDataReader loanReader = cmdLoan.ExecuteReader();
                int recFound = loanReader.Cast<object>().Count();
                //MessageBox.Show(recFound.ToString());
                loanReader.Close();

                SqlDataReader readerGetLoanInfo = cmdLoan.ExecuteReader(CommandBehavior.SingleRow);
                if (readerGetLoanInfo.HasRows)
                {
                    if (readerGetLoanInfo.Read())
                    {

                        monthlyRepayment = Convert.ToDecimal(readerGetLoanInfo["MonthlyRepayment"]);
                        repaymentLoanType = readerGetLoanInfo["LoanType"].ToString();
                        servicingLoan = true;

                        //MessageBox.Show("Monthly Loan Repayment: " + readerGetLoanInfo["MonthlyRepayment"].ToString() +
                        //  "\nLoan Type: " + repaymentLoanType);

                        //Check if monthlyRepayment is greater than Monthly savings, if it is deposit (zero - nothing)
                        //in members savings, otherwise deposit balance from loan into savings
                        if (monthlyRepayment >= totalSavings)
                        {
                            totalSavings = 0;
                            loanMoreThanSavings = true;
                        }
                        else
                        {
                            totalSavings = totalSavings - monthlyRepayment;
                        }

                    }
                }
                

                readerGetLoanInfo.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("getLoanTotal: - " + ex.Message);
            }
            finally
            {
                conn2.Close();
            }

            return monthlyRepayment;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lstDeductions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDeductions.SelectedItems.Count != 0)
            {
                string memberID = lstDeductions.SelectedItems[0].SubItems[1].Text;
                getSavingsInfo(memberID);
                getLoansInfo(memberID);
            }
        }

        //get selected listview member savings
        private void getSavingsInfo(string memberID)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string sqlQuery = "Select Remark as [Savings Type],Amount as Total from MemberSavingsTypeAcct where MemberID=@MemberID";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);

            cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@MemberID"].Value = memberID;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();



            try
            {
                conn.Open();
                da.Fill(ds, "Savings");
                DataTable dt = ds.Tables["Savings"];

                datGrdSavings.DataSource = null;
                datGrdSavings.DataSource = dt;


                datGrdSavings.Columns["Total"].DefaultCellStyle.Format = "N2";
                datGrdSavings.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        //get loans of selected listview
        private void getLoansInfo(string memberID)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string sqlQuery = "Select a.MonthlyRepayment,l.RepaymentAmount,l.AmountPaid,l.OutstandingAmount from LoanApplication a " +
                "inner join Loans l on a.LoanApplicationID = l.LoanApplicationID where a.MemberID=@MemberID and l.OutstandingAmount<>0";

            SqlCommand cmd = new SqlCommand(sqlQuery, conn);

            cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@MemberID"].Value = memberID;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Loans");
                DataTable dt = ds.Tables["Loans"];

                datGrdLoans.DataSource = null;
                datGrdLoans.DataSource = dt;

                datGrdLoans.Columns["MonthlyRepayment"].HeaderText = "Monthly Repayment";
                datGrdLoans.Columns["RepaymentAmount"].HeaderText = "Repayment Amount";
                datGrdLoans.Columns["AmountPaid"].HeaderText = "Amount Paid";
                datGrdLoans.Columns["OutstandingAmount"].HeaderText = "Outstanding Amount";

                datGrdLoans.Columns["MonthlyRepayment"].DefaultCellStyle.Format = "N2";
                datGrdLoans.Columns["RepaymentAmount"].DefaultCellStyle.Format = "N2";
                datGrdLoans.Columns["AmountPaid"].DefaultCellStyle.Format = "N2";
                datGrdLoans.Columns["OutstandingAmount"].DefaultCellStyle.Format = "N2";

                datGrdLoans.Columns["MonthlyRepayment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdLoans.Columns["RepaymentAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdLoans.Columns["AmountPaid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdLoans.Columns["OutstandingAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void btnPostDeduction_Click(object sender, EventArgs e)
        {

            int selMonth = (int)cboMonth.SelectedValue;
            int selYear = Convert.ToInt16(cboYear.Text);

            bool isAlreadyPosted = checkIfAlreadyPosted(selMonth, selYear);
            if (isAlreadyPosted == false)
            {
                DialogResult res = MessageBox.Show("Do you want to execute posting for the selected Month and Year?\n " +
                    "Please be sure about this because this process is not reversible", "Deduction Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    executeDeduction();
                }
            }
            else
            {
                MessageBox.Show("Posting for " + cboMonth.Text + " " + cboYear.Text + " has already been executed", "Deduction Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //MessageBox.Show(lstDeductions.Items.Count.ToString());
        }

        //check if that posting had been done for that month and year
        private bool checkIfAlreadyPosted(int month, int year)
        {
            int recFound = 0;
            bool result;

            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "select count(*) from Deductions where Month=@Month and Year=@Year";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            cmd.Parameters.Add("@Month", SqlDbType.Int);
            cmd.Parameters["@Month"].Value = month;

            cmd.Parameters.Add("@Year", SqlDbType.Int);
            cmd.Parameters["@Year"].Value = year;

            try
            {
                conn.Open();
                recFound = (int)cmd.ExecuteScalar();
                //MessageBox.Show(recFound.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            if (recFound == 0) { result = false; } else { result = true; }

            return result;
        }

        private void executeDeduction()
        {
            int numOfRecords = lstDeductions.Items.Count;
            int currentRecord;

            SqlConnection conn = ConnectDB.GetConnection();
            SqlTransaction sqlTrans = null;
            SqlCommand cmd;

            try
            {

                conn.Open();
                sqlTrans = conn.BeginTransaction();

                cmd = conn.CreateCommand();
                cmd.Transaction = sqlTrans;

                int selectedMonth = Convert.ToInt16(cboMonth.SelectedValue);
                int selectedYear = Convert.ToInt16(cboYear.Text);        

                #region loop through records
                //loop through records
                for (currentRecord = 0; currentRecord < numOfRecords; currentRecord++)
                {
                    cmd.Parameters.Clear();

                    memberID = Convert.ToInt16(lstDeductions.Items[currentRecord].SubItems[1].Text);
                    decimal monthlyLoanRepayment = Convert.ToDecimal(lstDeductions.Items[currentRecord].SubItems[5].Text);
                    decimal lstAllSavingsDeduction = Convert.ToDecimal(lstDeductions.Items[currentRecord].SubItems[4].Text);
                    decimal lstAllLoansDeduction = Convert.ToDecimal(lstDeductions.Items[currentRecord].SubItems[5].Text);
                    decimal lstTotalDeductions = Convert.ToDecimal(lstDeductions.Items[currentRecord].SubItems[6].Text);

                    totalSavings = Convert.ToDecimal(lstDeductions.Items[currentRecord].SubItems[4].Text);

                    string transactionID = "DED" + DateTime.Now.ToString("ddMMyyhhmmss");

                    Deduction newPosting = new Deduction();
                    string postSavingsStatus  = newPosting.postSavings(conn, cmd, sqlTrans, memberID, transactionID, totalSavings, numOfRows, errorflag, selectedMonth, selectedYear);
                    MessageBox.Show("Post Savings Status: " + postSavingsStatus);
                    
                    string postLoansStatus = newPosting.postLoans(conn, cmd, sqlTrans, memberID, transactionID, currentRecord, selectedMonth, selectedYear, numOfRows, errorflag, monthlyLoanRepayment);
                    MessageBox.Show("PostLoan Status: " + postLoansStatus);

                    string recordDeductionStatus = newPosting.recordDeduction(cmd, memberID, transactionID, currentRecord, selectedMonth, selectedYear, lstAllSavingsDeduction, lstAllLoansDeduction, lstTotalDeductions, numOfRows, errorflag);
                    MessageBox.Show("Record Deductions status: " + recordDeductionStatus);

                    string recordDeductionDetailsStatus = newPosting.recordDeductionDetails(cmd, memberID, transactionID, currentRecord, numOfRows, errorflag, lstAllSavingsDeduction, lstAllLoansDeduction, repaymentLoanType, servicingLoan, loanMoreThanSavings);
                    MessageBox.Show("Record Deduction Detail Status: " + recordDeductionDetailsStatus);

                    if (errorflag == 0)
                    {
                        MessageBox.Show("Posted");
                        //lstDeductions.Items[currentRecord].SubItems[7].Text = "Posted";
                    }
                }
                //end of for loop
                #endregion end of loop


                if (errorflag == 0)
                {
                    sqlTrans.Commit();
                    MessageBox.Show("Transaction committed");
                }
                else
                {
                    sqlTrans.Rollback();
                    MessageBox.Show("Transaction Failed");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();

            }

        }//end of executeDeduction

        private void txtAddFileNo_TextChanged(object sender, EventArgs e)
        {
            if (txtAddFileNo.Text.Length == 0)
            {
                btnAddDeduction.Enabled = false;
            }
            else
            {
                btnAddDeduction.Enabled = true;
            }
        }

        private void btnRemoveDeductions_Click(object sender, EventArgs e)
        {
            if (lstDeductions.SelectedItems.Count > 0)
            {
                DialogResult res = MessageBox.Show("Do you really wish to remove the selected record?", "Deduction Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    lstDeductions.Items.RemoveAt(lstDeductions.SelectedIndices[0]);
                    datGrdSavings.DataSource = null;
                    datGrdLoans.DataSource = null;
                }
            }
            else
            {
                MessageBox.Show("No record has been selected to be removed from the List.\nPlease select a record to remove from the List", "Deduction Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnAddDeduction_Click(object sender, EventArgs e)
        {
            //check if the fileno is genuine and is not already in the list
            //get number of all records
            int numOfRecords = lstDeductions.Items.Count - 1;
            bool alreadyInList = false;
            bool memberExist = false;
            string addFileNoDeduction;
            decimal monthlyLoanRepayment;
            decimal totalDeduction;
            int memberID = 0;
            string lastRecId;
            int nextRecId;

            
            SqlConnection conn = null;
            SqlCommand cmd = null;

            conn = ConnectDB.GetConnection();
            cmd = conn.CreateCommand();

            conn.Open();
            
            addFileNoDeduction = txtAddFileNo.Text.Trim().ToUpper();

            #region check if member is genuine and exist
            string strQuery = "Select MemberID,FileNo from Members where FileNo='" + addFileNoDeduction + "'";
            cmd.CommandText = strQuery;

            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    memberID = Convert.ToInt16(reader["MemberID"]);
                    memberExist = true;
                    reader.Close();
                }
                else
                {
                    memberExist = false;
                    MessageBox.Show("Sorry, No member with that File No", "Deduction Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            #endregion
            

            #region Check if the FileNo is already in the List if it is a genuine member FileNo
            if (memberExist)
            {
                for (int i = 0; i < numOfRecords; i++)
                {
                    if (addFileNoDeduction == lstDeductions.Items[i].SubItems[2].Text.ToString().ToUpper())
                    {
                        alreadyInList = true;
                        DialogResult res = MessageBox.Show("That Record is Already in the List", "Deduction Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
            }
            #endregion

            
            #region get loan amount for the entered member if it does not exist in the list
            if ((memberExist == true) && (alreadyInList == false))
            {

                //Get member's Savings using memberID
                strQuery = "Select m.MemberID, m.FileNo, m.Title + ' ' + m.LastName + ' ' + m.FirstName + ' ' + m.MiddleName as Name, " +
                "SUM(s.Amount) as Amount from Members m inner join MemberSavingsTypeAcct s on m.MemberID=s.MemberID where m.MemberID=" + memberID + " group by m.MemberID,m.FileNo,m.Title,m.FirstName,m.LastName,m.MiddleName";

                cmd.CommandText = strQuery;

                try
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {

                            //get the serial id of the last record
                            lastRecId = lstDeductions.Items[numOfRecords].SubItems[0].Text;

                            //Add 1 to the last record Id to get the next record id
                            nextRecId = (Int16.Parse(lastRecId)) + 1;
                            
                            //check for loan records                                
                            monthlyLoanRepayment = getMonthlyLoan(memberID);

                            //calculate monthly total deduction using the total savings plus monthly loan repayment
                            totalDeduction = monthlyLoanRepayment + Convert.ToDecimal(reader["Amount"]);

                            //add data to the lstDeductions
                            String[] row = {nextRecId.ToString(),reader["MemberID"].ToString(), reader["FileNo"].ToString(), 
                                                   reader["Name"].ToString(),CheckForNumber.formatCurrency(reader["Amount"].ToString()),
                                                   CheckForNumber.formatCurrency2(monthlyLoanRepayment.ToString()), CheckForNumber.formatCurrency(totalDeduction.ToString())};
                            ListViewItem item = new ListViewItem(row);
                            lstDeductions.Items.Add(item);
                            txtAddFileNo.Text = string.Empty;
                            btnAddDeduction.Enabled = false;

                        }
                        reader.Close();
                        lblRecordNo.Text = "No. of Records: " + lstDeductions.Items.Count.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Last Phase: " + ex.Message);
                }
            }
            #endregion end of if statement
        }
   
    
    }
        

        


}

