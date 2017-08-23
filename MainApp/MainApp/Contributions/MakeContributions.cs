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
    public partial class MakeContributions : Form
    {
        int memberID;
        

        public MakeContributions()
        {
            InitializeComponent();
        }

        private void chkMonthYear_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMonthYear.Checked==true)
            {
                cboMonth.Enabled = true;
                cboYear.Enabled = true;
            }
            else if (chkMonthYear.Checked==false)
            {
                cboMonth.Enabled = false;
                cboYear.Enabled = false;
            }
        }

        private void MakeContributions_Load(object sender, EventArgs e)
        {
            loadItemIntoCboYear();

            loadPaymentMode();
            loadBanks();
           
            txtAmount.TextAlign = HorizontalAlignment.Right;
            
        }

        private void loadItemIntoCboYear()
        {
            DateTime myDate = DateTime.Now;
            int thisYear = myDate.Year;

            int countback = 10;
            while (countback > 0)
            {
                cboYear.Items.Add(thisYear--);
                countback--;
            }
        }

        private void loadPaymentMode()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select PaymentModeID, PaymentMode from PaymentMode";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "PaymentMode");
                DataTable dt = ds.Tables["PaymentMode"];
                
               
                DataRow row = dt.NewRow();
                row["PaymentMode"] = "-- Select a Payment Mode --";
                dt.Rows.InsertAt(row, 0);
                cboPaymentMode.DisplayMember = "PaymentMode";
                cboPaymentMode.ValueMember = "PaymentModeID";
                cboPaymentMode.DataSource = dt;
                
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

        private void loadBanks()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select BankID, BankName from Banks";
            SqlCommand cmd = new SqlCommand(strQuery,conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Banks");
                DataTable dt = ds.Tables["Banks"];

                DataRow row = dt.NewRow();
                row["BankName"] = "-- Select a Bank --";
                dt.Rows.InsertAt(row, 0);
                cboBank.DisplayMember = "BankName";
                cboBank.ValueMember = "BankID";
                cboBank.DataSource = dt;

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

        private void cboPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPaymentMode.Text == "Others")
            {
                panelOtherPayments.Visible = true;
                panelTellerDetails.Visible = false;

            }
            else if (cboPaymentMode.Text == "Cash")
            {
                lblOtherPaymentMode.Text = "Receipt No.";
                panelOtherPayments.Visible = true;
                panelTellerDetails.Visible = false;

            }
            else if (cboPaymentMode.Text != "-- Select a Payment Mode --")
            {
                panelTellerDetails.Visible = true;
                panelOtherPayments.Visible = false;
            }
            else
            {
                panelTellerDetails.Visible = false;
                panelOtherPayments.Visible = false;
            }
        }

        private void btnFindMember_Click(object sender, EventArgs e)
        {
            if (txtfileNo.Text == string.Empty)
            {
                MessageBox.Show("Enter a File No. to Find a Member", "Make Contributions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection conn = ConnectDB.GetConnection();
                memberID = findMember(txtfileNo.Text.Trim(), conn);
                if (memberID != 0)
                {
                    fetchExistingMemberContributions();
                    loadMemberSavingsAcctType();
                }
                
            }
        }

        private int findMember(string fileNo, SqlConnection conn)
        {
            int memberID=0;
            string strQuery = "Select MemberID, FileNo, Title + ' ' + LastName + ' ' + MiddleName + ' ' + FirstName as FullName, Photo from Members where FileNo='" + fileNo + "'";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                string paths = PhotoPath.getPath();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        memberID = Convert.ToInt16(reader["MemberID"]);
                        MemberProfileInfo.Text = reader["FullName"].ToString() + "\n" + reader["FileNo"].ToString(); ;
                        if (reader["Photo"].ToString() != string.Empty)
                        {
                            picMember.Image = Image.FromFile(paths + "\\photos\\" + reader["Photo"].ToString());
                        }
                        else
                        {
                            picMember.Image = Image.FromFile(paths + "\\photos\\profile_img.png");
                        }
                        MemberProfileInfo.Visible = true;
                        picMember.Visible = true;
                        btnSave.Enabled = true;
                    }
                                        
                }
                else
                {
                    picMember.Image = Image.FromFile(paths + "\\photos\\profile_img.png");
                    picMember.Visible = false;
                    MemberProfileInfo.Visible = false;
                    btnSave.Enabled = false;
                    MessageBox.Show("Sorry, that Record is not Found!", "Make Contributions", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            return memberID;
        }

        private void fetchExistingMemberContributions()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select p.PaymentMode [Payment Mode],m.Month,s.Year,t.Remark as Account, s.Amount,b.BankName [Bank],c.OtherPayment [Other Payment],c.TellerNo [Teller No.], c.ReceiptNo as [Receipt No.],c.Comment, s.TransactionID [Transact. ID],s.Date " +
                "from Savings s left join Contributions c on s.SavingsID=c.SavingsID " + 
                "left join PaymentMode p on c.PaymentModeID=p.PaymentModeID " +
                "left join MonthByName m on s.Month=m.MonthID " +
                "left join Banks b on c.BankID=b.BankID " +   
                "left join MemberSavingsTypeAcct t on c.SavingsAcctID=t.SavingsTypeID " +
                "where s.SavingSource='Contribution' and s.MemberID=" + memberID + " and t.MemberID=" + memberID + " order by s.SavingsID desc";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            datGVContributions.DataSource = null;
            datGVContributions.Columns.Clear();
            datGVContributions.Rows.Clear();
            datGVContributions.Refresh();
            try
            {
                conn.Open();
                da.Fill(ds, "Contributions");
                DataTable dt = ds.Tables["Contributions"];
                if (dt.Rows.Count > 0)
                {
                    datGVContributions.DataSource = dt;

                    datGVContributions.Columns["Amount"].DefaultCellStyle.Format = "N2";
                    datGVContributions.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
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

        private void btnSave_Click(object sender, EventArgs e)
        {

            int paymentModeID = 0;
            string BankID = string.Empty                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                      ;
            string tellerNo = string.Empty;
            string otherPaymentMode = string.Empty;
            string cashReceiptNo = string.Empty;
            int flagError = 0;
            decimal amount = 0;
            string specifiedDateMonth= string.Empty;
            string specifiedDateYear= string.Empty;
            string comment= string.Empty;
            string errMsg = null;


            #region Validations
            if (cboPaymentMode.Text != "-- Select a Payment Mode --")
            {

                paymentModeID = (int) cboPaymentMode.SelectedValue;

                
                if ((cboPaymentMode.Text != "Others") && (cboPaymentMode.Text != "Cash"))
                {
                    if (cboBank.SelectedValue.ToString() != "0" && txtTellerNo.Text != string.Empty)
                    {
                        BankID = cboBank.SelectedValue.ToString();
                        tellerNo = txtTellerNo.Text.Trim();
                    }
                    else
                    {
                        errMsg += "Bank and Teller/Draft No. are required\n";
                        flagError = 1;
                    }
                }
                else if (cboPaymentMode.Text == "Others")
                {
                    if (txtOtherPayments.Text != string.Empty)
                    {
                        otherPaymentMode = txtOtherPayments.Text.Trim();
                    }
                    else
                    {
                        errMsg += "Other Payment Mode  is required\n";
                        flagError = 1;
                    }
                }
                else if (cboPaymentMode.Text == "Cash")
                {
                    if (txtOtherPayments.Text != string.Empty)
                    {
                        cashReceiptNo = txtOtherPayments.Text.Trim();
                    }
                    else
                    {
                        errMsg += "Reciept No. is required\n";
                        flagError = 1;
                    }
                }
            }
            else
            {
                errMsg += "Select a Payment Mode\n";
                flagError = 1;
            }




            //if CheckMonthYear is on Check if Month and Year are Supplied Values
            if (chkMonthYear.Checked)
            {
                if (cboMonth.Text != string.Empty && cboYear.Text != string.Empty)
                {
                    specifiedDateMonth = pickMonthValue(cboMonth.Text);
                    specifiedDateYear = cboYear.Text;
                }
                else
                {
                    errMsg += "Please Specify Month and Year\n";
                    flagError = 1;
                }
            }
            else
            {
                DateTime currentDateTime = DateTime.Now;
                specifiedDateMonth = currentDateTime.Month.ToString();
                specifiedDateYear = currentDateTime.Year.ToString();
            }


            //
            if (txtAmount.Text == string.Empty)
            {
                errMsg += "Contribution Amount is required\n";
                flagError = 1;

            }
            else
            {
                amount =  Convert.ToDecimal(txtAmount.Text.Trim());
            }
            #endregion

            if (flagError == 1 && errMsg!=null)
            {
                MessageBox.Show("[An Error has Occurred]\n" + errMsg, "Make Contributions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //MessageBox.Show("Perform contribution operation. MemberID = " + memberID);
                DialogResult res = MessageBox.Show("Do you want to perform this Contribution operation?", "Contributions", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    comment = txtComment.Text.Trim();
                    performSaveOperation(paymentModeID, BankID, tellerNo, cashReceiptNo, otherPaymentMode, amount, specifiedDateMonth, specifiedDateYear, comment);
                    memberID = 0;
                }
            }

        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (CheckForNumber.isNumeric(txtAmount.Text.Trim()))
            {
                decimal amount = Convert.ToDecimal(txtAmount.Text);
                if (amount > 0)
                {
                    txtAmount.Text = CheckForNumber.formatCurrency(txtAmount.Text);
                }
                else
                {
                    MessageBox.Show("Amount entered is Invalid.\nAmount should not be zero or less than.", "Make Contributions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAmount.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Amount entered is Invalid.\nAmount should be numeric.", "Make Contributions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAmount.Text = string.Empty;
            }
        }

        private void performSaveOperation(int paymentModeID, string BankID, string tellerNo, string cashReceiptNo, string otherPaymentMode, decimal amount, string specifiedDateMonth, string specifiedDateYear, string comment)
        {
            //MessageBox.Show("Payment Mode: " + paymentModeID + "\nBankID: " +  BankID + "\nTeller No: " + tellerNo + "\nOther Payment Mode: " + otherPaymentMode + "\nAmount: " + amount + "\nMonth : " + specifiedDateMonth + "\nYear: " + specifiedDateYear + "\nComment: " + comment );
            SqlConnection conn = ConnectDB.GetConnection();
            

            string transactionID = "SAV" + DateTime.Now.ToString("ddMMyyhhmmss");
            string savingSource = "Contribution";
            string strInsertSavings = "Insert into Savings(MemberID,SavingSource,Amount,Month,Year,TransactionID)values(@MemberID,@SavingSource,@Amount,@Month,@Year,@TransactionID)";
            SqlCommand cmdInsertSavings = new SqlCommand(strInsertSavings, conn);
            #region cmdInsertSavings Parameters
            cmdInsertSavings.Parameters.Add("@MemberID", System.Data.SqlDbType.Int);
            cmdInsertSavings.Parameters["@MemberID"].Value = memberID;

            cmdInsertSavings.Parameters.Add("@SavingSource", System.Data.SqlDbType.NVarChar, 40);
            cmdInsertSavings.Parameters["@SavingSource"].Value = savingSource;

            cmdInsertSavings.Parameters.Add("@Amount", System.Data.SqlDbType.Decimal);
            cmdInsertSavings.Parameters["@Amount"].Value = amount;

            cmdInsertSavings.Parameters.Add("@Month", System.Data.SqlDbType.NVarChar, 5);
            cmdInsertSavings.Parameters["@Month"].Value = specifiedDateMonth;

            cmdInsertSavings.Parameters.Add("@Year", System.Data.SqlDbType.NVarChar, 5);
            cmdInsertSavings.Parameters["@Year"].Value = specifiedDateYear;

            cmdInsertSavings.Parameters.Add("@TransactionID", System.Data.SqlDbType.NVarChar, 30);
            cmdInsertSavings.Parameters["@TransactionID"].Value = transactionID;

            #endregion cmdInsertSavings Parameters


            SqlTransaction sqlTrans = null;
            bool dbOperationSuccess = true;
            try
            {
                conn.Open();
                sqlTrans = conn.BeginTransaction();
                cmdInsertSavings.Transaction = sqlTrans;

                int rowAffected = cmdInsertSavings.ExecuteNonQuery();

                #region Check if cmdInsertSavings is successful and perform next operation
                if (rowAffected > 0)
                {
                    
                    string strSavingInfo = "Select SavingsID from Savings where TransactionID='" + transactionID + "'";
                    SqlCommand cmdSavingsQuery = new SqlCommand(strSavingInfo, conn);
                    cmdSavingsQuery.Transaction = sqlTrans;

                    int newSavingsID = 0;
                    newSavingsID = (int) cmdSavingsQuery.ExecuteScalar();

                    #region Check if newSavingsID is found
                    if (newSavingsID != 0)
                    {
                        //begin operation to insert into Contributions Table if DbOperation has been false then RollBack Transactions
                        string strContrib = "Insert into Contributions(SavingsID,PaymentModeID,OtherPayment,BankID,TellerNo,ReceiptNo,Comment,SavingsAcctID,TransactionID)values(@SavingsID,@PaymentModeID,@OtherPayment,@BankID,@TellerNo,@ReceiptNo,@Comment,@SavingsAcctID,@TransactionID)";
                        SqlCommand cmdContrib = new SqlCommand(strContrib, conn);

                        #region cmdContrib Parameters
                        cmdContrib.Parameters.Add("@SavingsID", System.Data.SqlDbType.Int);
                        cmdContrib.Parameters["@SavingsID"].Value = newSavingsID;

                        cmdContrib.Parameters.Add("@PaymentModeID", System.Data.SqlDbType.Int);
                        cmdContrib.Parameters["@PaymentModeID"].Value = paymentModeID;

                        cmdContrib.Parameters.Add("@OtherPayment", System.Data.SqlDbType.NVarChar, 50);
                        cmdContrib.Parameters["@OtherPayment"].Value = otherPaymentMode;

                        cmdContrib.Parameters.Add("@BankID", System.Data.SqlDbType.NVarChar, 5);
                        cmdContrib.Parameters["@BankID"].Value = BankID;

                        cmdContrib.Parameters.Add("@TellerNo", System.Data.SqlDbType.NVarChar, 50);
                        cmdContrib.Parameters["@TellerNo"].Value = tellerNo;

                        cmdContrib.Parameters.Add("@ReceiptNo", SqlDbType.NVarChar, 50);
                        cmdContrib.Parameters["@ReceiptNo"].Value = cashReceiptNo;

                        cmdContrib.Parameters.Add("@Comment", System.Data.SqlDbType.NVarChar, 100);
                        cmdContrib.Parameters["@Comment"].Value = txtComment.Text.Trim();

                        cmdContrib.Parameters.Add("@SavingsAcctID", System.Data.SqlDbType.Int);
                        cmdContrib.Parameters["@SavingsAcctID"].Value = cboMemberSavingsType.SelectedValue;

                        cmdContrib.Parameters.Add("@TransactionID", System.Data.SqlDbType.NVarChar, 50);
                        cmdContrib.Parameters["@TransactionID"].Value = transactionID;

                        #endregion cmdContrib Parameters

                        cmdContrib.Transaction = sqlTrans;

                        rowAffected = 0;
                        rowAffected = cmdContrib.ExecuteNonQuery();

                        if (rowAffected > 0)
                        {
                            dbOperationSuccess = true;
                        }
                        else
                        {
                            dbOperationSuccess = false;
                        }
                            
                    }
                    else
                    {
                        dbOperationSuccess = false;

                    }
                    #endregion Check if newSavingID is found                    
                    
                }
                else
                {
                    dbOperationSuccess = false;
                }
                #endregion


                //Check if dbOperationSuccess is true - Commit or false - RollBack
                if (dbOperationSuccess == true)
                {
                    MessageBox.Show("Contribution has been Successfully Saved.", "Make Contributions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sqlTrans.Commit();
                    fetchExistingMemberContributions();
                    clearFields();
                }
                else
                {
                    MessageBox.Show("An Error has Occurred!", "Make Contributions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sqlTrans.Rollback();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                
                sqlTrans.Rollback();
            }
            finally
            {
                conn.Close();
            }

            


        }


        private string pickMonthValue(string specifiedDateMonth)
        {
            string selectedMonthValue = null;
            switch (specifiedDateMonth)
            {
                case "January":
                    selectedMonthValue = "1";
                    break;
                case "February":
                    selectedMonthValue = "2";
                    break;
                case "March":
                    selectedMonthValue = "3";
                    break;
                case "April":
                    selectedMonthValue = "4";
                    break;
                case "May":
                    selectedMonthValue = "5";
                    break;
                case "June":
                    selectedMonthValue = "6";
                    break;
                case "July":
                    selectedMonthValue = "7";
                    break;
                case "August":
                    selectedMonthValue = "8";
                    break;
                case "September":
                    selectedMonthValue = "9";
                    break;
                case "October":
                    selectedMonthValue = "10";
                    break;
                case "November":
                    selectedMonthValue = "11";
                    break;
                case "December":
                    selectedMonthValue = "12";
                    break;
              }

            return selectedMonthValue;
        }

        private void clearFields()
        {
            cboPaymentMode.SelectedValue = 0;
            cboBank.SelectedValue = 0;
            txtTellerNo.Clear();
            txtOtherPayments.Clear();
            txtAmount.Clear();
            txtComment.Clear();
            chkMonthYear.Checked = false;
            panelOtherPayments.Visible = false;
            panelTellerDetails.Visible = false;
            //cboMemberSavingsType.Items.Clear();

            //string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            //picMember.Image = Image.FromFile(paths + "\\photos\\profile_img.png");

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void loadMemberSavingsAcctType()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select SavingsTypeID, Remark from MemberSavingsTypeAcct where MemberID=@MemberID";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;
            cmd.Parameters.Add("@MemberID", SqlDbType.Int);
            cmd.Parameters["@MemberID"].Value = memberID;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "MemberSavingsTypeAcct");
                DataTable dt = ds.Tables["MemberSavingsTypeAcct"];

                cboMemberSavingsType.DataSource = dt;
                cboMemberSavingsType.ValueMember = "SavingsTypeID";
                cboMemberSavingsType.DisplayMember = "Remark";

                cboMemberSavingsType.SelectedValue = 99;
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
