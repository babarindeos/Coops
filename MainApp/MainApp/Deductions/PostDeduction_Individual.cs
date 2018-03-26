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

namespace MainApp
{
    public partial class PostDeduction_Individual : Form
    {
        int memberID;
        decimal totalSavings;
        decimal monthlyLoanRepayment;
        int numOfRows;
        int errorflag = 0;
        string repaymentLoanType;
        bool servicingLoan = false;
        bool loanMoreThanSavings = false;
        string UserId;

        public PostDeduction_Individual(string UserID)
        {
            InitializeComponent();
            UserId = UserID;

            //LstDeduction Properties
            lstMonthlyDeductions.View = View.Details;
            lstMonthlyDeductions.FullRowSelect = true;

            //LstDeductions Columns
            lstMonthlyDeductions.Columns.Add("SN", 40);
            lstMonthlyDeductions.Columns.Add("MemberID", 0);
            lstMonthlyDeductions.Columns.Add("File No", 80);
            lstMonthlyDeductions.Columns.Add("Name", 250);
            lstMonthlyDeductions.Columns.Add("Savings", 120);
            lstMonthlyDeductions.Columns.Add("Loans", 120);
            lstMonthlyDeductions.Columns.Add("Total", 150);
            lstMonthlyDeductions.Columns.Add("Status", 100);


            //LstDeductions Alignment
            lstMonthlyDeductions.Columns[4].TextAlign = HorizontalAlignment.Right;
            lstMonthlyDeductions.Columns[5].TextAlign = HorizontalAlignment.Right;
            lstMonthlyDeductions.Columns[6].TextAlign = HorizontalAlignment.Right;
            lstMonthlyDeductions.Columns[7].TextAlign = HorizontalAlignment.Right;

            //populate cboMonth and cboYear
            populateCboMonth();
            populateCboYear();


            //lstVwSavings Properties
            lstVwSavings.View = View.Details;
            lstVwSavings.FullRowSelect = true;

            //lstVwSavings Columns
            lstVwSavings.Columns.Add("TypeID", 0);
            lstVwSavings.Columns.Add("Type", 100);
            lstVwSavings.Columns.Add("Amount", 100);

            //lstVwSavings Alignment
            lstVwSavings.Columns[2].TextAlign = HorizontalAlignment.Right;


            //lstVwLoans Properties
            lstVwLoans.View = View.Details;
            lstVwLoans.FullRowSelect = true;

            //lstVwLoans Columns
            lstVwLoans.Columns.Add("Monthly Repay",100);
            lstVwLoans.Columns.Add("Loan Repayment",100);
            lstVwLoans.Columns.Add("Amount Paid",100);
            lstVwLoans.Columns.Add("Outstanding",100);
            lstVwLoans.Columns.Add("Loan type", 100);
            lstVwLoans.Columns.Add("LoanTypeID", 50);

            //lstVwLoans Alignment
            lstVwLoans.Columns[0].TextAlign = HorizontalAlignment.Right;
            lstVwLoans.Columns[1].TextAlign = HorizontalAlignment.Right;
            lstVwLoans.Columns[2].TextAlign = HorizontalAlignment.Right;
            lstVwLoans.Columns[3].TextAlign = HorizontalAlignment.Right;                     

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

        private void getPreviousDeductionDate(int memberID)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select d.DeductionID, m.Month + ' ' + d.Year as DeductionMonthYear from Deductions d left join MonthByName m" +
                " on d.Month=m.MonthID where d.MemberID=" + memberID + " order by DeductionID desc";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (reader.HasRows)
                {
                    reader.Read();
                    lblPreviousPosting.Text = "Previous Deduction : " + reader["DeductionMonthYear"].ToString();
                }
                else
                {
                    lblPreviousPosting.Text = "No Previous Deductions";
                }
                reader.Close();
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

        private void txtFindByFileNo_TextChanged(object sender, EventArgs e)
        {
            if (txtFindByFileNo.Text.Length != 0)
            {
                btnFindMember.Enabled = true;
            }
            else
            {
                btnFindMember.Enabled = false;
            }
        }

        private void btnFindMember_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select MemberID, FileNo, LastName + ' ' + FirstName + ' ' + MiddleName as Fullname, Photo from Members where FileNo='" + txtFindByFileNo.Text + "'";

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

                lstMonthlyDeductions.Items.Clear();
                if (reader.HasRows)
                {
                    reader.Read();
                    memberID = Convert.ToInt16(reader["MemberID"]);
                    memberPersonalInfo.Text = reader["Fullname"].ToString() + "\n" + reader["FileNo"].ToString();
                    if (reader["Photo"].ToString() != null || reader["Photo"].ToString() != string.Empty)
                    {
                        memberPic.Image = Image.FromFile(paths + "\\photos\\" + reader["Photo"].ToString());
                    }

                    memberPic.Visible = true;
                    memberPersonalInfo.Visible = true;

                    getMonthlyDeductionsInfo(memberID);
                    getMemberPreviousDeductions(memberID);
                    getPreviousDeductionDate(memberID);

                    btnPostDeduction.Enabled = true;


                    //Display Savings and Loan information
                    //lstMonthlyDeductions_SelectedIndexChanged(sender, e);
                    string selectedMemberID = lstMonthlyDeductions.Items[0].SubItems[1].Text;
                    getSavingsInfo(selectedMemberID);
                    getLoansInfo(selectedMemberID);
                }
                else
                {
                    memberPic.Image = Image.FromFile(paths + "\\photos\\profile_img.png");
                    MessageBox.Show("Sorry, there is no member with such File No.", "Deduction Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFindByFileNo_TextChanged(sender, e);
                }

                reader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Member Search - " + ex.Message);
            }
            finally
            {

            }
        }



        private void getMonthlyDeductionsInfo(int memberID)
        {
            decimal loanMonthlyRepayment;
            int counter;
            decimal totalDeduction;

            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select m.MemberID, m.FileNo, m.Title + ' ' + m.LastName + ' ' + m.FirstName + ' ' + m.MiddleName as Name, " +
                "SUM(s.Amount) as Amount from Members m inner join MemberSavingsTypeAcct s on m.MemberID=s.MemberID where m.MemberID=" + memberID + " group by m.MemberID,m.FileNo,m.Title,m.FirstName,m.LastName,m.MiddleName";

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
                        //check for loan records
                        loanMonthlyRepayment = getMonthlyLoan(memberID);

                        //calculate monthly total deduction using the total savings plus monthly loan repayment
                        totalDeduction = loanMonthlyRepayment + Convert.ToDecimal(reader["Amount"]);

                        //add data to the lstDeductions
                        String[] row = {counter.ToString(),reader["MemberID"].ToString(), reader["FileNo"].ToString(), 
                                           reader["Name"].ToString(),CheckForNumber.formatCurrency(reader["Amount"].ToString()),
                                           CheckForNumber.formatCurrency2(loanMonthlyRepayment.ToString()), CheckForNumber.formatCurrency(totalDeduction.ToString())};
                        ListViewItem item = new ListViewItem(row);

                        lstMonthlyDeductions.Items.Clear();
                        lstMonthlyDeductions.Items.Add(item);

                    }
                    reader.Close();
                    //lblRecordNo.Text = "No. of Records: " + counter.ToString();
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
                
                //MessageBox.Show("Loan Servicing found: " +  recFound.ToString());
                loanReader.Close();

                SqlDataReader readerGetLoanInfo = cmdLoan.ExecuteReader(CommandBehavior.SingleRow);
                if (readerGetLoanInfo.HasRows)
                {
                    if (readerGetLoanInfo.Read())
                    {

                        monthlyRepayment = Convert.ToDecimal(readerGetLoanInfo["MonthlyRepayment"]);
                        repaymentLoanType = readerGetLoanInfo["LoanType"].ToString();

                        //MessageBox.Show("Monthly Loan Repayment: " + readerGetLoanInfo["MonthlyRepayment"].ToString() +  "\nLoan Type: " + repaymentLoanType);
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

        private void getMemberPreviousDeductions(int memberID)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select d.DeductionID, m.Month, d.Year, d.Savings, d.Loans, d.Total, d.TransactionID, d.DatePosted from Deductions d "+
                "left join MonthByName m on d.Month=m.MonthID where MemberID=" + memberID + " order by d.DeductionID Desc";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Deductions");
                DataTable dt = ds.Tables["Deductions"];

                dtGridVPreviousDeductions.DataSource = dt;

                dtGridVPreviousDeductions.Columns["DeductionID"].HeaderText = "ID";
                dtGridVPreviousDeductions.Columns["DeductionID"].Width = 50;

                dtGridVPreviousDeductions.Columns["TransactionID"].HeaderText = "Transact. ID";
                dtGridVPreviousDeductions.Columns["DatePosted"].HeaderText = "Date Posted";

                dtGridVPreviousDeductions.Columns["Savings"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtGridVPreviousDeductions.Columns["Loans"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtGridVPreviousDeductions.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dtGridVPreviousDeductions.Columns["Savings"].DefaultCellStyle.Format = "N2";
                dtGridVPreviousDeductions.Columns["Loans"].DefaultCellStyle.Format = "N2";
                dtGridVPreviousDeductions.Columns["Total"].DefaultCellStyle.Format = "N2";

                lblPrevDeductionsCount.Text = "No. of Records: " + ds.Tables["Deductions"].Rows.Count.ToString();

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
            int selMemberID = memberID;

            bool isAlreadyPosted = checkIfAlreadyPosted(selMonth, selYear, selMemberID);
            if (isAlreadyPosted == false)
            {
                DialogResult res = MessageBox.Show("Do you wish to Execute Posting for the selected Member, Month and Year? " +
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
        }

        //check if that posting had been done for that month and year
        private bool checkIfAlreadyPosted(int month, int year, int selMember)
        {
            int recFound = 0;
            bool result;

            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "select count(*) from Deductions where Month=@Month and Year=@Year and MemberID=@selMemberID";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            cmd.Parameters.Add("@Month", SqlDbType.Int);
            cmd.Parameters["@Month"].Value = month;

            cmd.Parameters.Add("@Year", SqlDbType.Int);
            cmd.Parameters["@Year"].Value = year;

            cmd.Parameters.Add("@selMemberID", SqlDbType.Int);
            cmd.Parameters["@selMemberID"].Value = selMember;

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
            int numOfRecords = lstMonthlyDeductions.Items.Count;
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

                    memberID = Convert.ToInt16(lstMonthlyDeductions.Items[currentRecord].SubItems[1].Text);
                    decimal monthlyLoanRepayment = Convert.ToDecimal(lstMonthlyDeductions.Items[currentRecord].SubItems[5].Text);
                    decimal lstAllSavingsDeduction = Convert.ToDecimal(lstMonthlyDeductions.Items[currentRecord].SubItems[4].Text);
                    decimal lstAllLoansDeduction = Convert.ToDecimal(lstMonthlyDeductions.Items[currentRecord].SubItems[5].Text);
                    decimal lstTotalDeductions = Convert.ToDecimal(lstMonthlyDeductions.Items[currentRecord].SubItems[6].Text);


                    string transactionID = "DED" + DateTime.Now.ToString("ddMMyyhhmmss");
                    totalSavings = Convert.ToDecimal(lblTotalSavings.Text);

                    Deduction newPosting = new Deduction();
                    string postSavingsStatus = newPosting.postSavings(conn, cmd, sqlTrans, memberID, transactionID, lstAllSavingsDeduction, numOfRows, errorflag, selectedMonth, selectedYear);
                    //MessageBox.Show("Post Savings Status: " + postSavingsStatus);

                    string postLoansStatus = newPosting.postLoans(conn, cmd, sqlTrans, memberID, transactionID, currentRecord, selectedMonth, selectedYear, numOfRows, errorflag, monthlyLoanRepayment);
                    //MessageBox.Show("PostLoan Status: " + postLoansStatus);

                    string recordDeductionStatus = newPosting.recordDeduction(cmd, memberID, transactionID, currentRecord, selectedMonth, selectedYear, lstAllSavingsDeduction, lstAllLoansDeduction, lstTotalDeductions, numOfRows, errorflag);
                    //MessageBox.Show("Record Deductions status: " + recordDeductionStatus);

                    //string recordDeductionDetailsStatus = newPosting.recordDeductionDetails(cmd, memberID, transactionID, currentRecord, numOfRows, errorflag, lstAllSavingsDeduction, lstAllLoansDeduction, repaymentLoanType, servicingLoan, loanMoreThanSavings);
                    //MessageBox.Show("Record Deduction Detail Status: " + recordDeductionDetailsStatus);
                    int recordDeductionDetailStatus = recordDeductionDetails(cmd,memberID,transactionID,errorflag,numOfRows);
                    //MessageBox.Show(recordDeductionDetailStatus.ToString());

                    
                }
                //end of for loop
                #endregion end of loop


                if (errorflag==0)
                {
                    sqlTrans.Commit();
                    MessageBox.Show("Member Deduction has been successfully posted.","Deduction Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    getMonthlyDeductionsInfo(memberID);
                    getMemberPreviousDeductions(memberID);
                    getPreviousDeductionDate(memberID);

                    
                    //Display Savings and Loan information
                    //lstMonthlyDeductions_SelectedIndexChanged(sender, e);
                    string selectedMemberID = lstMonthlyDeductions.Items[0].SubItems[1].Text;
                    getSavingsInfo(selectedMemberID);
                    getLoansInfo(selectedMemberID);

                    txtChangeSavingsAmt.Text = string.Empty;
                    txtChangeLoanAmount.Text = string.Empty;

                    ActivityLog.logActivity(UserId, "Posting Deduction - Individual", "Deduction Posting for MemberID:" + memberID + " for  Month:" + selectedMonth + " " + selectedYear);
                }
                else
                {
                    sqlTrans.Rollback();
                    MessageBox.Show("Deduction Transaction failed and is aborted!","Deduction Info",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        }


        private int recordDeductionDetails(SqlCommand cmd,int memberID, string transactionID, int errorflag, int numOfRows)
        {
            //MessageBox.Show(lstVwSavings.Items.Count.ToString());
            string strQuery = "Select DeductionID,TransactionID from Deductions where TransactionID=@TransactionID";
            cmd.CommandText = strQuery;
            #region cmd parameters
            cmd.Parameters["@TransactionID"].Value = transactionID;
            #endregion

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int deductionID = (int)reader["DeductionID"];            
            reader.Close();

            //Insert Savings into DeductionsDetails
            int savingDeductionDetailStatus = SavingsDeductionDetails(cmd, transactionID, ref errorflag, ref numOfRows, ref strQuery, deductionID);

            //Insert Loans into DeductionsDetails
            int loanDeductionDetailStatus = LoansDeductionDetails(cmd, transactionID, ref errorflag, ref numOfRows, deductionID);


            
            return numOfRows; 
        }


        private int LoansDeductionDetails(SqlCommand cmd, string transactionID, ref int errorflag, ref int numOfRows, int deductionID)
        {

            string strQuery = "Insert into DeductionDetails(DeductionID,DeductionType,SavingsTypeID,Amount,Remarks,TransactionID)Values" +
               "(@DeductionID,@DeductionType,@SavingsTypeID,@Amount,@Remarks,@TransactionID)";

            cmd.CommandText = strQuery;
            
            string deductionType = string.Empty;
            decimal deductionAmount = 0;
            string loanTypeID = string.Empty;

            if (lstVwLoans.Items.Count != 0)
            {
                for (int i = 0; i < lstVwLoans.Items.Count; i++)
                {
                    deductionType = lstVwLoans.Items[i].SubItems[4].Text;
                    deductionAmount = Convert.ToDecimal(lstMonthlyDeductions.Items[i].SubItems[5].Text);
                    loanTypeID = lstVwLoans.Items[i].SubItems[5].Text;

                    #region cmd parameters
                    cmd.Parameters["@DeductionID"].Value = deductionID;
                    cmd.Parameters["@DeductionType"].Value = deductionType;
                    cmd.Parameters["@SavingsTypeID"].Value = loanTypeID;
                    cmd.Parameters["@Amount"].Value = deductionAmount;
                    cmd.Parameters["@Remarks"].Value = string.Empty;
                    cmd.Parameters["@TransactionID"].Value = transactionID;
                    #endregion cmd parameters
                    numOfRows = cmd.ExecuteNonQuery();
                    if (numOfRows == 0) { errorflag = 1; }

                }

            }

            return numOfRows;
        }

        private int SavingsDeductionDetails(SqlCommand cmd, string transactionID, ref int errorflag, ref int numOfRows, ref string strQuery, int deductionID)
        {
            strQuery = "Insert into DeductionDetails(DeductionID,DeductionType,SavingsTypeID,Amount,Remarks,TransactionID)Values" +
               "(@DeductionID,@DeductionType,@SavingsTypeID,@Amount,@Remarks,@TransactionID)";

            cmd.CommandText = strQuery;
            cmd.Parameters.Add("@DeductionID", SqlDbType.Int);
            cmd.Parameters.Add("@DeductionType", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@SavingsTypeID", SqlDbType.NVarChar, 10);
            //cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
            cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar, 400);
            //cmd.Parameters.Add("@TransactionID", SqlDbType.NVarChar, 50);

            string deductionType = string.Empty;
            decimal deductionAmount = 0;
            string savingTypeID = string.Empty;

            if (lstVwSavings.Items.Count != 0)
            {
                for (int i = 0; i < lstVwSavings.Items.Count; i++)
                {
                    //lstVwSavings.Items[i].SubItems[0].Text + " - " + lstVwSavings.Items[i].SubItems[1].Text);
                    deductionType = lstVwSavings.Items[i].SubItems[1].Text;
                    deductionAmount = Convert.ToDecimal(lstVwSavings.Items[i].SubItems[2].Text);
                    savingTypeID = lstVwSavings.Items[i].SubItems[0].Text;


                    #region cmd parameters
                    cmd.Parameters["@DeductionID"].Value = deductionID;
                    cmd.Parameters["@DeductionType"].Value = deductionType;
                    cmd.Parameters["@SavingsTypeID"].Value = savingTypeID;
                    cmd.Parameters["@Amount"].Value = deductionAmount;
                    cmd.Parameters["@Remarks"].Value = string.Empty;
                    cmd.Parameters["@TransactionID"].Value = transactionID;
                    #endregion cmd parameters
                    numOfRows = cmd.ExecuteNonQuery();
                    if (numOfRows == 0) { errorflag = 1; }
                }
            }

            return numOfRows;
        }

        private void lstMonthlyDeductions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMonthlyDeductions.SelectedItems.Count != 0)
            {
                string memberID = lstMonthlyDeductions.SelectedItems[0].SubItems[1].Text;
                getSavingsInfo(memberID);
                getLoansInfo(memberID);
            }
        }//end of executeDeduction

        private void getSavingsInfo(string memberID)
        {
            decimal calTotalSavings = 0;

            SqlConnection conn = ConnectDB.GetConnection();
            string sqlQuery = "Select SavingsTypeID,Remark,Amount from MemberSavingsTypeAcct where MemberID=@MemberID";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);

            cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar, 20);
            cmd.Parameters["@MemberID"].Value = memberID;

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                lstVwSavings.Items.Clear();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        calTotalSavings += Convert.ToDecimal(reader["Amount"]);
                        string[] row = { reader["SavingsTypeID"].ToString(), reader["Remark"].ToString(), CheckForNumber.formatCurrency2(reader["Amount"].ToString()) };
                        ListViewItem item = new ListViewItem(row);
                        lstVwSavings.Items.Add(item);
                    }
                    lblTotalSavings.Text = CheckForNumber.formatCurrency2(calTotalSavings.ToString());
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Get Savings Info - " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void getLoansInfo(string memberID)
        {
            //decimal loanMonthlyPayment = 0;
            //get loan amount
            decimal serviceLoanAmount = Convert.ToDecimal(lstMonthlyDeductions.Items[0].SubItems[5].Text);
            if (serviceLoanAmount > 0)
            {
                SqlConnection conn = ConnectDB.GetConnection();
                string sqlQuery = "Select a.MonthlyRepayment,l.RepaymentAmount,l.AmountPaid,l.OutstandingAmount, lt.Type, lt.LoanTypeID from LoanApplication a " +
                "inner join Loans l on a.LoanApplicationID = l.LoanApplicationID " +
                "inner join LoanType lt on a.LoanTypeID=lt.LoanTypeID " +
                "where a.MemberID=@MemberID and l.OutstandingAmount<>0";

                SqlCommand cmd = new SqlCommand(sqlQuery, conn);

                cmd.Parameters.Add("@MemberID", SqlDbType.NVarChar, 20);
                cmd.Parameters["@MemberID"].Value = memberID;


                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult);

                    lstVwLoans.Items.Clear();
                    if (reader.HasRows)
                    {
                         reader.Read();
                        
                            string[] row = {CheckForNumber.formatCurrency2(reader["MonthlyRepayment"].ToString()),CheckForNumber.formatCurrency2(reader["RepaymentAmount"].ToString()),CheckForNumber.formatCurrency2(reader["AmountPaid"].ToString()),CheckForNumber.formatCurrency2(reader["OutstandingAmount"].ToString()),reader["Type"].ToString(), reader["LoanTypeID"].ToString()};
                            ListViewItem item = new ListViewItem(row);
                            lstVwLoans.Items.Add(item);
                        
                        lblTotalLoans.Text = CheckForNumber.formatCurrency2(reader["MonthlyRepayment"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Get Loans Info: - " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void lstVwSavings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVwSavings.SelectedItems.Count != 0)
            {
                txtChangeSavingsAmt.Text = lstVwSavings.SelectedItems[0].SubItems[2].Text;
                txtChangeSavingsAmt.Enabled = true;
            }
        }

        private void txtChangeSavingsAmt_TextChanged(object sender, EventArgs e)
        {
            if ((lstVwSavings.SelectedItems.Count != 0) && (txtChangeSavingsAmt.Text != string.Empty))
            {
                btnChangeSavingsAmt.Enabled = true;
            }
        }

        private void btnChangeSavingsAmt_Click(object sender, EventArgs e)
        {
            decimal new_SavingsAmount;
            decimal totalSavingsRecalculated = 0;

            if (lstVwSavings.SelectedItems.Count > 0   && txtChangeSavingsAmt.Text != string.Empty)
            {
                int lstCountItem = lstVwSavings.Items.Count;

                if (Decimal.TryParse(txtChangeSavingsAmt.Text, out new_SavingsAmount))
                {
                    lstVwSavings.SelectedItems[0].SubItems[2].Text = CheckForNumber.formatCurrency2(txtChangeSavingsAmt.Text);

                    for (int i = 0; i < lstCountItem; i++)
                    {
                        totalSavingsRecalculated += Convert.ToDecimal(lstVwSavings.Items[i].SubItems[2].Text);
                    }

                    lblTotalSavings.Text = CheckForNumber.formatCurrency2(totalSavingsRecalculated.ToString());
                }
                else
                {
                    MessageBox.Show("The Amount entered is invalid", "Deduction Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Select an a Savings Type and Supply an Amount", "Deduction Info", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void lstVwLoans_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVwLoans.Items.Count != 0)
            {
                txtChangeLoanAmount.Enabled = true;
                btnChangeLoanAmt.Enabled = true;

                txtChangeLoanAmount.Text = lstVwLoans.SelectedItems[0].SubItems[0].Text;
            }
        }

        private void btnChangeLoanAmt_Click(object sender, EventArgs e)
        {
            decimal new_LoansAmt;
            decimal new_totalAmt;

            if (lstVwLoans.SelectedItems.Count > 0 && txtChangeLoanAmount.Text != string.Empty)
            {
                if (decimal.TryParse(txtChangeLoanAmount.Text, out new_LoansAmt))
                {
                    if (Convert.ToDecimal(txtChangeLoanAmount.Text) > 0)
                    {

                        lstMonthlyDeductions.Items[0].SubItems[5].Text = CheckForNumber.formatCurrency2(txtChangeLoanAmount.Text);

                        new_totalAmt = Convert.ToDecimal(lstMonthlyDeductions.Items[0].SubItems[4].Text) + Convert.ToDecimal(lstMonthlyDeductions.Items[0].SubItems[5].Text);
                        lstMonthlyDeductions.Items[0].SubItems[6].Text = CheckForNumber.formatCurrency2(new_totalAmt.ToString());

                    }
                    else
                    {
                        MessageBox.Show("The Amount entered is invalid", "Deduction Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {

                    MessageBox.Show("The Amount entered is invalid", "Deduction Info", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                MessageBox.Show("Select a Loan and Supply a new Loan Amount", "Deduction Info", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnApplyChanges_Click(object sender, EventArgs e)
        {
            decimal new_LoansAmt = 0;
            //decimal new_totalAmt;

            lstMonthlyDeductions.Items[0].SubItems[4].Text = lblTotalSavings.Text;
            if (txtChangeLoanAmount.Text == string.Empty)
            {

                lstMonthlyDeductions.Items[0].SubItems[5].Text = lblTotalLoans.Text;
                new_LoansAmt = Convert.ToDecimal(lblTotalLoans.Text);
            }
            else
            {
                

                if (decimal.TryParse(txtChangeLoanAmount.Text, out new_LoansAmt))
                {
                    if (Convert.ToDecimal(txtChangeLoanAmount.Text) > 0)
                    {

                        lstMonthlyDeductions.Items[0].SubItems[5].Text = CheckForNumber.formatCurrency2(txtChangeLoanAmount.Text);
                        new_LoansAmt = Convert.ToDecimal(txtChangeLoanAmount.Text);

                    }
                    else
                    {
                        MessageBox.Show("The new Loan Amount entered is invalid", "Deduction Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lstMonthlyDeductions.Items[0].SubItems[5].Text = lblTotalLoans.Text;
                        new_LoansAmt = Convert.ToDecimal(lblTotalLoans.Text);
                    }

                }
            }

                        lstMonthlyDeductions.Items[0].SubItems[6].Text = CheckForNumber.formatCurrency2(Convert.ToString(Convert.ToDecimal(lblTotalSavings.Text) + new_LoansAmt));
        }

        private void PostDeduction_Individual_Load(object sender, EventArgs e)
        {
            
        }

        private void txtChangeSavingsAmt_Leave(object sender, EventArgs e)
        {
            if (!FieldValidator.isBlank(txtChangeSavingsAmt.Text) && CheckForNumber.isNumeric(txtChangeSavingsAmt.Text))
            {
                txtChangeSavingsAmt.Text = CheckForNumber.formatCurrency2(txtChangeSavingsAmt.Text);
            }
        }

        private void txtChangeLoanAmount_Leave(object sender, EventArgs e)
        {
            if (!FieldValidator.isBlank(txtChangeLoanAmount.Text) && CheckForNumber.isNumeric(txtChangeLoanAmount.Text))
            {
                txtChangeLoanAmount.Text = CheckForNumber.formatCurrency2(txtChangeLoanAmount.Text);
            }
        }

        
        
    
    
    }
           
    
    
}
