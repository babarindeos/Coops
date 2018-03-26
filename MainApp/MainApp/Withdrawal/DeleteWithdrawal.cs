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
    public partial class DeleteWithdrawal : Form
    {
        private string UserId;
        private string savingsID;
        private string savingsType;
        private string withdrawalAmt;
        private string fileNo_Surname;
        private string param_savingsType;

        public DeleteWithdrawal(string userId)
        {
            InitializeComponent();
            this.UserId = userId;
        }

        private void DeleteWithdrawal_Load(object sender, EventArgs e)
        {

            fileNo_Surname = string.Empty;
            param_savingsType = string.Empty;

            loadWithdrawals(fileNo_Surname,param_savingsType);
            BuildTempSavingsAcctType.Create();
            loadSavingsType();
            
        }

        private void loadSavingsType()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string sqlQuery = "Select SavingsTypeID,SavingsName from TempSavingsAcctType";
            SqlCommand cmd = new SqlCommand(sqlQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            try{
                conn.Open();
                da.Fill(ds, "TempSavingsAcctType");
                DataTable dt = ds.Tables["TempSavingsAcctType"];

                DataRow row = dt.NewRow();
                row["SavingsName"] = "";
                dt.Rows.InsertAt(row, 0);

                cboSavingsType.DisplayMember = "SavingsName";
                cboSavingsType.ValueMember = "SavingsTypeID";

                cboSavingsType.DataSource = dt;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally{
                conn.Close();
            }


        }


        private void loadWithdrawals(string fileNo_Surname, string param_savingsType)
        {
            SqlConnection conn = ConnectDB.GetConnection();

            string strQuery = null;
            

            if (fileNo_Surname == string.Empty && param_savingsType == string.Empty)
            {
                strQuery = "Select sw.SavingsWithdrawalID 'ID',sw.SavingsID, m.FileNo 'File No.', m.LastName + ' ' + m.MiddleName + ' ' + m.FirstName as 'Full Name', " +
                    "st.SavingsName 'Account Type', sw.Amount, sw.WithdrawAmount 'Withdrawal Amt.', sw.Balance, s.TransactionID 'Transaction ID', s.Date " +
                    "from SavingsWithdrawal sw left join Savings s on s.SavingsID=sw.SavingsID " +
                    "left join Members m on m.MemberID=s.MemberID " +
                    "left join TempSavingsAcctType st on st.SavingsTypeID =sw.SavingsTypeID " +
                    "order by sw.SavingsWithdrawalID desc";
            }
            else if (fileNo_Surname != string.Empty && param_savingsType == string.Empty)
            {
                strQuery = "Select sw.SavingsWithdrawalID 'ID',sw.SavingsID, m.FileNo 'File No.', m.LastName + ' ' + m.MiddleName + ' ' + m.FirstName as 'Full Name', " +
                    "st.SavingsName 'Account Type', sw.Amount, sw.WithdrawAmount 'Withdrawal Amt.', sw.Balance, s.TransactionID 'Transaction ID', s.Date " +
                    "from SavingsWithdrawal sw left join Savings s on s.SavingsID=sw.SavingsID " +
                    "left join Members m on m.MemberID=s.MemberID " +
                    "left join TempSavingsAcctType st on st.SavingsTypeID =sw.SavingsTypeID " +
                    "where m.FileNo LIKE '%" + fileNo_Surname + "%' OR m.LastName LIKE '%" + fileNo_Surname + "%' " +
                    "order by sw.SavingsWithdrawalID desc";
            }
            else if (fileNo_Surname == string.Empty && param_savingsType != string.Empty)
            {
                strQuery = "Select sw.SavingsWithdrawalID 'ID',sw.SavingsID, m.FileNo 'File No.', m.LastName + ' ' + m.MiddleName + ' ' + m.FirstName as 'Full Name', " +
                    "st.SavingsName 'Account Type', sw.Amount, sw.WithdrawAmount 'Withdrawal Amt.', sw.Balance, s.TransactionID 'Transaction ID', s.Date " +
                    "from SavingsWithdrawal sw left join Savings s on s.SavingsID=sw.SavingsID " +
                    "left join Members m on m.MemberID=s.MemberID " +
                    "left join TempSavingsAcctType st on st.SavingsTypeID =sw.SavingsTypeID " +
                    "where sw.SavingsTypeID=" + param_savingsType + " " +
                    "order by sw.SavingsWithdrawalID desc";
            }
            else if (fileNo_Surname != string.Empty && param_savingsType != string.Empty)
            {
                strQuery = "Select sw.SavingsWithdrawalID 'ID',sw.SavingsID, m.FileNo 'File No.', m.LastName + ' ' + m.MiddleName + ' ' + m.FirstName as 'Full Name', " +
                    "st.SavingsName 'Account Type', sw.Amount, sw.WithdrawAmount 'Withdrawal Amt.', sw.Balance, s.TransactionID 'Transaction ID', s.Date " +
                    "from SavingsWithdrawal sw left join Savings s on s.SavingsID=sw.SavingsID " +
                    "left join Members m on m.MemberID=s.MemberID " +
                    "left join TempSavingsAcctType st on st.SavingsTypeID =sw.SavingsTypeID " +
                    "where sw.SavingsTypeID=" + param_savingsType + " " +
                    "And m.FileNo LIKE '%" + fileNo_Surname + "%' OR m.LastName LIKE '%" + fileNo_Surname + "%' " +
                    "order by sw.SavingsWithdrawalID desc";
            }


            //MessageBox.Show(strQuery);

            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "SavingsWithdrawal");
                DataTable dt = ds.Tables["SavingsWithdrawal"];

                dtGrdVwWithdrawal.DataSource = dt;
                dtGrdVwWithdrawal.Columns["ID"].Width = 60;
                dtGrdVwWithdrawal.Columns["Full Name"].Width = 200;
                dtGrdVwWithdrawal.Columns["Account Type"].Width = 120;
                dtGrdVwWithdrawal.Columns["Transaction ID"].Width = 120;
                dtGrdVwWithdrawal.Columns["Withdrawal Amt."].Width = 120;
                dtGrdVwWithdrawal.Columns["Amount"].DefaultCellStyle.Format = "N2";
                dtGrdVwWithdrawal.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtGrdVwWithdrawal.Columns["Withdrawal Amt."].DefaultCellStyle.Format = "N2";
                dtGrdVwWithdrawal.Columns["Withdrawal Amt."].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtGrdVwWithdrawal.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtGrdVwWithdrawal.Columns["Balance"].DefaultCellStyle.Format = "N2";
                dtGrdVwWithdrawal.Columns["SavingsID"].Visible = false;

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dtGrdVwWithdrawal.SelectedRows.Count > 0)
            {
                savingsID = dtGrdVwWithdrawal.SelectedRows[0].Cells[1].Value.ToString();
                savingsType = dtGrdVwWithdrawal.SelectedRows[0].Cells[4].Value.ToString();
                withdrawalAmt = dtGrdVwWithdrawal.SelectedRows[0].Cells[6].Value.ToString();
                
                DialogResult res = MessageBox.Show("Do you wish to delete the selected record? savingsType ", "Withdrawal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    ExecuteDeleteOps(savingsID);
                }
            }
            else
            {
                MessageBox.Show("Select the Record you wish to Delete", "Withdrawal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecuteDeleteOps(string savingsID)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            try
            {
                conn.Open();
                SqlTransaction sqlTrans = conn.BeginTransaction();

                SqlCommand cmd = conn.CreateCommand();
                cmd.Transaction = sqlTrans;

                string strQuery1 = "Delete from SavingsWithdrawal where savingsID='" + savingsID + "'";
                string strQuery2 = "Delete from Savings where savingsID='" + savingsID + "'";

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery1;

                int rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    cmd.CommandText = strQuery2;
                    rowAffected = cmd.ExecuteNonQuery();
                    if (rowAffected > 0)
                    {
                        sqlTrans.Commit();
                        MessageBox.Show("The Selected Record has been deleted.", "Withdrawal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        string logMessage = "Withdrawal Record DELETED with Savings ID: " + savingsID + ", Savings Type: " + savingsType + ", Amount: " + withdrawalAmt;
                        ActivityLog.logActivity(UserId,"Withdrawal",logMessage);

                        DeleteWithdrawal deleteWithdrawal = new DeleteWithdrawal(UserId);
                        deleteWithdrawal.MdiParent = this.ParentForm;
                        deleteWithdrawal.Show();
                        this.Close();

                    }
                    else
                    {
                        sqlTrans.Rollback();
                        MessageBox.Show("An error occurred! Operation has been aborted.", "Withdrawal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    sqlTrans.Rollback();
                    MessageBox.Show("An error occurred! Operation has been aborted.", "Withdrawal", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void txtFileNo_Surname_Leave(object sender, EventArgs e)
        {
            if (txtFileNo_Surname.Text != string.Empty)
            {
                fileNo_Surname = txtFileNo_Surname.Text.Trim();
                loadWithdrawals(fileNo_Surname,param_savingsType);
            }
        }

        private void cboSavingsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSavingsType.SelectedIndex != 0)
            {
                param_savingsType = cboSavingsType.SelectedValue.ToString();
                loadWithdrawals(fileNo_Surname, param_savingsType);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            fileNo_Surname = string.Empty;
            param_savingsType = string.Empty;

            if (txtFileNo_Surname.Text != string.Empty)
            {
                fileNo_Surname = txtFileNo_Surname.Text.Trim();
            }

            if (cboSavingsType.SelectedIndex != 0)
            {
                param_savingsType = cboSavingsType.SelectedValue.ToString();
            }

            if (fileNo_Surname != string.Empty || param_savingsType != string.Empty)
            {
                loadWithdrawals(fileNo_Surname, param_savingsType);
            }
        }


        
    }
}
