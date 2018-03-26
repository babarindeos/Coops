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
    public partial class EditLoansBroughtForward : Form
    {
        private string userId;
        private string strInterestRate = string.Empty;
        private string paymentStatus;
        private string paymentFinished;
        private string dateFinishedPayment;
        string loanApplicationID;
        string loanID;

        public EditLoansBroughtForward(string UserID)
        {
            InitializeComponent();
            this.userId = UserID;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void EditLoansBroughtForward_Load(object sender, EventArgs e)
        {
            loadDataIntoGridView();
            loadLoanCategory();
            loadLoanType();
        }

        private void loadLoanCategory()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select LoanCategoryID,Name from LoanCategory where LoanCategoryID in (Select LoanCategoryID from LoanApplication)";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            cboLoanCategory.DataSource = null;

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
                cboLoanCategory.SelectedIndex = 1;


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

        private void loadLoanType()
        {


            if (cboLoanCategory.SelectedIndex > 0)
            {
                

                SqlConnection conn = ConnectDB.GetConnection();
                string strQuery = "Select LoanCategoryID, LoanTypeID,Type from LoanType where LoanCategoryID=" + cboLoanCategory.SelectedValue;
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
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }


            }

        }

        private void loadDataIntoGridView()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select l.LoansID,a.LoanApplicationID,m.FileNo,m.Title + ' ' + m.FirstName + ' ' + m.MiddleName + ' ' + m.LastName as 'Full Name'," +
            "a.LoanAmount 'Amount', l.RepaymentAmount 'Repayment Amt.',l.AmountPaid 'Amt. Paid', l.OutstandingAmount 'Outstanding Amt.',l.PaymentStatus 'Payment Status',l.PaymentFinished 'Payment Finished',l.DateFinishedPayment 'Finished Paying',l.TransactionID," +
            "l.DateCreated 'Date' from LoanApplication a " +
            "inner join Loans l on l.LoanApplicationID=a.LoanApplicationID " +
            "inner join Members m on a.MemberID=m.MemberID " +
            "where l.TransactionID LIKE '%LBF%' " +
            "order by l.LoansID desc";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Loans");
                DataTable dt = ds.Tables["Loans"];

                datGrdVwLoansForward.DataSource = dt;

                datGrdVwLoansForward.Columns["LoansID"].Visible = false;
                datGrdVwLoansForward.Columns["LoanApplicationID"].Visible = false;
                datGrdVwLoansForward.Columns["Repayment Amt."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdVwLoansForward.Columns["Repayment Amt."].DefaultCellStyle.Format = "N2";
                datGrdVwLoansForward.Columns["Amt. Paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdVwLoansForward.Columns["Amt. Paid"].DefaultCellStyle.Format = "N2";
                datGrdVwLoansForward.Columns["Outstanding Amt."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdVwLoansForward.Columns["Outstanding Amt."].DefaultCellStyle.Format = "N2";
                datGrdVwLoansForward.Columns["FileNo"].Width = 50;
                datGrdVwLoansForward.Columns["Payment Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                datGrdVwLoansForward.Columns["Payment Finished"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                datGrdVwLoansForward.Columns["Payment Status"].Width = 80;
                datGrdVwLoansForward.Columns["Payment Finished"].Width = 80;
                datGrdVwLoansForward.Columns["Amount"].DefaultCellStyle.Format = "N2";
                datGrdVwLoansForward.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                datGrdVwLoansForward.Columns.Add(btn);
                btn.HeaderText = "Action";
                btn.Text = "Select";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;
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

        private void datGrdVwLoansForward_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            
            SqlConnection conn = ConnectDB.GetConnection();

            if (e.ColumnIndex == 0)
            {
                loanApplicationID = datGrdVwLoansForward.Rows[e.RowIndex].Cells[2].Value.ToString();
                loanID = datGrdVwLoansForward.Rows[e.RowIndex].Cells[1].Value.ToString();

                btnEnableEdit.Enabled = shouldEnableEdit();                
                
                string strQuery = "Select a.AppMonth,a.AppYear,a.StartRepaymentMonth,a.StartRepaymentYear,a.LoanCategoryID," +
                    "a.LoanTypeID,a.LoanAmount,a.InterestAmount,a.TotalRepayment,l.AmountPaid,a.MonthlyRepayment,a.LoanDuration, " +
                    "a.InterestRate,l.OutstandingAmount,l.PaymentStatus,l.PaymentFinished,l.DateFinishedPayment,l.Remark from LoanApplication a " +
                    "inner join Loans l on a.LoanApplicationID=l.LoanApplicationID " +
                    "where a.LoanApplicationID='" + loanApplicationID + "'";

                SqlCommand cmd = new SqlCommand(strQuery, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtAmount.Text = CheckForNumber.formatCurrency2(reader["LoanAmount"].ToString());
                        txtInterest.Text = CheckForNumber.formatCurrency2(reader["InterestAmount"].ToString());
                        txtTotalRepayment.Text = CheckForNumber.formatCurrency2(reader["TotalRepayment"].ToString());
                        txtMonthlyRepayment.Text = CheckForNumber.formatCurrency2(reader["MonthlyRepayment"].ToString());
                        lblDuration.Text = CheckForNumber.formatCurrency2(reader["LoanDuration"].ToString());
                        lblInterestRate.Text = CheckForNumber.formatCurrency2(reader["InterestRate"].ToString());
                        txtAmountPaid.Text = CheckForNumber.formatCurrency2(reader["AmountPaid"].ToString());
                        txtOutstandingAmt.Text = CheckForNumber.formatCurrency2(reader["OutstandingAmount"].ToString());
                        txtRemark.Text = reader["Remark"].ToString();

                        cboLoanCategory.SelectedValue = reader["LoanCategoryID"].ToString();
                        loadLoanType();
                        cboLoanType.SelectedValue = reader["LoanTypeID"].ToString();

                        DateTime loanApplicationDate = new DateTime(Convert.ToInt16(reader["AppYear"].ToString()), Convert.ToInt16(reader["AppMonth"].ToString()), 1);
                        dtAppDate.Value = loanApplicationDate;

                        DateTime startRepayment = new DateTime(Convert.ToInt16(reader["StartRepaymentYear"].ToString()),Convert.ToInt16(reader["StartRepaymentMonth"].ToString()), 1);
                        dtStartRepayment.Value = startRepayment;

                        if (reader["PaymentFinished"].ToString() == "Yes")
                        {
                            dateFinishedPayment = reader["DateFinishedPayment"].ToString();
                            dtPickerPaymentFinished.Visible = true;
                            DateTime theFinishedPaymentDate = DateTime.Parse(dateFinishedPayment);
                            dtPickerPaymentFinished.Value = theFinishedPaymentDate;

                        }
                        else
                        {
                            dateFinishedPayment = string.Empty;
                        }


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

        private void btnEnableEdit_Click(object sender, EventArgs e)
        {
            groupBox2.Enabled = shouldEnableEdit();        
            
        }

        private Boolean shouldEnableEdit()
        {
            Boolean resultEdit = false;

            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select count(*) from LoanRepayment where LoanID=@LoanID";

            SqlCommand cmd = new SqlCommand(strQuery, conn);
            cmd.Parameters.Add("@LoanID", SqlDbType.Int);
            cmd.Parameters["@LoanID"].Value = loanID;

            try
            {
                conn.Open();
                int recFound = Convert.ToInt16(cmd.ExecuteScalar());
                if (recFound > 0)
                {
                    MessageBox.Show("Selected Record cannot be Edited Since it Repayment has begun.", "Loans BF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    resultEdit = false;
                    groupBox2.Enabled = false;
                    btnEnableEdit.Enabled = false;
                }
                else
                {
                    resultEdit = true;
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

            return resultEdit;
        }

        private void cboLoanCategory_Leave(object sender, EventArgs e)
        {
            loadLoanType();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtInterest_Leave(object sender, EventArgs e)
        {

        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (txtAmount.Text != string.Empty && (CheckForNumber.isNumeric(txtAmount.Text)))
            {
                if (Convert.ToDecimal(txtAmount.Text) > 0)
                {
                    txtAmountPaid.Enabled = true;

                    decimal loanAmount = Convert.ToDecimal(txtAmount.Text);
                    decimal interestRate = Convert.ToDecimal(lblInterestRate.Text);
                    string strDuration = lblDuration.Text;

                    decimal duration = decimal.Parse(strDuration);
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

        private void cboLoanType_Leave(object sender, EventArgs e)
        {

        }

        private void cboLoanType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoanType.SelectedIndex == 0)
            {
                txtAmount.Enabled = false;
            }
            else
            {
                txtAmount.Enabled = true;

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


                    //calculate if amount is not empty
                    if ((txtAmount.Text !=string.Empty) && (CheckForNumber.isNumeric(txtAmount.Text)))
                    {
                        txtAmount_Leave(sender,e);

                        if ((txtAmountPaid.Text != string.Empty) && (CheckForNumber.isNumeric(txtAmountPaid.Text)))
                        {
                            txtAmountPaid_Leave(sender, e);
                        }
                        else
                        {
                            txtAmountPaid.Text = "0";
                            txtAmountPaid_Leave(sender, e);
                        }
                    }

                    
                }
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show("Do you wish to update the record?", "Loans BF", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                executeEditLoansBF();
            }

        }

        private void executeEditLoansBF()
        {
            if (txtAmount.Text != string.Empty && txtInterest.Text != string.Empty && txtTotalRepayment.Text != string.Empty && txtAmountPaid.Text != string.Empty && txtMonthlyRepayment.Text != string.Empty)
            {
                SqlConnection conn = ConnectDB.GetConnection();
                conn.Open();

                try
                {

                    SqlTransaction sqlTrans = conn.BeginTransaction();


                    string QueryLoanApp = "Update LoanApplication set AppMonth=@AppMonth, AppYear=@AppYear,LoanCategoryID=@LoanCategoryID, " +
                        "LoanTypeID=@LoanTypeID,LoanAmount=@LoanAmount,StartRepaymentMonth=@StartRepaymentMonth,StartRepaymentYear=@StartRepaymentYear," +
                        "LoanDuration=@LoanDuration,InterestRate=@InterestRate,InterestAmount=@InterestAmount,TotalRepayment=@TotalRepayment, " +
                        "MonthlyRepayment=@MonthlyRepayment where LoanApplicationID=@LoanApplicationID";

                    SqlCommand cmd = new SqlCommand(QueryLoanApp, conn);
                    cmd.Transaction = sqlTrans;

                    //MessageBox.Show("Application  ID: " + loanApplicationID.ToString());
                    #region parameters
                    cmd.Parameters.Add("@AppMonth", SqlDbType.Int);
                    cmd.Parameters["@AppMonth"].Value = dtAppDate.Value.Month.ToString();

                    cmd.Parameters.Add("@AppYear", SqlDbType.Int);
                    cmd.Parameters["@AppYear"].Value = dtAppDate.Value.Year.ToString();

                    cmd.Parameters.Add("@LoanCategoryID", SqlDbType.Int);
                    cmd.Parameters["@LoanCategoryID"].Value = cboLoanCategory.SelectedValue;

                    cmd.Parameters.Add("@LoanTypeID", SqlDbType.Int);
                    cmd.Parameters["@LoanTypeID"].Value = cboLoanType.SelectedValue;

                    cmd.Parameters.Add("@LoanAmount", SqlDbType.Decimal);
                    cmd.Parameters["@LoanAmount"].Value = txtAmount.Text;

                    cmd.Parameters.Add("@StartRepaymentMonth", SqlDbType.Int);
                    cmd.Parameters["@StartRepaymentMonth"].Value = dtStartRepayment.Value.Month.ToString();

                    cmd.Parameters.Add("@StartRepaymentYear", SqlDbType.Int);
                    cmd.Parameters["@StartRepaymentYear"].Value = dtStartRepayment.Value.Year.ToString();

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

                    cmd.Parameters.Add("@LoanApplicationID", SqlDbType.Int);
                    cmd.Parameters["@LoanApplicationID"].Value = loanApplicationID;
                    #endregion


                    int rowAffected_QueryLoanApp = cmd.ExecuteNonQuery();
                    MessageBox.Show("QueryLoanApp: " + rowAffected_QueryLoanApp.ToString());

                    string QueryLoans;

                    if (dateFinishedPayment != string.Empty)
                    {
                        QueryLoans = "Update Loans set RepaymentAmount=@RepaymentAmount,AmountPaid=@AmountPaid,OutstandingAmount=@OutstandingAmount, " +
                            "PaymentStatus=@PaymentStatus,PaymentFinished=@PaymentFinished,DateFinishedPayment=@DateFinishedPayment,Remark=@Remark " +
                            "where LoanApplicationID=@LoanApplicationID";
                    }
                    else
                    {
                        QueryLoans = "Update Loans set RepaymentAmount=@RepaymentAmount,AmountPaid=@AmountPaid,OutstandingAmount=@OutstandingAmount, " +
                            "PaymentStatus=@PaymentStatus,PaymentFinished=@PaymentFinished,Remark=@Remark " +
                            "where LoanApplicationID=@LoanApplicationID";

                    }

                    cmd.CommandText = QueryLoans;
                    //cmd.Transaction = sqlTrans;

                    #region parameters
                    cmd.Parameters.Add("@RepaymentAmount", SqlDbType.Decimal);
                    cmd.Parameters["@RepaymentAmount"].Value = txtTotalRepayment.Text;

                    cmd.Parameters.Add("@AmountPaid", SqlDbType.Decimal);
                    cmd.Parameters["@AmountPaid"].Value = txtAmountPaid.Text;

                    cmd.Parameters.Add("@OutstandingAmount", SqlDbType.Decimal);
                    cmd.Parameters["@OutstandingAmount"].Value = txtOutstandingAmt.Text;

                    cmd.Parameters.Add("@PaymentStatus", SqlDbType.NVarChar, 10);
                    cmd.Parameters["@PaymentStatus"].Value = paymentStatus;

                    cmd.Parameters.Add("@PaymentFinished", SqlDbType.NVarChar, 5);
                    cmd.Parameters["@PaymentFinished"].Value = paymentFinished;

                    if (dateFinishedPayment != string.Empty)
                    {
                        cmd.Parameters.Add("@DateFinishedPayment", SqlDbType.Date);
                        cmd.Parameters["@DateFinishedPayment"].Value = DateTime.Parse(dateFinishedPayment);
                    }

                    cmd.Parameters.Add("@Remark", SqlDbType.NVarChar, 1000);
                    cmd.Parameters["@Remark"].Value = txtRemark.Text;

                    cmd.Parameters["@LoanApplicationID"].Value = loanApplicationID;

                    #endregion

                    int rowAffected_QueryLoans = cmd.ExecuteNonQuery();
                    MessageBox.Show("QueryLoans: " + rowAffected_QueryLoans.ToString());

                    if ((rowAffected_QueryLoanApp > 0) && (rowAffected_QueryLoans > 0))
                    {
                        sqlTrans.Commit();
                        MessageBox.Show("Record has been successfully edited.", "Loans Forward", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ActivityLog.logActivity(userId, "LoansForward", "Edit Loans Brought Forward with LoanApplication ID of " + loanApplicationID);

                        EditLoansBroughtForward editLoansBroughtForward = new EditLoansBroughtForward(userId);
                        editLoansBroughtForward.MdiParent = this.ParentForm;
                        editLoansBroughtForward.Show();

                        this.Close();

                    }
                    else
                    {
                        sqlTrans.Rollback();
                        MessageBox.Show("An error occurred editing record.", "Loans Forward", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                
            }//end of if statement check

        }







    }
}
