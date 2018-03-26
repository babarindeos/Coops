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
    public partial class ViewLoanDetails : Form
    {
        private string loanApplicationID;
        private string loanID;

        public ViewLoanDetails(string loanAppID)
        {
            InitializeComponent();
            this.loanApplicationID = loanAppID;
            
            loanID = string.Empty;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ViewLoanDetails_Load(object sender, EventArgs e)
        {
            loadLoan();
            loadLoanRepayment();
        }

        private void loadLoan()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select LoansID, LoanApplicationID,RepaymentAmount 'Repayment Amount.',AmountPaid 'Amount Paid',OutstandingAmount 'Outstanding Amt.',PaymentStatus 'Payment Status', " +
                "PaymentFinished 'Payment Finished',DateFinishedPayment 'Finished Payment',TransactionID 'Trans. ID',Remark,DateCreated 'Date Created' from Loans where LoanApplicationID='" + loanApplicationID + "'";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Loans");
                DataTable dt = ds.Tables["Loans"];
                dtGrdVwLoans.DataSource = dt;

                dtGrdVwLoans.Columns["LoansID"].Visible = false;
                dtGrdVwLoans.Columns["LoanApplicationID"].Visible = false;
                dtGrdVwLoans.Columns["Repayment Amount."].DefaultCellStyle.Format = "N2";
                dtGrdVwLoans.Columns["Amount Paid"].DefaultCellStyle.Format = "N2";
                dtGrdVwLoans.Columns["Amount Paid"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtGrdVwLoans.Columns["Outstanding Amt."].DefaultCellStyle.Format = "N2";
                dtGrdVwLoans.Columns["Outstanding Amt."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtGrdVwLoans.Columns["Finished Payment"].DefaultCellStyle.Format = "D";
                dtGrdVwLoans.Columns["Date Created"].DefaultCellStyle.Format = "D";

                if (dtGrdVwLoans.Rows.Count > 0)
                {
                    loanID = dtGrdVwLoans.Rows[0].Cells[0].Value.ToString();
                    //MessageBox.Show(loanID);
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

        private void loadLoanRepayment()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select l.LoanRepaymentID,m.FileNo,m.LastName 'Last Name',m.FirstName 'First Name',m.MiddleName 'Middle Name',l.RepaymentAmount 'Repayment Amt.', " +
                "l.PaidAmount 'Paid Amt',l.Outstanding 'Outstanding Amt.',l.PaidCumulative 'Paid Cumulative',l.Excess, " +
                "l.Remark,l.RepayTransactID,l.DatePosted 'Date Posted' from LoanRepayment l " +
                "left join Members m on l.MemberID=m.MemberID " +
                "where l.LoanID=" + loanID + " " +
                "order by l.LoanRepaymentID desc";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "LoanRepayment");
                DataTable dt = ds.Tables["LoanRepayment"];
                dtGrdVwRepayment.DataSource = dt;

                dtGrdVwRepayment.Columns["LoanRepaymentID"].Visible = false;
                dtGrdVwRepayment.Columns["FileNo"].Width = 80;
                dtGrdVwRepayment.Columns["Repayment Amt."].DefaultCellStyle.Format = "N2";
                dtGrdVwRepayment.Columns["Repayment Amt."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dtGrdVwRepayment.Columns["Paid Amt"].DefaultCellStyle.Format = "N2";
                dtGrdVwRepayment.Columns["Paid Amt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dtGrdVwRepayment.Columns["Outstanding Amt."].DefaultCellStyle.Format = "N2";
                dtGrdVwRepayment.Columns["Outstanding Amt."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                dtGrdVwRepayment.Columns["Paid Cumulative"].DefaultCellStyle.Format = "N2";
                dtGrdVwRepayment.Columns["Paid Cumulative"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                
                dtGrdVwRepayment.Columns["Excess"].DefaultCellStyle.Format = "N2";
                dtGrdVwRepayment.Columns["Excess"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                lblRecNo.Text = "No.of Records: " + dt.Rows.Count.ToString();
                
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
