using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace MainApp
{
    public static class BuildTempSavingsAcctType
    {
        public static void Create()
        {
            Hashtable savingsType = new Hashtable();
            savingsType.Add("99","Personal Savings");

            SqlConnection conn = ConnectDB.GetConnection();
            string strTruncate = "Truncate Table TempSavingsAcctType";
            string strQuery = "Select SavingsTypeID,SavingsName from SavingsType";
            string strInsert = "Insert into TempSavingsAcctType(SavingsTypeID,SavingsName)Values(@SavingsTypeID,@SavingsName)";

            SqlCommand cmdTruncate = new SqlCommand(strTruncate, conn);
            SqlCommand cmdQuery = new SqlCommand(strQuery,conn);
            SqlCommand cmdInsert = new SqlCommand(strInsert, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmdQuery.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        savingsType.Add(reader["SavingsTypeID"].ToString(), reader["SavingsName"].ToString());
                    }
                }

                reader.Close();
                
                //Excute Truncate Command on Table
                cmdTruncate.ExecuteNonQuery();

                //Sqlcommand parameters
                cmdInsert.Parameters.Add("@SavingsTypeID", SqlDbType.Int);
                cmdInsert.Parameters.Add("@SavingsName", SqlDbType.NVarChar, 50);

                    
                foreach (DictionaryEntry item in savingsType)
                {
                    cmdInsert.Parameters["@SavingsTypeID"].Value = item.Key;
                    cmdInsert.Parameters["@SavingsName"].Value = item.Value;
                    cmdInsert.ExecuteNonQuery();
                }

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
