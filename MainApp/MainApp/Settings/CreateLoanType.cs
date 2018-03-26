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
    public partial class CreateLoanType : Form
    {
        public CreateLoanType()
        {
            InitializeComponent();
        }

        private void CreateLoanType_Load(object sender, EventArgs e)
        {
            loadLoanCategory();
            loadCreatedLoanTypes();
        }

        private void loadLoanCategory()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "select LoanCategoryID, Name, Description, DateCreated as [Date Created] from LoanCategory";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "LoanCategory");
                DataTable dt = ds.Tables["LoanCategory"];

                
                cboCategory.DisplayMember = "Name";
                cboCategory.ValueMember = "LoanCategoryID";

                DataRow row = dt.NewRow();
                row["Name"] = "-- Select a Loan Category --";
                dt.Rows.InsertAt(row, 0);
                cboCategory.DataSource = dt;


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

        private void loadCreatedLoanTypes()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select c.Name as [Loan Category], t.Type, t.Duration as [Duration (Months)], t.InterestRate as [Interest Rate (%)], t.Description,t.DateCreated as [Date Created] " +
                "from LoanType t left join LoanCategory c on c.LoanCategoryID=t.LoanCategoryID";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "LoanType");
                DataTable dt = ds.Tables["LoanType"];
                grdLoanType.DataSource = dt;
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

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtType.Text != string.Empty)
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
            //MessageBox.Show(cboCategory.SelectedValue.ToString());
            if (cboCategory.SelectedValue.ToString() != string.Empty)
            {
                SqlConnection conn = ConnectDB.GetConnection();
                string strQuery = "Insert into LoanType(LoanCategoryID,Type,Duration,InterestRate,Description)values(@LoanCategoryID,@Type,@Duration,@InterestRate,@Description)";
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                
                cmd.Parameters.Add("@LoanCategoryID", SqlDbType.Int);
                cmd.Parameters["@LoanCategoryID"].Value = cboCategory.SelectedValue;

                cmd.Parameters.Add("@Type", SqlDbType.NVarChar,50);
                cmd.Parameters["@Type"].Value = txtType.Text.Trim();

                cmd.Parameters.Add("@Duration", SqlDbType.NVarChar, 50);
                cmd.Parameters["@Duration"].Value = numDuration.Value;

                cmd.Parameters.Add("@InterestRate", SqlDbType.Decimal);
                cmd.Parameters["@InterestRate"].Value = numInterestRate.Value;

                cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 200);
                cmd.Parameters["@Description"].Value = txtDescription.Text.Trim();

                try
                {
                    conn.Open();
                    int rowsAffected = 0;
                    rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Loan Type [" + txtType.Text + "] has been successfully created.", "Loan Type", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clearFields();
                        loadCreatedLoanTypes();
                    }
                    else
                    {
                        MessageBox.Show("Sorry, an error has occurred", "Loan Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            else
            {
                MessageBox.Show("Sorry, Please select a Loan Category to proceed", "Loan Type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void clearFields()
        {
            cboCategory.SelectedIndex = 0;
            txtType.Text = string.Empty;
            numDuration.Value = 1;
            numInterestRate.Value = 0;
            txtDescription.Text = string.Empty;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
