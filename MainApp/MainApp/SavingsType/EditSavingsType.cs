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
    public partial class EditSavingsType : Form
    {
        Hashtable savings;

        public EditSavingsType()
        {
            InitializeComponent();
        }

        private void EditSavingsType_Load(object sender, EventArgs e)
        {
            loadSavingsType();
        }

        private void loadSavingsType()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select SavingsName, Description from SavingsType";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                savings = new Hashtable();
                lstSavings.Items.Clear();
                int countRecords = 0;
                while (reader.Read())
                {
                    lstSavings.Items.Add(reader["SavingsName"].ToString());
                    savings.Add(reader["SavingsName"].ToString(), reader["Description"].ToString());
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


        private void lstSavings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSavings.SelectedIndex != -1)
            {
                txtName.Text = lstSavings.SelectedItem.ToString();
                txtDescription.Text = savings[lstSavings.SelectedItem].ToString();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstSavings.SelectedIndex != -1)
            {
                if (txtName.Text != string.Empty)
                {
                    performEditFunc();
                }
                else
                {
                    MessageBox.Show("Savings Type Name is required!", "Edit Savings Type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Select Savings Item to Effect an Edit", "Edit Savings Type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void performEditFunc()
        {
            string selSavings = lstSavings.SelectedItem.ToString();
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Update SavingsType set SavingsName=@Name, Description=@Description where SavingsName=@selSavings";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "SavingsName");
            cmd.Parameters["@Name"].Value = txtName.Text.Trim();

            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 200, "Description");
            cmd.Parameters["@Description"].Value = txtDescription.Text.Trim();

            cmd.Parameters.Add("@selSavings", SqlDbType.NVarChar, 50);
            cmd.Parameters["@selsavings"].Value = selSavings;

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected>0)
                {
                    MessageBox.Show("Savings Item '" + selSavings + "' has been successfully updated", "Edit Savings Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnCancel_Click(null,null);
                    
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtDescription.Clear();
            loadSavingsType();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            loadSavingsType();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select SavingsName, Description from SavingsType where SavingsName LIKE '%" + txtSearch.Text + "%'";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                lstSavings.Items.Clear();
                savings = new Hashtable();
                int countRecords = 0;
                while (reader.Read())
                {
                    lstSavings.Items.Add(reader["SavingsName"].ToString());
                    savings.Add(reader["SavingsName"].ToString(), reader["Description"].ToString());
                    countRecords++;
                }
                lblRecord.Text = "No. of Records: " + countRecords;
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
