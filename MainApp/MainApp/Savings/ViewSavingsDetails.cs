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
    public partial class ViewSavingsDetails : Form
    {
        private string selectedSavingsID;
        private string selectedSavingSource;
        private string selectedTransactionID;

        public ViewSavingsDetails(string savingsID, string savingSource, string transactionID)
        {
            InitializeComponent();
            selectedSavingsID = savingsID;
            selectedSavingSource = savingSource;
            selectedTransactionID = transactionID;
           
        }

        private void ViewSavingsDetails_Load(object sender, EventArgs e)
        {
            string tableName = string.Empty;

            switch (selectedSavingSource)
            {
                case "Contribution":
                    tableName = "Contributions";
                    break;
                case "Loan":
                    tableName = "Loans";
                    break;
                case "Deduction":
                    tableName = "Deductions";
                    break;
                case "Deduction - Loan Repayment Excess":
                    tableName = "Deductions";
                    break;
                case "SavingsForward":
                    tableName = "SavingsForward";
                    break;
                case "Withdrawal":
                    tableName = "SavingsWithdrawal";
                    break;
            }

            getSavingsInfo();
            getSavingDetailsInfo(tableName,selectedTransactionID);

        }

        private void getSavingsInfo()
        {
            //MessageBox.Show(selectedSavingsID.ToString());
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select s.SavingsID 'Savings ID', m.FileNo 'File No',m.Title + ' ' + m.LastName + ' ' + m.FirstName + ' ' + m.MiddleName as 'Full Name', " +
                "s.SavingSource 'Saving Source', s.Amount, mon.Month + ' ' + s.Year 'Period', s.Date " +
                "from Savings s left join Members m on m.MemberID = s.MemberID " +
                "left join MonthByName mon on s.Month=mon.MonthID where s.SavingsID=" + selectedSavingsID;

            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                                
                da.Fill(ds,"Savings");
                DataTable dt = ds.Tables["Savings"];

                dtGrdSavings.DataSource = dt;
                                
                dtGrdSavings.Columns["File No"].Width = 90;
                dtGrdSavings.Columns["Full Name"].Width = 200;
                dtGrdSavings.Columns["Saving Source"].Width = 150;
                dtGrdSavings.Columns["Savings ID"].Visible = true;
                dtGrdSavings.Columns["Amount"].DefaultCellStyle.Format = "N2";
                dtGrdSavings.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                

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

        private void getSavingDetailsInfo(string tableName, string selectedTransactionID)
        {
            string strQuery = string.Empty;
            //MessageBox.Show("TableName: " + tableName + "\nTransactionID: " + selectedTransactionID);
            switch (tableName)
            {
                case "Deductions":
                    strQuery = "Select d.DeductionID 'Deduction ID',m.Title + ' ' +  m.LastName + ' ' + m.FirstName + ' ' + m.MiddleName as 'Full Name', " +
                    "mon.Month,d.Year,d.Savings,d.Loans,d.Total,d.TransactionID,d.DatePosted as 'Date Posted' " +
                    "from Deductions d left join Members m on d.MemberID = m.MemberID " +
                    "left join MonthByName mon on mon.MonthID=d.Month " +
                    "where d.TransactionID='" + selectedTransactionID + "'";
                    //MessageBox.Show(strQuery);
                    break;
                case "SavingsForward":
                    BuildTempSavingsAcctType.Create();
                    strQuery = "Select SavingsForwardID 'SF ID',mon.Month,sf.Year,t.SavingsName 'Saving Type',sf.Amount,sf.Comment, " +
                        "sf.TransactionID,sf.DatePosted from SavingsForward sf left join MonthByName mon on sf.Month=mon.MonthID " +
                        "left join TempSavingsAcctType t on sf.SavingsTypeID=t.SavingsTypeID " +
                        "where sf.SavingsID=" + selectedSavingsID;
                    break;            
                case "Contributions":
                    BuildTempSavingsAcctType.Create();
                    strQuery = "Select c.ContributionID 'Contribution ID',p.PaymentMode 'Payment Mode',c.OtherPayment 'Other Payment',b.BankName 'Bank Name',t.SavingsName 'Savings Type',c.TellerNo 'Teller No',c.ReceiptNo 'ReceiptNo', " +
                        "c.Comment,c.TransactionID,c.Date from Contributions c " +
                        "left join PaymentMode p on c.PaymentModeID=p.PaymentModeID " +
                        "left join Banks b on b.BankID=c.BankID " + 
                        "left join TempSavingsAcctType t on c.SavingsAcctID=t.SavingsTypeID " +
                        "where c.SavingsID=" + selectedSavingsID;
                    break;
                case "Loans":
                    strQuery = "Select l.LoansID 'Loan ID',l.LoanApplicationID 'App. ID', m.Title + ' ' + m.LastName + ' ' + m.FirstName + ' ' + m.MiddleName as 'Full Name', " +
                        "a.LoanAmount 'Loan Amount',a.InterestRate 'Interest Rate',a.interestAmount 'Interest Amt.',a.MonthlyRepayment 'Monthly Repayment', " +
                        "l.RepaymentAmount 'Total Repayment',l.AmountPaid 'Amt. Paid', l.OutstandingAmount 'Outstanding Amt.',l.PaymentStatus 'Payment Status', " +
                        "mon.Month 'App. Month',a.AppYear 'App. Year',mth.Month 'Start Repayment Mth.',a.StartRepaymentYear 'Start Repayment Yr.', lc.Name 'Loan Category',lt.Type 'Loan Type', l.DateFinishedPayment 'Finished Repayment', l.TransactionID,l.DateCreated 'Date Created'" +
                        "from Loans l inner join LoanApplication a on a.LoanApplicationID=l.LoanApplicationID " +
                        "left join Members m on m.MemberID=a.MemberID " +
                        "left join LoanCategory lc on a.LoanCategoryID=lc.LoanCategoryID " +
                        "left join LoanType lt on a.LoanTypeID=lt.LoanTypeID " +
                        "left join MonthByName mon on mon.MonthID=a.AppMonth " +
                        "left join MonthByName mth on mth.MonthID=a.StartRepaymentMonth " +
                        "where l.TransactionID='" + selectedTransactionID + "'";

                    break;
                case "SavingsWithdrawal":
                    strQuery = "Select w.SavingsWithdrawalID 'ID',w.SavingsID 'Savings ID', st.SavingsName 'Savings Type', w.Amount,w.WithdrawAmount 'Withdrawal',w.Balance,w.Date from SavingsWithdrawal w " +
                        "inner join SavingsType st on w.SavingsTypeID=st.SavingsTypeID " + 
                        "where w.SavingsID = " + selectedSavingsID +
                        " order by w.SavingsWithdrawalID desc";
                    break;

            }

            SqlConnection conn = ConnectDB.GetConnection();
            SqlCommand cmd = new SqlCommand(strQuery,conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "SavingDetails");
                DataTable dt = ds.Tables["SavingDetails"];
                dtGrdSavingDetails.DataSource = dt;

                if (tableName == "Deductions")
                {
                    dtGrdSavingDetails.Columns["Savings"].DefaultCellStyle.Format = "N2";
                    dtGrdSavingDetails.Columns["Loans"].DefaultCellStyle.Format = "N2";
                    dtGrdSavingDetails.Columns["Total"].DefaultCellStyle.Format = "N2";
                    dtGrdSavingDetails.Columns["Full Name"].Width = 250;
                }
                else if (tableName=="SavingsForward")
                {
                    dtGrdSavingDetails.Columns["Amount"].DefaultCellStyle.Format = "N2";
                    dtGrdSavingDetails.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (tableName == "Loans")
                {
                    dtGrdSavingDetails.Columns["Loan Amount"].DefaultCellStyle.Format = "N2";
                    dtGrdSavingDetails.Columns["Loan Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dtGrdSavingDetails.Columns["Interest Rate"].DefaultCellStyle.Format = "N2";
                    dtGrdSavingDetails.Columns["Interest Rate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dtGrdSavingDetails.Columns["Interest Amt."].DefaultCellStyle.Format = "N2";
                    dtGrdSavingDetails.Columns["Interest Amt."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dtGrdSavingDetails.Columns["Monthly Repayment"].DefaultCellStyle.Format = "N2";
                    dtGrdSavingDetails.Columns["Monthly Repayment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dtGrdSavingDetails.Columns["Total Repayment"].DefaultCellStyle.Format = "N2";
                    dtGrdSavingDetails.Columns["Total Repayment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dtGrdSavingDetails.Columns["Amt. Paid"].DefaultCellStyle.Format = "N2";
                    dtGrdSavingDetails.Columns["Amt. Paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dtGrdSavingDetails.Columns["Outstanding Amt."].DefaultCellStyle.Format = "N2";
                    dtGrdSavingDetails.Columns["Outstanding Amt."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dtGrdSavingDetails.Columns["Payment Status"].DefaultCellStyle.Format = "N2";
                    dtGrdSavingDetails.Columns["Payment Status"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
                else if (tableName == "SavingsWithdrawal")
                {
                    dtGrdSavingDetails.Columns["Amount"].DefaultCellStyle.Format = "N2";
                    dtGrdSavingDetails.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dtGrdSavingDetails.Columns["Withdrawal"].DefaultCellStyle.Format = "N2";
                    dtGrdSavingDetails.Columns["Withdrawal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dtGrdSavingDetails.Columns["Balance"].DefaultCellStyle.Format = "N2";
                    dtGrdSavingDetails.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
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
}
