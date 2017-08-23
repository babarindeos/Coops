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
    public partial class ViewDepartments : Form
    {
        public ViewDepartments()
        {
            InitializeComponent();
        }

        private void ViewDepartments_Load(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectDB.GetConnection();

            string strSelectDept = "Select DepartmentName, Description from Departments";
            SqlCommand cmdDept = new SqlCommand(strSelectDept, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmdDept);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Departments");
                DataTable dt = ds.Tables["Departments"];

                dtGrdDept.DataSource = dt;
                lblTotalRecord.Text =  "No. of Records: " + dt.Rows.Count;

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

        private void txtSearch_KeyUp(object sender, EventArgs e)
        {
            
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string searchDeptByName = txtSearch.Text;

            if (searchDeptByName != string.Empty)
            {
                string strQuery = "Select DepartmentName,Description from Departments where DepartmentName LIKE '%" + searchDeptByName + "%'";
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                try
                {
                    conn.Open();
                    da.Fill(ds, "Departments");
                    conn.Close();
                    DataTable dt = ds.Tables["Departments"];
                    dtGrdDept.DataSource = dt;
                    dtGrdDept.Update();
                    dtGrdDept.Refresh();


                    lblTotalRecord.Text = "No. of Records: " + dt.Rows.Count;
                   


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
                MessageBox.Show("Department Name is required", "Search Department", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            ViewDepartments_Load(sender,e);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
