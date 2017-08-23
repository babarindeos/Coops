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
    public partial class PostLoanRepayment : Form
    {

        string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
        int countLoanServicing;
        int currentServicingLoan;
        List<string> loanServicing;
        string memberID;
        string strFilter;



        public PostLoanRepayment()
        {
            InitializeComponent();
        }

        private void btnFindLoanByFileNo_Click(object sender, EventArgs e)
        {
            bool isRecordFound = false;
            isRecordFound =  MemberAllApprovedLoans();
            if (isRecordFound == true)
            {
                strFilter = "";
                MemberRepaymentRecords(strFilter);
            }

        }

        private bool MemberAllApprovedLoans()
        {
            bool isRecordFound = false;

            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select l.LoansID as [ID], l.TransactionID as [Transact. ID],m.Title + ' ' + m.LastName + ' ' + m.MiddleName + ' ' + m.FirstName as FullName, " +
                "a.MemberID,m.photo,a.TotalRepayment as Repayment,l.AmountPaid as [Amt. Paid], l.OutstandingAmount as [Outstanding],a.ApprovalStatus,l.PaymentFinished " +
                "from Loans l inner join LoanApplication a on l.TransactionID=a.TransactionID " +
                "inner join Members m on a.MemberID=m.MemberID " +
                "and a.ApprovalStatus='Yes' " +
                "and m.FileNo='" + txtFileNo.Text + "' order by l.LoansID desc";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Loans");
                DataTable dt = ds.Tables["Loans"];

                if (dt.Rows.Count > 0)
                {
                    datGrdLoans.DataSource = null;
                    datGrdLoans.Columns.Clear();
                    datGrdLoans.Rows.Clear();
                    datGrdLoans.Refresh();
                    datGrdLoans.DataSource = dt;

                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    datGrdLoans.Columns.Add(btn);
                    btn.HeaderText = "Details";
                    btn.Text = "View";
                    btn.Name = "btn";
                    btn.UseColumnTextForButtonValue = true;

                    datGrdLoans.Columns["FullName"].Visible = false;
                    datGrdLoans.Columns["MemberID"].Visible = false;
                    datGrdLoans.Columns["Photo"].Visible = false;
                    datGrdLoans.Columns["ApprovalStatus"].Visible = false;
                    datGrdLoans.Columns["PaymentFinished"].Visible = false;
                    datGrdLoans.Columns["Id"].Width = 40;
                    datGrdLoans.Columns["Repayment"].DefaultCellStyle.Format = "N2";
                    datGrdLoans.Columns["Amt. Paid"].DefaultCellStyle.Format = "N2";
                    datGrdLoans.Columns["Outstanding"].DefaultCellStyle.Format = "N2";
                    datGrdLoans.Columns["Repayment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    datGrdLoans.Columns["Amt. Paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    datGrdLoans.Columns["Outstanding"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    //retrieve Member Photo
                    string memberPic = string.Empty;
                    string fullName = string.Empty;
                    //MessageBox.Show(datGrdLoans.Rows.Count.ToString());
                    countLoanServicing = datGrdLoans.Rows.Count;
                    loanServicing = new List<string>();

                    //clear List before beginning adding items.
                    loanServicing.Clear();

                    foreach (DataRow row in dt.Rows)
                    {
                        memberPic = row["Photo"].ToString();
                        fullName = row["FullName"].ToString();
                        memberID = row["MemberID"].ToString();
                        string paymentFinished = row["PaymentFinished"].ToString();
                        if (paymentFinished == string.Empty || paymentFinished != "Yes")
                        {
                            //MessageBox.Show(row["PaymentFinished"].ToString());
                            loanServicing.Add(row["Id"].ToString() + " - " + row["Transact. ID"].ToString());
                        }    
                       
                    }

                    if (memberPic != string.Empty)
                    {
                        picMember.Image = Image.FromFile(paths + "//photos//" + memberPic);
                    }

                    MemberProfileInfo.Text = fullName + "\n" + txtFileNo.Text;
                    MemberProfileInfo.Visible = true;

                    //check if member has any loan to service
                    if (loanServicing.Count == 0)
                    {
                        MessageBox.Show("Currently no loan to service","Loan Repayment",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        grpPostRepayment.Enabled = false;
                        gBoxServicingLoan.Visible = false;
                    }
                    else
                    {
                        //Read Out List of Loans Member is to Service
                        //MessageBox.Show(countLoanServicing.ToString());
                        grpPostRepayment.Enabled = true;
                        gBoxServicingLoan.Visible = true;

                        currentServicingLoan = loanServicing.Count - 1;
                        txtServicingLoan.Text = loanServicing[currentServicingLoan];

                        //MessageBox.Show(loanServicing[currentServicingLoan].ToString());
                        string servicingTransactionID = loanServicing[currentServicingLoan];
                        servicingTransactionID = servicingTransactionID.Substring(servicingTransactionID.IndexOf("-") + 1).Trim();

                        //MessageBox.Show(servicingTransactionID.ToString());
                        string strResult = "Select RepaymentAmount, AmountPaid, OutstandingAmount from Loans where TransactionID='" + servicingTransactionID + "'";
                        SqlCommand cmdResult = new SqlCommand(strResult, conn);

                        SqlDataReader reader = cmdResult.ExecuteReader();
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                txtServicingRepaymentAmt.Text = CheckForNumber.formatCurrency(reader["RepaymentAmount"].ToString());
                                txtServicingAmtPaid.Text = CheckForNumber.formatCurrency(reader["AmountPaid"].ToString());
                                txtServicingOutstanding.Text = CheckForNumber.formatCurrency(reader["OutstandingAmount"].ToString());
                            }
                        }
                    }

                    //Record true if the searched Member exist
                    isRecordFound = true;
                }
                else
                {
                    MessageBox.Show("Sorry, there is no member with that File No.", "Loans", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    //Record false if Member record does not exist
                    isRecordFound = false;
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

            return isRecordFound;
        }

        private void MemberRepaymentRecords(string strFilter)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select LoanID,TransactionID,RepaymentAmount,PaidAmount,Outstanding,PaidCumulative,Excess,RepayTransactID as [Repayment TransactID],Remark,DatePosted " +
                "from LoanRepayment where MemberID=@MemberID " + strFilter  + " order by LoanRepaymentID desc";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            
            cmd.Parameters.Add("@MemberID", SqlDbType.Int);
            cmd.Parameters["@MemberID"].Value = memberID;

            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                adt.Fill(ds, "LoanRepayment");
                DataTable dt = ds.Tables["LoanRepayment"];
                datGrdRepayments.DataSource = dt;

                datGrdRepayments.Columns["LoanID"].Width = 60;
                datGrdRepayments.Columns["LoanID"].HeaderText = "ID";

                datGrdRepayments.Columns["RepaymentAmount"].HeaderText = "Repayment Amount";
                datGrdRepayments.Columns["RepaymentAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdRepayments.Columns["RepaymentAmount"].DefaultCellStyle.Format = "N2";

                datGrdRepayments.Columns["PaidAmount"].HeaderText = "Paid Amount";
                datGrdRepayments.Columns["PaidAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdRepayments.Columns["PaidAmount"].DefaultCellStyle.Format = "N2";

                datGrdRepayments.Columns["Outstanding"].HeaderText = "Outstanding";
                datGrdRepayments.Columns["Outstanding"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdRepayments.Columns["Outstanding"].DefaultCellStyle.Format = "N2";

                datGrdRepayments.Columns["PaidCumulative"].HeaderText = "Paid Cumulative";
                datGrdRepayments.Columns["PaidCumulative"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdRepayments.Columns["PaidCumulative"].DefaultCellStyle.Format = "N2";

                datGrdRepayments.Columns["Excess"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdRepayments.Columns["Excess"].DefaultCellStyle.Format = "N2";

                lblNumRepayments.Text = "Number of Records: " + dt.Rows.Count.ToString();
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

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void datGrdLoans_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.ColumnIndex.ToString());
            if (e.ColumnIndex == 10)
            {
                datGrdLoans.Rows[e.RowIndex].Selected = true;
                string transactionID = datGrdLoans.Rows[e.RowIndex].Cells[1].Value.ToString();
                string loanID = datGrdLoans.Rows[e.RowIndex].Cells[0].Value.ToString();
               
                strFilter = "and LoanID =" + loanID ;

                getSelectedLoanDetail(transactionID);
                MemberRepaymentRecords(strFilter);


            }
        }


        private void getSelectedLoanDetail(string transactionID)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select l.LoansID as [Id], l.TransactionID as [Transact. ID], " +
                "a.TotalRepayment, l.AmountPaid, l.OutstandingAmount, a.ApprovalStatus, " +
                "a.StartRepaymentMonth, a.StartRepaymentYear, t.Type, t.Duration, t.InterestRate, a.LoanAmount, a.InterestAmount, a.MonthlyRepayment " +
                "from Loans l inner join LoanApplication a on l.TransactionID=a.TransactionID " +
                "left join LoanType t on a.LoanTypeID=t.LoanTypeID " +
                "where a.ApprovalStatus='Yes' " +
                "and a.TransactionID='" + transactionID  + "' order by l.LoansID desc";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        //MessageBox.Show(reader["StartRepaymentMonth"].ToString());
                        txtStartRepayment.Text = DateFunction.getMonthByName(Convert.ToInt32(reader["StartRepaymentMonth"])) + " " + reader["StartRepaymentYear"].ToString();
                        txtLoanType.Text = reader["Type"].ToString();
                        txtDuration.Text = reader["Duration"].ToString();
                        txtInterestRate.Text = reader["InterestRate"].ToString();
                        txtLoanAmount.Text = CheckForNumber.formatCurrency(reader["LoanAmount"].ToString());
                        txtRepaymentAmount.Text = CheckForNumber.formatCurrency(reader["TotalRepayment"].ToString());
                        txtInterestAmount.Text = CheckForNumber.formatCurrency(reader["InterestAmount"].ToString());
                        txtMonthlyRepayment.Text = CheckForNumber.formatCurrency(reader["MonthlyRepayment"].ToString());
                        txtAmountPaid.Text = CheckForNumber.formatCurrency(reader["AmountPaid"].ToString());
                        txtOutstanding.Text = CheckForNumber.formatCurrency(reader["OutstandingAmount"].ToString());

                        //alignment of controls
                        txtLoanAmount.TextAlign = HorizontalAlignment.Right;
                        txtRepaymentAmount.TextAlign = HorizontalAlignment.Right;
                        txtInterestAmount.TextAlign = HorizontalAlignment.Right;
                        txtMonthlyRepayment.TextAlign = HorizontalAlignment.Right;
                        txtAmountPaid.TextAlign = HorizontalAlignment.Right;
                        txtOutstanding.TextAlign = HorizontalAlignment.Right;
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

        private void PostLoanRepayment_Load(object sender, EventArgs e)
        {
            txtServicingRepaymentAmt.TextAlign = HorizontalAlignment.Right;
            txtServicingAmtPaid.TextAlign = HorizontalAlignment.Right;
            txtServicingOutstanding.TextAlign = HorizontalAlignment.Right;
        }

        private void txtPayAmount_Leave(object sender, EventArgs e)
        {
            if (CheckForNumber.isNumeric(txtPayAmount.Text))
            {
                txtPayAmount.Text = CheckForNumber.formatCurrency(txtPayAmount.Text);
                btnPostRepayment.Enabled = true;

                int loanSize = loanServicing.Count - 1;
                int loopTimes = 0;
                decimal amountToPay;
                decimal totalRepaymentAmount;
                decimal amountPaidAlready;
                decimal outstanding;

                decimal newOutstanding;
                decimal newAmountPaid;

                decimal excess = 0;

                string servicingTransactionID = string.Empty;

                totalRepaymentAmount = Convert.ToDecimal(txtServicingRepaymentAmt.Text);
                amountPaidAlready = Convert.ToDecimal(txtServicingAmtPaid.Text);
                amountToPay = Convert.ToDecimal(txtPayAmount.Text);


                outstanding = totalRepaymentAmount - amountPaidAlready;

                txtExtraFeedback.Text = string.Empty;
                txtPaymentStatus.Text = string.Empty;
                txtCalAmountPaid.Text = string.Empty;

                while (loanSize >= 0)
                {
                    loopTimes++;

                    if (amountToPay <= outstanding)
                    {
                        newAmountPaid = amountToPay + amountPaidAlready;
                        newOutstanding = totalRepaymentAmount - (newAmountPaid);
                                            

                        if (excess==0)
                        {
                            txtCalOutstanding.Text =CheckForNumber.formatCurrency(newOutstanding.ToString());
                            txtCalAmountPaid.Text = CheckForNumber.formatCurrency(newAmountPaid.ToString());
                        }

                            txtExtraFeedback.Text += "\n\n------------------------";
                            txtExtraFeedback.Text += servicingTransactionID + Environment.NewLine + "Repayment: " + CheckForNumber.formatCurrency(totalRepaymentAmount.ToString()) + Environment.NewLine;
                            txtExtraFeedback.Text += "Paying: " + CheckForNumber.formatCurrency(amountToPay.ToString()) + Environment.NewLine;
                            txtExtraFeedback.Text += "Outstanding: " + CheckForNumber.formatCurrency(newOutstanding.ToString()) + Environment.NewLine;
                        
                       

                        if (newOutstanding == 0)
                        {
                            txtPaymentStatus.Text = "Paid";
                        }
                        else
                        {
                            txtPaymentStatus.Text = "Paying";
                        }


                        break;

                    }
                    else
                    {
                        //newAmountPaid = amountToPay + totalRepaymentAmount;
                        decimal noteAmountPaid;
                        noteAmountPaid = amountToPay;
                        excess = amountToPay - outstanding;
                        amountToPay = excess;

                        
                        //MessageBox.Show("Amount Paid: " + totalRepaymentAmount.ToString());
                        //MessageBox.Show("Excess: " + excess);

                        txtCalOutstanding.Text = "0.00";
                        txtCalAmountPaid.Text += totalRepaymentAmount + ", ";
                        txtPaymentStatus.Text = "Paid";

                        txtExtraFeedback.Text += "\n\n------------------------";
                        txtExtraFeedback.Text += servicingTransactionID + Environment.NewLine + "Repayment: " + CheckForNumber.formatCurrency(totalRepaymentAmount.ToString()) + Environment.NewLine;
                        txtExtraFeedback.Text += "Paying: " + CheckForNumber.formatCurrency(noteAmountPaid.ToString()) + Environment.NewLine;
                        txtExtraFeedback.Text += "Excess: " + CheckForNumber.formatCurrency(excess.ToString()) + Environment.NewLine;
                        
                    }


                    loanSize--;

                    if (loanSize < 0)
                    {
                        if (excess > 0)
                        {
                            txtExtraFeedback.Text += "\n\n------------------------";
                            txtExtraFeedback.Text += "Savings Deposit: " + CheckForNumber.formatCurrency(excess.ToString());
                        }
                        break;
                    }

                    SqlConnection conn = ConnectDB.GetConnection();
                    servicingTransactionID = loanServicing[loanSize];
                    servicingTransactionID = servicingTransactionID.Substring(servicingTransactionID.IndexOf("-") + 1).Trim();
                    string strQuery2 = "Select RepaymentAmount,OutstandingAmount,AmountPaid from Loans where TransactionID='" + servicingTransactionID + "'";
                    SqlCommand cmdQuery = new SqlCommand(strQuery2, conn);

                    conn.Open();
                    SqlDataReader reader = cmdQuery.ExecuteReader();
                    reader.Read();

                    outstanding = Convert.ToDecimal(reader["OutstandingAmount"]);
                    totalRepaymentAmount = Convert.ToDecimal(reader["RepaymentAmount"]);
                    amountPaidAlready = Convert.ToDecimal(reader["AmountPaid"]);

                    

                }
            }
            else
            {
                txtCalAmountPaid.Clear();
                txtCalOutstanding.Clear();

            }
        }

        private void btnPostRepayment_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you wish to Post this Loan Repayment?", "Loans", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                #region Execute_Loan_Repayment
                //declare and initialize variables
                //MessageBox.Show("Member ID: " + memberID);

                int loanSize = loanServicing.Count - 1;

                #region declaration and initialisation
                decimal amountPaying = 0;
                decimal savedAmountPaying = 0;
                decimal rePayment = 0;
                decimal amountPaid = 0;
                decimal newAmountPaid = 0;
                decimal outstanding = 0;
                decimal newOutstanding = 0;
                decimal excess = 0;
                string loanId;
                string loanToService;
                string transactionID;
                string paymentStatus;
                string paymentFinished;
                DateTime dateFinishedPayment;
                bool disContinueLoop = false;

                string strQuery;
                string strInsertRepayment;
                string strUpdateLoan;
                int rowsAffected;
                bool dbOperationStatus = true;

                #endregion end of declaration and initialisation

                SqlConnection conn = ConnectDB.GetConnection();
                SqlCommand cmdSelectLoans;
                SqlCommand cmdInsertRepayment;
                SqlCommand cmdUpdateLoan;
                SqlDataReader reader;
                SqlTransaction sqlTrans = null;

                amountPaying = Convert.ToDecimal(txtPayAmount.Text);
                string rePayTransactID = "PAY" + DateTime.Now.ToString("ddMMyyhhmmss");

                //MessageBox.Show("RePayTransactID: " + rePayTransactID);

                //Execute Loans Servicing

                #region while section
                while (loanSize >= 0)
                {
                    //MessageBox.Show();
                    //MessageBox.Show("Loan item: " + loanSize.ToString() + " - " + loanServicing[loanSize]);

                    loanToService = loanServicing[loanSize];
                    loanId = loanToService.Substring(0, loanToService.IndexOf("-"));
                    transactionID = loanToService.Substring(loanToService.IndexOf("-") + 1).Trim();
                    //MessageBox.Show("Loan ID: " + loanId + " TransactionID: " + transactionID);


                    //Setup command to retrieve Loan Record
                    strQuery = "Select RepaymentAmount, AmountPaid, OutstandingAmount from Loans where LoansID='" + loanId +
                        "' and TransactionID='" + transactionID + "'";
                    cmdSelectLoans = new SqlCommand(strQuery, conn);

                    #region try section
                    try
                    {
                        //MessageBox.Show("Connection State: " + conn.State);
                        if (conn.State != ConnectionState.Open)
                        {
                            //MessageBox.Show("Db wasn't opened, it is now..");
                            conn.Open();
                            sqlTrans = conn.BeginTransaction();
                        }

                        //Execute cmdSelectLoans Command
                        cmdSelectLoans.Transaction = sqlTrans;
                        reader = cmdSelectLoans.ExecuteReader();

                        reader.Read();
                        rePayment = Convert.ToDecimal(reader["RepaymentAmount"]);
                        outstanding = Convert.ToDecimal(reader["OutstandingAmount"]);
                        amountPaid = Convert.ToDecimal(reader["AmountPaid"]);

                        //MessageBox.Show("Outstanding Loan: " + outstanding);

                        savedAmountPaying = amountPaying;

                        if (amountPaying <= outstanding)
                        {
                            newOutstanding = outstanding - amountPaying;
                            newAmountPaid = amountPaying + amountPaid;
                            excess = 0;
                            disContinueLoop = true;
                        }
                        else
                        {
                            excess = amountPaying - outstanding;
                            newOutstanding = 0;
                            newAmountPaid = rePayment;
                            amountPaying = excess;
                        }

                        reader.Close(); //close reader for cmdSelectLoans

                        //MessageBox.Show("New Outstanding: " + newOutstanding + "\nNew Amount Paid: " + newAmountPaid + "\nExcess: " + excess + "\nSaved Amount: " + savedAmountPaying);

                        //Begin Repayment subroutine
                        strInsertRepayment = "Insert into LoanRepayment(MemberID,LoanID,TransactionID,RepaymentAmount,PaidAmount,Outstanding,PaidCumulative,Excess,Remark,RepayTransactID)" +
                             "values(@MemberID,@LoanID,@TransactionID,@RepaymentAmount,@NewAmountPaid,@NewOutstanding,@PaidCumulative,@Excess,@Remark,@RepayTransactID)";

                        cmdInsertRepayment = new SqlCommand(strInsertRepayment, conn);

                        #region cmdInsertRepayment parameters
                        cmdInsertRepayment.Parameters.Add("@MemberID", SqlDbType.Int);
                        cmdInsertRepayment.Parameters["@MemberID"].Value = memberID;

                        cmdInsertRepayment.Parameters.Add("@LoanID", SqlDbType.Int);
                        cmdInsertRepayment.Parameters["@LoanID"].Value = Convert.ToInt32(loanId);

                        cmdInsertRepayment.Parameters.Add("@TransactionID", SqlDbType.VarChar, 50);
                        cmdInsertRepayment.Parameters["@TransactionID"].Value = transactionID;

                        cmdInsertRepayment.Parameters.Add("@RepaymentAmount", SqlDbType.Decimal);
                        cmdInsertRepayment.Parameters["@RepaymentAmount"].Value = rePayment;

                        cmdInsertRepayment.Parameters.Add("@NewAmountPaid", SqlDbType.Decimal);
                        cmdInsertRepayment.Parameters["@NewAmountPaid"].Value = savedAmountPaying;

                        cmdInsertRepayment.Parameters.Add("@NewOutstanding", SqlDbType.Decimal);
                        cmdInsertRepayment.Parameters["@NewOutstanding"].Value = newOutstanding;

                        cmdInsertRepayment.Parameters.Add("@PaidCumulative", SqlDbType.Decimal);
                        cmdInsertRepayment.Parameters["@PaidCumulative"].Value = newAmountPaid;

                        cmdInsertRepayment.Parameters.Add("@Excess", SqlDbType.Decimal);
                        cmdInsertRepayment.Parameters["@Excess"].Value = excess;

                        cmdInsertRepayment.Parameters.Add("@Remark", SqlDbType.NVarChar, 100);
                        cmdInsertRepayment.Parameters["@Remark"].Value = txtRemark.Text.Trim();

                        cmdInsertRepayment.Parameters.Add("@RepayTransactID", SqlDbType.NVarChar, 50);
                        cmdInsertRepayment.Parameters["@RepayTransactID"].Value = rePayTransactID;
                        #endregion

                        cmdInsertRepayment.Transaction = sqlTrans;
                        rowsAffected = cmdInsertRepayment.ExecuteNonQuery();

                        if (rowsAffected < 1)
                        {
                            dbOperationStatus = false;
                        }

                        if (dbOperationStatus == false)
                        {
                            MessageBox.Show("An error has occurred and Operation has been terminated!", "Loan Repayment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;

                        }
                        else
                        {
                            //Begin Loan Update subroutine
                            strUpdateLoan = "Update Loans set AmountPaid=@NewAmountPaid, OutstandingAmount=@NewOutstandingAmount," +
                             "PaymentStatus=@PaymentStatus,PaymentFinished=@PaymentFinished,DateFinishedPayment=@DateFinishedPayment " +
                             "where LoansID=@LoanID and TransactionID=@TransactionID";


                            if (newOutstanding > 0)
                            {
                                //MessageBox.Show("PayStatus: Paying | PaymentFinished: No");
                                paymentStatus = "Paying";
                                paymentFinished = "No";
                            }
                            else
                            {
                                //MessageBox.Show("PayStatus: PAID | PaymentFinished: Yes");
                                paymentStatus = "PAID";
                                paymentFinished = "Yes";
                            }

                            cmdUpdateLoan = new SqlCommand(strUpdateLoan, conn);

                            #region cmdUpdateLoan parameters
                            cmdUpdateLoan.Parameters.Add("@NewAmountPaid", SqlDbType.Decimal);
                            cmdUpdateLoan.Parameters["@NewAmountPaid"].Value = newAmountPaid;

                            cmdUpdateLoan.Parameters.Add("@NewOutstandingAmount", SqlDbType.Decimal);
                            cmdUpdateLoan.Parameters["@NewOutstandingAmount"].Value = newOutstanding;

                            cmdUpdateLoan.Parameters.Add("@PaymentStatus", SqlDbType.NVarChar, 10);
                            cmdUpdateLoan.Parameters["@PaymentStatus"].Value = paymentStatus;

                            cmdUpdateLoan.Parameters.Add("@PaymentFinished", SqlDbType.NVarChar, 5);
                            cmdUpdateLoan.Parameters["@PaymentFinished"].Value = paymentFinished;

                            dateFinishedPayment = DateTime.Now;
                            cmdUpdateLoan.Parameters.Add("@DateFinishedPayment", SqlDbType.Date);
                            cmdUpdateLoan.Parameters["@DateFinishedPayment"].Value = dateFinishedPayment;

                            cmdUpdateLoan.Parameters.Add("@LoanID", SqlDbType.Int);
                            cmdUpdateLoan.Parameters["@LoanID"].Value = Convert.ToInt32(loanId);

                            cmdUpdateLoan.Parameters.Add("@TransactionID", SqlDbType.NVarChar, 50);
                            cmdUpdateLoan.Parameters["@TransactionID"].Value = transactionID;

                            #endregion

                            cmdUpdateLoan.Transaction = sqlTrans;
                            rowsAffected = cmdUpdateLoan.ExecuteNonQuery();

                            if (rowsAffected != 1)
                            {
                                dbOperationStatus = false;
                            }




                        }//end of try snippet   



                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    #endregion end of try




                    loanSize--;
                    if (disContinueLoop == true && excess == 0)
                    {
                        break;
                    }
                    else if (loanSize < 0 && excess > 0)
                    {
                        //MessageBox.Show("Savings deposit: " + excess);

                        dbOperationStatus = depositExcessInSavings(excess, transactionID, conn, sqlTrans);

                    }



                }
                #endregion end of while section


                //Close up database connection
                if (dbOperationStatus == true)
                {
                    sqlTrans.Commit();
                    txtServicingAmtPaid.Text = txtCalAmountPaid.Text;
                    txtServicingOutstanding.Text = txtCalOutstanding.Text;
                    MessageBox.Show("Repayment Operation is Successful", "Loan Repayment", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    sqlTrans.Rollback();
                    MessageBox.Show("An error has occurred!", "Loan Repayment", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                conn.Close();
                //MessageBox.Show("After Database Close, Db State: " + conn.State);
                #endregion
                clearFields();

                bool isRecordFound = false;
                isRecordFound = MemberAllApprovedLoans();

                strFilter = "";
                MemberRepaymentRecords(strFilter);

            }

        }

        private void clearFields()
        {
            txtStartRepayment.Text = string.Empty;
            txtLoanType.Text = string.Empty;
            txtDuration.Text = string.Empty;
            txtInterestRate.Text = string.Empty;
            txtLoanAmount.Text = string.Empty;
            txtRepaymentAmount.Text = string.Empty;
            txtInterestAmount.Text = string.Empty;
            txtMonthlyRepayment.Text = string.Empty;
            txtAmountPaid.Text = string.Empty;
            txtOutstanding.Text = string.Empty;

            txtPayAmount.Text = string.Empty;
            txtRemark.Text = string.Empty;

            txtCalAmountPaid.Text = string.Empty;
            txtCalOutstanding.Text = string.Empty;
            txtPaymentStatus.Text = string.Empty;
            txtExtraFeedback.Text = string.Empty;
        }

        private void txtPayAmount_TextChanged(object sender, EventArgs e)
        {
            if (CheckForNumber.isNumeric(txtPayAmount.Text) && (txtPayAmount.Text!=string.Empty))
            {
                btnPostRepayment.Enabled = true;
            } 
            else
            {
                btnPostRepayment.Enabled = false;
            }

        }


        private bool depositExcessInSavings(decimal excess, string transactionID, SqlConnection conn, SqlTransaction sqlTrans)
        {
            string strSavingsInsert = "Insert into Savings(MemberID,SavingSource,Amount,Month,Year,TransactionID)" +
                                    "values(@MemberID,@SavingSource,@Amount,@Month,@Year,@TransactionID)";

            SqlCommand cmdSavingsInsert = new SqlCommand(strSavingsInsert, conn);
            #region cmdSavingsInsert Parameters
            cmdSavingsInsert.Parameters.Add("@MemberID", SqlDbType.Int);
            cmdSavingsInsert.Parameters["@MemberID"].Value = memberID;

            cmdSavingsInsert.Parameters.Add("@SavingSource", SqlDbType.NVarChar, 40);
            cmdSavingsInsert.Parameters["@SavingSource"].Value = "Loan";

            cmdSavingsInsert.Parameters.Add("@Amount", SqlDbType.Decimal);
            cmdSavingsInsert.Parameters["@Amount"].Value = excess;

            DateTime currentDate = DateTime.Now;
            int currentMonth = currentDate.Month;
            int currentYear = currentDate.Year;

            cmdSavingsInsert.Parameters.Add("@Month", SqlDbType.NVarChar, 5);
            cmdSavingsInsert.Parameters["@Month"].Value = currentMonth.ToString();

            cmdSavingsInsert.Parameters.Add("@Year", SqlDbType.NVarChar, 5);
            cmdSavingsInsert.Parameters["@Year"].Value = currentYear.ToString();

            cmdSavingsInsert.Parameters.Add("@TransactionID", SqlDbType.NVarChar, 30);
            cmdSavingsInsert.Parameters["@TransactionID"].Value = transactionID;
            #endregion cmdSavingsInsert

            bool operationStatus = true;

            try
            {
                //conn.Open();
                cmdSavingsInsert.Transaction = sqlTrans;

                int rowAffected = cmdSavingsInsert.ExecuteNonQuery();

                if (rowAffected != 1)
                {
                    operationStatus = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

            return operationStatus;

        }


    }
}
