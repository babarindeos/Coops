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
    public partial class FindMember : Form
    {
        public FindMember()
        {
            InitializeComponent();
        }

        private void FindMember_Load(object sender, EventArgs e)
        {
            loadMembersIntoList();

            //Savings ListView Properties
            lstVSavings.View = View.Details;
            lstVSavings.FullRowSelect = true;
            

            //Setting ListView Columns
            lstVSavings.Columns.Add("Savings Type", 250);
            lstVSavings.Columns.Add("Amount", 100);
        }

        private void loadMembersIntoList()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "select MemberID,FileNo,Title + ' ' + LastName + ' ' + MiddleName + ' ' + FirstName as FullName from Members order by FileNo";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int counter = 0;
                lstMembers.Items.Clear();
                while (reader.Read())
                {
                    lstMembers.Items.Add(reader["FileNo"] + " - " + reader["FullName"]);
                    counter++;
                }

                lblRecordNo.Text = "No. of Records : " + counter;
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

        private void lstMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (grpMemberInfo.Visible == false)
            {
                grpMemberInfo.Visible = true;
            }

            //Clear lstVSavingsType of Existing Information
            lstVSavings.Items.Clear();

            int memberID = 0;

            string recordIdentifier = lstMembers.SelectedItem.ToString();
            string selectedRecordFileNo = recordIdentifier.Substring(0, recordIdentifier.IndexOf("-")).Trim();

            SqlConnection conn = ConnectDB.GetConnection();
            
            //Get Member Profile Info
            memberID = fetchMemberProfileData(memberID, selectedRecordFileNo, conn);

            //Get Member Shares
            fetchMemberSharesInfo(memberID, conn);

            fetchMemberSavingsAcct(memberID, conn);
        }

        private void fetchMemberSharesInfo(int memberID, SqlConnection conn)
        {
            string strShares = "Select MemberID, Shares from Shares where MemberID=" + memberID;
            SqlCommand cmdShares = new SqlCommand(strShares, conn);
            try
            {
                conn.Open();
                SqlDataReader readShares = cmdShares.ExecuteReader();
                if (readShares.HasRows)
                {
                    readShares.Read();
                    string savingsType = "Shares";
                    string amount = readShares["Shares"].ToString();
                    amount = string.Format("{0:0,0.00}", Convert.ToDecimal(amount));

                    string[] row = { savingsType, amount };
                    ListViewItem item = new ListViewItem(row);
                    lstVSavings.Items.Add(item);
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

        private int fetchMemberProfileData(int memberID, string selectedRecordFileNo, SqlConnection conn)
        {
            
            string strQuery = "Select m.MemberID, m.FileNo, m.Title, m.FirstName, m.MiddleName, m.LastName, m.Gender, m.Address," +
                "m.LGA, s.State, m.Phone, m.Email, d.DepartmentName, b.BankName, m.AccountNo, m.Photo,m.NOKFullName,m.NOKAddress," +
                "m.NOKPhone from Members m inner join States s on m.StateID = s.StateID " +
                "inner join Departments d on m.DepartmentID = d.DepartmentID " +
                "inner join Banks b on m.BankID = b.BankID " +
                "where m.FileNo='" + selectedRecordFileNo + "'";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtFileNo.Text = reader["FileNo"].ToString();
                    txtTitle.Text = reader["Title"].ToString();
                    txtFirstName.Text = reader["FirstName"].ToString();
                    txtMIddleName.Text = reader["MiddleName"].ToString();
                    txtLastName.Text = reader["LastName"].ToString();
                    txtGender.Text = (reader["Gender"].ToString() == "M" ? "Male" : "Female");
                    txtAddress.Text = reader["Address"].ToString();
                    txtLGA.Text = reader["LGA"].ToString();
                    txtState.Text = reader["State"].ToString();
                    txtPhone.Text = reader["Phone"].ToString();
                    txtEmail.Text = reader["EMail"].ToString();
                    txtDepartment.Text = reader["DepartmentName"].ToString();
                    txtBank.Text = reader["BankName"].ToString();
                    txtAccountNo.Text = reader["AccountNo"].ToString();
                    txtNOKName.Text = reader["NOKFullName"].ToString();
                    txtNOKAddress.Text = reader["NOKAddress"].ToString();
                    txtNOKPhone.Text = reader["NOKPhone"].ToString();

                    if (reader["Photo"].ToString() != string.Empty)
                    {
                        
                        //Load User picture
                        string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 9));
                        picMember.Image = Image.FromFile(paths + "\\photos\\" + reader["Photo"].ToString());
                        //MessageBox.Show(paths);
                    }

                    memberID = (int)reader["MemberID"];

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
            return memberID;
        }

        private void fetchMemberSavingsAcct(int memberID, SqlConnection conn)
        {
            string strSavingsAcct = "Select MemberID, SavingsTypeID, Amount, Remark from MemberSavingsTypeAcct where MemberID=" + memberID + " order by SavingsTypeID desc";
            SqlCommand cmdSavingsAcct = new SqlCommand(strSavingsAcct, conn);

            try
            {
                conn.Open();
                SqlDataReader readerSavingsAcct = cmdSavingsAcct.ExecuteReader();
                if (readerSavingsAcct.HasRows)
                {
                    while (readerSavingsAcct.Read())
                    {
                        string savingTypeAcct = readerSavingsAcct["Remark"].ToString();
                        string amount = readerSavingsAcct["Amount"].ToString();
                        amount = string.Format("{0:0,0.00}", Convert.ToDecimal(amount));

                        string[] row = { savingTypeAcct, amount };
                        ListViewItem item = new ListViewItem(row);
                        lstVSavings.Items.Add(item);
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

        private void btnFindMember_Click(object sender, EventArgs e)
        {
            if (txtFindMember.Text != string.Empty)
            {
                SqlConnection conn = ConnectDB.GetConnection();
                string strQuery = "Select FileNo, Title + ' ' + LastName + ' ' + MiddleName + ' ' + FirstName as FullName from Members where FileNo LIKE '%"
                    + txtFindMember.Text + "%' OR LastName LIKE '%" + txtFindMember.Text + "%' OR FirstName LIKE '%"
                    + txtFindMember.Text + "%' OR MiddleName LIKE '%" + txtMIddleName + "%' order by FileNo";
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    int counter = 0;
                    lstMembers.Items.Clear();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            lstMembers.Items.Add(reader["FileNo"] + " - " + reader["FullName"]);
                            counter++;
                        }

                    }
                    else
                    {
                        grpMemberInfo.Visible = false;
                        MessageBox.Show("Sorry, no record with that information is found", "Find Member", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    lblRecordNo.Text = "No. of Records : " + counter.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
 

            }else{
                loadMembersIntoList();
            }

        }

        private void txtFindMember_TextChanged(object sender, EventArgs e)
        {
            if (txtFindMember.Text == string.Empty)
            {
                loadMembersIntoList();
            }
        }
    }
}
