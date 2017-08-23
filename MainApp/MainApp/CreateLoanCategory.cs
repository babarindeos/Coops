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
    public partial class CreateLoanCategory : Form
    {
        public CreateLoanCategory()
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
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Insert into LoanCategory(Name,Description)values(@Name,@Description)";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 100);
            cmd.Parameters["@Name"].Value = txtName.Text.Trim();

            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 200);
            cmd.Parameters["@Description"].Value = txtDescription.Text.Trim();

            try
            {
                conn.Open();
                int rowsAffected = 0;
                rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Category " + txtName.Text + " has been successfully created.", "Create Loan Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clearFields();
                    loadLoanCategories();
                }
                else
                {
                    MessageBox.Show("An error has occurred!", "Create Loan Category", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void clearFields()
        {
            txtName.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }

        private void CreateLoanCategory_Load(object sender, EventArgs e)
        {
            loadLoanCategories();
        }

        private void loadLoanCategories()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select Name, Description, DateCreated as [Date Created] from LoanCategory";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "LoanCategory");
                DataTable dt = ds.Tables["LoanCategory"];
                grdLoansCategory.DataSource = dt;
                lblRecord.Text = "No. of Records: " + dt.Rows.Count;
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
            clearFields();
        }
    }
}
