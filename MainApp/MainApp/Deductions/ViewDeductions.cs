using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace MainApp
{
    public partial class ViewDeductions : Form
    {
        public ViewDeductions()
        {
            InitializeComponent();
        }

        private void ViewDeductions_Load(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select m.MemberID, m.FileNo + ' ' + m.LastName + ' ' + m.FirstName  as Fullname," +
                "d.Month, d.Year, d.Savings, d.Loans, d.Total, d.TransactionID, d.DatePosted from Deductions d inner join Members m on d.MemberID=m.MemberID";

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Deductions");
                DataTable dt = ds.Tables["Deductions"];

                datGrdVwDeductions.DataSource = dt;

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
