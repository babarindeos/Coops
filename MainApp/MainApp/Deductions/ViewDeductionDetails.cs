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
    public partial class ViewDeductionDetails : Form
    {
        string selDeductionId;

        public ViewDeductionDetails(string selectedDeductionID)
        {
            InitializeComponent();
            this.selDeductionId = selectedDeductionID;
        }

        private void ViewDeductionDetails_Load(object sender, EventArgs e)
        {
            getDeductions();
            getDeductionDetails();
        }

        private void getDeductions()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select m.MemberID, m.FileNo, m.LastName + ' ' + m.FirstName  as 'Full Name'," +
                   "Mon.Month, d.Year, d.Savings, d.Loans, d.Total, d.TransactionID, d.DatePosted 'Date Posted', d.DeductionID from Deductions d " +
                   "inner join Members m on d.MemberID=m.MemberID " +
                   "inner join MonthByName Mon on Mon.MonthID=d.Month " +
                   "where d.DeductionID='" + selDeductionId + "'";

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Deductions");
                DataTable dt = ds.Tables["Deductions"];

                dtGrdDeductions.DataSource = dt;
                dtGrdDeductions.Columns[0].Visible = false;
                dtGrdDeductions.Columns[1].HeaderText = "File No.";
                dtGrdDeductions.Columns["Full Name"].Width = 200;
                dtGrdDeductions.Columns["Savings"].DefaultCellStyle.Format = "N2";
                dtGrdDeductions.Columns["Loans"].DefaultCellStyle.Format = "N2";
                dtGrdDeductions.Columns["Total"].DefaultCellStyle.Format = "N2";
                dtGrdDeductions.Columns["Savings"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtGrdDeductions.Columns["Loans"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtGrdDeductions.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtGrdDeductions.Columns["DeductionID"].Visible = false;
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

        private void getDeductionDetails()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select DeductionType, Amount, TransactionID, DatePosted 'Date Posted' from DeductionDetails " +
                 "where DeductionID='" + selDeductionId + "'";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "DeductionDetails");
                DataTable dt = ds.Tables["DeductionDetails"];

                dtGrdDedDetails.DataSource = dt;
                dtGrdDedDetails.Columns["Amount"].DefaultCellStyle.Format = "N2";
                dtGrdDedDetails.Columns["DeductionType"].Width = 200;
                dtGrdDedDetails.Columns["TransactionID"].Width = 150;
                dtGrdDedDetails.Columns["TransactionID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtGrdDedDetails.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtGrdDedDetails.Columns["Date Posted"].Width = 200;
                

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
