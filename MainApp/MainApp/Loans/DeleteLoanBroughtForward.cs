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
    public partial class DeleteLoanBroughtForward : Form
    {
        private string userId;
        private string strFilter;

        public DeleteLoanBroughtForward(string UserID)
        {
            this.userId = UserID;
            InitializeComponent();
        }

        private void DeleteLoanBroughtForward_Load(object sender, EventArgs e)
        {
            strFilter = string.Empty;
            loadLoansBroughtForward();

        }

        private void loadLoansBroughtForward()
        {
            SqlConnection conn = ConnectDB.GetConnection();

            string strQuery = string.Empty;
            if (strFilter == string.Empty)
            {
                strQuery = "Select l.LoansID,a.LoanApplicationID,m.FileNo,m.Title + ' ' + m.FirstName + ' ' + m.MiddleName + ' ' + m.LastName as 'Full Name'," +
                "a.LoanAmount 'Amount', l.RepaymentAmount 'Repayment Amt.',l.AmountPaid 'Amt. Paid', l.OutstandingAmount 'Outstanding Amt.',l.PaymentStatus 'Payment Status',l.PaymentFinished 'Payment Finished',l.DateFinishedPayment 'Finished Paying',l.TransactionID," +
                "l.DateCreated 'Date' from LoanApplication a " +
                "inner join Loans l on l.LoanApplicationID=a.LoanApplicationID " +
                "inner join Members m on a.MemberID=m.MemberID " +
                "where l.TransactionID LIKE '%LBF%' " +
                "order by l.LoansID desc";
            }
            else
            {
                strQuery = "Select l.LoansID,a.LoanApplicationID,m.FileNo,m.Title + ' ' + m.FirstName + ' ' + m.MiddleName + ' ' + m.LastName as 'Full Name'," +
                "a.LoanAmount 'Amount', l.RepaymentAmount 'Repayment Amt.',l.AmountPaid 'Amt. Paid', l.OutstandingAmount 'Outstanding Amt.',l.PaymentStatus 'Payment Status',l.PaymentFinished 'Payment Finished',l.DateFinishedPayment 'Finished Paying',l.TransactionID," +
                "l.DateCreated 'Date' from LoanApplication a " +
                "inner join Loans l on l.LoanApplicationID=a.LoanApplicationID " +
                "inner join Members m on a.MemberID=m.MemberID " +
                "where l.TransactionID LIKE '%LBF%' and m.FileNo='" + strFilter + "' " +
                "order by l.LoansID desc";
            }

            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            datGrdVwLoansForward.DataSource = null;
            datGrdVwLoansForward.Columns.Clear();
            datGrdVwLoansForward.Rows.Clear();
            datGrdVwLoansForward.Refresh();

            try
            {
                conn.Open();
                da.Fill(ds, "Loans");
                DataTable dt = ds.Tables["Loans"];
                datGrdVwLoansForward.DataSource = dt;

                lblRecordNo.Text = "No. of Record: " + dt.Rows.Count;

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
                btn.Text = "Delete";
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

        private void txtFileNo_TextChanged(object sender, EventArgs e)
        {
            if (txtFileNo.Text != string.Empty)
            {
                btnFileNoSearch.Enabled = true;
            }
            else
            {
                btnFileNoSearch.Enabled = false;
            }
        }

        private void btnFileNoSearch_Click(object sender, EventArgs e)
        {
            if (txtFileNo.Text != string.Empty)
            {
                strFilter = txtFileNo.Text.ToUpper();
                
                loadLoansBroughtForward();
                
            }

        }

        private void datGrdVwLoansForward_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(datGrdVwLoansForward.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
            MessageBox.Show(e.ColumnIndex.ToString());
        }
    }
}
