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
    public partial class FrmRprtMemberSavings : Form
    {
        public FrmRprtMemberSavings()
        {
            InitializeComponent();
        }

        private void FrmRprtMemberSavings_Load(object sender, EventArgs e)
        {

        }

        private void txtFileNo_Leave(object sender, EventArgs e)
        {
            if (txtFileNo.Text.Trim() != string.Empty)
            {
                SqlConnection conn = ConnectDB.GetConnection();
                string strQuery = "Select Title + ' ' + LastName + ' ' + FirstName + ' ' + MiddleName as 'FullName' " +
                    "from Members " +
                    "where FileNo='" + txtFileNo.Text + "'";
                SqlCommand cmd = new SqlCommand(strQuery, conn);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            lblMemberInfo.Text = reader["FullName"].ToString();
                            lblMemberInfo.Visible = true;
                            btnSubmit.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sorry, there is no member with that FileNo.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string strFileNo;
            string strFromDate;
            string strToDate;

            if (txtFileNo.Text.Trim() != string.Empty)
            {
                strFileNo = txtFileNo.Text;
                strFromDate = dtFrom.Value.ToShortDateString();
                strToDate = dtTo.Value.ToShortDateString();

                RprtMemberSavings rptMemberSavings = new RprtMemberSavings(strFileNo, strFromDate, strToDate);
                rptMemberSavings.MdiParent = this.ParentForm;
                rptMemberSavings.Show();
            }
            else
            {
                MessageBox.Show("Member FileNo. is missing", "Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
