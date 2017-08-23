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
    public partial class EditBank : Form
    {

        Hashtable banks;

        public EditBank()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void EditBank_Load(object sender, EventArgs e)
        {
            //LV properties
            lstBank.View = View.Details;
            lstBank.FullRowSelect = true;

            //column name
            lstBank.Columns.Add("Banks", 450);
            

            loadBanks();
        }


        #region Load Banks into ListView
        private void loadBanks()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select BankName, Description from Banks";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            try
            {
                conn.Open();
                banks = new Hashtable();
                SqlDataReader reader = cmd.ExecuteReader();
                lstBank.Items.Clear();

                int countRecords = 0;
                while (reader.Read())
                {
                    banks.Add(reader["BankName"].ToString(), reader["Description"].ToString());
                    lstBank.Items.Add(reader["BankName"].ToString());
                    countRecords++;
                }

                lblRecordNo.Text = "No. of Records: " + countRecords;
                             
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

        private void lstBank_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstBank.SelectedItems.Count != 0)
            {
               
                string BankName =  lstBank.SelectedItems[0].SubItems[0].Text;
                txtName.Text = BankName;
                txtDescription.Text = banks[BankName].ToString();
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstBank.SelectedItems.Count == 0)
            {
                MessageBox.Show("No Bank Information has been selected for Update","Edit Bank",MessageBoxButtons.OK,MessageBoxIcon.Error);
                
            }
            else
            {
                string selectedBank = lstBank.SelectedItems[0].SubItems[0].Text;
                if (txtName.Text == string.Empty)
                {
                    MessageBox.Show("Bank Name is required to edit '" + selectedBank + "' Information", "Edit Bank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    updateBankInfo(selectedBank);
                }
            }
        }


        private void updateBankInfo(string selectedBank)
        {
            string selBank = selectedBank;

            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Update Banks set BankName=@BankName,Description=@Description where BankName=@selBank";
            SqlCommand cmd = new SqlCommand(strQuery,conn);

            cmd.Parameters.Add("@BankName", SqlDbType.NVarChar, 50);
            cmd.Parameters["@BankName"].Value = txtName.Text.Trim();

            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 200);
            cmd.Parameters["@Description"].Value = txtDescription.Text.Trim();

            cmd.Parameters.Add("@selBank", SqlDbType.NVarChar, 50);
            cmd.Parameters["@selBank"].Value = selBank;

            try
            {
                conn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected>0)
                {
                    MessageBox.Show("The Bank '" + selBank + "' has been edited and updated!", "Edit Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadBanks();
                }
                else
                {
                    MessageBox.Show("An error has occurred updating '" + selBank + "'", "Edit Bank", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                txtName.Clear();
                txtDescription.Clear();

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtDescription.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select BankName, Description from Banks where BankName LIKE '%" + txtSearch.Text + "%'";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                banks = new Hashtable();
                int countRecords = 0;
                lstBank.Items.Clear();
                while (reader.Read())
                {
                    banks.Add(reader["BankName"].ToString(), reader["Description"].ToString());
                    string[] row = { reader["BankName"].ToString() };
                    ListViewItem item = new ListViewItem(row);
                    lstBank.Items.Add(item);                                   
                    countRecords++;
                }
                lblRecordNo.Text = "No. of Records: " + countRecords;

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

        private void btnAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            loadBanks();
        }



    }
}
