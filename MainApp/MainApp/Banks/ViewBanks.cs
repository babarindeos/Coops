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
    public partial class ViewBanks : Form
    {
        public ViewBanks()
        {
            InitializeComponent();
        }

        private void ViewBanks_Load(object sender, EventArgs e)
        {
            //LV properties
            lstBanks.View = View.Details;
            lstBanks.FullRowSelect = true;

            //column width
            lstBanks.Columns.Add("Bank", 300);
            lstBanks.Columns.Add("Description", 500);

            loadBankList();
        }

        private void loadBankList()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "select BankName, Description from Banks";
            SqlCommand cmd = new SqlCommand(strQuery,conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                lstBanks.Items.Clear();
                int countRecord = 0;
                while(reader.Read())
                {
                    string[] row = { reader["BankName"].ToString(), reader["Description"].ToString() };
                    ListViewItem item = new ListViewItem(row);
                    lstBanks.Items.Add(item);
                    countRecord++;

                }
                lblRecord.Text = "No.of Records: " + countRecord;
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select BankName,Description from Banks where BankName LIKE '%" + txtSearch.Text + "%'";
            SqlCommand cmd = new SqlCommand(strQuery,conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                lstBanks.Items.Clear();
                int countRecord = 0;
                while (reader.Read())
                {
                    string[] row = { reader["BankName"].ToString(), reader["Description"].ToString() };
                    ListViewItem item = new ListViewItem(row);
                    lstBanks.Items.Add(item);
                    countRecord++;
                }
                lblRecord.Text = "No.of Records: " + countRecord;
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
            loadBankList();
        }
    }
}
