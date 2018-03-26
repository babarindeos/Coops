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
    public partial class ShowActivityLog : Form
    {
        public ShowActivityLog()
        {
            InitializeComponent();
        }

        private void ShowActivityLog_Load(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select l.ActivityLogID as [ActivityLog ID],l.UserID,u.LastName + ' ' + u.FirstName as [FullName],u.Role,l.ActivityType,l.Description " +
                "from ActivityLog l left join Users u";

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "ActivityLog");
                DataTable dt = ds.Tables["ActivityLog"];

                datGrdViewActivityLog.DataSource = dt;
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
