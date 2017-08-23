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
    public partial class DeleteDepartment : Form
    {

        Hashtable depts;

        public DeleteDepartment()
        {
            InitializeComponent();
        }

        private void DeleteDepartment_Load(object sender, EventArgs e)
        {
            loadDepartments();


        }

        private void loadDepartments()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select DepartmentName,Description from Departments";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            try
            {
                conn.Open();
                depts = new Hashtable();
                SqlDataReader reader = cmd.ExecuteReader();
                int countRecords = 0;
                lstDepartment.Items.Clear();
                while (reader.Read())
                {
                    depts.Add(reader["DepartmentName"].ToString(), reader["Description"].ToString());
                    lstDepartment.Items.Add(reader["DepartmentName"].ToString());
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

        private void lstDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtDescription.Text = depts[lstDepartment.SelectedItem].ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select DepartmentName, Description from Departments where DepartmentName LIKE '%" + txtSearch.Text + "%'";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            try
            {
                conn.Open();
                depts = new Hashtable();
                SqlDataReader reader = cmd.ExecuteReader();
                int countRecords = 0;
                lstDepartment.Items.Clear();
                while (reader.Read())
                {
                    depts.Add(reader["DepartmentName"].ToString(), reader["Description"].ToString());
                    lstDepartment.Items.Add(reader["DepartmentName"].ToString());
                    countRecords++;
                }

                lblRecord.Text = "No of Records: " + countRecords;
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

        private void DeleteDept()
        {
            string selectedDept = lstDepartment.SelectedItem.ToString();
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Delete from Departments where  DepartmentName='" + selectedDept + "'";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Department '" + selectedDept + "' has been successfully deleted ", "Delete Department", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDepartments();
                    txtDescription.Clear();
                    txtSearch.Clear();
                }
                else
                {
                    MessageBox.Show("An error has occurred trying to delete Department '" + selectedDept + "'!", "Delete Department", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnDeleteDepartment_Click(object sender, EventArgs e)
        {
            if (lstDepartment.SelectedIndex != -1)
            {
                DialogResult result = MessageBox.Show("Do you wish to delete Department '" + lstDepartment.SelectedItem + "' ? ", "Delete Department", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeleteDept();
                }
            }
            else
            {
                MessageBox.Show("No Department has been selected for Deletion","Delete Department",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            loadDepartments();
        }

        
    }
}
