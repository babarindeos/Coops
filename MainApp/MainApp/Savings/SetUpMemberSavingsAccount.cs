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
    public partial class SetUpMemberSavingsAccount : Form
    {
        string memberFileNo = null;
        int myselectedmemberID = 0;
        
       

        public SetUpMemberSavingsAccount()
        {
            InitializeComponent();
        }

        private void SetUpMemberSavingsAccount_Load(object sender, EventArgs e)
        {
            //ListView Properties Settings
            lstVSavings.View = View.Details;
            lstVSavings.FullRowSelect = true;

            //ListView Columns Name
            lstVSavings.Columns.Add("ID", 0);
            lstVSavings.Columns.Add("Savings Type", 300);
            lstVSavings.Columns.Add("Amount", 200);
            lstVSavings.Columns.Add("Date Created", 200);

            txtRegularSavings.TextAlign = HorizontalAlignment.Right;
            //txtShares.TextAlign = HorizontalAlignment.Right;

            txtSavingsAmount.TextAlign = HorizontalAlignment.Right;

           
        }

        private void btnFindRecord_Click(object sender, EventArgs e)
        {
            memberFileNo = txtFileNo.Text.Trim();

            setAndClearFieldsToDefault();

            if (txtFileNo.Text == string.Empty)
            {
                MessageBox.Show("File No is required to perform a search", "SetUp Member Savings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                loadMemberRegisteredSavingsType();
            }


            if (cboSavingsType.Items.Count==0 && myselectedmemberID != 0 )
            {
                //Load Savings Type after loading of Member's Savings Type
                loadSavingsType();
            }
            
        }

        private void loadMemberRegisteredSavingsType()
        {
            decimal totalSavings = 0;
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select m.MemberID, m.FileNo, m.Title + ' ' + m.LastName + ' ' + m.MiddleName + ' ' +  m.FirstName as [FullName], "+
                "m.Photo, m.DateCreated as RegDateCreated, t.SavingsName, s.SavingsAcctID, s.Amount, s.Remark, " +
                "s.DateCreated as SavingsDateCreated from Members m left join MemberSavingsTypeAcct s on m.MemberID=s.MemberID " +
                "left join SavingsType t on s.SavingsTypeID=t.SavingsTypeID where m.FileNo='" + txtFileNo.Text.Trim() + "'";
            
            /**
            string strSharesQuery = "Select m.MemberID, m.FileNo, s.Shares from Members m " +
                "inner join Shares s on m.MemberID=s.MemberID where m.FileNo='" + txtFileNo.Text.Trim() + "'";
             **/


            SqlCommand cmd = new SqlCommand(strQuery, conn);
            //SqlCommand cmdShares = new SqlCommand(strSharesQuery, conn);
            
            try
            {
                conn.Open();

                /****Execute and read shares --- Modification after first Observation meeting with Client
                SqlDataReader reader = cmdShares.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        txtShares.Text = CheckForNumber.formatCurrency(reader["Shares"].ToString());
                    }
                }
                reader.Close();
                 * 
                 * ***/
                //Execute and read Regular Savings and other savings

                SqlDataReader reader = cmd.ExecuteReader();
                int recordCount = 0;
                lstVSavings.Items.Clear();


                //Check if record is found and start performing operation
                if (reader.HasRows)
                {
                    string paths = PhotoPath.getPath();

                    picMember.Visible = true;
                    lblMemberProfileInfo.Visible = true;
                    lblRegistrationDate.Visible = true;

                    #region Read Data from Reader
                    while (reader.Read())
                    {
                        recordCount++;

                        if (recordCount == 1)
                        {
                            //MessageBox.Show("Record Count: " + recordCount.ToString());
                            if (reader["Photo"].ToString() != string.Empty)
                            {
                                picMember.Image = Image.FromFile(paths + "\\photos\\" + reader["Photo"].ToString());                                
                            }
                            else
                            {
                                picMember.Image = Image.FromFile(paths + "\\photos\\profile_img.png");
                            }
                            lblMemberProfileInfo.Text = reader["FullName"].ToString() + "\n" + reader["FileNo"].ToString();
                            lblRegistrationDate.Text = "Member since " + string.Format("{0:ddd, MMM d, yyyy}", reader["RegDateCreated"]);
                            myselectedmemberID = (int)reader["MemberID"];

                        }

                        if (reader["Remark"].ToString() == "Shares Savings")
                        {
                            txtRegularSavings.Text = CheckForNumber.formatCurrency(reader["Amount"].ToString());
                            totalSavings += Convert.ToDecimal(reader["Amount"]);
                            continue;
                           
                        }

                        string[] row = {reader["SavingsAcctID"].ToString(), reader["Remark"].ToString(), CheckForNumber.formatCurrency(reader["Amount"].ToString()), string.Format("{0:ddd, MMM d, yyyy}", reader["SavingsDateCreated"])};
                        ListViewItem item = new ListViewItem(row);
                        lstVSavings.Items.Add(item);
                        
                        totalSavings += Convert.ToDecimal(reader["Amount"]);
                        
                    }
                    #endregion



                }
                else
                {
                    MessageBox.Show("Sorry, Record with that FileNo is not found", "Members Savings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                lblRecordNo.Text = "No. of Records : " + recordCount;
                lblTotalSavings.Text = "Savings Total: " + CheckForNumber.formatCurrency2(totalSavings.ToString());
                lblTotalSavings.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "-- loadMemberRegisteredSavingsType -- ");
            }
            finally
            {
                conn.Close();
            }
        }

        private void cboSavingsType_Click(object sender, EventArgs e)
        {
            
        }

        private void loadSavingsType()
        {
            if (memberFileNo == null || memberFileNo == string.Empty)
            {
                MessageBox.Show("Select a member record ");
            }
            else
            {
                SqlConnection conn = ConnectDB.GetConnection();
                string strQuery = "Select SavingsTypeID, SavingsName from SavingsType order by SavingsName";
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                try
                {
                    conn.Open();
                    da.Fill(ds, "SavingsType");
                    DataTable dt = ds.Tables["SavingsType"];

                    cboSavingsType.Items.Clear();
                    DataRow row = dt.NewRow();
                    row["SavingsName"] = "--  Select Savings Type to Add --";
                    dt.Rows.InsertAt(row, 0);
                    cboSavingsType.DisplayMember = "SavingsName";
                    cboSavingsType.ValueMember = "SavingsTypeID";
                    cboSavingsType.DataSource = dt;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "--loadSavingsType--");
                }
                finally
                {
                    conn.Close();
                }

            }
        }

       


        private void cboSavingsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selSavingsType = cboSavingsType.Text;

            bool matchFound = false;

            if (cboSavingsType.Text != "--  Select Savings Type to Add --")
            {
                for (int i = 0; i < lstVSavings.Items.Count; i++)
                {
                    //MessageBox.Show("SelSavingsType = " + selSavingsType.ToString() + " -  listView Item : " + lstVSavings.Items[i].SubItems[0].Text + " -- savingsTypeID -- " + cboSavingsType.SelectedValue.ToString());
                    if (selSavingsType == lstVSavings.Items[i].SubItems[1].Text)
                    {
                        matchFound = true;
                    }
                }

                if (matchFound == false)
                {
                    txtSavingsAmount.ReadOnly = false;
                    txtSavingsAmount.Enabled = true;
                    btnAddSavingsType.Enabled = true;
                }
                else if (matchFound == true)
                {
                    MessageBox.Show("You already have [" + cboSavingsType.Text + "] Savings Type Created\nYou can't run duplicate accounts.", "SetUp Savings Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSavingsAmount.ReadOnly = true;
                    txtSavingsAmount.Enabled = false;
                    btnAddSavingsType.Enabled = false;
                }
            }
        }

        private void txtSavingsAmount_Leave(object sender, EventArgs e)
        {
            bool isNumeric = CheckForNumber.isNumeric(txtSavingsAmount.Text.Trim());
            if (isNumeric)
            {

                txtSavingsAmount.Text = CheckForNumber.formatCurrency(txtSavingsAmount.Text.Trim());
            }
            else
            {
                MessageBox.Show("The amount is invalid. Please enter numeric values.", "SetUp Member Savings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddSavingsType_Click(object sender, EventArgs e)
        {
            if (txtSavingsAmount.Text.Trim() != string.Empty)
            {
                DialogResult result = MessageBox.Show("Do you wish to create [" + cboSavingsType.Text + "] Savings Type with Amount of [" + txtSavingsAmount.Text + "]", "SetUp Member Savings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    addNewSavingsType();
                }
            }
            else
            {
                MessageBox.Show("Savings Amount is required!", "SetUp Member Savings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addNewSavingsType()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Insert into MemberSavingsTypeAcct(MemberID,SavingsTypeID,Amount,Remark)Values(@MemberID,@SavingsTypeID,@Amount,@Remark)";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            #region cmd parameters
            cmd.Parameters.Add("@MemberID", System.Data.SqlDbType.Int);
            cmd.Parameters["@MemberID"].Value = myselectedmemberID;

            cmd.Parameters.Add("@SavingsTypeID", System.Data.SqlDbType.Int);
            cmd.Parameters["@SavingsTypeID"].Value = cboSavingsType.SelectedValue;

            cmd.Parameters.Add("@Amount", System.Data.SqlDbType.Decimal);
            cmd.Parameters["@Amount"].Value = txtSavingsAmount.Text.Trim();

            cmd.Parameters.Add("@Remark", System.Data.SqlDbType.NVarChar);
            cmd.Parameters["@Remark"].Value = cboSavingsType.Text;
            #endregion
            
            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Savings Types [" + cboSavingsType.Text + "] has been successfully created.", "SetUp Member Savings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadMemberRegisteredSavingsType();
                    setAndClearFieldsToDefault();

                }
                else
                {
                    MessageBox.Show("An Error has Occurred Creating Savings Type!", "SetUp Member Savings", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        private void setAndClearFieldsToDefault()
        {
            txtSavingsAmount.Clear();
            txtSavingsAmount.Enabled = false;
            txtSavingsAmount.ReadOnly = true;
            btnAddSavingsType.Enabled = false;
            btnRemoveSavingsType.Enabled = false;
        }

        private void btnRemoveSavingsType_Click(object sender, EventArgs e)
        {
            if (lstVSavings.SelectedItems.Count != 0)
            {             

                DialogResult result = MessageBox.Show("Do You Really Wish to Remove [" + lstVSavings.SelectedItems[0].SubItems[1].Text + "] Savings Type\nfrom Member's Savings Account", "SetUp Member Savings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    removeSelectedSavingsType();
                }

            }
            else
            {
                MessageBox.Show("Select a Savings Type from the List to Remove", "SetUp Member Savings", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void lstVSavings_Click(object sender, EventArgs e)
        {
            btnRemoveSavingsType.Enabled = true;
            
        }

        private void removeSelectedSavingsType()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string selSavingsAcctID = lstVSavings.SelectedItems[0].SubItems[0].Text;
            string selSavingsName = lstVSavings.SelectedItems[0].SubItems[1].Text;
            string strQuery = "Delete from MemberSavingsTypeAcct where SavingsAcctID=@SavingsAcctID";

            SqlCommand cmd = new SqlCommand(strQuery, conn);
            cmd.Parameters.Add("@SavingsAcctID", System.Data.SqlDbType.Int);
            cmd.Parameters["@SavingsAcctID"].Value = Convert.ToInt16(selSavingsAcctID);

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Savings Type [" + selSavingsName + "] has been Successfully Removed\n from Member's Account.", "SetUp Member Savings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadMemberRegisteredSavingsType();
                }
                else
                {
                    MessageBox.Show("An Error Occurred Removing [" + selSavingsName + "] Savings Type from Member's Account", "SetUp Member Savings", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void lstVSavings_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

       
    }
}
