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
    public partial class EditMember : Form
    {
        //Declarations
        int memberID;
        string photoName = null;


        public EditMember()
        {
            InitializeComponent();
        }

        
        private void EditMember_Load(object sender, EventArgs e)
        {
            //Resize form height
            this.Height = 119;

            loadStateIntoComboBox();
            loadDeparmentsIntoComboBox();
            loadBanksIntoComboBox();
        }


        private void loadStateIntoComboBox()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select StateID, State from States order by State";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "States");
                DataTable dt = ds.Tables["States"];
                
                cbo_State.DisplayMember = "State";
                cbo_State.ValueMember = "StateID";

                cbo_State.DataSource = dt;
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

        private void loadDeparmentsIntoComboBox()
        {
            DataSet ds = Departments.GetDepartmentList();
            DataTable dt = ds.Tables["Departments"];
            cbo_department.DisplayMember = "DepartmentName";
            cbo_department.ValueMember = "DepartmentID";
            cbo_department.DataSource = dt;
        }

        private void loadBanksIntoComboBox()
        {
            DataSet ds = Banks.GetBanks();
            DataTable dt = ds.Tables["Banks"];
            cbo_Bank.DisplayMember = "BankName";
            cbo_Bank.ValueMember = "BankID";
            cbo_Bank.DataSource = dt;
        }


        private void btnFindMember_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select m.MemberID, m.FileNo, m.Title, m.FirstName, m.MiddleName, m.LastName, m.Gender, m.Address," +
                "m.LGA, m.StateID, s.State, m.Phone, m.Email, m.DepartmentID, d.DepartmentName, m.BankID, b.BankName, m.AccountNo, m.Photo,m.NOKFullName,m.NOKAddress," +
                "m.NOKPhone from Members m inner join States s on m.StateID = s.StateID " +
                "inner join Departments d on m.DepartmentID = d.DepartmentID " +
                "inner join Banks b on m.BankID = b.BankID " +
                "where m.FileNo='" + txtFindByFileNo.Text + "'";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    this.Height = 603;

                    memberID = (int) reader["MemberID"];
                    photoName = reader["Photo"].ToString();

                    txt_FileNo.Text = reader["FileNo"].ToString();
                    txt_Title.Text = reader["Title"].ToString();
                    txt_FirstName.Text = reader["FirstName"].ToString();
                    txt_MiddleName.Text = reader["MiddleName"].ToString();
                    txt_LastName.Text = reader["LastName"].ToString();
                    string gender = reader["Gender"].ToString();
                    if (gender == "M") { rad_Male.Checked = true; } else { rad_Female.Checked = true; }
                    txt_Address.Text = reader["Address"].ToString();
                    txt_LGA.Text = reader["LGA"].ToString();
                    cbo_State.SelectedValue =(int) reader["StateID"];
                    txt_Phone.Text = reader["Phone"].ToString();
                    txt_Email.Text = reader["Email"].ToString();
                    cbo_department.SelectedValue = (int) reader["DepartmentID"];
                    cbo_Bank.SelectedValue = (int)reader["BankID"];
                    txt_AccountNo.Text = reader["AccountNo"].ToString();
                    txt_NOKName.Text = reader["NOKFullName"].ToString();
                    txt_NOKAddress.Text = reader["NOKAddress"].ToString();
                    txt_NOKPhone.Text = reader["NOKPhone"].ToString();

                    if (reader["Photo"].ToString() != string.Empty)
                    {
                        //Load User picture
                        string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                        picMember.Image = Image.FromFile(paths + "\\photos\\" + reader["Photo"].ToString());
                    }

                    btnEnableEditing.Enabled = true;

                    
                }
                else
                {
                    MessageBox.Show("Sorry, there is no record with that File No.", "Record Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void cbo_State_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnEnableEditing_Click(object sender, EventArgs e)
        {
            txt_FileNo.ReadOnly = !(txt_FileNo.ReadOnly);
            txt_Title.ReadOnly = !(txt_Title.ReadOnly);
            txt_FirstName.ReadOnly = !(txt_FirstName.ReadOnly);
            txt_MiddleName.ReadOnly = !(txt_MiddleName.ReadOnly);
            txt_LastName.ReadOnly = !(txt_LastName.ReadOnly);
            rad_Male.Enabled = !(rad_Male.Enabled);
            rad_Female.Enabled = !(rad_Female.Enabled);
            txt_Address.ReadOnly = !(txt_Address.ReadOnly);
            txt_LGA.ReadOnly = !(txt_LGA.ReadOnly);
            cbo_State.Enabled = !(cbo_State.Enabled);
            txt_Phone.ReadOnly = !(txt_Phone.ReadOnly);
            txt_Email.ReadOnly = !(txt_Email.ReadOnly);
            cbo_department.Enabled = !(cbo_department.Enabled);
            cbo_Bank.Enabled = !(cbo_Bank.Enabled);
            txt_AccountNo.ReadOnly = !(txt_AccountNo.ReadOnly);
            txt_NOKName.ReadOnly = !(txt_NOKName.ReadOnly);
            txt_NOKAddress.ReadOnly = !(txt_NOKAddress.ReadOnly);
            txt_NOKPhone.ReadOnly = !(txt_NOKPhone.ReadOnly);
            btnLoadPic.Enabled = !(btnLoadPic.Enabled);
            btnClearPic.Enabled = !(btnClearPic.Enabled);
            btnCancel.Enabled = !(btnCancel.Enabled);
            btnUpdate.Enabled = !(btnUpdate.Enabled);

            if (btnEnableEditing.Text=="Enable Editing")
            {
                btnEnableEditing.Text = "Disable Editing";
            }else 
            {
                btnEnableEditing.Text = "Enable Editing";
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnEnableEditing_Click(sender, e);
            this.Height = 119;
            btnEnableEditing.Enabled = !(btnEnableEditing.Enabled);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show("Do you wish to Update Member Information?", "Edit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                #region Edit Member
                //check that all fields have been supplied.
                bool isAnyFieldBlank = anyBlankField();

                //check that the FileNo has not been changed to an assigned FileNo of another member
                SqlConnection conn = ConnectDB.GetConnection();
                bool isFileNoAlreadyAssigned = fileNoAlreadyAssigned(memberID, conn);

                //MessageBox.Show("isAnyFieldBlank " + isAnyFieldBlank + " -  isFileNoAlreadyAssigned - " + isFileNoAlreadyAssigned); 

                if ((isAnyFieldBlank == false) && (isFileNoAlreadyAssigned == false))
                {

                    string strUpdate = "Update Members set FileNo=@FileNo, FirstName=@FirstName, MiddleName=@MiddleName, LastName=@LastName," +
                        " Gender=@Gender, Address=@Address, LGA=@LGA, StateID=@StateID, Phone=@Phone, Email=@Email, DepartmentID=@DepartmentID," +
                        " BankID=@BankID, AccountNo=@AccountNo, Photo=@Photo, NOKFullName=@NOKFullName, NOKAddress=@NOKAddress, NOKPhone=@NOKPhone " +
                        " where MemberID=@MemberID";

                    SqlCommand cmdUpate = new SqlCommand(strUpdate, conn);

                    cmdUpate.Parameters.Add("@FileNo", System.Data.SqlDbType.NVarChar, 50, "FileNo");
                    cmdUpate.Parameters["@FileNo"].Value = txt_FileNo.Text.Trim();

                    cmdUpate.Parameters.Add("@FirstName", System.Data.SqlDbType.NVarChar, 50, "FirstName");
                    cmdUpate.Parameters["@FirstName"].Value = txt_FirstName.Text.Trim();

                    cmdUpate.Parameters.Add("@MiddleName", System.Data.SqlDbType.NVarChar, 50, "MiddleName");
                    cmdUpate.Parameters["@MiddleName"].Value = txt_MiddleName.Text.Trim();

                    cmdUpate.Parameters.Add("@LastName", System.Data.SqlDbType.NVarChar, 50, "LastName");
                    cmdUpate.Parameters["@LastName"].Value = txt_LastName.Text.Trim();

                    char gender = 'M';
                    if (rad_Male.Checked)
                    {
                        gender = 'M';
                    }
                    else if (rad_Female.Checked)
                    {
                        gender = 'F';
                    }


                    cmdUpate.Parameters.Add("@Gender", System.Data.SqlDbType.Char, 1, "Gender");
                    cmdUpate.Parameters["@Gender"].Value = gender;

                    cmdUpate.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar, 100, "Address");
                    cmdUpate.Parameters["@Address"].Value = txt_Address.Text.Trim();

                    cmdUpate.Parameters.Add("@LGA", System.Data.SqlDbType.NVarChar, 50, "LGA");
                    cmdUpate.Parameters["@LGA"].Value = txt_LGA.Text.Trim();

                    cmdUpate.Parameters.Add("@StateID", System.Data.SqlDbType.Int);
                    cmdUpate.Parameters["@StateID"].Value = cbo_State.SelectedValue;

                    cmdUpate.Parameters.Add("@Phone", System.Data.SqlDbType.NVarChar, 50, "Phone");
                    cmdUpate.Parameters["@Phone"].Value = txt_Phone.Text.Trim();

                    cmdUpate.Parameters.Add("@Email", System.Data.SqlDbType.NVarChar, 50, "Email");
                    cmdUpate.Parameters["@Email"].Value = txt_Email.Text.Trim();

                    cmdUpate.Parameters.Add("@DepartmentID", System.Data.SqlDbType.Int);
                    cmdUpate.Parameters["@DepartmentID"].Value = cbo_department.SelectedValue;

                    cmdUpate.Parameters.Add("@BankID", System.Data.SqlDbType.Int);
                    cmdUpate.Parameters["@BankID"].Value = cbo_Bank.SelectedValue;

                    cmdUpate.Parameters.Add("@AccountNo", System.Data.SqlDbType.NVarChar, 50);
                    cmdUpate.Parameters["@AccountNo"].Value = txt_AccountNo.Text.Trim();

                    cmdUpate.Parameters.Add("@Photo", System.Data.SqlDbType.NVarChar, 100, "Photo");
                    cmdUpate.Parameters["@Photo"].Value = photoName;

                    cmdUpate.Parameters.Add("@NOKFullName", System.Data.SqlDbType.NVarChar, 50, "NOKFullName");
                    cmdUpate.Parameters["@NOKFullName"].Value = txt_NOKName.Text.Trim();

                    cmdUpate.Parameters.Add("@NOKAddress", System.Data.SqlDbType.NVarChar, 50, "NOKAddress");
                    cmdUpate.Parameters["@NOKAddress"].Value = txt_NOKAddress.Text.Trim();

                    cmdUpate.Parameters.Add("@NOKPhone", System.Data.SqlDbType.NVarChar, 50, "Phone");
                    cmdUpate.Parameters["@NOKPhone"].Value = txt_NOKPhone.Text.Trim();

                    cmdUpate.Parameters.Add("@MemberID", System.Data.SqlDbType.Int);
                    cmdUpate.Parameters["@MemberID"].Value = memberID;


                    try
                    {
                        conn.Open();

                        int rowsAffected = cmdUpate.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Member Record has been successfully Updated.", "Record Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("An Error has Occurred! Update has been aborted.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    MessageBox.Show("An error has occurred. Update cannot be performed at this time.\nEnsure all entries are accurately supplied.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                #endregion
            }


        }

        private bool anyBlankField()
        {
            bool blankFieldExist = false;
            string strMessage = string.Empty;
            if (FieldValidator.isBlank(txt_Title.Text))
            {
                strMessage += "Title is required";
                blankFieldExist = true;
            }

            if (FieldValidator.isBlank(txt_FileNo.Text))
            {
                strMessage += "\nFile No. is required";
                blankFieldExist = true;
            }

            if (FieldValidator.isBlank(txt_LastName.Text))
            {
                strMessage += "\nLast Name is required";
                blankFieldExist = true;
            }

            if (FieldValidator.isBlank(txt_FirstName.Text))
            {
                strMessage += "\nFirst Name is required";
                blankFieldExist = true;
            }

            if (FieldValidator.isBlank(txt_Address.Text))
            {
                strMessage += "\nAddress is required";
                blankFieldExist = true;
            }

            if (FieldValidator.isBlank(txt_LGA.Text))
            {
                strMessage += "\nLGA is required";
                blankFieldExist = true;
            }

            if (FieldValidator.isBlank(txt_Phone.Text))
            {
                strMessage += "\nPhone No. is required";
                blankFieldExist = true;
            }

            if (FieldValidator.isBlank(txt_NOKName.Text))
            {
                strMessage += "\nNext of Kin Name is required";
                blankFieldExist = true;
            }

            if (FieldValidator.isBlank(txt_NOKAddress.Text))
            {
                strMessage += "\nNext of Kin Address is required";
                blankFieldExist = true;
            }

            if (FieldValidator.isBlank(txt_NOKPhone.Text))
            {
                strMessage += "\nNext of Kin Phone No. is required";
                blankFieldExist = true;
            }

            if (strMessage != string.Empty || blankFieldExist == true)
            {
                MessageBox.Show(strMessage, "An Error has Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return blankFieldExist;
        }

        private bool fileNoAlreadyAssigned(int memberID, SqlConnection conn)
        {

            bool result = false;
            string strQuery = "Select MemberID, Title, LastName, FirstName, FileNo from Members where MemberID!=@MemberID and FileNo=@FileNo";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            cmd.Parameters.Add("@MemberID", System.Data.SqlDbType.Int);
            cmd.Parameters["@MemberID"].Value = memberID;

            cmd.Parameters.Add("@FileNo", System.Data.SqlDbType.NVarChar, 50);
            cmd.Parameters["@FileNo"].Value = txt_FileNo.Text.Trim();

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Members");
                DataTable dt = ds.Tables["Members"];
                int recordFound = dt.Rows.Count;
                if (recordFound>0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        string name = row["Title"].ToString() + ' ' + row["LastName"].ToString() + ' ' + row["FirstName"].ToString();
                        MessageBox.Show("The File No. " + row["FileNo"].ToString() + " is assigned to " + name, "FileNo. Already Exist", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    result = true;
                }
                else
                {
                    result = false;
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

            return result;

        }

        private void btnClearPic_Click(object sender, EventArgs e)
        {
            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            //picMember.Image = Image.FromFile(paths + "\\photos\\" + reader["Photo"].ToString());
            picMember.Image = Image.FromFile(paths + "\\photos\\profile_img.png");
            photoName = null;
        }

        private void btnLoadPic_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = "C:\\";
            open.Filter = "Image Files(*.jpg)|*.jpg|All Files(*.*)|*.*";
            open.FilterIndex = 1;

            if (open.ShowDialog() == DialogResult.OK)
            {
                if (open.CheckFileExists)
                {
                    string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                    string correctFileName = System.IO.Path.GetFileName(open.FileName);
                    string fileSuffix = DateTime.Now.ToString("dd_MM_yy_hh_mm_ss");
                    try
                    {
                        photoName = "userphoto" + fileSuffix + ".jpg";
                        System.IO.File.Copy(open.FileName, paths + "\\photos\\" + photoName);
                        picMember.Image = Image.FromFile(paths + "\\photos\\" + photoName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {

                    }

                }

            }
        }

        private void txt_LastName_Leave(object sender, EventArgs e)
        {
            txt_LastName.Text = txt_LastName.Text.ToUpper();
        }
    }
}
