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
    public partial class MakeWithdrawal : Form
    {
        string memberID = string.Empty;
        decimal memberTotalSavingsByType;
        private string UserID;

        public MakeWithdrawal(string userId)
        {
            InitializeComponent();

            this.UserID = userId;


            lstVwSavingsSource.View = View.Details;
            lstVwSavingsSource.FullRowSelect = true;

            lstVwSavingsSource.Columns.Add("Savings Source", 250);
            lstVwSavingsSource.Columns.Add("Amount", 200);
        }

        private void btnGetMember_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select m.MemberID,m.FileNo,m.Title,m.FirstName,m.LastName,m.MiddleName,m.Photo " +
                "from Members m where m.FileNo='" + txtFileNo.Text.Trim() + "'";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            string paths = PhotoPath.getPath();
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    
                    if (reader.Read())
                    {
                        picMember.Visible = true;
                        lblMemberInfo.Visible = true;
                        lblMemberInfo.Text = reader["Title"].ToString() + ' ' + reader["LastName"].ToString() + ' ' + reader["FirstName"].ToString() + ' ' + reader["MiddleName"].ToString();
                        if (reader["Photo"].ToString() != string.Empty)
                        {
                            picMember.Image = Image.FromFile(paths + "\\photos\\" + reader["Photo"].ToString());
                        }
                        else
                        {
                            picMember.Image = Image.FromFile(paths + "\\photos\\profile_img.png");
                        }

                        memberID = reader["MemberID"].ToString();
                        //getMember Savings Account Types
                        cboSavingsType.DataSource = null;
                        getMemberSavingsAccountType(memberID);
                        getPreviousWithdrawals();
                    }
                }
                else
                {
                    lblMemberInfo.Text = string.Empty;
                    picMember.Image = Image.FromFile(paths + "\\photos\\profile_img.png");
                    picMember.Visible = false;
                    lblMemberInfo.Visible = false;
                    MessageBox.Show("There is no record with that FileNo.", "Withdrawal", MessageBoxButtons.OK, MessageBoxIcon.Error);

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


        private void getPreviousWithdrawals()
        {
            BuildTempSavingsAcctType.Create();

            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select w.SavingsWithdrawalID 'ID',w.SavingsID 'Savings ID', st.SavingsName 'Savings Type', w.Amount,w.WithdrawAmount 'Withdrawal',w.Balance,w.Date from SavingsWithdrawal w " +
                        "left join TempSavingsAcctType st on w.SavingsTypeID=st.SavingsTypeID order by w.SavingsWithdrawalID desc";
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            datGrdVwSavings.DataSource = null;

            try
            {
                conn.Open();
                da.Fill(ds, "Withdrawal");
                DataTable dt = ds.Tables["Withdrawal"];


                datGrdVwSavings.DataSource = dt;

                datGrdVwSavings.Columns["ID"].Width = 80;

                datGrdVwSavings.Columns["Amount"].DefaultCellStyle.Format = "N2";
                datGrdVwSavings.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                datGrdVwSavings.Columns["Withdrawal"].DefaultCellStyle.Format = "N2";
                datGrdVwSavings.Columns["Withdrawal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                datGrdVwSavings.Columns["Balance"].DefaultCellStyle.Format = "N2";
                datGrdVwSavings.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


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


        private void getMemberSavingsAccountType(string memberID)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select SavingsTypeID,Remark from MemberSavingsTypeAcct " +
                "where MemberID=" + memberID;
            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "MemberSavingsTypeAcct");
                DataTable dt = ds.Tables["MemberSavingsTypeAcct"];

                cboSavingsType.Items.Clear();
                DataRow row = dt.NewRow();
                row["Remark"] = "--  Select Savings Type --";
                dt.Rows.InsertAt(row, 0);

                cboSavingsType.DataSource = dt;
                cboSavingsType.DisplayMember = "Remark";
                cboSavingsType.ValueMember = "SavingsTypeID";

                //cboSavingsType
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

        private void cboSavingsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cboSavingsType.SelectedIndex.ToString());
            lstVwSavingsSource.Items.Clear();
            lblAcctAmount.Text = string.Empty;
            txtWithdrawAmt.Text = string.Empty;

            if (cboSavingsType.SelectedIndex != 0)
            {
                //Enable btnPose
                btnPost.Enabled = true;

                //Enable txtWithdrawal control
                txtWithdrawAmt.Enabled = true;

                int savingsTypeID = Convert.ToInt16(cboSavingsType.SelectedValue);
                //MessageBox.Show("Member ID: " + memberID + "\nSavings TypeID: " + savingsTypeID);

                SavingsByAcctType memberSavings = new SavingsByAcctType();

                #region Member Contributions
                decimal contributionsByType = memberSavings.getContributionSavings(memberID, savingsTypeID);

                //Add Contributions to ListView
                string[] row = { "Contributions", CheckForNumber.formatCurrency2(contributionsByType.ToString()) };
                ListViewItem item = new ListViewItem(row);
                lstVwSavingsSource.Items.Add(item);
                #endregion 

                #region Member Savings Forward
                decimal savingsForwardType = memberSavings.getSavingsForward(memberID, savingsTypeID);

                //Add SavingsForward to ListView
                string[] row2 = { "Savings Forward", CheckForNumber.formatCurrency2(savingsForwardType.ToString()) };
                item = new ListViewItem(row2);
                lstVwSavingsSource.Items.Add(item);
                #endregion

                #region Member Deductions Type
                decimal deductionsByType = memberSavings.getDeductionSavings(memberID, savingsTypeID);

                //Add Deductions to ListView
                string[] row3 = { "Deductions", CheckForNumber.formatCurrency2(deductionsByType.ToString()) };
                item = new ListViewItem(row3);
                lstVwSavingsSource.Items.Add(item);
                #endregion

                #region Member Withdrawal 
                decimal withdrawalByType = memberSavings.getWithdrawalSavings(memberID, savingsTypeID);

                //Add Withdrawal to ListView
                string[] row4 = { "Withdrawal", CheckForNumber.formatCurrency2("-"+withdrawalByType.ToString()) };
                item = new ListViewItem(row4);
                lstVwSavingsSource.Items.Add(item);
                #endregion

                memberTotalSavingsByType = (contributionsByType + savingsForwardType + deductionsByType) - (withdrawalByType);

                lblAcctAmount.Text = CheckForNumber.formatCurrency2(memberTotalSavingsByType.ToString());
                //MessageBox.Show("Contribution : " + contributionsByType.ToString() + "\nSavings Forward: " + savingsForwardType.ToString() + "\nDeduction: " + deductionsByType.ToString());

                if (memberTotalSavingsByType == 0)
                {
                    txtWithdrawAmt.Enabled = false;
                    btnPost.Enabled = false;
                }
                else
                {
                    txtWithdrawAmt.Enabled = true;
                    btnPost.Enabled = true;
                }
            }
            else
            {
                btnPost.Enabled = false;
                txtWithdrawAmt.Enabled = false;
            }
        }

        private void txtWithdrawAmt_TextChanged(object sender, EventArgs e)
        {
            
            if (txtWithdrawAmt.Text != string.Empty)
            {
                if (CheckForNumber.isNumeric(txtWithdrawAmt.Text))
                {
                    decimal withdrawalAmt = Convert.ToDecimal(txtWithdrawAmt.Text);
                    decimal balance = memberTotalSavingsByType - (withdrawalAmt);
                    lblAmtBalance.Text = CheckForNumber.formatCurrency2(balance.ToString());

                    //Enable or disable btn based on balance
                    if (balance >= 0  && withdrawalAmt>0)
                    {
                        btnPost.Enabled = true;
                    }
                    else
                    {
                        btnPost.Enabled = false;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Amount has been supplied", "Withdrawal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                btnPost.Enabled = false;
            }
            
        }

        private void txtWithdrawAmt_Leave(object sender, EventArgs e)
        {
            if (txtWithdrawAmt.Text != string.Empty)
            {
                if (CheckForNumber.isNumeric(txtWithdrawAmt.Text))
                {
                    txtWithdrawAmt.Text = CheckForNumber.formatCurrency2(txtWithdrawAmt.Text);
                }
                else
                {
                    MessageBox.Show("Invalid Amount has been supplied", "Withdrawal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtWithdrawAmt.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("Amount has not been supplied", "Withdrawal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPost_Click(object sender, EventArgs e)
        {
            if (CheckForNumber.isNumeric(txtWithdrawAmt.Text) && (Convert.ToDecimal(txtWithdrawAmt.Text) > 0))
            {
                DialogResult res = MessageBox.Show("Do you wish to post this Transaction?", "Withdrawal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    #region ExecutePost
                    string strMonth = dateTimePicker1.Value.Month.ToString();
                    string strYear = dateTimePicker1.Value.Year.ToString();

                    string transactionID = "WIT" + DateTime.Now.ToString("ddMMyyhhmmss");
                    SqlConnection conn = ConnectDB.GetConnection();

                    conn.Open();
                    SqlTransaction mySqlTrans = conn.BeginTransaction();

                    string strInsertSavings = "Insert into Savings(MemberID,SavingSource,Amount,Month,Year,TransactionID)values(@MemberID," +
                        "@SavingSource,@Amount,@Month,@Year,@TransactionID)";
                    string strInsertSavingsWithdrawal = "Insert into SavingsWithdrawal(SavingsID,MemberID,SavingsTypeID,Amount," +
                         "WithdrawAmount,Balance)values(@SavingsID,@MemberID,@SavingsTypeID,@Amount,@WithdrawalAmount,@Balance)";

                    string strQuery = "Select SavingsID from Savings where TransactionID=@TransactionID";

                    SqlCommand cmd = conn.CreateCommand();
                    cmd.Transaction = mySqlTrans;

                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strInsertSavings;

                    #region cmdParameters
                    cmd.Parameters.Add("@MemberID", SqlDbType.Int);
                    cmd.Parameters["@MemberID"].Value = memberID;

                    cmd.Parameters.Add("@SavingSource", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@SavingSource"].Value = "Withdrawal";

                    cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                    cmd.Parameters["@Amount"].Value = "-" + txtWithdrawAmt.Text;

                    cmd.Parameters.Add("@Month", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@Month"].Value = strMonth;

                    cmd.Parameters.Add("@Year", SqlDbType.NVarChar, 50);
                    cmd.Parameters["@Year"].Value = strYear;

                    cmd.Parameters.Add("@TransactionID", SqlDbType.NVarChar, 30);
                    cmd.Parameters["@TransactionID"].Value = transactionID;
                    #endregion cmdParameters
                    try
                    {


                        int rowAffected = cmd.ExecuteNonQuery();

                        if (rowAffected > 0)
                        {
                            cmd.CommandText = strQuery;
                            cmd.Parameters["@TransactionID"].Value = transactionID;

                            int savingsID = Convert.ToInt16(cmd.ExecuteScalar());

                            cmd.CommandText = strInsertSavingsWithdrawal;

                            #region cmdParameters - strInsertSavingsWithrawal
                            cmd.Parameters.Add("@SavingsID", SqlDbType.Int);
                            cmd.Parameters["@SavingsID"].Value = savingsID;

                            cmd.Parameters["@MemberID"].Value = memberID;

                            cmd.Parameters.Add("@SavingsTypeID", SqlDbType.Int);
                            cmd.Parameters["@SavingsTypeID"].Value = cboSavingsType.SelectedValue;

                            cmd.Parameters["@Amount"].Value = lblAcctAmount.Text;

                            cmd.Parameters.Add("@WithdrawalAmount", SqlDbType.Decimal);
                            cmd.Parameters["@WithdrawalAmount"].Value = txtWithdrawAmt.Text;

                            cmd.Parameters.Add("@Balance", SqlDbType.Decimal);
                            cmd.Parameters["@Balance"].Value = lblAmtBalance.Text;
                            #endregion

                            rowAffected = cmd.ExecuteNonQuery();
                            if (rowAffected > 0)
                            {
                                mySqlTrans.Commit();
                                MessageBox.Show("Transaction is Successfully Posted","Withdrawal",MessageBoxButtons.OK,MessageBoxIcon.Information);

                                string logDescription = cboSavingsType.Text + " withdrawal of " + txtWithdrawAmt.Text + 
                                    " from Member with ID " + memberID;
                                        
                                
                                txtWithdrawAmt.Text = string.Empty;
                                txtWithdrawAmt.Enabled = false;
                                btnPost.Enabled = false;
                                getPreviousWithdrawals();
                                ActivityLog.logActivity(UserID, "Withdrawal", logDescription);

                            }
                            else
                            {
                                mySqlTrans.Rollback();
                                MessageBox.Show("An error has occurred!", "Withdrawal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                        }
                        else
                        {
                            mySqlTrans.Rollback();
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
                    #endregion
                }
            }
            else
            {
                MessageBox.Show("Withdrawal Amount has not been Supplied", "Withdrawal", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void lstVwSavingsSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void lstVwSavingsSource_Click(object sender, EventArgs e)
        {
            if (lstVwSavingsSource.Items.Count > 0)
            {
                string savingsSource =  lstVwSavingsSource.SelectedItems[0].SubItems[0].Text.ToString();
                SqlConnection conn = ConnectDB.GetConnection();
                string strQuery = string.Empty;

                SqlCommand cmd = null;
                datGrdVwSavings.DataSource = null;
                DataTable dt = null;
                

                switch (savingsSource)
                {
                    case "Contributions":
                        strQuery = "Select c.ContributionID 'ID',pay.PaymentMode,c.OtherPayment,m.Month,s.Year,s.Amount,acct.SavingsName 'Savings Name', " +
                                    "b.BankName 'Bank Name',c.TellerNo 'Teller No.',c.ReceiptNo 'Receipt No.',c.Comment,s.SavingSource 'Saving Source', " +
                                    "s.TransactionID,c.Date from Contributions c " +
                                    "left join Savings s on s.SavingsID=c.SavingsID " +
                                    "left join MonthByName m on s.Month=m.MonthID " +
                                    "left join Banks b on b.BankID=c.BankID " +
                                    "left join PaymentMode pay on pay.PaymentModeID=c.PaymentModeID " +
                                    "left join TempSavingsAcctType acct on acct.SavingsTypeID=c.SavingsAcctID " +
                                    "where s.SavingSource='Contribution' and s.MemberID="+memberID+" and c.SavingsAcctID='" + cboSavingsType.SelectedValue.ToString() + "'";

                        cmd = new SqlCommand(strQuery, conn);
                        conn.Open();
                    
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            DataSet ds = new DataSet();

                            da.Fill(ds, "Savings");
                            dt = ds.Tables["Savings"];
                    
                            
                        break;
                    case "Savings Forward":
                        strQuery = "Select sf.SavingsForwardID 'ID',mon.Month,sf.year 'Year',st.SavingsName 'Savings Type',sf.Amount,sf.Comment, " +
                            "sf.TransactionID,sf.DatePosted 'Date Posted' from SavingsForward sf " +
                            "inner join Savings s on sf.SavingsID=s.SavingsID " +
                            "left join TempSavingsAcctType st on sf.SavingsTypeID = st.SavingsTypeID " +
                            "left join MonthByName mon on sf.Month=mon.MonthID " +
                            "where s.SavingSource='SavingsForward' and s.MemberID=" + memberID + " and sf.SavingsTypeID='" + cboSavingsType.SelectedValue.ToString() + "'";

                            cmd = new SqlCommand(strQuery, conn);
                            conn.Open();
                            da = new SqlDataAdapter(cmd);
                            ds = new DataSet();

                            da.Fill(ds, "SavingsForward");
                            dt = ds.Tables["SavingsForward"];


                        break;
                    case "Deductions":
                        strQuery = "Select dd.deductionDetailsID 'ID',st.SavingsName 'Savings Type',mon.Month,s.Year,dd.Amount,dd.Remarks, " +
                            "dd.TransactionID,dd.DatePosted from DeductionDetails dd " +
                            "left join Savings s on s.TransactionID=dd.TransactionID " +
                            "left join TempSavingsAcctType st on st.SavingsTypeID=dd.SavingsTypeID " +
                            "left join MonthByName mon on mon.MonthID=s.Month " +
                            "where s.SavingSource='Deduction' and s.MemberID=" + memberID + " and dd.SavingsTypeID='" + cboSavingsType.SelectedValue.ToString() + "'";

                            cmd = new SqlCommand(strQuery, conn);
                            conn.Open();
                            da = new SqlDataAdapter(cmd);
                            ds = new DataSet();

                            da.Fill(ds, "Deductions");
                            dt = ds.Tables["Deductions"];


                        break;
                    case "Withdrawal":
                        strQuery = "Select sw.SavingsWithdrawalID 'ID', mon.Month, s.Year, st.SavingsName 'Savings Type', " +
                            "sw.Amount,sw.WithdrawAmount,sw.Balance, s.TransactionID, s.Date " +
                            "from SavingsWithdrawal sw " +
                            "left join TempSavingsAcctType st on st.SavingsTypeID=sw.SavingsTypeID " +
                            "left join Savings s on sw.SavingsID=s.SavingsID " +
                            "left join MonthByName mon on mon.MonthID=s.Month ";

                            cmd = new SqlCommand(strQuery, conn);
                            conn.Open();
                            da = new SqlDataAdapter(cmd);
                            ds = new DataSet();

                            da.Fill(ds, "Withdrawal");
                            dt = ds.Tables["Withdrawal"];
                        
                        break;
                }

               

                try
                {
                    datGrdVwSavings.DataSource = dt;
                    datGrdVwSavings.Columns["Amount"].DefaultCellStyle.Format = "N2";
                    datGrdVwSavings.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    datGrdVwSavings.Columns["ID"].Width = 60;

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
}
