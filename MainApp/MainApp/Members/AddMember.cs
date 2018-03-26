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
    public partial class AddMember : Form
    {
        string photoName = string.Empty;

        public AddMember()
        {
            InitializeComponent();
            getStartSavingsMonth();
            getStartSavingsYear();
        }

        private void getStartSavingsMonth()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select MonthID,Month from MonthByName";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Months");
                DataTable dt = ds.Tables["Months"];
                cboStartSavingsMonth.DataSource = dt;
                cboStartSavingsMonth.DisplayMember = "Month";
                cboStartSavingsMonth.ValueMember = "MonthID";

                //select next month
                DateTime currentDate = DateTime.Now;
                DateTime nextDate = currentDate.AddMonths(1);
                int nextMonth = nextDate.Month;
                //MessageBox.Show(nextMonth.ToString());

                //select the next month
                cboStartSavingsMonth.SelectedValue = nextMonth;


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

        private void getStartSavingsYear()
        {
            DateTime myDate = DateTime.Now;
            int thisYear = myDate.Year;
            int startYear = 1990;

            int countforward = 40;
            int loop = 0;
            while (loop <= countforward)
            {
                cboStartSavingsYear.Items.Add(startYear++);
                loop++;
            }

            cboStartSavingsYear.SelectedItem = thisYear;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radMale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radFemale_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter_1(object sender, EventArgs e)
        {

        }

        #region Add Members Load Method
        private void AddMember_Load(object sender, EventArgs e)
        {
            txtEntryFee.TextAlign = HorizontalAlignment.Right;
            txtRegularSavings.TextAlign = HorizontalAlignment.Right;
            txtOtherSavingsAmount.TextAlign = HorizontalAlignment.Right;

            //LV Properties
            lstVOtherSavings.View = View.Details;
            lstVOtherSavings.FullRowSelect = true;

            //LV Column Names
            lstVOtherSavings.Columns.Add("ID",0);
            lstVOtherSavings.Columns.Add("Savings Type", 150);
            lstVOtherSavings.Columns.Add("Amount", 150);
            
            // TODO: This line of code loads data into the 'fUNAAB_CTCS.Members' table. You can move, or remove it, as needed.
             loadStates();
             loadDepartments();
             loadBanks();
             loadSavingsType();
        }
        #endregion

        #region Load States from Database into State Combo
        private void loadStates()
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
                DataRow row = dt.NewRow();
                row["State"] = "--  Select State --";
                dt.Rows.InsertAt(row, 0);
                cboState.DisplayMember = "State";
                cboState.ValueMember = "StateID";
                
                cboState.DataSource = dt;
                         
                
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
        #endregion

        #region Load Departments from Database
        private void loadDepartments()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select DepartmentID, DepartmentName, Description from Departments order by DepartmentName";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Departments");
                DataTable dt = ds.Tables["Departments"];
                cboDepartment.DisplayMember = "DepartmentName";
                cboDepartment.ValueMember = "DepartmentID";
                DataRow row = dt.NewRow();
                row["DepartmentName"] = "-- Select Department --";
                dt.Rows.InsertAt(row, 0);
                cboDepartment.DataSource = dt;
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
        #endregion

        #region Load Banks from Database
        private void loadBanks()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select BankID, BankName, Description from Banks order by BankName";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Banks");
                DataTable dt = ds.Tables["Banks"];
                cboBank.DisplayMember = "BankName";
                cboBank.ValueMember = "BankID";
                DataRow row = dt.NewRow();
                row["BankName"] = "-- Select Bank --";
                dt.Rows.InsertAt(row, 0);
                cboBank.DataSource = dt;
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
        #endregion

        #region Load Savings Type
        private void loadSavingsType()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select SavingsTypeID,SavingsName, Description from SavingsType order by SavingsName";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "SavingsType");
                DataTable dt = ds.Tables["SavingsType"];
                cboOtherSavings.DisplayMember = "SavingsName";
                cboOtherSavings.ValueMember = "SavingsTypeID";
                DataRow row = dt.NewRow();
                row["SavingsName"] = "-- Add Savings Type --";
                dt.Rows.InsertAt(row, 0);
                cboOtherSavings.DataSource = dt;

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
        #endregion

        #region Add Savings Button Click Event
        private void btnAddSavings_Click(object sender, EventArgs e)
        {
            if (cboOtherSavings.SelectedValue.ToString() != string.Empty)
            {
                string OtherSavings = cboOtherSavings.Text;
                bool savingsTypeAlreadyExist = false;

                #region Check to see if Selected Savings Type has been added
                //check to see if OtherSavings Amount have been supplied
                if (txtOtherSavingsAmount.Text != string.Empty)
                {
                    #region Loop through List View and check if selected cbo item has already been added
                    //check to see to item has not been added and turn to either true or false
                    if (lstVOtherSavings.Items.Count != 0)
                    {
                
                        for (int i = 0; i < lstVOtherSavings.Items.Count; i++)
                        {
                            //MessageBox.Show(lstVOtherSavings.Items[i].SubItems[1].Text.Trim() + " -- " + cboOtherSavings.Text.Trim());
                            if (lstVOtherSavings.Items[i].SubItems[1].Text.Trim() == cboOtherSavings.Text.Trim())
                            {
                                MessageBox.Show("The Savings Type '" + cboOtherSavings.Text + "' has been added already","Add Savings Type",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                savingsTypeAlreadyExist = true;
                            }
                            
                        }
                    }
                    #endregion

                    //if SavingsType has not been added already perform addition to ListView
                    if (savingsTypeAlreadyExist == false)
                    {
                        //Add selected cboSavings Item to ListView
                        addSavingsTypeToListView(cboOtherSavings.SelectedValue.ToString(), cboOtherSavings.Text, txtOtherSavingsAmount.Text);

                    }
                    

                }
                else
                {
                    MessageBox.Show("Savings Amount is required to Add a Savings Type","Savings Type",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
                #endregion
            }
            else
            {
                MessageBox.Show("Please Select a Savings Type and Amount to Add a Savings Type","Savings Type",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                
            }
        }
        #endregion


        #region Method to add Savings Type to List View
        private void addSavingsTypeToListView(string ID,string SavingsName,string Amount)
        {
            string formatAmount = String.Format("{0:0,0.00}", Convert.ToDecimal(Amount)); 
            

            string[] row = { ID, SavingsName, formatAmount};
            ListViewItem item = new ListViewItem(row);
            lstVOtherSavings.Items.Add(item);
            txtOtherSavingsAmount.Clear();


        }
        #endregion

        private void txtOtherSavingsAmount_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtOtherSavingsAmount_Leave(object sender, EventArgs e)
        {
            string strValue = txtOtherSavingsAmount.Text.Trim();
            if (CheckForNumber.isNumeric(strValue))
            {
                txtOtherSavingsAmount.Text = CheckForNumber.formatCurrency(txtOtherSavingsAmount.Text);
            }
            else
            {
                MessageBox.Show("Value entered for Savings Amount is Invalid", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtOtherSavingsAmount.Clear();
            }
        }

        

        private void txtRegularSavings_Leave(object sender, EventArgs e)
        {
            string strValue = txtRegularSavings.Text.Trim();
            if (CheckForNumber.isNumeric(strValue))
            {
                txtRegularSavings.Text = CheckForNumber.formatCurrency(txtRegularSavings.Text); 
            }
            else
            {
                MessageBox.Show("Value entered for Regular Savings is Invalid", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtRegularSavings.Clear();
            }
        }

        private void btnRemoveSavings_Click(object sender, EventArgs e)
        {
            if (lstVOtherSavings.SelectedItems.Count != 0)
            {
                lstVOtherSavings.Items.RemoveAt(lstVOtherSavings.SelectedIndices[0]);
            }
            else
            {
                MessageBox.Show("Select a Savings Type to Remove Item","Remove Savings Type",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void txtLastName_Leave(object sender, EventArgs e)
        {
            txtLastName.Text = txtLastName.Text.ToUpper().Trim();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            txtEmail.Text = txtEmail.Text.ToLower().Trim();
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
                    string paths = PhotoPath.getPath();
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

        private void btnClearPic_Click(object sender, EventArgs e)
        {
            string paths = PhotoPath.getPath();
            picMember.Image = Image.FromFile(paths + "\\photos\\profile_img.png");
            photoName = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //Validate Member's information before saving
            bool validationSucceed;
            validationSucceed = passValidation();

            if (validationSucceed)
            {
                if (!fileNoExist())
                {
                    DialogResult res = MessageBox.Show("Do you really wish to register this person as a member?", "Member Registration", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        registerNewMember();
                    }
                }
                else
                {
                    MessageBox.Show("A member with same FileNo Already Exist", "New Member Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

            //check if Member with FileNo already Exist

        }


        //Check if member with same FileNo already exist
        #region Check if member with same FileNo already exist
        private bool fileNoExist()
        {

            bool result = true;

            SqlConnection conn = ConnectDB.GetConnection();

            string strFileNoExist = "Select Count(*) from Members where FileNo=@FileNo";
            SqlCommand cmdFileNoExist = new SqlCommand(strFileNoExist, conn);

            cmdFileNoExist.Parameters.Add("@FileNo", SqlDbType.NVarChar, 20, "FileNo");
            cmdFileNoExist.Parameters["@FileNo"].Value = txtFileNo.Text.Trim();

            try
            {
                conn.Open();
                int rowFound = (int) cmdFileNoExist.ExecuteScalar();
                if (rowFound > 0)
                {
                    result = true;  //record of same FileNo exist
                }
                else
                {
                    result = false;  //No record of same FileNo exist
                }

               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
           
            return result;

        }
        #endregion
        //End of member check with same FileNo




        #region Register New Member Function
        private void registerNewMember()
        {
            //MessageBox.Show(cboState.SelectedValue.ToString());

            string title = txtTitle.Text.Trim();
            string firstname = txtFirstName.Text.Trim();
            string middlename = txtMiddleName.Text.Trim();
            string lastname = txtLastName.Text.Trim();
            string gender = string.Empty;
            if (radMale.Checked)
            { 
                gender = "M"; 
            }else
            {
                gender = "F";
            }
            string address = txtAddress.Text.Trim();
            string lga = txtLGA.Text.Trim();
            string stateID = cboState.SelectedValue.ToString();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string fileno = txtFileNo.Text.Trim().ToUpper();
            string departmentID = cboDepartment.SelectedValue.ToString();
            string bankID = cboBank.SelectedValue.ToString();
            string accountNo = txtAccountNo.Text.Trim();
            string NOKFullName = txtNOKName.Text.Trim();
            string NOKAddress = txtNOKAddress.Text.Trim();
            string NOKPhone = txtNOKPhone.Text.Trim();
            string EntryFee = txtEntryFee.Text.Trim();
            string RegularSavings = txtRegularSavings.Text.Trim();

            
            SqlConnection conn = ConnectDB.GetConnection();
            string strAddMember = "Insert into Members(FileNo,Title,FirstName,MiddleName,LastName," +
                "Gender,Address,LGA,StateID,Phone,Email,DepartmentID,BankID,AccountNo,Photo,NOKFullName," +
                "NOKAddress,NOKPhone,StartSavingsMonth,StartSavingsYear)values(@FileNo,@Title,@FirstName,@MiddleName,@LastName,@Gender,@Address,@LGA," +
                "@StateID,@Phone,@Email,@DepartmentID,@BankID,@AccountNo,@Photo,@NOKFullName,@NOKAddress,@NOKPhone,@StartSavingsMonth,@StartSavingsYear)";

            SqlCommand cmdAddMember = new SqlCommand(strAddMember, conn);

            #region cmdAddMember Parameters
            cmdAddMember.Parameters.Add("@FileNo", SqlDbType.NVarChar, 20, "FileNo");
            cmdAddMember.Parameters["@FileNo"].Value = fileno;

            cmdAddMember.Parameters.Add("@Title", SqlDbType.NVarChar, 20, "@Title");
            cmdAddMember.Parameters["@Title"].Value = title;

            cmdAddMember.Parameters.Add("@FirstName", SqlDbType.NVarChar, 50, "FirstName");
            cmdAddMember.Parameters["@FirstName"].Value = firstname;

            cmdAddMember.Parameters.Add("@MiddleName", SqlDbType.NVarChar, 50, "MiddleName");
            cmdAddMember.Parameters["@MiddleName"].Value = middlename;

            cmdAddMember.Parameters.Add("@LastName", SqlDbType.NVarChar, 50, "LastName");
            cmdAddMember.Parameters["@LastName"].Value = lastname;

            cmdAddMember.Parameters.Add("@Gender", SqlDbType.NChar, 1, "Gender");
            cmdAddMember.Parameters["@Gender"].Value = gender;

            cmdAddMember.Parameters.Add("@Address", SqlDbType.NVarChar, 100, "Address");
            cmdAddMember.Parameters["@Address"].Value = address;

            cmdAddMember.Parameters.Add("@LGA", SqlDbType.NVarChar, 50, "LGA");
            cmdAddMember.Parameters["@LGA"].Value = lga;

            cmdAddMember.Parameters.Add("@StateID", SqlDbType.Int);
            cmdAddMember.Parameters["@StateID"].Value = stateID;

            cmdAddMember.Parameters.Add("@Phone", SqlDbType.NVarChar, 50, "Phone");
            cmdAddMember.Parameters["@Phone"].Value = phone;

            cmdAddMember.Parameters.Add("@Email", SqlDbType.NVarChar, 50, "Email");
            cmdAddMember.Parameters["@Email"].Value = email;

            cmdAddMember.Parameters.Add("@DepartmentID", SqlDbType.Int);
            cmdAddMember.Parameters["@DepartmentID"].Value = departmentID;

            cmdAddMember.Parameters.Add("@BankID", SqlDbType.Int);
            cmdAddMember.Parameters["@BankID"].Value = bankID;

            cmdAddMember.Parameters.Add("@AccountNo", SqlDbType.NVarChar, 50, "AccountNo");
            cmdAddMember.Parameters["@AccountNo"].Value = accountNo;

            cmdAddMember.Parameters.Add("@Photo", SqlDbType.NVarChar, 200, "Photo");
            cmdAddMember.Parameters["@Photo"].Value = photoName;

            cmdAddMember.Parameters.Add("@NOKFullName", SqlDbType.NVarChar, 50, "NOKFullName");
            cmdAddMember.Parameters["@NOKFullName"].Value = NOKFullName;

            cmdAddMember.Parameters.Add("@NOKAddress", SqlDbType.NVarChar, 50, "NOKAddress");
            cmdAddMember.Parameters["@NOKAddress"].Value = NOKAddress;

            cmdAddMember.Parameters.Add("@NOKPhone", SqlDbType.NVarChar, 30, "NOKPhone");
            cmdAddMember.Parameters["@NOKPhone"].Value = NOKPhone;

            cmdAddMember.Parameters.Add("@StartSavingsMonth", SqlDbType.Int);
            cmdAddMember.Parameters["@StartSavingsMonth"].Value = cboStartSavingsMonth.SelectedValue;

            cmdAddMember.Parameters.Add("@StartSavingsYear", SqlDbType.Int);
            cmdAddMember.Parameters["@StartSavingsYear"].Value = Convert.ToInt16(cboStartSavingsYear.Text);
            #endregion

            SqlTransaction sqlTrans = null;
            bool DBOperationSuccess = true;

            #region Try-Catch for Adding New Member
            try
            {
                conn.Open();
                sqlTrans = conn.BeginTransaction();
                cmdAddMember.Transaction = sqlTrans;

                int rowsAffected = cmdAddMember.ExecuteNonQuery();

                #region if insertion into Members DBTable Successful
                if (rowsAffected > 0)
                {
                    string strRetrieveMemberID = "Select MemberID,FileNo from Members where FileNo=@FileNo";
                    SqlCommand cmdRetrieveMember = new SqlCommand(strRetrieveMemberID, conn);
                    cmdRetrieveMember.Parameters.Add("@FileNo", SqlDbType.NVarChar, 20, "FileNo");
                    cmdRetrieveMember.Parameters["@FileNo"].Value = fileno;

                    cmdRetrieveMember.Transaction = sqlTrans;

                    int memberID = (int) cmdRetrieveMember.ExecuteScalar();


                    //Insert EntranceFee into EntranceFees Table 
                    #region Insert EntranceFee into Entrance Table
                    string strShares = "Insert into EntranceFees(MemberID,Amount,Remark)values(@MemberID,@Amount,@Remark)";
                    SqlCommand cmdShares = new SqlCommand(strShares, conn);
                    cmdShares.Parameters.Add("@MemberID", SqlDbType.Int);
                    cmdShares.Parameters["@MemberID"].Value = memberID;

                    cmdShares.Parameters.Add("@Amount", SqlDbType.Decimal);
                    cmdShares.Parameters["@Amount"].Value = EntryFee;

                    cmdShares.Parameters.Add("@Remark", SqlDbType.NVarChar, 50, "Remark");
                    cmdShares.Parameters["@Remark"].Value = "Entrance Fees";

                    cmdShares.Transaction = sqlTrans;

                    int rowsAdded = cmdShares.ExecuteNonQuery();
                    if (rowsAdded == 0) { DBOperationSuccess = false; }

                    #endregion 


                    //Insert into Regular Savings Table
                    #region Insert into Regular Savings Table
                    string strSavingsRegular = "Insert into MemberSavingsTypeAcct(MemberID,SavingsTypeID,Amount,Remark)" +
                        "values(@MemberID,@SavingsTypeID,@Amount,@Remark)";
                    SqlCommand cmdSavingsRegular = new SqlCommand(strSavingsRegular, conn);

                    cmdSavingsRegular.Parameters.Add("@MemberID", SqlDbType.Int);
                    cmdSavingsRegular.Parameters["@MemberID"].Value = memberID;

                    cmdSavingsRegular.Parameters.Add("@SavingsTypeID", SqlDbType.Int);
                    cmdSavingsRegular.Parameters["@SavingsTypeID"].Value = 99;

                    cmdSavingsRegular.Parameters.Add("@Amount", SqlDbType.Decimal);
                    cmdSavingsRegular.Parameters["@Amount"].Value = RegularSavings;

                    cmdSavingsRegular.Parameters.Add("@Remark", SqlDbType.NVarChar, 50, "Remark");
                    cmdSavingsRegular.Parameters["@Remark"].Value = "Shares Savings";

                    cmdSavingsRegular.Transaction = sqlTrans;

                    int rowsNew = cmdSavingsRegular.ExecuteNonQuery();
                    if (rowsNew == 0) { DBOperationSuccess = false; }

                    #endregion
                    //end of Insertion into Regular Savings 


                    //lstVOtherSavings Function ------
                    #region lstVOtherSavings Function
                    
                    if (lstVOtherSavings.Items.Count != 0)
                    {
                        for (int i = 0; i < lstVOtherSavings.Items.Count; i++)
                        {
                            string savingTypeID = lstVOtherSavings.Items[i].SubItems[0].Text;
                            Decimal amount = Convert.ToDecimal(lstVOtherSavings.Items[i].SubItems[2].Text);
                            string remark = lstVOtherSavings.Items[i].SubItems[1].Text;

                            string strInsertSavingsType = "Insert into MemberSavingsTypeAcct(MemberID,SavingsTypeID,Amount,Remark)values(@MemberID,@SavingsTypeID,@Amount,@Remark)";
                            SqlCommand cmdInsertSavingsType = new SqlCommand(strInsertSavingsType, conn);

                            cmdInsertSavingsType.Parameters.Add("@MemberID", SqlDbType.Int);
                            cmdInsertSavingsType.Parameters["@MemberID"].Value = memberID;

                            cmdInsertSavingsType.Parameters.Add("@SavingsTypeID", SqlDbType.Int);
                            cmdInsertSavingsType.Parameters["@SavingsTypeID"].Value = savingTypeID;

                            cmdInsertSavingsType.Parameters.Add("@Amount", SqlDbType.Decimal);
                            cmdInsertSavingsType.Parameters["@Amount"].Value = amount;

                            cmdInsertSavingsType.Parameters.Add("@Remark", SqlDbType.NVarChar, 50, "Remark");
                            cmdInsertSavingsType.Parameters["@Remark"].Value = remark;

                            cmdInsertSavingsType.Transaction = sqlTrans;

                            int rowsInserted = cmdInsertSavingsType.ExecuteNonQuery();
                            if (rowsInserted == 0) { DBOperationSuccess = false; }


                        }
                    }

                    #endregion
                    //end of lstVOtherSavings Function ----

                    if (DBOperationSuccess == true)
                    {
                        sqlTrans.Commit();
                        MessageBox.Show("New Member has been Successfully Registered", "New Member Registration", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        clearAllFields();                      


                    }
                    else
                    {
                        sqlTrans.Rollback();
                    }


                }
                else
                {
                    sqlTrans.Rollback();
                }
                #endregion



            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlTrans.Rollback();
            }
            finally
            {
                conn.Close();
            }

            #endregion
            
        }
        #endregion


        #region passValidation Function - Validate Field Entries
        private bool passValidation()
        {
            bool validationPassed = true;
            string strMessage = null;
            if (txtTitle.Text == string.Empty)
            {
                strMessage += "Title is required";
                validationPassed = false;
                txtTitle.BackColor = System.Drawing.Color.Yellow;
            }
            else
            {
                txtTitle.BackColor = Color.Empty;
            }



            if (FieldValidator.isBlank(txtFirstName.Text))
            {
                strMessage += "\nFirst Name is required";
                validationPassed = false;
                txtFirstName.BackColor = Color.Yellow;
            }
            else
            {
                txtFirstName.BackColor = Color.Empty;
            }


            if (txtLastName.Text == string.Empty)
            {
                strMessage += "\nLast Name is required";
                validationPassed = false;
                txtLastName.BackColor = Color.Yellow;
            }
            else
            {
                txtLastName.BackColor = Color.Empty;
            }


            if (!radMale.Checked && !radFemale.Checked)
            {
                strMessage += "\nGender is required";
                validationPassed = false;
                radMale.BackColor = Color.Yellow;
                radFemale.BackColor = Color.Yellow;

            }
            else
            {
                radMale.BackColor = Color.Empty;
                radFemale.BackColor = Color.Empty;
            }


           
            if (txtPhone.Text == string.Empty)
            {
                strMessage += "\nPhone No. is required";
                validationPassed = false;
                txtPhone.BackColor = Color.Yellow;
            }
            else
            {
                txtPhone.BackColor = Color.White;
            }
           


            if (cboState.Text == "--  Select State --")
            {
                strMessage += "\nSelect a State";
                validationPassed = false;
                cboState.BackColor = Color.Yellow;
            }
            else
            {
                cboState.BackColor = Color.White;
            }


            if (txtFileNo.Text == string.Empty)
            {
                strMessage += "\nFile No. is required";
                validationPassed = false;
                txtFileNo.BackColor = Color.Yellow;
            }
            else
            {
                txtFileNo.BackColor = Color.White;
            }



            if (cboDepartment.Text == "-- Select Department --")
            {
                strMessage += "\nDepartment is required";
                validationPassed = false;
                cboDepartment.BackColor = Color.Yellow;
            }
            else
            {
                cboDepartment.BackColor = Color.White;
            }



            if (FieldValidator.isBlank(txtNOKName.Text))
            {
                strMessage += "\nNext of Kin Name is required";
                validationPassed = false;
                txtNOKName.BackColor = Color.Yellow;
            }
            else
            {
                txtNOKName.BackColor = Color.White;
            }



            if (FieldValidator.isBlank(txtNOKPhone.Text))
            {
                strMessage += "\nNext of Kin Phone No. is required";
                validationPassed = false;
                txtNOKPhone.BackColor = Color.Yellow;
            }
            else
            {
                txtNOKPhone.BackColor = Color.Empty;
            }



            if (FieldValidator.isBlank(txtEntryFee.Text))
            {
                strMessage += "\nEntry Fee Amount is required";
                validationPassed = false;
                txtEntryFee.BackColor = Color.Yellow;
            }
            else
            {
                txtEntryFee.BackColor = Color.White;
            }



            if (FieldValidator.isBlank(txtRegularSavings.Text))
            {
                strMessage += "\nRegular Savings Amount is required";
                validationPassed = false;
                txtRegularSavings.BackColor = Color.Yellow;
            }
            else
            {
                txtRegularSavings.BackColor = Color.White;
            }


            if (strMessage != null)
            {
                MessageBox.Show(strMessage, "New Member Validation  - From Validator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            return validationPassed;
        }
        #endregion 

        private void cboState_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void clearAllFields()
        {
            txtTitle.Clear();
            txtFirstName.Clear();
            txtMiddleName.Clear();
            txtLastName.Clear();
            radMale.Checked = false;
            radFemale.Checked = false;
            txtAddress.Clear();
            txtLGA.Clear();
            cboState.SelectedIndex = 0;
            txtPhone.Clear();
            txtEmail.Clear();
            txtFileNo.Clear();
            cboDepartment.SelectedIndex = 0;
            cboBank.SelectedIndex = 0;
            txtAccountNo.Clear();
            txtNOKName.Clear();
            txtNOKAddress.Clear();
            txtNOKPhone.Clear();
            txtEntryFee.Clear();
            txtRegularSavings.Clear();
            cboOtherSavings.SelectedIndex = 0;
            txtOtherSavingsAmount.Clear();
            lstVOtherSavings.Items.Clear();
            btnClearPic_Click(null, null);

        }

        private void txtRegularSavings_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEntryFee_Leave(object sender, EventArgs e)
        {
         
            string strValue = txtEntryFee.Text.Trim();
            if (CheckForNumber.isNumeric(strValue))
            {
                txtEntryFee.Text = CheckForNumber.formatCurrency(txtEntryFee.Text);
                
            }
            else
            {
                MessageBox.Show("Value entered for Entrance Fee is Invalid", "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEntryFee.Clear();
            }
        
        }

        private void txtFileNo_Leave(object sender, EventArgs e)
        {
            txtFileNo.Text = txtFileNo.Text.ToUpper();
        }

       

    }
}
