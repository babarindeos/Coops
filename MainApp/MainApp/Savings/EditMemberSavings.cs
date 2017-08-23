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
    public partial class EditMemberSavings : Form
    {
        int myselectedmemberID = 0;

        public EditMemberSavings()
        {
            InitializeComponent();
        }

        private void EditMemberSavings_Load(object sender, EventArgs e)
        {
            //Setting ListView Properties
            lstVSavings.View = View.Details;
            lstVSavings.FullRowSelect = true;

            //Setting Columns
            lstVSavings.Columns.Add("ID", 0);
            lstVSavings.Columns.Add("Savings Type", 250);
            lstVSavings.Columns.Add("Amount", 200);
            lstVSavings.Columns.Add("Date Created", 200);

            txtAmount.TextAlign = HorizontalAlignment.Right;
        }

        private void txtFileNo_TextChanged(object sender, EventArgs e)
        {
            if (txtFileNo.Text != string.Empty)
            {
                btnFindMember.Enabled = true;
            }
            else
            {
                btnFindMember.Enabled = false;
            }
        }

        private void btnFindMember_Click(object sender, EventArgs e)
        {

            clearAndSetControls();
            decimal totalSavings = 0;
            SqlConnection conn = ConnectDB.GetConnection();

            /** - Modified about First Meeting
            string strSharesQuery = "Select m.MemberID, m.FileNo, s.SharesID, s.Shares, s.DateCreated from Members m " +
                "inner join Shares s on m.MemberID=s.MemberID where m.FileNo='" + txtFileNo.Text.Trim() + "'";
            
             * **/

            string strQuery = "Select m.MemberID, m.FileNo, m.Title + ' ' + m.LastName + ' ' + m.MiddleName + ' ' +  m.FirstName as [FullName], m.Photo, m.DateCreated as RegDateCreated," +
                "t.SavingsName, s.SavingsAcctID, s.Amount, s.Remark, s.DateCreated as SavingsDateCreated from Members m left outer join MemberSavingsTypeAcct s on m.MemberID=s.MemberID " +
                "left outer join SavingsType t on s.SavingsTypeID=t.SavingsTypeID where m.FileNo='" + txtFileNo.Text.Trim() + "'";

            //SqlCommand cmdShares = new SqlCommand(strSharesQuery, conn);
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            try
            {
                conn.Open();
                lstVSavings.Items.Clear();

               /** Modified after first meeting....Shares is type of Savings
                SqlDataReader reader = cmdShares.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        string[] row = { reader["SharesID"].ToString(), "Shares", CheckForNumber.formatCurrency(reader["Shares"].ToString()), string.Format("{0:ddd, MMM d, yyyy}", reader["DateCreated"]) };
                        ListViewItem item = new ListViewItem(row);
                        lstVSavings.Items.Add(item);
                    }
                }
                reader.Close();
                * */


                int counter = 0;


                string paths = PhotoPath.getPath();
                //MessageBox.Show(Application.StartupPath.ToString());
                //MessageBox.Show(paths.ToString());
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    picMember.Visible = true;
                    lblMemberProfileInfo.Visible = true;
                    lblRegistrationDate.Visible = true;

                    while (reader.Read())
                    {
                        string[] row = { reader["SavingsAcctID"].ToString(), reader["Remark"].ToString(), CheckForNumber.formatCurrency(reader["Amount"].ToString()), string.Format("{0:ddd, MMM d, yyyy}", reader["RegDateCreated"]) };
                        ListViewItem item = new ListViewItem(row);
                        lstVSavings.Items.Add(item);

                        counter++;
                        totalSavings += Convert.ToDecimal(reader["Amount"]);
                        if (counter == 1)
                        {
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
                    }
                }
                else
                {
                    clearAndSetControls();
                    MessageBox.Show("Sorry, Record with File No. [" + txtFileNo.Text + "] is not Found!"  , "Edit Member Savings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
                lblRecordNo.Text = "No. of Records: " + counter.ToString();
                lblTotalSavings.Text = "Savings Total:   " + CheckForNumber.formatCurrency2(totalSavings.ToString());
                lblTotalSavings.Visible = true;
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

        private void clearAndSetControls()
        {
            picMember.Visible = false;
            lblMemberProfileInfo.Visible = false;
            lblRegistrationDate.Visible = false;
            txtAmount.Clear();
            txtAmount.Enabled = false;
            txtComment.Clear();
            txtComment.Enabled = false;
            txtSavingsType.Clear();
            btnUpdate.Enabled = false;
        }

        private void lstVSavings_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lstVSavings_Click(object sender, EventArgs e)
        {
            txtSavingsType.Text = lstVSavings.SelectedItems[0].SubItems[1].Text;
            txtAmount.Text = lstVSavings.SelectedItems[0].SubItems[2].Text;
            btnUpdate.Enabled = true;
            txtAmount.Enabled = true;
            txtComment.Enabled = true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lstVSavings.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a Savings Type to Edit Savings Amount", "Edit Member Savings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtAmount.Text == string.Empty)
                {
                    MessageBox.Show("Amount is Required to Effect an Update", "Edit Member Savings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (CheckForNumber.isNumeric(txtAmount.Text))
                    {
                        updateMemberSavings();
                    }
                    else
                    {
                        MessageBox.Show("Amount Entered is Invalid", "Edit Member Savings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            txtAmount.Text = CheckForNumber.formatCurrency(txtAmount.Text.Trim());
        }

        private void updateMemberSavings()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string savingsType = lstVSavings.SelectedItems[0].SubItems[1].Text;
            string savingsID = lstVSavings.SelectedItems[0].SubItems[0].Text;
            string amount = txtAmount.Text.Trim();

            //string strUpdateShares = "Update Shares set Shares=@Shares where SharesID=@SharesID";
            //SqlCommand cmdUpdateShares = new SqlCommand(strUpdateShares, conn);

            #region cmd parameters
            //cmdUpdateShares.Parameters.Add("@Shares", System.Data.SqlDbType.Decimal);
            //cmdUpdateShares.Parameters["@Shares"].Value = amount;

            //cmdUpdateShares.Parameters.Add("@SharesID", System.Data.SqlDbType.Int);
            //cmdUpdateShares.Parameters["@SharesID"].Value = savingsID;

            DateTime dateModified = DateTime.Now;

            string strUpdateSavings = "Update MemberSavingsTypeAcct set Amount=@Amount, DateModified=@dateModified where SavingsAcctID=@SavingsAcctID";
            SqlCommand cmdUpdateSavings = new SqlCommand(strUpdateSavings, conn);

            cmdUpdateSavings.Parameters.Add("@Amount", System.Data.SqlDbType.Decimal);
            cmdUpdateSavings.Parameters["@Amount"].Value = amount;

            cmdUpdateSavings.Parameters.Add("@SavingsAcctID", System.Data.SqlDbType.Int);
            cmdUpdateSavings.Parameters["@SavingsAcctID"].Value = savingsID;

            cmdUpdateSavings.Parameters.Add("@dateModified", System.Data.SqlDbType.DateTime);
            cmdUpdateSavings.Parameters["@dateModified"].Value = dateModified;
            #endregion cmd parameters
            
            try
            {
                conn.Open();

                int rowAffected = 0;
                
                rowAffected = cmdUpdateSavings.ExecuteNonQuery();
                

                if (rowAffected > 0)
                {
                    MessageBox.Show("Savings Account has been Successfully Updated", "Edit Member Savings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lstVSavings.SelectedItems[0].SubItems[2].Text = txtAmount.Text.Trim();
                    txtAmount.Clear();
                    txtComment.Clear();
                    txtAmount.Enabled = false;
                    txtComment.Enabled = false;
                    btnUpdate.Enabled = false;
                    lstVSavings.SelectedItems.Clear();

                    //recalculate totalSavings
                    decimal totalSavings = 0;
                    for (int i = 0; i < lstVSavings.Items.Count; i++)
                    {
                        totalSavings += Convert.ToDecimal(lstVSavings.Items[i].SubItems[2].Text.ToString());
                    }
                    lblTotalSavings.Text = "Savings Total:  " + CheckForNumber.formatCurrency2(totalSavings.ToString());
                }
                else
                {
                    MessageBox.Show("An Error has Occurred Updating Savings", "Edit Member Savings", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
