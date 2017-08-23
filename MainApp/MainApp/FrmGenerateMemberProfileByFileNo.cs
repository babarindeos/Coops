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
    public partial class FrmGenerateMemberProfileByFileNo : Form
    {
        public FrmGenerateMemberProfileByFileNo()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Check if the member exist
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select count(*) from Members where FileNo=@FileNo";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;

            cmd.Parameters.Add("@FileNo", SqlDbType.NVarChar, 50);
            cmd.Parameters["@FileNo"].Value = txtFileNo.Text;

            try
            {
                conn.Open();
                int recordFound = Convert.ToInt16(cmd.ExecuteScalar());
                if (recordFound > 0)
                {

                    FrmReportMemberProfile frmReportMemberProfile = new FrmReportMemberProfile(txtFileNo.Text);
                    frmReportMemberProfile.Show();
                }
                else
                {
                    MessageBox.Show("There's no member with that File No.", "Report Generation", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
