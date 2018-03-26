using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data.SqlClient;

namespace MainApp
{
    class Cl_UnpostDeductions
    {
        public string unpostSavingsDeductions(SqlConnection conn, SqlCommand cmd, List<string> selDeductionTransactionDel)
        {
            int statusFlag = 0;
            foreach (string child in selDeductionTransactionDel)
            {                
                cmd.CommandText = "Delete from Savings where SavingSource='Deduction' AND TransactionID='" + child + "'";
                statusFlag = cmd.ExecuteNonQuery();                
            }
            return statusFlag.ToString();
        }

        public string unpostSavingsDeductions(SqlConnection conn, SqlCommand cmd, int memberID, string selDedTransactionId)
        {
            int statusFlag = 0;

            cmd.CommandText = "Delete from Savings where SavingSource='Deduction' AND MemberID=" + memberID + " AND TransactionID='" + selDedTransactionId + "'";
            statusFlag = cmd.ExecuteNonQuery();

            return statusFlag.ToString();
        }


        public string unpostLoansDeduction(SqlConnection conn, SqlCommand cmd, List<string> selDeductionTransactionDel)
        {
            int statusFlag = 0;
            foreach (string child in selDeductionTransactionDel)
            {
                cmd.CommandText = "Delete from LoanRepayment where RepayTransactID='" + child + "'";
                statusFlag = cmd.ExecuteNonQuery();                
            }
            return statusFlag.ToString();
        }

        public string unpostLoansDeduction(SqlConnection conn, SqlCommand cmd, int memberID, string selDedTransactionId)
        {
            int statusFlag = 0;
           
                cmd.CommandText = "Delete from LoanRepayment where RepayTransactID='" + selDedTransactionId + "' AND MemberID=" + memberID;
                statusFlag = cmd.ExecuteNonQuery();
            
            return statusFlag.ToString();
        }

        public string unpostDeductions(SqlConnection conn, SqlCommand cmd, List<string> selDeductionTransactionDel, string selDelMonth, int selDelYear)
        {
            int statusFlag = 0;
            //int monthInNum = ConvertMonthToNum(selDelMonth);
            

            foreach (string child in selDeductionTransactionDel)
            {
                cmd.CommandText = "Delete from Deductions where TransactionID='" + child + "'";
                statusFlag = cmd.ExecuteNonQuery();
            }
            return statusFlag.ToString();
        }

        public string unpostDeductions(SqlConnection conn, SqlCommand cmd, int memberID, string selDedTransactionId, string selDelMonth, int selDelYear)
        {
            int statusFlag = 0;
            int monthInNum = ConvertMonthToNum(selDelMonth);            
            
                cmd.CommandText = "Delete from Deductions where TransactionID='" + selDedTransactionId + "' AND MemberID=" + memberID + 
                    " AND Month=" + monthInNum + " AND Year=" + selDelYear;
                statusFlag = cmd.ExecuteNonQuery();
            
            return statusFlag.ToString();
        }

        private int ConvertMonthToNum(string selDelMonth)
        {
            int monthInNum = 0;
            //Convert Month to Number
            switch (selDelMonth)
            {
                case "January":
                    monthInNum = 1;
                    break;
                case "February":
                    monthInNum = 2;
                    break;
                case "March":
                    monthInNum = 3;
                    break;
                case "April":
                    monthInNum = 4;
                    break;
                case "May":
                    monthInNum = 5;
                    break;
                case "June":
                    monthInNum = 6;
                    break;
                case "July":
                    monthInNum = 7;
                    break;
                case "August":
                    monthInNum = 8;
                    break;
                case "September":
                    monthInNum = 9;
                    break;
                case "October":
                    monthInNum = 10;
                    break;
                case "November":
                    monthInNum = 11;
                    break;
                case "December":
                    monthInNum = 12;
                    break;
            }
            return monthInNum;
        }

        public string unpostDeductionDetails(SqlConnection conn, SqlCommand cmd, List<string> selDeductionTransactionDel)
        {
            int statusFlag = 0;
            foreach (string child in selDeductionTransactionDel)
            {
                cmd.CommandText = "Delete from DeductionDetails where TransactionID='" + child + "'";
                statusFlag = cmd.ExecuteNonQuery();
            }
            return statusFlag.ToString();
        }

        public string unpostDeductionDetails(SqlConnection conn, SqlCommand cmd, int memberID, string selDedTransactionId)
        {
            int statusFlag = 0;
            
                cmd.CommandText = "Delete from DeductionDetails where TransactionID='" + selDedTransactionId + "'";
                statusFlag = cmd.ExecuteNonQuery();
            
            return statusFlag.ToString();
        }

        public string unpostDeductionDates(SqlConnection conn, SqlCommand cmd, string selDelMonth, int selDelYear)
        {
            int statusFlag = 0;

            switch (selDelMonth)
            {
                case "January":
                    selDelMonth = "1";
                    break;
                case "February":
                    selDelMonth = "2";
                    break;
                case "March":
                    selDelMonth = "3";
                    break;
                case "April":
                    selDelMonth = "4";
                    break;
                case "May":
                    selDelMonth = "5";
                    break;
                case "June":
                    selDelMonth = "6";
                    break;
                case "July":
                    selDelMonth = "7";
                    break;
                case "August":
                    selDelMonth = "8";
                    break;
                case "September":
                    selDelMonth = "9";
                    break;
                case "October":
                    selDelMonth = "10";
                    break;
                case "November":
                    selDelMonth = "11";
                    break;
                case "December":
                    selDelMonth = "12";
                    break;
            }
                        
            cmd.CommandText = "Delete from DeductionDates where Month='" + selDelMonth + "' and Year='" + selDelYear + "'";
            statusFlag = cmd.ExecuteNonQuery();

            return statusFlag.ToString();
        }

      

    }
}
