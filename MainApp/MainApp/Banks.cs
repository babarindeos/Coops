using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MainApp
{
    public static class Banks
    {
        public static DataSet GetBanks()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select BankID, BankName, Description from Banks order by BankName";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Banks");

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                conn.Close();
            }

            return ds;
        }
    }
}
