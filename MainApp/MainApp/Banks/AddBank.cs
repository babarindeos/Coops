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
    public partial class AddBank : Form
    {
        public AddBank()
        {
            InitializeComponent();
        }

        private void AddBank_Load(object sender, EventArgs e)
        {
            //LV properties
            lstBank.View = View.Details;
            lstBank.FullRowSelect = true;

            //construct column
            lstBank.Columns.Add("Bank", 250);
            lstBank.Columns.Add("Description", 350);

            loadBankList();
        }

        private void loadBankList()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select BankName, Description from Banks";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                lstBank.Items.Clear();

                while (reader.Read())
                {
                    string[] row = { reader["BankName"].ToString(), reader["Description"].ToString() };
                    ListViewItem item = new ListViewItem(row);
                    lstBank.Items.Add(item);

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


        #region Bank Name Already Exist Procedure
        private bool bankNameAlreadyExist()
        {
            int rowsCount=0;
            SqlConnection conn = ConnectDB.GetConnection();
            string bankName = txtName.Text;
            bankName = bankName.Trim();
            string strQuery = "Select count(*) from Banks where BankName='" + bankName + "'";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            try
            {
                conn.Open();
                rowsCount = (int) cmd.ExecuteScalar();
                
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            if (rowsCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        #endregion 

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty)
            {
                if (bankNameAlreadyExist())
                {
                    MessageBox.Show("Bank Name '" + txtName.Text + "'  already exist");
                    
                    
                }
                else
                {
                    
                    addBankProc();
                    loadBankList();
                }
            }
            else
            {
                MessageBox.Show("Bank Name is required to Add a Bank!", "Add Bank", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }//end of txtName.Text!=string.Empty
        }


        #region Add Bank Procedure
        private void addBankProc()
        {
            string BankName = txtName.Text;
            string Description = txtDescription.Text;

            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Insert into Banks(BankName,Description)values(@BankName,@Description)";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            cmd.Parameters.Add("@BankName", SqlDbType.NVarChar, 50);
            cmd.Parameters["@BankName"].Value = BankName;

            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 200);
            cmd.Parameters["@Description"].Value = Description;

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Bank '" + BankName + "' has been successfully added", "Add Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("An error occurred adding Bank", "Add Bank", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        }//end of addBankProc
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtDescription.Clear();
            loadBankList();
            txtName.Focus();
        }
      

    }


}
