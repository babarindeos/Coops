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
    public partial class CreateSavingsType : Form
    {
        public CreateSavingsType()
        {
            InitializeComponent();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty)
            {
                addType();
                loadSavingsRecords();
                
                
            }
            else
            {
                MessageBox.Show("Savings Type require a Name", "Add Savings Type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void addType()
        {
            string typeName = txtName.Text.Trim();
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Insert into SavingsType(SavingsName,Description)values(@SavingsName,@Description)";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            cmd.Parameters.Add("@SavingsName",SqlDbType.NVarChar,50,"SavingsName");
            cmd.Parameters["@SavingsName"].Value = txtName.Text.Trim();

            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 200, "Description");
            cmd.Parameters["@Description"].Value = txtDescription.Text.Trim();

            
            try
            {
                conn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    MessageBox.Show("Savings Type '" + typeName + "' has been successfully created", "Create Savings Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Dispose();
                conn.Close();
            }

        }

        private void CreateSavingsType_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'fUNAAB_CTCS.Banks' table. You can move, or remove it, as needed.

            loadSavingsRecords();
        }

        private void loadSavingsRecords()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select SavingsName,Description from SavingsType";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "SavingsType");
                conn.Close();

                DataTable dt = ds.Tables["SavingsType"];
                grdSavingsType.DataSource = dt;
                grdSavingsType.Columns[0].HeaderText = "Savings Name";



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
    }
}
