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
    public partial class LoanApplication : Form
    {

        SqlConnection conn = ConnectDB.GetConnection();
        string paths = PhotoPath.getPath();

        private string userId;
        private string memberID;

        public LoanApplication(string UserID)
        {
            InitializeComponent();
            userId = UserID;
        }

        private void LoanApplication_Load(object sender, EventArgs e)
        {
            DateTime appDate = DateTime.Now;
            lblAppMonthYear.Text = "Loan Application for " + appDate.ToString("MMMM, yyyy");
            //MessageBox.Show(DateFunction.getMonthByName(appDate.Month));

            cboMonth.Text = DateFunction.getMonthByName(appDate.Month);
            cboYear.Text = appDate.Year.ToString();

            loadMemberFileNoIntoCboFileNo();
            loadLoanCategoryIntoCboCategory();

            txtLoanDuration.TextAlign = HorizontalAlignment.Right;
            txtLoanInterestRate.TextAlign = HorizontalAlignment.Right;
            txtAmount.TextAlign = HorizontalAlignment.Right;
            txtInterestAmount.TextAlign = HorizontalAlignment.Right;
            txtTotalRepaymentAmount.TextAlign = HorizontalAlignment.Right;
            txtMonthRepayment.TextAlign = HorizontalAlignment.Right;

            lblSuretyMemberID_1.Text = string.Empty;
            lblSuretyMemberID_2.Text = string.Empty;
            lblSuretyMemberID_3.Text = string.Empty;

            lblSurety1.Text = string.Empty;
            lblSurety2.Text = string.Empty;
            lblWitness.Text = string.Empty;

        }

        private void loadMemberFileNoIntoCboFileNo()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select MemberID, FileNo from Members order by FileNo";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "FileNo");
                DataTable dt = ds.Tables["FileNo"];

                DataRow row = dt.NewRow();
                row["FileNo"] = "-- Select a File No. --";
                dt.Rows.InsertAt(row, 0);

                cboFileNo.DisplayMember = "FileNo";
                cboFileNo.ValueMember = "MemberID";
                cboFileNo.DataSource = dt;
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

        private void loadLoanCategoryIntoCboCategory()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select LoanCategoryID, Name from LoanCategory";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds,"LoanCategory");
                DataTable dt = ds.Tables["LoanCategory"];

                DataRow row = dt.NewRow();
                row["Name"] = "-- Select a Loan Category --";
                dt.Rows.InsertAt(row, 0);

                cboCategory.DisplayMember = "Name";
                cboCategory.ValueMember = "LoanCategoryID";

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

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboYear.Text != string.Empty)
            {
                lblAppMonthYear.Text = "Loan Application for " + cboMonth.Text + ", " + cboYear.Text;
            }
            else
            {
                lblAppMonthYear.Text = "Loan Application for " + cboMonth.Text;
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMonth.Text != string.Empty)
            {
                lblAppMonthYear.Text = "Loan Application for " + cboMonth.Text + ", " + cboYear.Text;
            }
            else
            {
                lblAppMonthYear.Text = "Loan Application for " + cboYear.Text;
            }
        }

        private void cboFileNo_Leave(object sender, EventArgs e)
        {
            retrieveMemberProfileByFileNo();
        }

        private void retrieveMemberProfileByFileNo()
        {
            

            if (cboFileNo.Text != "-- Select a File No. --")
            {
                #region retrieveMemberProfile
                SqlConnection conn = ConnectDB.GetConnection();
                string strQuery = "Select MemberID,Title,FileNo,FirstName,MiddleName,LastName,Photo from Members " +
                   "where FileNo='" + cboFileNo.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            lblMemberProfile.Visible = true;
                            lblMemberProfile.Text = reader["Title"].ToString() + " " + reader["LastName"].ToString() + " " + reader["FirstName"].ToString() + " " + reader["MiddleName"].ToString().Substring(0) + ".";
                            memberID = reader["MemberID"].ToString();

                            if ( reader["Photo"].ToString()!=null && reader["Photo"].ToString() != string.Empty)
                            {
                                picMember.Image = Image.FromFile(paths + "//photos//" + reader["Photo"].ToString());
                            }
                            else
                            {
                                picMember.Image = Image.FromFile(paths + "//photos//profile_img.png");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sorry, no record with that File No. [" + cboFileNo.Text + "] exist.", "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        picMember.Image = Image.FromFile(paths + "//photos//profile_img.png");
                        lblMemberProfile.Text = string.Empty;

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

                #endregion end of retrieveMemberProfile
            }
            else
            {
                picMember.Image = Image.FromFile(paths + "\\photos\\profile_img.png");
                lblMemberProfile.Text = string.Empty;
                lblMemberProfile.Visible = false;
            } //end of if (--Select a File No. --)

        }

        private void cboFileNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            retrieveMemberProfileByFileNo();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.Text != "-- Select a Loan Category --")
            {
                //retrieve LoanType Based on the selected LoanCategory
                #region retrieveLoanType
                    SqlConnection conn = ConnectDB.GetConnection();
                    string strQuery = "Select LoanTypeID,LoanCategoryID,Type from LoanType where LoanCategoryID=" + (Convert.ToInt16(cboCategory.SelectedValue));
                    SqlCommand cmd = new SqlCommand(strQuery, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();

                    try
                    {
                        conn.Open();
                        da.Fill(ds, "LoanType");
                        DataTable dt = ds.Tables["LoanType"];

                        DataRow row = dt.NewRow();
                        row["Type"] = "-- Select a Loan Type --";
                        dt.Rows.InsertAt(row, 0);
                        cboType.DisplayMember = "Type";
                        cboType.ValueMember = "LoanTypeID";

                        cboType.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + " Loan Category");
                    }
                    finally
                    {
                        conn.Close();
                    }

                #endregion                
            }
            else
            {
                //cboType.Items.Clear();
            }
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboType.Text != "-- Select a Loan Type --")
            {
                txtAmount.Enabled = true;
                txtFormFee.Enabled = true;
                #region retrieveLoanDetails

                    SqlConnection conn = ConnectDB.GetConnection();
                    string strQuery = "Select LoanTypeID,Duration,InterestRate from LoanType where LoanTypeID=" + cboType.SelectedValue;
                    SqlCommand cmd = new SqlCommand(strQuery, conn);

                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        txtLoanDuration.Text = reader["Duration"].ToString();
                        txtLoanInterestRate.Text = reader["InterestRate"].ToString();
                        
                        DateTime currentDate = DateTime.Now;
                        DateTime nextMonthStartRepayment = currentDate.AddMonths(0);
                        DateTime endOfRepayment = nextMonthStartRepayment.AddMonths(Convert.ToInt16(txtLoanDuration.Text));
                        txtEndRepaymentDate.Text = endOfRepayment.ToString("MMMM yyyy");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + " Loan Type");
                    }
                    finally
                    {
                        conn.Close();
                    }

                #endregion 
            }
            else
            {
                txtAmount.Enabled = false;
                txtFormFee.Enabled = false;
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtAmount.Text != string.Empty)
            {
                if (CheckForNumber.isNumeric(txtAmount.Text.Trim()) == true)
                {
                    decimal interestAmount = (Convert.ToDecimal(txtAmount.Text)) * ((Convert.ToDecimal(txtLoanInterestRate.Text)) / 100);
                    txtInterestAmount.Text = CheckForNumber.formatCurrency(interestAmount.ToString());

                    decimal totalRepaymentAmount = Convert.ToDecimal(txtAmount.Text) + interestAmount;
                    txtTotalRepaymentAmount.Text = CheckForNumber.formatCurrency(totalRepaymentAmount.ToString());

                    decimal monthRepayment = totalRepaymentAmount / Convert.ToInt16(txtLoanDuration.Text);
                    txtMonthRepayment.Text = CheckForNumber.formatCurrency(monthRepayment.ToString());

                    //enable btnSaveApplication 
                    btnSaveApplication.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Sorry, Invalid value has been entered for Amount", "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                btnSaveApplication.Enabled = false;
            }
        }

        private void chkSurety1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSurety1.Checked == true)
            {
                txtSuretyFileNo1.Enabled = false;
                txtSuretyName1.Enabled = true;
                picSurety1.Image = Image.FromFile(paths + "//photos//profile_img.png");
                txtSuretyFileNo1.Clear();
                lblSurety1.Text = string.Empty;
                lblSuretyMemberID_1.Text = string.Empty; 
            }
            else
            {
                txtSuretyFileNo1.Enabled = true;
                txtSuretyName1.Enabled = false;
                txtSuretyName1.Clear();
            }
        }

        private void chkSurety2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSurety2.Checked == true)
            {
                txtSuretyFileNo2.Enabled = false;
                txtSuretyName2.Enabled = true;
                picSurety2.Image = Image.FromFile(paths + "//photos//profile_img.png");
                txtSuretyFileNo2.Clear();
                lblSurety2.Text = string.Empty;
                lblSuretyMemberID_2.Text = string.Empty;
            }
            else
            {
                txtSuretyFileNo2.Enabled = true;
                txtSuretyName2.Enabled = false;
                txtSuretyName2.Clear();
            }
        }

        private void chkWitness_CheckedChanged(object sender, EventArgs e)
        {
            if (chkWitness.Checked == true)
            {
                txtWitnessFileNo.Enabled = false;
                txtWitnessName.Enabled = true;
                picWitness.Image = Image.FromFile(paths + "//photos//profile_img.png");
                txtWitnessFileNo.Clear();
                lblWitness.Text = string.Empty;
                lblSuretyMemberID_3.Text = string.Empty;
            }
            else
            {
                txtWitnessFileNo.Enabled = true;
                txtWitnessName.Enabled = false;
                txtWitnessName.Clear();
            }
        }

        private void txtSuretyName1_TextChanged(object sender, EventArgs e)
        {
            if (txtSuretyName1.Text != string.Empty)
            {
                lblSurety1.Visible = true;
                picSurety1.Visible = true;
                lblSurety1.Text = txtSuretyName1.Text.Trim();        
            }
            else
            {
                lblSurety1.Text = string.Empty;
                lblSurety1.Visible = false;
                picSurety1.Visible = false;
            }
        }

        private void txtSuretyName2_TextChanged(object sender, EventArgs e)
        {
            if (txtSuretyName2.Text != string.Empty)
            {
                lblSurety2.Visible = true;
                picSurety2.Visible = true;
                lblSurety2.Text = txtSuretyName2.Text.Trim();
            }
            else
            {
                lblSurety2.Text = string.Empty;
                lblSurety2.Visible = false;
                picSurety2.Visible = false;
            }
        }

        private void txtWitnessName_TextChanged(object sender, EventArgs e)
        {
            if (txtWitnessName.Text != string.Empty)
            {
                lblWitness.Visible = true;
                picWitness.Visible = true;
                lblWitness.Text = txtWitnessName.Text.Trim();              
            }
            else
            {
                lblWitness.Text = string.Empty;
                lblWitness.Visible = false;
                picWitness.Visible = false;
            }
        }

        private void txtSuretyFileNo1_Leave(object sender, EventArgs e)
        {
            string strSender = "Surety1";
            if (txtSuretyFileNo1.Text != string.Empty)
            {
                if (txtSuretyFileNo1.Text != cboFileNo.Text && txtSuretyFileNo1.Text != txtSuretyFileNo2.Text && txtSuretyFileNo1.Text != txtWitnessFileNo.Text)
                {
                    getSuretyData(strSender, txtSuretyFileNo1.Text);
                  
                }
                else
                {
                    MessageBox.Show("Surety cannot be same person as the receipt, surety or witness", "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSuretyFileNo1.Text = string.Empty;
                }
            }
        }

        private void getSuretyData(string strSender,string memberFileNo)
        {
            string memberProfile = string.Empty;
            string memberID = string.Empty;
            string memberPic = string.Empty;
            string paths = PhotoPath.getPath();

            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select MemberID,FileNo,Title,LastName,MiddleName,FirstName,Photo from Members where FileNo='" + memberFileNo + "'";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    memberProfile = reader["Title"].ToString() + " " + reader["LastName"].ToString() + " " + reader["FirstName"].ToString() + " " + reader["MiddleName"].ToString();
                    memberID = reader["MemberID"].ToString();
                    memberPic = reader["Photo"].ToString();

                    switch (strSender)
                    {
                        case "Surety1":
                            lblSurety1.Visible = true;
                            picSurety1.Visible = true;
                            lblSurety1.Text = "Surety 1\n" + memberProfile;
                            lblSuretyMemberID_1.Text = memberID;
                            if (memberPic != string.Empty)
                            {
                                picSurety1.Image = Image.FromFile(paths + "//photos//" + memberPic.ToString());                                
                            }
                            break;
                        case "Surety2":
                            lblSurety2.Visible = true;
                            picSurety2.Visible = true;
                            lblSurety2.Text = "Surety 2\n" + memberProfile;
                            lblSuretyMemberID_2.Text = memberID;
                            if (memberPic != string.Empty)
                            {
                                picSurety2.Image = Image.FromFile(paths + "//photos//" + memberPic.ToString());
                            }
                            break;
                        case "Witness":
                            lblWitness.Visible = true;
                            picWitness.Visible = true;
                            lblWitness.Text = "Witness\n" + memberProfile;
                            lblSuretyMemberID_3.Text = memberID;
                            if (memberPic != null || memberPic == string.Empty)
                            {
                                picWitness.Image = Image.FromFile(paths + "//photos//" + memberPic.ToString());
                            }
                            break;


                    }//end of Switch

                }
                else
                {
                    MessageBox.Show("Sorry, there is no member with the File No. ["+ memberFileNo +"]", "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    switch (strSender)
                    {
                        case "Surety1":
                            txtSuretyFileNo1.Clear();
                            break;
                        case "Surety2":
                            txtSuretyFileNo2.Clear();
                            break;
                        case "Witness":
                            txtWitnessFileNo.Clear();
                            break;
                    }
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

        private void txtSuretyFileNo2_Leave(object sender, EventArgs e)
        {
            string strSender = "Surety2";
            if (txtSuretyFileNo2.Text != String.Empty)
            {
                if (txtSuretyFileNo2.Text != cboFileNo.Text && txtSuretyFileNo1.Text != txtSuretyFileNo2.Text && txtSuretyFileNo2.Text != txtWitnessFileNo.Text)
                {
                    getSuretyData(strSender, txtSuretyFileNo2.Text);
                }
                else
                {
                    MessageBox.Show("Surety cannot be same person as the recipient, surety or witness", "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSuretyFileNo2.Text = string.Empty;
                }
            }
        }

        private void txtWitnessFileNo_Leave(object sender, EventArgs e)
        {
            string strSender = "Witness";
            if (txtWitnessFileNo.Text != string.Empty)
            {
                if (txtWitnessFileNo.Text != cboFileNo.Text && txtSuretyFileNo1.Text != txtWitnessFileNo.Text && txtSuretyFileNo2.Text != txtWitnessFileNo.Text)
                {
                    getSuretyData(strSender, txtWitnessFileNo.Text);
                }
                else
                {
                    MessageBox.Show("Witness cannot be same person as the recipient or surety", "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtWitnessFileNo.Text = string.Empty;
                }
            }

        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (CheckForNumber.isNumeric(txtAmount.Text.Trim()))
            {
                txtAmount.Text = CheckForNumber.formatCurrency(txtAmount.Text.Trim());
            }
        }

        private void chkStartRepayment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStartRepayment.Checked == true)
            {
                cboStartRepaymentMonth.Enabled = true;
                cboStartRepaymentYear.Enabled = true;
            }
            else
            {
                cboStartRepaymentMonth.Enabled = false;
                cboStartRepaymentYear.Enabled = false;
            }

        }

        private void cboStartRepaymentYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboYear.Text != string.Empty)
            {
                if (Convert.ToInt32(cboStartRepaymentYear.Text) < (Convert.ToInt32(cboYear.Text)))
                {
                    MessageBox.Show("Sorry, the entry is Invalid. It is a Date in the Past.", "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cboStartRepaymentYear.Text = cboYear.Text;
                }
            }
            else
            {
                MessageBox.Show("Set the Date for the Loan Application", "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSaveApplication_Click(object sender, EventArgs e)
        {
            bool fieldVerifierSuccess = true;
            fieldVerifierSuccess = fieldVerification();

            if (fieldVerifierSuccess == true)
            {
                DialogResult result = MessageBox.Show("Do you confirm this application and wish to save it?", "Loan Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    saveLoanApplication();
                }
            }
           
        }


        private bool fieldVerification()
        {
            bool verificationStatus = true;
            string errMessage = string.Empty;
            if (cboFileNo.Text == "-- Select a File No. --")
            {
                errMessage += "Specify Member Applying for the Loan by entering Member File No.\n";
            }

            if (cboCategory.Text == "-- Select a Loan Category --")
            {
                errMessage += "Select a Loan Category and then pick a Loan Type\n";
            }

            if (cboType.Text == "-- Select a Loan Type --")
            {
                errMessage += "Select a Loan Type for this application\n";
            }

            if (txtAmount.Text == string.Empty)
            {
                errMessage += "No Loan Amount has been specified\n"; 
            }

            if (!CheckForNumber.isNumeric(txtAmount.Text))
            {
                errMessage += "Loan Amount is in invalid format\n";
            }

            if (txtFormFee.Text == string.Empty || (!CheckForNumber.isNumeric(txtFormFee.Text)))
            {
                errMessage += "Form Fee is in invalid format\n";
            }

            if (errMessage != string.Empty)
            {
                verificationStatus = false;
                MessageBox.Show(errMessage, "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            return verificationStatus;
        }


        private void saveLoanApplication()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Insert into LoanApplication(AppMonth,AppYear,MemberID,LoanCategoryID,LoanTypeID," +
                "LoanAmount,FormFee,StartRepaymentMonth,StartRepaymentYear,SuretyMemberID1,SuretyMemberID2,WitnessMemberID," +
                "NonMemberSurety1,NonMemberSurety2,NonMemberWitness,LoanDuration,InterestRate,InterestAmount," +
                "TotalRepayment,MonthlyRepayment,TransactionID)values(@AppMonth,@AppYear,@MemberID,@LoanCategoryID,@LoanTypeID,"+
            "@LoanAmount,@FormFee,@StartRepaymentMonth,@StartRepaymentYear,@SuretyMemberID1,@SuretyMemberID2,@WitnessMemberID,"+
            "@NonMemberSurety1,@NonMemberSurety2,@NonMemberWitness,@LoanDuration,@InterestRate,@InterestAmount,"+
            "@TotalRepayment,@MonthlyRepayment,@TransactionID)";

            string transactionID = "LOA" + DateTime.Now.ToString("ddMMyyhhmmss");
            
            SqlCommand cmd = new SqlCommand(strQuery,conn);

            #region parameters
            cmd.Parameters.Add("@AppMonth", SqlDbType.Int);
            cmd.Parameters["@AppMonth"].Value = DateFunction.getMonthByDate(cboMonth.Text);


            cmd.Parameters.Add("@AppYear", SqlDbType.Int);
            cmd.Parameters["@AppYear"].Value = Convert.ToInt32(cboYear.Text);

            cmd.Parameters.Add("@MemberID", SqlDbType.Int);        
            cmd.Parameters["@MemberID"].Value = memberID;

            cmd.Parameters.Add("@LoanCategoryID", SqlDbType.Int);
            cmd.Parameters["@LoanCategoryID"].Value = Convert.ToInt32(cboCategory.SelectedValue.ToString());

            cmd.Parameters.Add("@LoanTypeID", SqlDbType.Int);
            cmd.Parameters["@LoanTypeID"].Value = Convert.ToInt32(cboType.SelectedValue.ToString());

            cmd.Parameters.Add("@LoanAmount", SqlDbType.Decimal);
            cmd.Parameters["@LoanAmount"].Value = Convert.ToDecimal(txtAmount.Text);

            cmd.Parameters.Add("@FormFee", SqlDbType.Decimal);
            cmd.Parameters["@FormFee"].Value = Convert.ToDecimal(txtFormFee.Text);

                    int startRepaymentMonth = 0;
                    int startRepaymentYear = 0;
                    if ((chkStartRepayment.Checked == true) && (cboStartRepaymentMonth.Text != string.Empty) && (cboStartRepaymentYear.Text != string.Empty))
                    {
                        startRepaymentMonth = DateFunction.getMonthByDate(cboStartRepaymentMonth.Text);
                        startRepaymentYear = Convert.ToInt32(cboStartRepaymentYear.Text);
                    }
                    else
                    {
                        //DateTime currentDate = DateTime.Now;
                        //int currentMonth = currentDate.Month;
                        string strAppDate = cboMonth.Text + " " + cboYear.Text;
                        DateTime appDate = DateTime.Parse(strAppDate);
                        DateTime nextMonth = appDate.AddMonths(1);
                        startRepaymentMonth = nextMonth.Month;
                        startRepaymentYear = nextMonth.Year;
                    }
            
            cmd.Parameters.Add("@StartRepaymentMonth", SqlDbType.Int);
            cmd.Parameters["@StartRepaymentMonth"].Value = startRepaymentMonth;

            cmd.Parameters.Add("@StartRepaymentYear", SqlDbType.Int);
            cmd.Parameters["@StartRepaymentYear"].Value = startRepaymentYear;

            cmd.Parameters.Add("@SuretyMemberID1", SqlDbType.NVarChar,10);
            cmd.Parameters["@SuretyMemberID1"].Value = lblSuretyMemberID_1.Text;

            cmd.Parameters.Add("@SuretyMemberID2", SqlDbType.NVarChar,10);
            cmd.Parameters["@SuretyMemberID2"].Value = lblSuretyMemberID_2.Text;

            cmd.Parameters.Add("@WitnessMemberID", SqlDbType.NVarChar,10);
            cmd.Parameters["@WitnessMemberID"].Value = lblSuretyMemberID_3.Text;

            cmd.Parameters.Add("@NonMemberSurety1", SqlDbType.NVarChar, 100);
            cmd.Parameters["@NonMemberSurety1"].Value = txtSuretyName1.Text;

            cmd.Parameters.Add("@NonMemberSurety2", SqlDbType.NVarChar, 100);
            cmd.Parameters["@NonMemberSurety2"].Value = txtSuretyName2.Text;

            cmd.Parameters.Add("@NonMemberWitness", SqlDbType.NVarChar, 100);
            cmd.Parameters["@NonMemberWitness"].Value = txtWitnessName.Text;

            cmd.Parameters.Add("@LoanDuration", SqlDbType.Int);
            cmd.Parameters["@LoanDuration"].Value = Convert.ToInt32(txtLoanDuration.Text);

            cmd.Parameters.Add("@InterestRate", SqlDbType.Decimal);
            cmd.Parameters["@InterestRate"].Value = Convert.ToDecimal(txtLoanInterestRate.Text);

            cmd.Parameters.Add("@InterestAmount", SqlDbType.Decimal);
            cmd.Parameters["@InterestAmount"].Value = Convert.ToDecimal(txtInterestAmount.Text);

            cmd.Parameters.Add("@TotalRepayment", SqlDbType.Decimal);
            cmd.Parameters["@TotalRepayment"].Value = Convert.ToDecimal(txtTotalRepaymentAmount.Text);

            cmd.Parameters.Add("@MonthlyRepayment", SqlDbType.Decimal);
            cmd.Parameters["@MonthlyRepayment"].Value = Convert.ToDecimal(txtMonthRepayment.Text);

            cmd.Parameters.Add("@TransactionID", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TransactionID"].Value = transactionID;
            #endregion

            
            try
            {
                conn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                
                if (rowAffected > 0)
                {
                    MessageBox.Show("Loan Application has been Successfully saved.", "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    clearAllFields();

                    string ActivityType = "Loan Application";
                    string Description = "Loan Application of " + cboType.Text + ". Amount: " + txtAmount.Text + " for " + cboFileNo.Text + " with TransactionID: " + transactionID;
                    ActivityLog.logActivity(userId, ActivityType, Description);
                }
                else
                {
                    MessageBox.Show("An error has occurred!", "Loan Application", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally
            {
                conn.Close();
            }


           
        }


        private void clearAllFields()
        {
            DateTime appDate = DateTime.Now;
            lblAppMonthYear.Text = "Loan Application for " + appDate.ToString("MMMM, yyyy");
            //MessageBox.Show(DateFunction.getMonthByName(appDate.Month));

            cboMonth.Text = DateFunction.getMonthByName(appDate.Month);
            cboYear.Text = appDate.Year.ToString();

            cboFileNo.SelectedIndex = 0;
            cboCategory.SelectedIndex = 0;
            cboType.Text = string.Empty;
            txtAmount.Text = string.Empty;
            chkStartRepayment.Checked = false;
            cboStartRepaymentMonth.Text = string.Empty;
            cboStartRepaymentYear.Text = string.Empty;
            txtSuretyFileNo1.Text = string.Empty;
            txtSuretyFileNo2.Text = string.Empty;
            txtWitnessFileNo.Text = string.Empty;
            chkSurety1.Checked = false;
            txtSuretyName1.Text = string.Empty;
            chkSurety2.Checked = false;
            txtSuretyName2.Text = string.Empty;
            chkWitness.Checked = false;
            txtWitnessName.Text = string.Empty;

            picMember.Image = Image.FromFile(paths + "//photos//profile_img.png");
            lblMemberProfile.Text = string.Empty;
            lblMemberProfile.Visible = false;
            txtLoanDuration.Text = string.Empty;
            txtLoanInterestRate.Text = string.Empty;
            txtInterestAmount.Text = string.Empty;
            txtTotalRepaymentAmount.Text = string.Empty;
            txtMonthRepayment.Text = string.Empty;
            txtEndRepaymentDate.Text = string.Empty;

            picSurety1.Image = Image.FromFile(paths + "//photos/profile_img.png");
            picSurety1.Visible = false;

            lblSurety1.Text = string.Empty;
            lblSurety1.Visible = false;

            lblSuretyMemberID_1.Text = string.Empty;
            lblSuretyMemberID_1.Visible = false;

            picSurety2.Image = Image.FromFile(paths + "//photos/profile_img.png");
            picSurety2.Visible = false;

            lblSurety2.Text = string.Empty;
            lblSurety2.Visible = false;

            lblSuretyMemberID_2.Text = string.Empty;
            lblSuretyMemberID_2.Visible = false;

            picWitness.Image = Image.FromFile(paths + "//photos/profile_img.png");
            picWitness.Visible = false;

            lblWitness.Text = string.Empty;
            lblWitness.Visible = false;

            lblSuretyMemberID_3.Text = string.Empty;
            lblSuretyMemberID_3.Visible = false;
               
        }

        private void lblSurety2_Click(object sender, EventArgs e)
        {

        }

        private void txtFormFee_Leave(object sender, EventArgs e)
        {
            txtFormFee.Text = CheckForNumber.formatCurrency2(txtFormFee.Text);
        }
       






    }
}
