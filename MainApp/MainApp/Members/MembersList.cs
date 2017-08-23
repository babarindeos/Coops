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
    public partial class MembersList : Form
    {
        public MembersList()
        {
            InitializeComponent();
        }

        private void MembersList_Load(object sender, EventArgs e)
        {
            loadMembersRecords();

        }

        private void loadMembersRecords()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "select m.MemberID, m.FileNo as [File No.], m.Title [Title],  m.FirstName [First Name],  m.MiddleName [Mid. Name], m.LastName [Last Name], " +
                "m.Gender,m.Address, m.LGA, s.State, m.Phone, m.Email, d.DepartmentName [Department], b.BankName [Bank], m.AccountNo [Account], m.NOKFullName [Next of Kin]," +
                "m.NOKPhone [Kin Phone], m.NOKAddress [NOK Addr.] from Members m inner join States s on m.StateID = s.StateID " +
                "inner join Departments d on m.DepartmentID=d.DepartmentID " +
                "inner join Banks b on m.BankID=b.BankID";

            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Members");
                DataTable dt = ds.Tables["Members"];
                datGrdMembers.DataSource = dt;

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                datGrdMembers.Columns.Add(btn);
                btn.HeaderText = "Acct. Details";
                btn.Text = "View Details";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;

                datGrdMembers.Columns[0].Visible = false;
                lblRecordNo.Text = "No. of Records : " + dt.Rows.Count;

                

                
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

        private void btnMemberProfile_Click(object sender, EventArgs e)
        {
            MemberProfile memberProfile = new MemberProfile();

            memberProfile.ShowDialog();
        }

        private void datGrdMembers_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void datGrdMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                
                    MessageBox.Show(datGrdMembers.Rows[e.RowIndex].Cells[2].Value.ToString());
                
            }
        }

        private void datGrdMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}
