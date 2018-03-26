using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MainApp
{
    public class SavingsByAcctType
    {
        SqlConnection conn = ConnectDB.GetConnection();
        string strQuery = string.Empty;

        public SavingsByAcctType()
        {
            
        }

        public decimal getContributionSavings(string memberID,int savingsTypeID)
        {
            decimal contributionSavings = 0;
            string strFound = "Select count(*) from  Savings s inner join Contributions c " +
                "on c.SavingsID=s.SavingsID where s.MemberID='" + memberID +
                "' and c.SavingsAcctID=" + savingsTypeID;

            strQuery = "Select SUM(s.Amount) from  Savings s inner join Contributions c " +
                "on c.SavingsID=s.SavingsID where s.MemberID='" + memberID +
                "' and c.SavingsAcctID=" + savingsTypeID;

            SqlCommand cmdFound = new SqlCommand(strFound, conn);
            SqlCommand cmdQuery = new SqlCommand(strQuery, conn);
            try
            {
                conn.Open();
                int rowFound = Convert.ToInt16(cmdFound.ExecuteScalar());
                if (rowFound > 0)
                {
                    contributionSavings = Convert.ToDecimal(cmdQuery.ExecuteScalar());
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
            return contributionSavings;
        }

        public decimal getSavingsForward(string memberID, int savingsTypeID)
        {
            decimal savingsForwardByType = 0;
            string strFound = "Select count(*) from SavingsForward sf inner join Savings s " +
                "on s.SavingsID=sf.SavingsID where s.MemberID='" + memberID +
                "' and sf.SavingsTypeID=" + savingsTypeID ;
            strQuery = "Select Sum(sf.Amount) from SavingsForward sf inner join Savings s " +
                "on s.SavingsID=sf.SavingsID where s.MemberID='" + memberID +
                "' and sf.SavingsTypeID=" + savingsTypeID;

            SqlCommand cmdFound = new SqlCommand(strFound, conn);
            SqlCommand cmdQuery = new SqlCommand(strQuery, conn);

            try
            {
                conn.Open();
                int rowFound = Convert.ToInt16(cmdFound.ExecuteScalar());
                if (rowFound > 0)
                {
                    savingsForwardByType = Convert.ToDecimal(cmdQuery.ExecuteScalar());
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

            return savingsForwardByType;
        }

        public decimal getDeductionSavings(string memberID, int savingsTypeID)
        {
            decimal deductionSavingType = 0;
            SqlConnection conn = ConnectDB.GetConnection();
            string strFound = "Select count(*) from DeductionDetails dd left join Deductions d on " +
                "dd.DeductionID=d.DeductionID where d.MemberID='" + memberID + "' and dd.SavingsTypeID=" + savingsTypeID;
            string strQuery = "Select SUM(dd.Amount) from DeductionDetails dd inner join Deductions d on " +
                "dd.DeductionID=d.DeductionID where d.MemberID='" + memberID + "' and dd.SavingsTypeID=" + savingsTypeID;

            SqlCommand cmdFound = new SqlCommand(strFound, conn);
            SqlCommand cmdQuery = new SqlCommand(strQuery, conn);

            try
            {
                conn.Open();
                int rowFound = Convert.ToInt16(cmdFound.ExecuteScalar());

                if (rowFound > 0)
                {
                    deductionSavingType = Convert.ToDecimal(cmdQuery.ExecuteScalar());
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
            return deductionSavingType;
        }


        public decimal getWithdrawalSavings(string memberID, int savingsTypeID)
        {
            decimal withdrawalSavingsType = 0;
            SqlConnection conn = ConnectDB.GetConnection();
            string strFound = "Select count(*) from SavingsWithdrawal where MemberID=" + memberID + " and " +
                "SavingsTypeID=" + savingsTypeID;
            string strQuery = "Select SUM(WithdrawAmount) from SavingsWithdrawal where MemberID=" + memberID + " and " +
                "SavingsTypeID=" + savingsTypeID;

            SqlCommand cmdFound = new SqlCommand(strFound, conn);
            SqlCommand cmdQuery = new SqlCommand(strQuery, conn);

            try
            {
                conn.Open();
                int rowFound = Convert.ToInt16(cmdFound.ExecuteScalar());
                if (rowFound > 0)
                {
                    withdrawalSavingsType = Convert.ToDecimal(cmdQuery.ExecuteScalar());
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

            return withdrawalSavingsType;
        }



    }
}
