using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MainApp
{
    class ActivityLog
    {
        public static void logActivity(string UserID, string ActivityType, string Description)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Insert into ActivityLog(UserID,ActivityType,Description)" +
                "Values(@UserID,@ActivityType,@Description)";

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;

            #region cmd parameters
            cmd.Parameters.Add("@UserID", SqlDbType.Int);
            cmd.Parameters["@UserID"].Value = Convert.ToInt16(UserID);

            cmd.Parameters.Add("@ActivityType", SqlDbType.NVarChar, 50);
            cmd.Parameters["@ActivityType"].Value = ActivityType.ToString();

            cmd.Parameters.Add("@Description", SqlDbType.NVarChar, 600);
            cmd.Parameters["@Description"].Value = Description.ToString();
            #endregion

            try
            {
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                conn.Close();
            }


        }
       
    }
}
