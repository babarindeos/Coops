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
using System.Collections;

namespace MainApp
{
    public partial class UnpostDeductions : Form
    {
        private string UserId;
        List<string> selDeductionIdDel;
        List<string> selDeductionTransactionDel;
        int selDeductionId;
        string selDedTransactionId;
        string selDelMonth;
        int selDelYear;

        public UnpostDeductions(string userId)
        {
            InitializeComponent();
            this.UserId = userId;
           
        }

        private void UnpostDeductions_Load(object sender, EventArgs e)
        {
            selDeductionTransactionDel = new List<string>();
            loadBulk();
            loadSingle();
        }

        private void loadBulk()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select d.DeductionDateID, m.Month, d.Year, d.DatePosted 'Date Posted' from DeductionDates d " +
                "left join MonthByName m on d.Month=m.MonthID " +
                "order by d.DeductionDateID desc";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "DeductionDates");
                DataTable dt = ds.Tables["DeductionDates"];

                dtGrdBulkDeductions.DataSource = dt;

                dtGrdBulkDeductions.Columns["DeductionDateID"].Visible = false;

                dtGrdBulkDeductions.Columns["Date Posted"].DefaultCellStyle.Format = "F";
                dtGrdBulkDeductions.Columns["Date Posted"].Width = 250;
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

        private void loadSingle()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select d.DeductionID 'ID', mn.Month, d.Year,m.MemberID, m.FileNo, m.LastName, m.FirstName, m.MiddleName, d.TransactionID, d.DatePosted 'Date Posted' from Deductions d " +
                "left join MonthByName mn on d.Month=mn.MonthID " +
                "left join Members m on m.MemberID = d.MemberID " +
                "order by d.DeductionID desc";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Deductions");
                DataTable dt = ds.Tables["Deductions"];
                dtGrdSingleDeductions.DataSource = dt;

                dtGrdSingleDeductions.Columns["MemberID"].Visible = false;
                dtGrdSingleDeductions.Columns["ID"].Width = 60;
                dtGrdSingleDeductions.Columns["Month"].Width = 70;
                dtGrdSingleDeductions.Columns["Year"].Width = 40;
                dtGrdSingleDeductions.Columns["FileNo"].Width = 60;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void dtGrdBulkDeductions_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void dtGrdBulkDeductions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGrdBulkDeductions.SelectedRows.Count > 0)
            {
                DateTime postedDate = Convert.ToDateTime(dtGrdBulkDeductions.SelectedRows[0].Cells[3].Value.ToString());
                DateTime today = DateTime.Now;
                int daysDiff = Convert.ToInt16((today - postedDate).TotalDays);
                if (daysDiff > 10)
                {
                    lblBulkStatus.Text = "Status: Posted " + daysDiff + " days ago";
                    btnBulkUnpost.Enabled = false;
                }
                else
                {
                    lblBulkStatus.Text = "Status: Posted " + daysDiff + " days ago";
                    btnBulkUnpost.Enabled = true;
                }
            }
        }

        private void btnBulkUnpost_Click(object sender, EventArgs e)
        {

            if (dtGrdBulkDeductions.SelectedRows.Count>0)
            {
                selDeductionId = Convert.ToInt16(dtGrdBulkDeductions.SelectedRows[0].Cells[0].Value.ToString());
                selDelMonth = dtGrdBulkDeductions.SelectedRows[0].Cells[1].Value.ToString();
                selDelYear = Convert.ToInt16(dtGrdBulkDeductions.SelectedRows[0].Cells[2].Value.ToString());
                //MessageBox.Show("ID: " + selDeductionId.ToString() + "Month: " + selDelMonth.ToString() + " Year: " + selDelYear.ToString());
            }
            else
            {
                MessageBox.Show("Choose a Deduction Record to Delete","Unpost Deduction",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult res = MessageBox.Show("Do you wish to Unpost the Selected Deduction?", "Unpost Deduction", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                SqlConnection conn = ConnectDB.GetConnection();
                SqlCommand cmd;
                

                try
                {
                    conn.Open();
                    SqlTransaction sqlTrans = conn.BeginTransaction();
                    cmd = conn.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = sqlTrans;
                    cmd.CommandText = "Select distinct d.TransactionID from Deductions d " +
                        "inner join MonthByName m on m.MonthID=d.Month " +
                        "where m.month='" + selDelMonth + "' And d.Year=" + selDelYear;

                    SqlDataReader reader = cmd.ExecuteReader();
                    selDeductionTransactionDel.Clear();
                    while (reader.Read())
                    {
                        selDeductionTransactionDel.Add(reader["TransactionID"].ToString());
                    }
                    reader.Close();

                    //MessageBox.Show(selDeductionTransactionDel.Count.ToString());

                    Cl_UnpostDeductions deletePosting = new Cl_UnpostDeductions();
                    string savingsDelStatus = deletePosting.unpostSavingsDeductions(conn, cmd, selDeductionTransactionDel);
                    string loanDelStatus = deletePosting.unpostLoansDeduction(conn, cmd, selDeductionTransactionDel);
                    string deductionDelStatus = deletePosting.unpostDeductions(conn, cmd, selDeductionTransactionDel, selDelMonth, selDelYear);
                    string deductionDetailsDelStatus = deletePosting.unpostDeductionDetails(conn, cmd, selDeductionTransactionDel);
                    string deductionDatesDelStatus = deletePosting.unpostDeductionDates(conn, cmd, selDelMonth, selDelYear); 
                    
                    //MessageBox.Show("Savings Status: " + savingsDelStatus + "\nLoans Status: " + loanDelStatus + "\nDeductions: " + deductionDelStatus + "\nDeduction Detials: " + deductionDetailsDelStatus);

                    if ((Convert.ToInt16(deductionDelStatus) != 0) && (Convert.ToInt16(deductionDetailsDelStatus) != 0) && (Convert.ToInt16(deductionDelStatus) != 0))
                    {
                        sqlTrans.Commit();
                        ActivityLog.logActivity(UserId, "Unpost Deduction - Bulk", "Unpost Deduction Record ID:" + selDeductionId + " for " + selDelMonth + " " + selDelYear);
                        MessageBox.Show("Selected record has been Successfully Deleted.", "Unpost Deduction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UnpostDeductions unpostDeductions = new UnpostDeductions(UserId);
                        unpostDeductions.MdiParent = this.ParentForm;
                        unpostDeductions.Show();
                        this.Close();
                    }
                    else
                    {
                        sqlTrans.Rollback();
                        MessageBox.Show("An error has occurred.", "Unpost Deduction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void dtGrdSingleDeductions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtGrdSingleDeductions.SelectedRows.Count > 0)
            {
                DateTime postedDate = Convert.ToDateTime(dtGrdSingleDeductions.SelectedRows[0].Cells[9].Value.ToString());
                DateTime today = DateTime.Now;
                int daysDiff = Convert.ToInt16((today - postedDate).TotalDays);
                if (daysDiff > 10)
                {
                    lblSingleStatus.Text = "Status: Posted " + daysDiff + " days ago";
                    btnSingleUnpost.Enabled = false;
                }
                else
                {
                    lblSingleStatus.Text = "Status: Posted " + daysDiff + " days ago";
                    btnSingleUnpost.Enabled = true;
                }

            }
        }

        private void btnSingleUnpost_Click(object sender, EventArgs e)
        {
            int memberID;
           
            if (dtGrdSingleDeductions.SelectedRows.Count > 0)
            {
                selDeductionId = Convert.ToInt16(dtGrdSingleDeductions.SelectedRows[0].Cells[0].Value.ToString());
                selDelMonth = dtGrdSingleDeductions.SelectedRows[0].Cells[1].Value.ToString();
                selDelYear = Convert.ToInt16(dtGrdSingleDeductions.SelectedRows[0].Cells[2].Value.ToString());
                memberID = Convert.ToInt16(dtGrdSingleDeductions.SelectedRows[0].Cells[3].Value.ToString());
                selDedTransactionId = dtGrdSingleDeductions.SelectedRows[0].Cells[8].Value.ToString();

                //MessageBox.Show("ID: " + selDeductionId.ToString() + "Month: " + selDelMonth.ToString() + " Year: " + selDelYear.ToString() + "MemberID: " + memberID.ToString() + "TransactionID: " + selDedTransactionId);
            }
            else
            {
                MessageBox.Show("Choose a Member Deduction Record to Delete", "Unpost Deduction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult res = MessageBox.Show("Do you wish to Unpost the Selected Record?", "Unpost", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                SqlConnection conn = ConnectDB.GetConnection();
                SqlCommand cmd = conn.CreateCommand();
                

                try
                {
                    conn.Open();
                    SqlTransaction sqlTrans = conn.BeginTransaction();
                    cmd.CommandType = CommandType.Text;
                    cmd.Transaction = sqlTrans;

                    Cl_UnpostDeductions deletePosting = new Cl_UnpostDeductions();
                    string savingsDelStatus = deletePosting.unpostSavingsDeductions(conn, cmd, memberID, selDedTransactionId);
                    string loanDelStatus = deletePosting.unpostLoansDeduction(conn, cmd, memberID, selDedTransactionId);
                    string deductionDelStatus = deletePosting.unpostDeductions(conn, cmd, memberID, selDedTransactionId, selDelMonth, selDelYear);
                    string deductionDetailsDelStatus = deletePosting.unpostDeductionDetails(conn, cmd, memberID, selDedTransactionId);

                    //MessageBox.Show("Savings Status: " + savingsDelStatus + "\nLoans Status: " + loanDelStatus + "\nDeductions: " + deductionDelStatus + "\nDeduction Detials: " + deductionDetailsDelStatus);

                    if ((Convert.ToInt16(savingsDelStatus) != 0) || (Convert.ToInt16(deductionDetailsDelStatus) != 0) || (Convert.ToInt16(deductionDelStatus) != 0))
                    {
                        sqlTrans.Commit();
                        ActivityLog.logActivity(UserId, "Unpost Deduction - Single", "Unpost Deduction for MemberID:" + memberID + " for " + selDelMonth + " " + selDelYear);
                        MessageBox.Show("Selected record has been Successfully Deleted.", "Unpost Deduction", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UnpostDeductions unpostDeductions = new UnpostDeductions(UserId);
                        unpostDeductions.MdiParent = this.ParentForm;
                        unpostDeductions.Show();
                        this.Close();
                    }
                    else
                    {
                        sqlTrans.Rollback();
                        MessageBox.Show("An error has occurred.", "Unpost Deduction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            SqlCommand cmd = conn.CreateCommand();
            string strQuery = "Select d.DeductionID 'ID', mn.Month, d.Year,m.MemberID, m.FileNo, m.LastName, m.FirstName, m.MiddleName, d.TransactionID, d.DatePosted 'Date Posted' from Deductions d " +
                "left join MonthByName mn on d.Month=mn.MonthID " +
                "left join Members m on m.MemberID = d.MemberID " +
                "where m.FileNo='" + txtSearch.Text.Trim() + "' OR LastName='" + txtSearch.Text.Trim() + "' " +
                "order by d.DeductionID desc";
            cmd.CommandText = strQuery;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Deductions");
                DataTable dt = ds.Tables["Deductions"];
                dtGrdSingleDeductions.DataSource = dt;

                dtGrdSingleDeductions.Columns["MemberID"].Visible = false;
                dtGrdSingleDeductions.Columns["ID"].Width = 60;
                dtGrdSingleDeductions.Columns["Month"].Width = 70;
                dtGrdSingleDeductions.Columns["Year"].Width = 40;
                dtGrdSingleDeductions.Columns["FileNo"].Width = 60;


            }
            catch(Exception ex)
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
