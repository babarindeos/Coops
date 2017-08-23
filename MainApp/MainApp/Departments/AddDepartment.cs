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
    public partial class AddDepartment : Form
    {
        

        public AddDepartment()
        {
            InitializeComponent();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AddDepartment_Load(object sender, EventArgs e)
        {
            loadDepartments();
        }


        public void loadDepartments()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string selectDept = "Select DepartmentID, DepartmentName,Description from Departments";
            SqlCommand cmd = new SqlCommand(selectDept, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            
            try
            {
                conn.Open();
                da.Fill(ds, "Departments");
                

                DataTable dt = ds.Tables["Departments"];
                dtGrdDepartment.DataSource = dt;
                dtGrdDepartment.Columns["DepartmentID"].Visible = false;
                dtGrdDepartment.Columns[1].HeaderText = "Department Name";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " From Load Departments Function");
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //check if Department Name has been supplied into the Department Field
            if (txtDepartmentName.Text == string.Empty)
            {
                MessageBox.Show("Department Name is required","Add Department Info",MessageBoxButtons.OK,MessageBoxIcon.Warning);

            }
            else
            {
               string departmentName = txtDepartmentName.Text;
               string description = txtDescription.Text;
               
                //check if department name has been already supplied
                bool deptAlreadyExist = checkDeptExist(departmentName);

                if (deptAlreadyExist == false)
                {
                    SqlConnection conn = ConnectDB.GetConnection();
                    string strInsert = "Insert into Departments(DepartmentName,Description)values(@DepartmentName,@Description)";
                    SqlCommand cmdInsert = new SqlCommand(strInsert, conn);
                    cmdInsert.Parameters.Add("@DepartmentName", SqlDbType.NVarChar, 100);
                    cmdInsert.Parameters["@DepartmentName"].Value = departmentName;

                    cmdInsert.Parameters.Add("@Description", SqlDbType.NVarChar, 200);
                    cmdInsert.Parameters["@Description"].Value = description;

                    try
                    {
                        conn.Open();
                        int rowsAffected = cmdInsert.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            this.loadDepartments();
                            this.dtGrdDepartment.Update();
                            MessageBox.Show("The Department '" + departmentName + "' has been added", "Add Department", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDepartmentName.Clear();

                        }
                        else
                        {
                            MessageBox.Show("An error has occured!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + " Button Add click function... ");
                    }
                    finally
                    {
                        conn.Close();
                    }


                }
                else
                {
                    //Show Message that DepartmentName has already been added
                    MessageBox.Show("The Department '" + departmentName + "' has been created", "Department Creation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    
                }//end of if (deptAlreadyExist==false)


            }// end of if (txtDepartmentName.Text == string.Empty)
        }

        private bool checkDeptExist(string departmentName)
        {
            int deptAlreadyExist=0;
            SqlConnection conn = ConnectDB.GetConnection();
                        string checkDept = "Select count(*) from Departments where DepartmentName=@DepartmentName";
                        SqlCommand cmd = new SqlCommand(checkDept,conn);
                        cmd.Parameters.Add("@DepartmentName", SqlDbType.NVarChar,100);
                        cmd.Parameters["@DepartmentName"].Value = departmentName;
            try{
                conn.Open();
                deptAlreadyExist = Convert.ToInt16(cmd.ExecuteScalar().ToString());

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message + "from CheckDeptExist function");
            }finally{
                conn.Close();
            }

            if (deptAlreadyExist>0)
            {
                return true;
            }else{
                return false;
            }


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtDepartmentName.Clear();
            txtDescription.Clear();
        }
    }
}
