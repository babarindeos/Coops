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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select UserId, Username, Password, Lastname, Firstname from Users where Username=@Username and Password=@Password";

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;

            cmd.Parameters.Add("@Username", SqlDbType.NVarChar, 50);
            cmd.Parameters["@Username"].Value = txtUsername.Text.Trim();

            cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50);
            cmd.Parameters["@Password"].Value = txtPassword.Text.Trim();

            try
            {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    MainApp mainApp = new MainApp(reader["UserId"].ToString(),reader["LastName"].ToString(),reader["FirstName"].ToString());
                    mainApp.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Authorised User Login Credentials", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
