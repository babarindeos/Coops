using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MainApp
{
    public static class Departments
    {
        public static DataSet GetDepartmentList()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select DepartmentID, DepartmentName, Description from Departments order by DepartmentName";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Departments");
            }
            catch(Exception ex)
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
