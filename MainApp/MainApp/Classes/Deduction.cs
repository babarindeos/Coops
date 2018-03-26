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
    class Deduction
    {        

        #region postSavings 
        public string postSavings(SqlConnection conn, SqlCommand cmd, SqlTransaction sqlTrans, int memberID, string transactionID, decimal totalSavings, int numOfRows, int errorflag, int selectedMonth, int selectedYear)
        {
            //Record savings in Savings Table
            cmd.CommandText = "Insert into Savings(MemberID,SavingSource,Amount,Month,Year,TransactionID)" +
                "Values(@MemberID,@SavingSource,@Amount,@Month,@Year,@TransactionID)";

            #region cmd parameters savings
            cmd.Parameters.Add("@MemberID", SqlDbType.Int);
            cmd.Parameters["@MemberID"].Value = memberID;

            cmd.Parameters.Add("@SavingSource", SqlDbType.NVarChar, 40);
            cmd.Parameters["@SavingSource"].Value = "Deduction";

            cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
            cmd.Parameters["@Amount"].Value = totalSavings;

            cmd.Parameters.Add("@Month", SqlDbType.Int);
            cmd.Parameters["@Month"].Value = selectedMonth;

            cmd.Parameters.Add("@Year", SqlDbType.Int);
            cmd.Parameters["@Year"].Value = selectedYear;

            cmd.Parameters.Add("@TransactionID", SqlDbType.NVarChar, 100);
            cmd.Parameters["@TransactionID"].Value = transactionID;
            #endregion

            numOfRows = cmd.ExecuteNonQuery();
            if (numOfRows == 0) { errorflag = 1; }
            
            return ("Saved Amount: " + totalSavings + "\n Savings status: " + numOfRows);

        }
        #endregion end postSavings

        #region postLoans
        public string postLoans(SqlConnection conn, SqlCommand cmd, SqlTransaction sqlTrans, int memberID, string transactionID, int currentRecord, int selectedMonth, int selectedYear, int numOfRows, int errorflag, decimal monthlyLoanRepayment)
        {            
            //if loan repayment is more than zero perform loan deductions
            string oppStatus = null;
         
            while (monthlyLoanRepayment > 0)
            {
                string sqlQuery = "Select a.MonthlyRepayment as MonthlyRepayment,l.AmountPaid,l.RepaymentAmount,l.OutstandingAmount,l.LoansID,l.TransactionID from LoanApplication a " +
                 "inner join Loans l on a.LoanApplicationID = l.LoanApplicationID where a.MemberID=@MemberID and l.OutstandingAmount<>0";

                cmd.CommandText = sqlQuery;

                SqlDataReader readerCount = cmd.ExecuteReader();
                int recFound = readerCount.Cast<object>().Count();
                readerCount.Close();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    
                    if (reader.Read())
                    {
                        decimal originalLoanPayment = monthlyLoanRepayment;
                        monthlyLoanRepayment = payLoanDeduction(cmd, monthlyLoanRepayment, transactionID, recFound, reader, numOfRows, errorflag);
                        oppStatus += "MonthLoanRepayment found: " + originalLoanPayment + "\n";
                    }

                }
                else
                {
                    //Deposit in Member Savings if there is not other Loan to service with the excess cash"
                    reader.Close();
                    depositExcessIntoSavings(cmd, monthlyLoanRepayment, memberID, transactionID, selectedMonth, selectedYear, numOfRows, errorflag);
                      oppStatus += "Deposit into savings : " +  monthlyLoanRepayment + "\nError Flag: " + errorflag;
                    break;
                }

                
            }//end of while (monthLoanRepayment>outstandingAmount)

           
            return oppStatus;
        }

        #endregion


        #region payLoanDeduction
        private decimal payLoanDeduction(SqlCommand cmd, decimal monthlyLoanRepayment, string transactionID, int recFound, SqlDataReader reader, int numOfRows, int errorflag)
        {
            //decimal monthlyRepayment = Convert.ToDecimal(reader["MonthlyRepayment"]);
            decimal monthlyRepayment = monthlyLoanRepayment;
            decimal amountPaid = Convert.ToDecimal(reader["AmountPaid"]);
            decimal repaymentAmount = Convert.ToDecimal(reader["RepaymentAmount"]);
            decimal outstandingAmount = Convert.ToDecimal(reader["OutstandingAmount"]);
            int loanID = (int)reader["LoansID"];
            string repayTransactionID = transactionID;
            string loanTransactionID = reader["TransactionID"].ToString();


            reader.Close();

            decimal new_outstandingAmount;
            decimal new_AmountPaid;
            decimal new_PaidCumulative;
            string new_paymentStatus;
            string new_paymentFinished;
            decimal excess = 0;


            #region if monthlyrepayment is less than outstanding repayment
            if (monthlyRepayment <= outstandingAmount)
            {
                #region monthlyRepayment is less than or equal to the outstandingAmount
                new_AmountPaid = amountPaid + monthlyRepayment;
                new_outstandingAmount = repaymentAmount - new_AmountPaid;
                new_PaidCumulative = new_AmountPaid;

                //check if loan has been completely paid
                if (new_outstandingAmount == 0)
                {
                    new_paymentStatus = "PAID";
                    new_paymentFinished = "Yes";
                }
                else
                {
                    new_paymentStatus = "Paying";
                    new_paymentFinished = "No";
                }

                string strLoanRepayment = "Insert into LoanRepayment(MemberID,LoanID,TransactionID,RepaymentAmount,PaidAmount,Outstanding,PaidCumulative,Excess,RepayTransactID)" +
                   "values(@MemberID,@LoanID,@TransactionID,@RepaymentAmount,@PaidAmount,@Outstanding,@PaidCumulative,@Excess,@RepayTransactID)";
                cmd.CommandText = strLoanRepayment;
                //set parameters for cmd
                #region cmd parameters for LoanRepayment

                cmd.Parameters.Add("@LoanID", SqlDbType.Int);
                cmd.Parameters["@LoanID"].Value = loanID;

                cmd.Parameters["@TransactionID"].Value = loanTransactionID;

                cmd.Parameters.Add("@RepaymentAmount", SqlDbType.Decimal);
                cmd.Parameters["@RepaymentAmount"].Value = repaymentAmount;

                cmd.Parameters.Add("@PaidAmount", SqlDbType.Decimal);
                cmd.Parameters["@PaidAmount"].Value = monthlyRepayment;

                cmd.Parameters.Add("@Outstanding", SqlDbType.Decimal);
                cmd.Parameters["@Outstanding"].Value = new_outstandingAmount;

                cmd.Parameters.Add("@PaidCumulative", SqlDbType.Decimal);
                cmd.Parameters["@PaidCumulative"].Value = new_PaidCumulative;

                cmd.Parameters.Add("@Excess", SqlDbType.Decimal);
                cmd.Parameters["@Excess"].Value = excess;

                cmd.Parameters.Add("@RepayTransactID", SqlDbType.NVarChar, 50);
                cmd.Parameters["@RepayTransactID"].Value = repayTransactionID;
                #endregion

                numOfRows = cmd.ExecuteNonQuery();
                if (numOfRows == 0) { errorflag = 1; }
                
                string strLoan = "update Loans set AmountPaid=@AmountPaid,OutstandingAmount=@OutstandingAmount,PaymentStatus=@PaymentStatus,PaymentFinished=@PaymentFinished " +
                    "where LoansID=@LoansID";
                cmd.CommandText = strLoan;

                //set parameters for cmd
                #region cmd parameters for Loans
                cmd.Parameters.Add("@AmountPaid", SqlDbType.Decimal);
                cmd.Parameters["@AmountPaid"].Value = new_AmountPaid;

                cmd.Parameters.Add("@OutstandingAmount", SqlDbType.Decimal);
                cmd.Parameters["@OutstandingAmount"].Value = new_outstandingAmount;

                cmd.Parameters.Add("@PaymentStatus", SqlDbType.NVarChar, 10);
                cmd.Parameters["@PaymentStatus"].Value = new_paymentStatus;

                cmd.Parameters.Add("@PaymentFinished", SqlDbType.NVarChar, 5);
                cmd.Parameters["@PaymentFinished"].Value = new_paymentFinished;

                cmd.Parameters.Add("@LoansID", SqlDbType.Int);
                cmd.Parameters["@LoansID"].Value = loanID;
                #endregion

                numOfRows = cmd.ExecuteNonQuery();
                if (numOfRows == 0) { errorflag = 1; }
                
                //No need to go through the loop, so break out  by turning monthLoanRepayment to zero (excess = 0; monthlyLoanRepayment = 0)
                monthlyLoanRepayment = excess;

                #endregion end of monthlyrepayment is less than outstanding repayment

            }
            else if (monthlyRepayment > outstandingAmount)
            {
                //if the monthlyLoanRepayment is more than the outstanding amount, that means there will 
                //be so excess left of the monthLoanRepayment. The excess should be used to pay for subsquent loan
                //repayment if it exist or deposited in the member savings.

                #region monthlyRepayment is greater than outstandingAmount

                new_AmountPaid = repaymentAmount;
                new_outstandingAmount = 0;
                new_PaidCumulative = new_AmountPaid;

                excess = monthlyRepayment - outstandingAmount;

                //Take the excess from what is left after monthly repayment and put it into monthlyLoanRepayment for subequent
                //operation for further loan repayment or depositing into member's savings

                monthlyLoanRepayment = excess;

                //check if loan has been completely paid and set status appropriately
                if (new_outstandingAmount == 0)
                {
                    new_paymentStatus = "PAID";
                    new_paymentFinished = "Yes";
                }
                else
                {
                    new_paymentStatus = "Paying";
                    new_paymentFinished = "No";
                }

                string strLoanRepayment = "Insert into LoanRepayment(MemberID,LoanID,TransactionID,RepaymentAmount,PaidAmount,Outstanding,PaidCumulative,Excess)" +
                   "values(@MemberID,@LoanID,@TransactionID,@RepaymentAmount,@PaidAmount,@Outstanding,@PaidCumulative,@Excess)";
                cmd.CommandText = strLoanRepayment;
                //set parameters for cmd
                #region cmd parameters for LoanRepayment

                cmd.Parameters.Add("@LoanID", SqlDbType.Int);
                cmd.Parameters["@LoanID"].Value = loanID;

                cmd.Parameters.Add("@RepaymentAmount", SqlDbType.Decimal);
                cmd.Parameters["@RepaymentAmount"].Value = repaymentAmount;

                cmd.Parameters.Add("@PaidAmount", SqlDbType.Decimal);
                cmd.Parameters["@PaidAmount"].Value = monthlyRepayment;

                cmd.Parameters.Add("@Outstanding", SqlDbType.Decimal);
                cmd.Parameters["@Outstanding"].Value = new_outstandingAmount;

                cmd.Parameters.Add("@PaidCumulative", SqlDbType.Decimal);
                cmd.Parameters["@PaidCumulative"].Value = new_PaidCumulative;

                cmd.Parameters.Add("@Excess", SqlDbType.Decimal);
                cmd.Parameters["@Excess"].Value = excess;
                #endregion

                numOfRows = cmd.ExecuteNonQuery();
                if (numOfRows == 0) { errorflag = 1; }
                
                string strLoan = "update Loans set AmountPaid=@AmountPaid,OutstandingAmount=@OutstandingAmount,PaymentStatus=@PaymentStatus,PaymentFinished=@PaymentFinished " +
                    "where LoansID=@LoansID";
                cmd.CommandText = strLoan;

                //set parameters for cmd
                #region cmd parameters for Loans
                cmd.Parameters.Add("@AmountPaid", SqlDbType.Decimal);
                cmd.Parameters["@AmountPaid"].Value = new_AmountPaid;

                cmd.Parameters.Add("@OutstandingAmount", SqlDbType.Decimal);
                cmd.Parameters["@OutstandingAmount"].Value = new_outstandingAmount;

                cmd.Parameters.Add("@PaymentStatus", SqlDbType.NVarChar, 10);
                cmd.Parameters["@PaymentStatus"].Value = new_paymentStatus;

                cmd.Parameters.Add("@PaymentFinished", SqlDbType.NVarChar, 5);
                cmd.Parameters["@PaymentFinished"].Value = new_paymentFinished;

                cmd.Parameters.Add("@LoansID", SqlDbType.Int);
                cmd.Parameters["@LoansID"].Value = loanID;
                #endregion

                numOfRows = cmd.ExecuteNonQuery();
                if (numOfRows == 0) { errorflag = 1; }
                
                #endregion

            }
            #endregion end of if monthlyRepayment <= outstandingAmount



            return monthlyLoanRepayment;
        }

        #endregion payLoanDeduction

        #region depositExcessIntoSavings
        private void depositExcessIntoSavings(SqlCommand cmd, decimal monthlyLoanRepayment, int memberID, string transactionID, int selectedMonth, int selectedYear, int numOfRows, int errorflag )
        {
            
            string sqlQuery = "Insert into Savings(MemberID,SavingSource,Amount,Month,Year,TransactionID) " +
                "Values(@MemberID,@SavingSource,@Amount,@Month,@Year,@TransactionID)";

            cmd.CommandText = sqlQuery;
            #region cmd Parameters
            cmd.Parameters["@MemberID"].Value = memberID;

            cmd.Parameters["@SavingSource"].Value = "Deduction - Loan Repayment Excess";

            cmd.Parameters["@Amount"].Value = monthlyLoanRepayment;

            cmd.Parameters["@Month"].Value = selectedMonth;

            cmd.Parameters["@Year"].Value = selectedYear;

            cmd.Parameters["@TransactionID"].Value = transactionID;

            #endregion end cmd parameters

            numOfRows = cmd.ExecuteNonQuery();
            if (numOfRows == 0) { errorflag = 1; }
           

        }
        #endregion end depositExcessIntoSavings


        #region Record Deduction Method
        public string recordDeduction(SqlCommand cmd, int memberID, string transactionID, int currentRecord, int selectedMonth, int selectedYear, decimal lstAllSavingsDeduction, decimal lstAllLoansDeduction, decimal lstTotalDeductions, int numOfRows, int errorflag)
        {
            
            string strQuery = "Insert into Deductions(Month,Year,MemberID,Savings,Loans,Total,TransactionID) " +
                "Values(@Month,@Year,@MemberID,@Savings,@Loans,@Total,@TransactionID)";
            cmd.CommandText = strQuery;

            #region cmd parameters
            cmd.Parameters["@Month"].Value = selectedMonth;

            cmd.Parameters["@Year"].Value = selectedYear;

            cmd.Parameters["@MemberID"].Value = memberID;

            cmd.Parameters.Add("@Savings", SqlDbType.Decimal);
            cmd.Parameters["@Savings"].Value = lstAllSavingsDeduction;

            cmd.Parameters.Add("@Loans", SqlDbType.Decimal);
            cmd.Parameters["@Loans"].Value = lstAllLoansDeduction;

            cmd.Parameters.Add("@Total", SqlDbType.Decimal);
            cmd.Parameters["@Total"].Value = lstTotalDeductions;

            cmd.Parameters["@TransactionID"].Value = transactionID;

            #endregion cmd parameters

            numOfRows = cmd.ExecuteNonQuery();
            if (numOfRows == 0) { errorflag = 1; };

            //return "Savings: " + lstAllSavingsDeduction + "\nLoans: " + lstAllLoansDeduction +"\nTotal: " + lstTotalDeductions;
            return numOfRows.ToString();

        }

        #endregion Record Deduction Method

        #region Record Deduction Details
        public string recordDeductionDetails(SqlCommand cmd, int memberID, string transactionID, int currentRecord, int numOfRows, int errorflag, decimal  lstAllSavingsDeduction, decimal lstAllLoansDeduction, string repaymentLoanType,bool servicingLoan, bool loanMoreThanSavings)
        {
            //retrieve the DeductionID for this Deduction Operation
            string strQuery = "Select DeductionID,TransactionID from Deductions where TransactionID=@TransactionID and MemberID=@MemberID";
            cmd.CommandText = strQuery;
            #region cmd parameters
            cmd.Parameters["@TransactionID"].Value = transactionID;
            cmd.Parameters["@MemberID"].Value = memberID;
            #endregion

            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int deductionID = (int)reader["DeductionID"];            
            reader.Close();

            //Get the savings of the member that amounts for the total monthly savings
            
            strQuery = "Select MemberID,Amount,Remark,SavingsTypeID from MemberSavingsTypeAcct where MemberID=@MemberID";
            cmd.CommandText = strQuery;

            #region cmd parameters;
            cmd.Parameters["@MemberID"].Value = memberID;
            #endregion

            Hashtable memberSavings = new Hashtable();
            Hashtable memberSavingsType = new Hashtable();

            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    memberSavings.Add(reader["Remark"], reader["Amount"]);
                    memberSavingsType.Add(reader["Remark"], reader["SavingsTypeID"]);
                }

                reader.Close();
            }

            //Insert Savings into DeductionsDetails
            strQuery = "Insert into DeductionDetails(DeductionID,DeductionType,SavingsTypeID,Amount,Remarks,TransactionID)Values" +
               "(@DeductionID,@DeductionType,@SavingsTypeID,@Amount,@Remarks,@TransactionID)";

            cmd.CommandText = strQuery;
            cmd.Parameters.Add("@DeductionID", SqlDbType.Int);
            cmd.Parameters.Add("@DeductionType", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@SavingsTypeID", SqlDbType.NVarChar, 10);
            cmd.Parameters.Add("@Remarks", SqlDbType.NVarChar,400);

            

            if ((lstAllLoansDeduction==0) && (lstAllSavingsDeduction>0))
            {
                foreach (DictionaryEntry child in memberSavings)
                {
                    #region cmd parameters

                    cmd.Parameters["@DeductionID"].Value = deductionID;

                    cmd.Parameters["@DeductionType"].Value = child.Key;

                    cmd.Parameters["@SavingsTypeID"].Value = memberSavingsType[child.Key];

                    cmd.Parameters["@Amount"].Value = child.Value;

                    cmd.Parameters["@Remarks"].Value = string.Empty;

                    cmd.Parameters["@TransactionID"].Value = transactionID;

                    #endregion cmd parameters

                    numOfRows = cmd.ExecuteNonQuery();
                    if (numOfRows == 0) { errorflag = 1; }
                    // MessageBox.Show(child.Key.ToString() + " -  " + child.Value.ToString() + "\nError Flag: " + errorflag);
                   
                }
            } 
            else if ((lstAllLoansDeduction>0) && (lstAllSavingsDeduction == 0))
            {
                #region cmd parameters
                cmd.Parameters["@DeductionId"].Value = deductionID;

                cmd.Parameters["@DeductionType"].Value = "Savings";

                cmd.Parameters["@SavingsTypeID"].Value = string.Empty;

                cmd.Parameters["@Amount"].Value = 0;

                cmd.Parameters["@Remarks"].Value = "No Savings, loan repayment.";

                cmd.Parameters["@TransactionID"].Value = transactionID;
                #endregion end of cmd parameters
                numOfRows = cmd.ExecuteNonQuery();
                if (numOfRows == 0) { errorflag = 1; }

            }
            else if ((lstAllLoansDeduction>0) && (lstAllSavingsDeduction>0))
            {
                decimal savingsAmount = 0;
                decimal theAmountSaved = 0;
                foreach (DictionaryEntry child in memberSavings)
                {
                    savingsAmount = Convert.ToDecimal(child.Value);
                    if (savingsAmount >= lstAllSavingsDeduction)
                    {
                        theAmountSaved = lstAllSavingsDeduction;
                    }
                    else
                    {
                        lstAllSavingsDeduction = lstAllSavingsDeduction - savingsAmount;
                        theAmountSaved = savingsAmount;
                    }

                    #region cmd parameters

                    cmd.Parameters["@DeductionID"].Value = deductionID;

                    cmd.Parameters["@DeductionType"].Value = child.Key;

                    cmd.Parameters["@SavingsTypeID"].Value = memberSavingsType[child.Key];

                    cmd.Parameters["@Amount"].Value = theAmountSaved;

                    cmd.Parameters["@Remarks"].Value = string.Empty;

                    cmd.Parameters["@TransactionID"].Value = transactionID;

                    #endregion cmd parameters

                    numOfRows = cmd.ExecuteNonQuery();
                    if (numOfRows == 0) { errorflag = 1; }
                    if (savingsAmount >= lstAllSavingsDeduction) { break; }
                    // MessageBox.Show(child.Key.ToString() + " -  " + child.Value.ToString() + "\nError Flag: " + errorflag);

                   
                }

            }

            //Check if the member is serving a loan. Get the type of loan and amount paying per month
            string loanRepaymentType = null;
            decimal loanRepaymentAmount = 0;

            loanRepaymentAmount = lstAllLoansDeduction;
            if (loanRepaymentAmount > 0) { loanRepaymentType = repaymentLoanType; } else { loanRepaymentType = "Loan Repayment - None"; }

            cmd.CommandText = strQuery;

            #region cmd parameters
            cmd.Parameters["@DeductionType"].Value = loanRepaymentType;
            cmd.Parameters["@SavingsTypeID"].Value = string.Empty;
            cmd.Parameters["@Amount"].Value = loanRepaymentAmount;
            #endregion

            numOfRows = cmd.ExecuteNonQuery();
            if (numOfRows == 0) { errorflag = 1; }

            return "Loan Details Insertion " + numOfRows.ToString() + "\nError Flag: " + errorflag;
        }
        #endregion End of Record Deduction Details

        //Record DeductionDates
        public string recordDeductionDate(int selectedMonth, int selectedYear)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Insert into DeductionDates(Month,Year)values(@Month,@Year)";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            cmd.Parameters.Add("@Month", SqlDbType.Int);
            cmd.Parameters["@Month"].Value = selectedMonth;

            cmd.Parameters.Add("@Year", SqlDbType.Int);
            cmd.Parameters["@Year"].Value = selectedYear;

            int rowAffected;
            
            try
            {
                conn.Open();
                rowAffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {
                conn.Close();
            }

            if (rowAffected > 0)
            {
                return "1";
            }
            else
            {
                return "0";
            }

        }

    }
}
