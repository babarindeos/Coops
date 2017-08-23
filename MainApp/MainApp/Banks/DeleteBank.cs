using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;

namespace MainApp
{
    public partial class DeleteBank : Form
    {

       
        public DeleteBank()
        {
            InitializeComponent();
        }

        private void DeleteBank_Load(object sender, EventArgs e)
        {
            //LV properties
            lstBank.View = View.Details;
            lstBank.FullRowSelect = true;

            //LV Column Name
            lstBank.Columns.Add("Bank", 400);

            loadBank();

        }


        #region Load Bank
        private void loadBank()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select BankName from Banks";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int countRecord = 0;
                lstBank.Items.Clear();
                while (reader.Read())
                {
                    string[] row = { reader["BankName"].ToString() };
                    ListViewItem item = new ListViewItem(row);
                    lstBank.Items.Add(item);
                    countRecord++;
                }
                lblRecord.Text = "No. of Records: " + countRecord.ToString();

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
        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != string.Empty)
            {
                searchBank();
            }
            else
            {
                MessageBox.Show("Bank Name is required to make a search", "Bank Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        #region Search Bank
        private void searchBank()
        {
            string bankName = txtSearch.Text.Trim();
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select BankName from Banks where BankName LIKE '%" + bankName + "%'";
            SqlCommand cmd = new SqlCommand(strQuery,conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int countRecords = 0;
                lstBank.Items.Clear();
                while(reader.Read())
                {
                    string[] row = {reader["BankName"].ToString()};
                    ListViewItem item = new ListViewItem(row);
                    lstBank.Items.Add(item);
                    countRecords++;
                }
                lblRecord.Text = "No. of Records: " + countRecords;
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
        #endregion

        private void btnAll_Click(object sender, EventArgs e)
        {
            loadBank();
        }

        private void btnDeleteBank_Click(object sender, EventArgs e)
        {
            if (lstBank.SelectedItems.Count != 0)
            {
                DialogResult result = MessageBox.Show("Do you wish to Delete '" + lstBank.SelectedItems[0].SubItems[0].Text + "'?","Delete Bank",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    deleteBank();
                }
                else
                {
                    loadBank();
                }
            }
            else
            {
                MessageBox.Show("No Bank has been selected for Deletion","Delete Bank",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        #region Delete Bank
        private void deleteBank()
        {

            string bankName = lstBank.SelectedItems[0].SubItems[0].Text.Trim();

            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Delete from Banks where BankName='" + bankName + "'";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            try
            {
                conn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    MessageBox.Show("The Bank '" + bankName + "' has been successfully deleted.", "Delete Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadBank();
                }
                else
                {
                    MessageBox.Show("An error has occurred deleting '" +  bankName + "'", "Delete Bank", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        #endregion

    }
}
