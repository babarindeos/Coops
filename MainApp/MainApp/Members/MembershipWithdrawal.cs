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
    public partial class MembershipWithdrawal : Form
    {
        SqlConnection conn;
        string memberID;

        public MembershipWithdrawal()
        {
            InitializeComponent();
            
        }

        private void btnFindMember_Click(object sender, EventArgs e)
        {
            conn = ConnectDB.GetConnection();
            string strQuery = "Select MemberID, FileNo, LastName + ' ' + FirstName + ' ' + MiddleName as FullName, photo from Members " +
                "where FileNo='" + txtFileNo.Text.Trim() + "'";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    memberID = reader["MemberID"].ToString();

                    lblMemberProfileInfo.Text = reader["FullName"].ToString() + "\n" + reader["FileNo"].ToString();

                    //display member photo
                    string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                    if (reader["Photo"].ToString() != null || reader["Photo"].ToString() == string.Empty)
                    {
                        picMember.Image = Image.FromFile(paths + "//photos//" + reader["Photo"].ToString());
                    }
                    picMember.Visible = true;
                    lblMemberProfileInfo.Visible = true;

                    getSavingStatus();
                    getLoanStatus();
                }
                else
                {
                    MessageBox.Show("Sorry, there is no member with that File No.", "Membership", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }finally{
                conn.Close();
            }
                
        }

        private void getSavingStatus()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select SUM(Amount) as TotalSavings from Savings where MemberID=" + memberID;
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    lblFinancialStatus.Text = "Savings:  " + CheckForNumber.formatCurrency2(reader["TotalSavings"].ToString());

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

            lblFinancialStatus.Visible = true;

        }

        private void getLoanStatus()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select count(*) as counter from Loans l " +
                "left join LoanApplication a on l.LoanApplicationID = a.LoanApplicationID " +
                "where (l.PaymentFinished is NULL or l.PaymentFinished='No') " +
                "and a.MemberID=" + memberID;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;

            try
            {
                conn.Open();
                int recFound =(int) cmd.ExecuteScalar();
                if (recFound > 0)
                {
                    strQuery = "Select SUM(l.OutstandingAmount) as Outstanding from Loans l " +
                                 "left join LoanApplication a on l.LoanApplicationID = a.LoanApplicationID " +
                                "where (l.PaymentFinished is NULL or l.PaymentFinished='No') " +
                                "and a.MemberID=" + memberID;
                    cmd.CommandText = strQuery;

                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    string outstandingAmount = reader["Outstanding"].ToString();
                    lblFinancialStatus.Text += "\nOutstanding Loan: " + CheckForNumber.formatCurrency2(outstandingAmount) + " from " + recFound.ToString() + " Loan Applications";
                    reader.Close();
                }
                else
                {
                    lblFinancialStatus.Text += "\n" + "No Outstanding Loan to pay.";
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

        private void txtComment_TextChanged(object sender, EventArgs e)
        {
            if (txtComment.Text == string.Empty)
            {
                btnWithdraw.Enabled = false;
            }
            else
            {
                btnWithdraw.Enabled = true;
            }
        }

        private void btnShowHide_Click(object sender, EventArgs e)
        {
            if (btnShowHide.Text == "Show Withdrawned Sheet")
            {
                this.Height = 523;
                btnShowHide.Text = "Hide Withdrawned Sheet";
            }
            else
            {
                this.Height = 207;
                btnShowHide.Text = "Show Withdrawned Sheet";
            }
        }

        private void MembershipWithdrawal_Load(object sender, EventArgs e)
        {
            
            this.Height = 207;
        }
    }
}
