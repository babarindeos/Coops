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
    public partial class NewLoanBroughtForward : Form
    {
        string paths = PhotoPath.getPath();
        private string memberID = string.Empty;
        private string strInterestRate = string.Empty;
        private string paymentStatus = string.Empty;
        private string paymentFinished = string.Empty;
        private string dateFinishedPayment = string.Empty;

        private string userId;

        public NewLoanBroughtForward(string UserID)
        {
            InitializeComponent();

            this.userId = UserID;
        }

        private void NewLoanBroughtForward_Load(object sender, EventArgs e)
        {
            loadLoanCategoryIntoCombo();
        }

        private void loadLoanCategoryIntoCombo()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select LoanCategoryID, Name from LoanCategory";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "LoanCategory");
                DataTable dt = ds.Tables["LoanCategory"];

                DataRow row = dt.NewRow();
                row["Name"] = "-- Select a Loan Category --";
                dt.Rows.InsertAt(row, 0);

                cboLoanCategory.DisplayMember = "Name";
                cboLoanCategory.ValueMember = "LoanCategoryID";

                cboLoanCategory.DataSource = dt;
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

        private void cboLoanCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoanCategory.Text != "-- Select a Loan Category --")
            {
                //retrieve LoanType Based on the selected LoanCategory
                #region retrieveLoanType
                SqlConnection conn = ConnectDB.GetConnection();
                string strQuery = "Select LoanTypeID,LoanCategoryID,Type from LoanType where LoanCategoryID=" + (Convert.ToInt16(cboLoanCategory.SelectedValue));
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                try
                {
                    conn.Open();
                    da.Fill(ds, "LoanType");
                    DataTable dt = ds.Tables["LoanType"];

                    DataRow row = dt.NewRow();
                    row["Type"] = "-- Select a Loan Type --";
                    dt.Rows.InsertAt(row, 0);
                    cboLoanType.DisplayMember = "Type";
                    cboLoanType.ValueMember = "LoanTypeID";

                    cboLoanType.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " Loan Category");
                }
                finally
                {
                    conn.Close();
                }

                #endregion
            }
            else
            {
                //cboType.Items.Clear();
            }
        }

        private void txtFileNo_Leave(object sender, EventArgs e)
        {
            if (txtFileNo.Text != string.Empty)
            {
                #region retrieveMemberProfile
                SqlConnection conn = ConnectDB.GetConnection();
                string strQuery = "Select MemberID,Title,FileNo,FirstName,MiddleName,LastName,Photo from Members " +
                   "where FileNo='" + txtFileNo.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            lblMemberProfile.Visible = true;
                            lblMemberProfile.Text = reader["Title"].ToString() + " " + reader["LastName"].ToString() + " " + reader["FirstName"].ToString() + " " + reader["MiddleName"].ToString().Substring(0) + ".";
                            memberID = reader["MemberID"].ToString();


                            if ( reader["Photo"].ToString()!=null && reader["Photo"].ToString() != string.Empty)
                            {
                                picMember.Image = Image.FromFile(paths + "//photos//" + reader["Photo"].ToString());
                            }
                            else
                            {
                                picMember.Image = Image.FromFile(paths + "//photos//profile_img.png");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sorry, no record with that File No. [" + txtFileNo.Text + "] exist.", "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        picMember.Image = Image.FromFile(paths + "//photos//profile_img.png");
                        lblMemberProfile.Text = string.Empty;
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

                #endregion end of retrieveMemberProfile
            }
            else
            {
                picMember.Image = Image.FromFile(paths + "\\photos\\profile_img.png");
                lblMemberProfile.Text = string.Empty;
                lblMemberProfile.Visible = false;
            } //end of if (--Select a File No. --)
            

        }

        private void cboLoanType_Leave(object sender, EventArgs e)
        {

            if (cboLoanType.SelectedIndex > 0)
            {
                
                SqlConnection conn = ConnectDB.GetConnection();
                string strQuery = "Select LoanTypeID, Duration, InterestRate from LoanType " +
                    "where LoanTypeID=" + cboLoanType.SelectedValue.ToString();
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                //MessageBox.Show(cboLoanType.SelectedValue.ToString());
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string strDuration = reader["Duration"].ToString();
                        strInterestRate = reader["InterestRate"].ToString();
                        string strBoth = strDuration + " Months | " + strInterestRate + "%";
                        lblDuration.Text = strDuration;
                        lblInterestRate.Text = strInterestRate;
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


            
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (txtAmount.Text != string.Empty && (CheckForNumber.isNumeric(txtAmount.Text)))
            {
                if (Convert.ToDecimal(txtAmount.Text) > 0)
                {
                    txtAmountPaid.Enabled = true;

                    decimal loanAmount = Convert.ToDecimal(txtAmount.Text);
                    decimal interestRate = Convert.ToDecimal(strInterestRate);
                    int duration = Convert.ToInt16(lblDuration.Text);
                    decimal totalRepayment;
                    decimal monthlyRepayment;

                    decimal interestAmount = loanAmount * (interestRate / 100);
                    txtInterest.Text = CheckForNumber.formatCurrency2(interestAmount.ToString());
                    totalRepayment = loanAmount + interestAmount;
                    monthlyRepayment = totalRepayment / duration;
                    txtTotalRepayment.Text = CheckForNumber.formatCurrency2(totalRepayment.ToString());

                    txtAmount.Text = CheckForNumber.formatCurrency2(txtAmount.Text);
                    txtMonthlyRepayment.Text = CheckForNumber.formatCurrency2(monthlyRepayment.ToString());

                }
                else
                {
                    txtAmountPaid.Text = string.Empty;
                    txtAmountPaid.Enabled = false;
                    MessageBox.Show("The Amount is required to proceed", "Loans", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                txtAmountPaid.Text = string.Empty;
                txtAmountPaid.Enabled = false;
            }
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            if ((memberID != string.Empty) && (cboLoanCategory.SelectedIndex > 0) && (cboLoanType.SelectedIndex > 0) && (txtInterest.Text != string.Empty) && (txtAmount.Text != string.Empty) && (txtTotalRepayment.Text != string.Empty) && (txtMonthlyRepayment.Text != string.Empty) && (txtAmountPaid.Text != string.Empty) && (txtOutstandingAmt.Text != string.Empty))
            {
                if (txtOutstandingAmt.Text != string.Empty)
                {
                    DialogResult res = MessageBox.Show("Do you wish to Post this Transaction?", "Loans", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        executePosting();
                    }
                }
                else
                {
                    MessageBox.Show("Supply Outstanding Amount to Proceed.", "Loans", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("All Fields must be proper filled in to Execute Post","Loans",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void executePosting()
        {
            btnPost.Enabled = false;

            string appMonth = dtAppDate.Value.Month.ToString();
            string appYear = dtAppDate.Value.Year.ToString();
            string rePay_StartMonth = dtStartRepayment.Value.Month.ToString();
            string rePay_StartYear = dtStartRepayment.Value.Year.ToString();               

            string transactionID = "LBF" + DateTime.Now.ToString("ddMMyyhhmmss");

            SqlConnection conn = ConnectDB.GetConnection();

            conn.Open();

            try
            {

            SqlTransaction sqlTrans = conn.BeginTransaction();
            

            string strQuery = "Insert into LoanApplication(AppMonth,AppYear,MemberID,LoanCategoryID,"+
                "LoanTypeID,LoanAmount,StartRepaymentMonth,StartRepaymentYear,LoanDuration,InterestRate,"+
                "InterestAmount,TotalRepayment,MonthlyRepayment,ApprovalStatus,TransactionID)"+
                "values(@AppMonth,@AppYear,@MemberID,@LoanCategoryID,@LoanTypeID,@LoanAmount,@StartRepaymentMonth,@StartRepaymentYear,"+
                "@LoanDuration,@InterestRate,@InterestAmount,@TotalRepayment,@MonthlyRepayment,@ApprovalStatus,@TransactionID)";

            SqlCommand cmd = new SqlCommand(strQuery, conn);
            cmd.Transaction = sqlTrans;

            #region Parameters
            cmd.Parameters.Add("@AppMonth", SqlDbType.Int);
            cmd.Parameters["@AppMonth"].Value = appMonth;

            cmd.Parameters.Add("@AppYear", SqlDbType.Int);
            cmd.Parameters["@AppYear"].Value = appYear;

            cmd.Parameters.Add("@MemberID", SqlDbType.Int);
            cmd.Parameters["@MemberID"].Value = memberID;

            cmd.Parameters.Add("@LoanCategoryID", SqlDbType.Int);
            cmd.Parameters["@LoanCategoryID"].Value = cboLoanCategory.SelectedValue.ToString();

            cmd.Parameters.Add("@LoanTypeID", SqlDbType.Int);
            cmd.Parameters["@LoanTypeID"].Value = cboLoanType.SelectedValue.ToString();

            cmd.Parameters.Add("@LoanAmount", SqlDbType.Decimal);
            cmd.Parameters["@LoanAmount"].Value = txtAmount.Text;

            cmd.Parameters.Add("@StartRepaymentMonth", SqlDbType.Decimal);
            cmd.Parameters["@StartRepaymentMonth"].Value = rePay_StartMonth;

            cmd.Parameters.Add("@StartRepaymentYear", SqlDbType.Decimal);
            cmd.Parameters["@StartRepaymentYear"].Value = rePay_StartYear;

            cmd.Parameters.Add("@LoanDuration", SqlDbType.Int);
            cmd.Parameters["@LoanDuration"].Value = lblDuration.Text;

            cmd.Parameters.Add("@InterestRate", SqlDbType.Decimal);
            cmd.Parameters["@InterestRate"].Value = lblInterestRate.Text;

            cmd.Parameters.Add("@InterestAmount", SqlDbType.Decimal);
            cmd.Parameters["@InterestAmount"].Value = txtInterest.Text;

            cmd.Parameters.Add("@TotalRepayment", SqlDbType.Decimal);
            cmd.Parameters["@TotalRepayment"].Value = txtTotalRepayment.Text;

            cmd.Parameters.Add("@MonthlyRepayment", SqlDbType.Decimal);
            cmd.Parameters["@MonthlyRepayment"].Value = txtMonthlyRepayment.Text;

            cmd.Parameters.Add("@ApprovalStatus", SqlDbType.NVarChar, 3);
            cmd.Parameters["@ApprovalStatus"].Value = "Yes";

            cmd.Parameters.Add("@TransactionID", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TransactionID"].Value = transactionID;
            #endregion

            string strQuery1;

            if (dateFinishedPayment != string.Empty)
            {
                strQuery1 = "Insert into Loans(LoanApplicationID,RepaymentAmount,AmountPaid,OutstandingAmount," +
                    "PaymentStatus,PaymentFinished,DateFinishedPayment,TransactionID,Remark)values(@LoanApplicationID," +
                    "@RepaymentAmount,@AmountPaid,@OutstandingAmount,@PaymentStatus,@PaymentFinished,@DateFinishedPayment," +
                    "@TransactionID,@Remark)";
            }
            else
            {
                strQuery1 = "Insert into Loans(LoanApplicationID,RepaymentAmount,AmountPaid,OutstandingAmount," +
                    "PaymentStatus,PaymentFinished,TransactionID,Remark)values(@LoanApplicationID," +
                    "@RepaymentAmount,@AmountPaid,@OutstandingAmount,@PaymentStatus,@PaymentFinished," +
                    "@TransactionID,@Remark)";
            }

            string strQuery3 = "Select LoanApplicationID from LoanApplication where TransactionID='" + transactionID + "'";

 
                int rowAffected = cmd.ExecuteNonQuery();
                //MessageBox.Show(rowAffected.ToString());
                if (rowAffected > 0)
                {
                      cmd = new SqlCommand(strQuery3, conn);
                      cmd.Transaction = sqlTrans;
                      int loanApplicationID = Convert.ToInt16(cmd.ExecuteScalar());
                      //MessageBox.Show(loanApplicationID.ToString());
                      

                    cmd = new SqlCommand(strQuery1, conn);
                    cmd.Transaction = sqlTrans;

                    #region parameters strQuery1
                    cmd.Parameters.Add("@LoanApplicationID", SqlDbType.Int);
                    cmd.Parameters["@LoanApplicationID"].Value = loanApplicationID;

                    cmd.Parameters.Add("@RepaymentAmount", SqlDbType.Decimal);
                    cmd.Parameters["@RepaymentAmount"].Value = txtTotalRepayment.Text;

                    cmd.Parameters.Add("@AmountPaid", SqlDbType.Decimal);
                    cmd.Parameters["@AmountPaid"].Value = txtAmountPaid.Text;

                    cmd.Parameters.Add("@OutstandingAmount", SqlDbType.Decimal);
                    cmd.Parameters["@OutstandingAmount"].Value = txtOutstandingAmt.Text;

                    cmd.Parameters.Add("@PaymentStatus", SqlDbType.NVarChar, 10);
                    cmd.Parameters["@PaymentStatus"].Value = paymentStatus;

                    cmd.Parameters.Add("@PaymentFinished", SqlDbType.NVarChar, 3);
                    cmd.Parameters["@PaymentFinished"].Value = paymentFinished;
                                        

                    if (dateFinishedPayment != string.Empty)
                    {
                        cmd.Parameters.Add("@DateFinishedPayment", SqlDbType.NVarChar, 40);
                        cmd.Parameters["@DateFinishedPayment"].Value = dateFinishedPayment;
                    }

                    cmd.Parameters.Add("@TransactionID", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@TransactionID"].Value = transactionID;

                    cmd.Parameters.Add("@Remark", SqlDbType.NVarChar, 1000);
                    cmd.Parameters["@Remark"].Value = txtRemark.Text;
                                        
                    #endregion

                    //Execute strQuery1
                    rowAffected = cmd.ExecuteNonQuery();

                    if (rowAffected > 0)
                    {
                        sqlTrans.Commit();
                        MessageBox.Show("Transaction has been successfully posted.", "Loans", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActivityLog.logActivity(userId, "LoansForward", "Added a new Loans Brought Forward record with TransactionID of " + transactionID);
                    }
                    else
                    {
                        sqlTrans.Rollback();
                        MessageBox.Show("An error has occurred! Operation has been aborted.", "Loans", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    

                    //Close existing form and reopen active form
                    
                    NewLoanBroughtForward newLoanBroughtForward = new NewLoanBroughtForward(userId);
                    newLoanBroughtForward.MdiParent = this.ParentForm;
                    newLoanBroughtForward.Show();

                    this.Close();


                }
                else
                {
                    MessageBox.Show("An error has occurred!","Loans",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        private void txtTotalRepayment_Leave(object sender, EventArgs e)
        {
            if (!FieldValidator.isBlank(txtTotalRepayment.Text))
            {
                txtTotalRepayment.Text = CheckForNumber.formatCurrency2(txtTotalRepayment.Text);
            }
            else
            {
                MessageBox.Show("Total Repayment Amount cannot be left blank.","Loans",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void txtAmountPaid_Leave(object sender, EventArgs e)
        {
            if (!FieldValidator.isBlank(txtAmountPaid.Text) && CheckForNumber.isNumeric(txtAmountPaid.Text))
            {
                decimal totalAmountRepayment = Convert.ToDecimal(txtTotalRepayment.Text);
                decimal amountPaid = Convert.ToDecimal(txtAmountPaid.Text);
                decimal outstandingAmount;

                if (amountPaid > totalAmountRepayment)
                {
                    MessageBox.Show("Sorry, that Amount Paid exceeds the Total Repayment Amount.", "Loans", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAmountPaid.Text = string.Empty;
                }
                else
                {
                    txtAmountPaid.Text = CheckForNumber.formatCurrency2(txtAmountPaid.Text);
                    outstandingAmount = totalAmountRepayment - amountPaid;
                    txtOutstandingAmt.Text = CheckForNumber.formatCurrency2(outstandingAmount.ToString());

                    //check outstanding amount and set paymentStatus                                      
                    if (outstandingAmount == 0) 
                    { 
                        paymentStatus = "PAID";
                        paymentFinished = "Yes";
                        dateFinishedPayment = dtPickerPaymentFinished.Value.ToString();

                        lblPaymentFinishedDate.Visible = true;
                        dtPickerPaymentFinished.Visible = true;
                    
                    } 
                    else 
                    {
                        paymentStatus = "Paying";
                        paymentFinished = "No";
                        dateFinishedPayment = string.Empty;

                        lblPaymentFinishedDate.Visible = false;
                        dtPickerPaymentFinished.Visible = false;
                        
                    }
                }
            }
        }

        private void txtOutstandingAmt_Leave(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cboLoanType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoanType.SelectedIndex > 0)
            {
                txtAmount.Enabled = true;
            }
            else
            {               
                txtAmount.Text = string.Empty;
                txtAmount.Enabled = false;            
            }
        }

        private void txtInterest_Leave(object sender, EventArgs e)
        {
            decimal totalRepayment;
            decimal monthlyRepayment;
            int duration = Convert.ToInt16(lblDuration.Text);

            if (txtInterest.Text!=string.Empty && (CheckForNumber.isNumeric(txtInterest.Text)))
            {
                if (txtAmount.Text!=string.Empty && (CheckForNumber.isNumeric(txtAmount.Text)))
                {
                    totalRepayment = Convert.ToDecimal(txtAmount.Text) + Convert.ToDecimal(txtInterest.Text);
                    monthlyRepayment = totalRepayment / duration;
                    txtTotalRepayment.Text = CheckForNumber.formatCurrency2(totalRepayment.ToString());
                    txtInterest.Text = CheckForNumber.formatCurrency2(txtInterest.Text);
                    txtMonthlyRepayment.Text = monthlyRepayment.ToString();
                }
                else
                {
                    MessageBox.Show("Enter a valid Capital to proceed", "Loans", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Invalid data entry","Loans",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtInterest.Text = string.Empty;

            }
        }

       
    }
}
