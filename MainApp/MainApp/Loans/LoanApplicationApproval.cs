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
    public partial class LoanApplicationApproval : Form
    {
        //string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
        string paths = PhotoPath.getPath();
        string strFilter;

        public LoanApplicationApproval()
        {
            InitializeComponent();
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void LoanApplicationApproval_Load(object sender, EventArgs e)
        {
            this.Height = 378;
            loadAllLoanApplications();
            txtMemberProfile.TextAlign = HorizontalAlignment.Right;

        }


        private void loadAllLoanApplications()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select a.LoanApplicationID,mn.Month as [Month],a.AppYear as [Year],m.LastName as [Last Name],m.FirstName  as [First Name],m.MiddleName  as [Mid. Name]," +
                "t.Type as [Loan Type], a.LoanAmount as [Amount],a.TransactionID as [Transaction ID], a.ApprovalStatus as Status, a.DatePosted as [Date] from LoanApplication a " +
                "left join Members m on a.MemberID=m.MemberID " +
                "left join MonthByName mn on a.AppMonth = mn.MonthID " +
                "left join LoanType t on a.LoanTypeID=t.LoanTypeID order by LoanApplicationID desc";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "LoanApplication");
                DataTable dt = ds.Tables["LoanApplication"];

                if (dt.Rows.Count > 0)
                {

                    datLoanApplicationGridView.DataSource = null;
                    datLoanApplicationGridView.Columns.Clear();
                    datLoanApplicationGridView.Rows.Clear();
                    datLoanApplicationGridView.Refresh();
                    datLoanApplicationGridView.DataSource = dt;

                    datLoanApplicationGridView.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    datLoanApplicationGridView.Columns["Amount"].DefaultCellStyle.Format = "N2";

                    datLoanApplicationGridView.Columns["Year"].Width = 70;
                    datLoanApplicationGridView.Columns["Status"].Width = 70;

                    datLoanApplicationGridView.Columns["LoanApplicationID"].Visible = false;


                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    datLoanApplicationGridView.Columns.Add(btn);
                    btn.HeaderText = "Action";
                    btn.Text = "Select Record";
                    btn.Name = "btn";
                    btn.UseColumnTextForButtonValue = true;
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

        private void datLoanApplicationGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string transactionID = null;
            string loanApplicationID = null;

            //MessageBox.Show(e.ColumnIndex.ToString());

            if (e.ColumnIndex == 0)
            {
                              
                transactionID = datLoanApplicationGridView.Rows[e.RowIndex].Cells[9].Value.ToString();
                loanApplicationID = datLoanApplicationGridView.Rows[e.RowIndex].Cells[1].Value.ToString();

            }
            else if (e.ColumnIndex ==11)
            {
                transactionID = datLoanApplicationGridView.Rows[e.RowIndex].Cells[8].Value.ToString();
                loanApplicationID = datLoanApplicationGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            }

            if ((e.ColumnIndex==0) || (e.ColumnIndex==11))
            {
                 getLoanApplicationDetails(transactionID, loanApplicationID);
                 datLoanApplicationGridView.Rows[e.RowIndex].Selected = true;
                 groupBox7.Visible = true;
            }
            
            //MessageBox.Show("Transaction ID: " + transactionID + "\nloanApplicationID: " + loanApplicationID);
           
        }

        private void getLoanApplicationDetails(string transactionID,string loanApplicationID)
        {
            txtApplicationID.Text = loanApplicationID;

            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select mn.Month as [AppMonth],a.AppYear as [AppYear],m.FileNo,m.LastName as [LastName],m.FirstName  as [FirstName],m.MiddleName  as [MiddleName], m.Photo," +
                "c.Name as [LoanCategory],t.Type as [LoanType], a.LoanAmount as [Amount],a.TransactionID as [TransactionID],a.DatePosted as [Date], " +
                "a.StartRepaymentMonth, a.StartRepaymentYear,a.SuretyMemberID1,a.SuretyMemberID2," +
                "a.WitnessMemberID, a.NonMemberSurety1, a.NonMemberSurety2, a.NonMemberWitness, " + 
                "a.LoanDuration, a.InterestRate, a.InterestAmount, a.TotalRepayment, a.MonthlyRepayment, a.ApprovalStatus from LoanApplication a " +
                "left join Members m on a.MemberID=m.MemberID " +
                "left join MonthByName mn on a.AppMonth = mn.MonthID " +
                "left join LoanCategory c on a.LoanCategoryID = c.LoanCategoryID " +
                "left join LoanType t on a.LoanTypeID=t.LoanTypeID " +
                "where TransactionID='" + transactionID + "' order by LoanApplicationID desc";

            SqlCommand cmd = new SqlCommand(strQuery,conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                txtApplicationDate.Text = reader["AppMonth"].ToString() + " " + reader["AppYear"].ToString();
                txtCategory.Text = reader["LoanCategory"].ToString();
                txtType.Text = reader["LoanType"].ToString();
                txtAmount.Text = CheckForNumber.formatCurrency(reader["Amount"].ToString());
                txtRepaymentDate.Text = DateFunction.getMonthByName(Convert.ToInt16(reader["StartRepaymentMonth"].ToString())) + " " + reader["StartRepaymentYear"].ToString();
                txtTransactionID.Text = reader["TransactionID"].ToString();
                txtDuration.Text = reader["LoanDuration"].ToString();
                txtInterestRate.Text = CheckForNumber.formatCurrency(reader["InterestRate"].ToString());
                txtInterestAmount.Text = CheckForNumber.formatCurrency(reader["InterestAmount"].ToString());
                txtTotalRepayment.Text = CheckForNumber.formatCurrency(reader["TotalRepayment"].ToString());
                txtMonthRepayment.Text = CheckForNumber.formatCurrency(reader["MonthlyRepayment"].ToString());
                txtMemberProfile.Text = reader["LastName"] + " " + reader["FirstName"] + " " + reader["MiddleName"];
                lblMemberFileNo.Text = reader["FileNo"].ToString();

                if (reader["Photo"].ToString() == null || reader["Photo"].ToString() == string.Empty)
                {
                    picMember.Image = Image.FromFile(paths + "//photos//" + reader["Photo"].ToString());
                }


                if ((reader["SuretyMemberID1"].ToString() != string.Empty))
                {
                    getSuretyDetails(reader["SuretyMemberID1"].ToString(),"1");
                }
                else
                {
                    lblSurety1.Text = "Surety 1\n" + reader["NonMemberSurety1"].ToString();
                    picSurety1.Image = Image.FromFile(paths + "//photos//profile_img.png");
                }


                if ((reader["SuretyMemberID2"].ToString() != string.Empty))
                {
                    getSuretyDetails(reader["SuretyMemberID2"].ToString(), "2");
                }
                else
                {
                    lblSurety2.Text = "Surety 2\n" + reader["NonMemberSurety2"].ToString();
                    picSurety2.Image = Image.FromFile(paths + "//photos//profile_img.png");
                }

                
                if ((reader["WitnessMemberID"].ToString() != string.Empty))
                {
                    getSuretyDetails(reader["WitnessMemberID"].ToString(), "3");
                }
                else
                {
                    lblWitness.Text = "Witness\n" + reader["NonMemberWitness"].ToString();
                    picWitness.Image = Image.FromFile(paths + "//photos//profile_img.png");
                }

                //MessageBox.Show(reader["ApprovalStatus"].ToString());

                switch (reader["ApprovalStatus"].ToString().Trim())
                {
                    case "":
                        lblApprovalStatus.Text = "Pending";
                        lblApprovalStatus.ForeColor = System.Drawing.Color.Black;
                        radYes.Checked = false;
                        radNo.Checked = false;
                        break;
                    case "Yes":
                        lblApprovalStatus.Text = "Loan Approved";
                        lblApprovalStatus.ForeColor = System.Drawing.Color.Green;
                        radYes.Checked = true;
                        break;
                    case "No":
                        lblApprovalStatus.Text = "Loan Not Approved";
                        lblApprovalStatus.ForeColor = System.Drawing.Color.Red;
                        radNo.Checked = true;
                        break;
                }

                
                //check/effect whether to enable or disable approval/disapproval box

                DateTime today = DateTime.Now;
                DateTime repaymentDate = DateTime.Parse(txtRepaymentDate.Text);
                TimeSpan diffBeforeRepayment = today.Subtract(repaymentDate);
                int daysBeforeRepayment = (int) diffBeforeRepayment.TotalDays;

                if (daysBeforeRepayment >= 0)
                {
                    grpApproval.Enabled = false;
                }
                else
                {
                    grpApproval.Enabled = true;
                }               



                //check the Application Details Section
                this.Height = 591;
            }
            catch (Exception ex)
            {
                MessageBox.Show("getLoanApplicationDetails " + ex.Message);
            }
            finally
            {
                conn.Close();
            }            
        }



        private void getSuretyDetails(string surety, string suretyNo)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select LastName + ' ' + FirstName + ' ' + MiddleName as FullName, Photo from Members where MemberID='" + surety + "'";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string memberPicture = string.Empty;

                if (reader["Photo"].ToString() != null || reader["Photo"].ToString() == string.Empty)
                {
                    memberPicture = paths + "//photos//" + reader["Photo"].ToString();
                }

                switch (suretyNo)
                {
                    case "1":
                        lblSurety1.Text = "Surety 1\n" + reader["FullName"].ToString();
                        picSurety1.Image = Image.FromFile(memberPicture);
                        break;
                    case "2":
                        lblSurety2.Text ="Surety 2\n" +  reader["FullName"].ToString();
                        picSurety2.Image = Image.FromFile(memberPicture);
                        break;
                    case "3":
                        lblWitness.Text = "Witness\n" + reader["FullName"].ToString();
                        picWitness.Image = Image.FromFile(memberPicture);
                        break;
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

        private void btnPerformAction_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you wish to perform this operation?", "Loan Application Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if (radYes.Checked)
                {
                    approveLoanOperation();
                }
                else if (radNo.Checked)
                {
                    cancelLoanApproval();
                }
            }
        }



        private void approveLoanOperation()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Insert into Loans(LoanApplicationID,RepaymentAmount,OutstandingAmount,TransactionID)" +
                "values(@LoanApplicationID,@RepaymentAmount,@OutstandingAmount,@TransactionID)";

            SqlCommand cmdInsert = new SqlCommand(strQuery, conn);

            cmdInsert.Parameters.Add("@LoanApplicationID", SqlDbType.NVarChar, 50);
            cmdInsert.Parameters["@LoanApplicationID"].Value = txtApplicationID.Text;

            cmdInsert.Parameters.Add("@RepaymentAmount", SqlDbType.Decimal);
            cmdInsert.Parameters["@RepaymentAmount"].Value = Convert.ToDecimal(txtTotalRepayment.Text);

            cmdInsert.Parameters.Add("@OutstandingAmount", SqlDbType.Decimal);
            cmdInsert.Parameters["@OutstandingAmount"].Value = Convert.ToDecimal(txtTotalRepayment.Text);

            cmdInsert.Parameters.Add("@TransactionID", SqlDbType.NVarChar, 50);
            cmdInsert.Parameters["@TransactionID"].Value = txtTransactionID.Text;

            
            string strUpdate = "Update LoanApplication set ApprovalStatus='Yes' where TransactionID='" +
                txtTransactionID.Text + "' and LoanApplicationID=" + txtApplicationID.Text;

            SqlCommand cmdUpate = new SqlCommand(strUpdate, conn);
                                  
            SqlTransaction sqlTrans = null;

            try
            {
                conn.Open();

                sqlTrans = conn.BeginTransaction();
                cmdInsert.Transaction = sqlTrans;

                int rowsAffected = cmdInsert.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    rowsAffected = 0;
                    cmdUpate.Transaction = sqlTrans;

                    rowsAffected = cmdUpate.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        sqlTrans.Commit();
                        MessageBox.Show("The Selected Loan Application has been Approved", "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblApprovalStatus.Text = "Loan is Approved";
                        lblApprovalStatus.ForeColor = System.Drawing.Color.Green;
                    }
                    else
                    {
                        sqlTrans.Rollback();
                        MessageBox.Show("An error has occurred", "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }                    
                }
                else
                {
                    MessageBox.Show("An error has occurred", "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sqlTrans.Rollback();
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


        private void cancelLoanApproval()
        {
            SqlConnection conn = ConnectDB.GetConnection();

            string strCheck = "Select count(*) from Loans where TransactionID='" +
                txtTransactionID.Text + "' and LoanApplicationID=" + txtApplicationID.Text;

            SqlCommand cmdCheck = new SqlCommand(strCheck, conn);

            string strDelete = "Delete from Loans where TransactionID='" +
                txtTransactionID.Text + "' and LoanApplicationID=" + txtApplicationID.Text;

            SqlCommand cmdDelete = new SqlCommand(strDelete, conn);
            
            string strUpdate = "Update LoanApplication set ApprovalStatus='No' where TransactionID='" +
                txtTransactionID.Text + "' and LoanApplicationID=" + txtApplicationID.Text;

            SqlCommand cmdUpdate = new SqlCommand(strUpdate, conn);

            SqlTransaction sqlTrans = null;

            try
            {
                conn.Open();
                sqlTrans = conn.BeginTransaction();

                int rowsAffected;
                bool boolOperationSuccess = true;

                cmdCheck.Transaction = sqlTrans;
                int recFound = (int) cmdCheck.ExecuteScalar();

                if (recFound > 0)
                {
                    cmdDelete.Transaction = sqlTrans;
                    rowsAffected = cmdDelete.ExecuteNonQuery();
                    if (rowsAffected==0)
                    {
                        boolOperationSuccess = false;                        
                    }

                }
                
                cmdUpdate.Transaction = sqlTrans;

                    rowsAffected = cmdUpdate.ExecuteNonQuery();
                    if (rowsAffected == 0)
                    {
                        boolOperationSuccess = false;
                    }
                

                //check and perform the relevant operation
                if (boolOperationSuccess == true)
                {
                    sqlTrans.Commit();
                    MessageBox.Show("The Selected Loan has been Unapproved", "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblApprovalStatus.Text = "Loan is Unapproved";
                    lblApprovalStatus.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    sqlTrans.Rollback();
                    MessageBox.Show("An error has occurred!", "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnOneDateSearch_Click(object sender, EventArgs e)
        {
            if ((cboSingleMonthSearch.Text != string.Empty) && (cboSingleYearSearch.Text != string.Empty))
            {
                strFilter = "where AppMonth=" + (cboSingleMonthSearch.SelectedIndex + 1) + " and AppYear=" + cboSingleYearSearch.Text;
            }
            else if ((cboSingleMonthSearch.Text != string.Empty) && (cboSingleYearSearch.Text == string.Empty))
            {
                strFilter = "where AppMonth=" + (cboSingleMonthSearch.SelectedIndex + 1);
            }
            else if ((cboSingleMonthSearch.Text == string.Empty) && (cboSingleYearSearch.Text != string.Empty))
            {
                strFilter = "where AppYear=" + cboSingleYearSearch.Text;
            }
            
            performSearchQuery(strFilter);
        }


        private void performSearchQuery(string strFilter)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select a.LoanApplicationID,mn.Month as [Month],a.AppYear as [Year],m.LastName as [Last Name],m.FirstName  as [First Name],m.MiddleName  as [Mid. Name]," +
                "t.Type as [Loan Type], a.LoanAmount as [Amount],a.TransactionID as [Transaction ID], a.ApprovalStatus as Status, a.DatePosted as [Date] from LoanApplication a " +
                "left join Members m on a.MemberID=m.MemberID " +
                "left join MonthByName mn on a.AppMonth = mn.MonthID " +
                "left join LoanType t on a.LoanTypeID=t.LoanTypeID " + strFilter + " order by LoanApplicationID desc";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            datLoanApplicationGridView.DataSource = null;
            datLoanApplicationGridView.Columns.Clear();
            datLoanApplicationGridView.Rows.Clear();
            datLoanApplicationGridView.Refresh();
            

            try
            {
                conn.Open();
                da.Fill(ds, "LoanApplication");
                DataTable dt = ds.Tables["LoanApplication"];

                if (dt.Rows.Count > 0)
                {                  
                    
                    datLoanApplicationGridView.DataSource = dt;

                    datLoanApplicationGridView.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    datLoanApplicationGridView.Columns["Amount"].DefaultCellStyle.Format = "N2";

                    datLoanApplicationGridView.Columns["LoanApplicationID"].Visible = false;
                    datLoanApplicationGridView.Columns["Year"].Width = 70;
                    datLoanApplicationGridView.Columns["Status"].Width = 70;


                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    datLoanApplicationGridView.Columns.Add(btn);
                    btn.HeaderText = "Action";
                    btn.Text = "Select Record";
                    btn.Name = "btn";
                    btn.UseColumnTextForButtonValue = true;

                    
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

        private void btnBetweenDateSearch_Click(object sender, EventArgs e)
        {
            if (cboFromMonth.Text!=string.Empty && cboFromYear.Text != string.Empty && cboToMonth.Text!=string.Empty && cboToYear.Text!=string.Empty)
            {
                int fromYear = Convert.ToInt16(cboFromYear.Text);
                int toYear = Convert.ToInt16(cboToYear.Text);

                if (toYear >= fromYear)
                {
                    strFilter = "where AppMonth between " + (cboFromMonth.SelectedIndex + 1) + " and " + (cboToMonth.SelectedIndex + 1) +
                        " or AppYear between " + cboFromYear.Text + " and " + cboToYear.Text;
                    performSearchQuery(strFilter);
                }
                else
                {
                    MessageBox.Show("Select the Dates in the proper order.", "Loan Application Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }else{
                MessageBox.Show("Ensure to pick the Dates for the period to perform this search", "Loan Application Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void btnFileNoSearch_Click(object sender, EventArgs e)
        {
            if (txtFileNoSearch.Text != string.Empty)
            {
                string memberID = null;
                //Check if the FileNo is genuine and exist. If it exist then retrieve the MemberID
                
                SqlConnection conn = ConnectDB.GetConnection();
                string strQuery = "Select MemberID,FileNo from Members where FileNo=@FileNo";
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = strQuery;

                cmd.Parameters.Add("@FileNo", SqlDbType.NVarChar,50);
                cmd.Parameters["@FileNo"].Value = txtFileNoSearch.Text.Trim();

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        memberID = reader["MemberID"].ToString();

                        strFilter = " where a.MemberID=" + memberID;
                        performSearchQuery(strFilter);
                    }
                    else
                    {
                        MessageBox.Show("Sorry, there is no Member with that File No.","Loan Application Status",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            else
            {
                MessageBox.Show("Enter Member File No. to make this Search", "Loan Application Status", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnTransactionIDSearch_Click(object sender, EventArgs e)
        {
            if (txtTransactionIDSearch.Text != string.Empty)
            {
                strFilter = "where a.TransactionID = '" + txtTransactionIDSearch.Text.Trim()  + "'";
                performSearchQuery(strFilter);
            }
            else
            {
                MessageBox.Show("Transaction ID must be supplied to perform\nthis search operation", "Loan Application Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStatusSearch_Click(object sender, EventArgs e)
        {
            if (cboStatus.Text != string.Empty)
            {
                if (cboStatus.SelectedIndex == 0)
                {
                    strFilter = "where a.ApprovalStatus is NULL";
                }
                else if (cboStatus.SelectedIndex == 1)
                {
                    strFilter = "where a.ApprovalStatus='Yes'";
                }
                else if (cboStatus.SelectedIndex == 2)
                {
                    strFilter = "where a.ApprovalStatus='No'";
                }

                performSearchQuery(strFilter);
            }
            else
            {
                MessageBox.Show("Select a Status option to proceed with the search", "Loan Application Status", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void datLoanApplicationGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
