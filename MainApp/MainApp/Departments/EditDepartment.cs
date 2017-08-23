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
    public partial class EditDepartment : Form
    {
        private string originalDeptName;
        private Hashtable deptDetails;

        public EditDepartment()
        {
            InitializeComponent();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void grpEditDepartment_Enter(object sender, EventArgs e)
        {

        }

        private void EditDepartment_Load(object sender, EventArgs e)
        {
            loadDepartments();
        }

        //load Departments
        private void loadDepartments()
        {
            deptDetails = new Hashtable();
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select DepartmentName, Description from Departments";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int countRecords = 0;
                lstDepartments.Items.Clear();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        deptDetails.Add(reader["DepartmentName"].ToString(), reader["Description"].ToString());
                        lstDepartments.Items.Add(reader["DepartmentName"].ToString());
                        countRecords++;
                    }
                }
                lblRecordNumber.Text = "No of Records: " + countRecords;

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
        //End of Load Departments

        

        private void selectDept()
        {
            
            originalDeptName = lstDepartments.SelectedItem.ToString();
            txtDepartmentName.Text = originalDeptName;
            txtDescription.Text = deptDetails[originalDeptName].ToString();

            
        }

        private void lstDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectDept();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtSearch.Text != string.Empty)
            {
                SqlConnection conn = ConnectDB.GetConnection();
                string strQuery = "Select DepartmentName, Description from  Departments where DepartmentName LIKE '%" + txtSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(strQuery, conn);

                try
                {
                    conn.Open();
                    lstDepartments.Items.Clear();
                    deptDetails = new Hashtable();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int countRecords = 0;

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            deptDetails.Add(reader["DepartmentName"].ToString(), reader["Description"].ToString());
                            lstDepartments.Items.Add(reader["DepartmentName"].ToString());
                            countRecords++;
                        }
                    }

                    lblRecordNumber.Text = "No of Records: " + countRecords;
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
                lstDepartments.Items.Clear();
                loadDepartments();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtDepartmentName.Clear();
            txtDescription.Clear();
            txtSearch.Clear();
            lstDepartments.SelectedIndex = -1;
            loadDepartments();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstDepartments.SelectedIndex != -1)
            {

                if (txtDepartmentName.Text != string.Empty)
                {
                    SqlConnection conn = ConnectDB.GetConnection();
                    string strQuery = "Update Departments set DepartmentName=@DepartmentName, Description=@Description where DepartmentName='" + originalDeptName + "'";
                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    cmd.Parameters.Add("@DepartmentName", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@DepartmentName"].Value = txtDepartmentName.Text;

                    cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 200);
                    cmd.Parameters["@Description"].Value = txtDescription.Text;

                    try
                    {
                        conn.Open();
                        int rowAffected = cmd.ExecuteNonQuery();

                        if (rowAffected > 0)
                        {
                            MessageBox.Show("Record has been successfully updated!");
                            loadDepartments();

                        }
                        else
                        {
                            MessageBox.Show("An error has occurred updating department!", "Edit Department", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        txtDepartmentName.Clear();
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
                else
                {
                    MessageBox.Show("The Department Name is required","Edit Department",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Select a Department to make an Update", "Edit Department", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        


        
    }
}
