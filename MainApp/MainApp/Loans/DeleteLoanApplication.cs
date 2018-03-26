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
    public partial class DeleteLoanApplication : Form
    {
        string strFilterMonth = string.Empty;
        string strFilterYear = string.Empty;
        DataTable dt;

        public DeleteLoanApplication()
        {
            InitializeComponent();
        }

        private void DeleteLoanApplication_Load(object sender, EventArgs e)
        {
            loadAllLoanApplicationRecords(strFilterMonth,strFilterYear);
                        
        }

        private void loadAllLoanApplicationRecords(string strFilterMonth, string strFilterYear)
        {
            string strWhereClause = string.Empty;
            if (strFilterMonth == "0")
            {
                strFilterMonth = string.Empty;
            }
            if (strFilterMonth != string.Empty && strFilterYear == string.Empty)
            {
                strWhereClause = "where a.AppMonth like '" + strFilterMonth + "'";
            }
            else if (strFilterMonth == string.Empty && strFilterYear != string.Empty)
            {
                strWhereClause = "where a.AppYear like '" + strFilterYear + "'";
            }
            else if (strFilterMonth != string.Empty && strFilterYear != string.Empty)
            {
                strWhereClause = "where a.AppMonth like '" + strFilterMonth + "' and a.AppYear like '" + strFilterYear + "'";
            }

            //MessageBox.Show(strWhereClause.ToString());
            

            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select a.LoanApplicationID as ID, c.Month, a.AppYear as Year,  m.LastName + ' ' + m.FirstName + ' ' + m.MiddleName as 'Full Name', " +
            "lc.Name as Category, lt.Type as Type, a.LoanAmount as Amount, a.InterestRate 'Interest Rate (%)', a.InterestAmount 'Interest Amount', a.TotalRepayment 'Total Repayment', " +
            "a.MonthlyRepayment 'Monthly Repayment', a.LoanDuration 'Loan Duration (Mnths)', sr.Month as 'Start Repay Month',a.StartRepaymentYear as 'Start Repay Year.', " +
            "s1.LastName + ' ' + s1.FirstName + ' ' + s1.MiddleName as 'Surety1', " +
            "s2.LastName + ' ' + s2.FirstName + ' ' + s2.MiddleName as 'Surety2', " +
            "s3.LastName + ' ' + s3.FirstName + ' ' + s3.MiddleName as Witness, " +
            "a.NonMemberSurety1 as 'Non-Member Surety1', a.NonMemberSurety2 as 'Non-Member Surety2', " +
            "a.NonMemberWitness as 'Non-Member Witness', " +
            "a.ApprovalStatus 'Approval Status', a.TransactionID, a.DatePosted 'Date Posted' " +
            "from LoanApplication a left join Members m on a.MemberID = m.MemberID " +
            "left join MonthByName c on a.AppMonth= c.MonthID " +
            "left join MonthByName sr on a.StartRepaymentMonth = sr.MonthID " +
            "left join LoanCategory lc on lc.LoanCategoryID = a.LoanCategoryID " +
            "left join LoanType lt on lt.LoanTypeID = a.LoanTypeID " +
            "left join Members s1 on s1.MemberID=a.SuretyMemberID1 " +
            "left join Members s2 on s2.MemberID=a.SuretyMemberID2 " +
            "left join Members s3 on s3.MemberID=a.WitnessMemberID " + strWhereClause +            
            "order by a.LoanApplicationID desc";

            string strTotalFilteredRecords = "Select count(*) from LoanApplication a " + strWhereClause;

            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "LoanApplications");
                dt = ds.Tables["LoanApplications"];

                datGrdVwLoansApp.DataSource = dt;

                datGrdVwLoansApp.Columns["ID"].Visible = false;
                datGrdVwLoansApp.Columns["Full Name"].Width = 200;
                datGrdVwLoansApp.Columns["Month"].Width = 70;
                datGrdVwLoansApp.Columns["Year"].Width = 50;
                datGrdVwLoansApp.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdVwLoansApp.Columns["Interest Rate (%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdVwLoansApp.Columns["Interest Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdVwLoansApp.Columns["Total Repayment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdVwLoansApp.Columns["Monthly Repayment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdVwLoansApp.Columns["Amount"].DefaultCellStyle.Format = "N2";
                datGrdVwLoansApp.Columns["Interest Amount"].DefaultCellStyle.Format = "N2";
                datGrdVwLoansApp.Columns["Total Repayment"].DefaultCellStyle.Format = "N2";

                cmd = new SqlCommand(strTotalFilteredRecords, conn);
                int recordCount = Convert.ToInt32(cmd.ExecuteScalar());
                lblRecordNo.Text = "No. of Records: " + recordCount.ToString();
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

        private void btnFindRecord_Click(object sender, EventArgs e)
        {
            if (cboMonth.Text != string.Empty || cboYear.Text != string.Empty)
            {
                //MessageBox.Show(cboMonth.SelectedIndex.ToString());
                strFilterMonth = cboMonth.SelectedIndex.ToString();
                strFilterYear = cboYear.Text.ToString();
                //MessageBox.Show(cboYear.Text.ToString());

                loadAllLoanApplicationRecords(strFilterMonth, strFilterYear);
            }
            else
            {
                MessageBox.Show("Please Select Month and Year to Proceed with Search", "Find Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (datGrdVwLoansApp.SelectedCells.Count > 0)
            {
                int selectedRowIndex = datGrdVwLoansApp.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = datGrdVwLoansApp.Rows[selectedRowIndex];
                string applicationID = Convert.ToString(selectedRow.Cells["ID"].Value);
                string applicationStatus = Convert.ToString(selectedRow.Cells["Approval Status"].Value);

                //MessageBox.Show(applicationID + ' ' + applicationStatus);
                if (applicationStatus == string.Empty)
                {
                    DialogResult res = MessageBox.Show("Do you really wish to delete the Selected Record?","Loan Application",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        DeleteSelectedAppRecord(applicationID);
                    }
                }
                else
                {
                    MessageBox.Show("Selected Loan Application Record cannot be Deleted as it has been Treated and Archived", "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {

            }
        }
        
        private void DeleteSelectedAppRecord(string applicationID)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strDelete = "Delete from LoanApplication where LoanApplicationID=" + applicationID;
            SqlCommand cmd = new SqlCommand(strDelete, conn);

            try
            {
                conn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    //MessageBox.Show("The Selected Record has been Deleted", "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    strFilterMonth = string.Empty;
                    strFilterYear = string.Empty;
                    loadAllLoanApplicationRecords(strFilterMonth,strFilterYear);
                    string userId = this.MdiParent.Controls["lblLoggedInUserID"].Text;
                    ActivityLog.logActivity(userId, "Delete Loan Application", "Loan Application with ID - " + applicationID + " was deleted.");
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExportData exportSavingsDetails = new ExportData();
            exportSavingsDetails.ExportToExcel(dt, saveFD);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            strFilterMonth = string.Empty;
            strFilterYear = string.Empty;
            loadAllLoanApplicationRecords(strFilterMonth, strFilterYear);
        }
    }
}
