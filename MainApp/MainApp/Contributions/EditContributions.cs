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
    public partial class EditContributions : Form
    {
        //declare a member global MemberID
        int memberID;



        public EditContributions()
        {
            InitializeComponent();
        }


        private void EditContributions_Load(object sender, EventArgs e)
        {
            loadItemIntoCboYear();
            loadPayment();
            loadBanks();
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

        private void loadPayment()
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
            SqlCommand cmd = new SqlCommand(strQuery, conn);
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


        private void btnFindMember_Click(object sender, EventArgs e)
        {
            if (txtfileNo.Text == string.Empty)
            {
                MessageBox.Show("Enter a File No. to Find a Member", "Edit Contributions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SqlConnection conn = ConnectDB.GetConnection();
                memberID = findMember(txtfileNo.Text.Trim(), conn);
                if (memberID != 0)
                {
                    fetchMemberContributions(conn, memberID);
                    getMemberSavingsType();
                }
            }
        }


        private int findMember(string fileNo, SqlConnection conn)
        {

            int memberID = 0;

            string strQuery = "Select MemberID, FileNo, Title + ' ' + LastName + ' ' + MiddleName + ' ' + FirstName as FullName, Photo from Members where FileNo='" + fileNo + "'";
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                if (reader.HasRows)
                {
                        if (reader.Read())
                        {
                            memberID = Convert.ToInt16(reader["MemberID"]);
                            MemberProfileInfo.Text = reader["FullName"].ToString() + "\n" + reader["FileNo"].ToString();
                            if(reader["Photo"].ToString() !=null || reader["Photo"].ToString()==string.Empty)
                            {
                                picMember.Image = Image.FromFile(paths + "//photos//" + reader["Photo"].ToString());
                            }
                            picMember.Visible = true;
                            MemberProfileInfo.Visible = true;
                        }
                }
                else
                {
                    picMember.Image = Image.FromFile(paths + "\\photos\\profile_img.png");
                    picMember.Visible = false;
                    MemberProfileInfo.Visible = false;
                    MessageBox.Show("Sorry, that Record is not Found!","Edit Contributions",MessageBoxButtons.OK,MessageBoxIcon.Error);
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

        private void fetchMemberContributions(SqlConnection conn, int memberID)
        {
            string strQuery = "Select p.PaymentMode [Payment Mode],m.Month,s.Year,s.Amount,b.BankName [Bank],c.OtherPayment [Other Payment],c.TellerNo [Teller No.], c.Comment, s.TransactionID [Transact. ID],s.Date " +
                "from Savings s left join Contributions c on s.SavingsID=c.SavingsID " +
                "left join PaymentMode p on c.PaymentModeID=p.PaymentModeID " +
                "left join MonthByName m on s.Month=m.MonthID " +
                "left join Banks b on c.BankID=b.BankID " +
                "where SavingSource='Contribution' and MemberID=" + memberID + " order by s.SavingsID desc";

            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                da.Fill(ds, "Contributions");
                DataTable dt = ds.Tables["Contributions"];

                datGVContributions.DataSource = null;
                datGVContributions.Columns.Clear();
                datGVContributions.Rows.Clear();
                datGVContributions.Refresh();

                if (dt.Rows.Count > 0)
                {                    
                    datGVContributions.DataSource = dt;

                    datGVContributions.Columns["Amount"].DefaultCellStyle.Format = "N2";
                    datGVContributions.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;


                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    datGVContributions.Columns.Add(btn);
                    btn.HeaderText = "Action";
                    btn.Text = "Select Record";
                    btn.Name = "btn";
                    btn.UseColumnTextForButtonValue = true;
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

        private void txtfileNo_TextChanged(object sender, EventArgs e)
        {
            if (txtfileNo.Text == String.Empty)
            {
                btnFindMember.Enabled = false;
            }
            else
            {
                btnFindMember.Enabled = true;
            }
        }

        private void datGVContributions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                //MessageBox.Show(e.ColumnIndex.ToString());
                //MessageBox.Show(datGVContributions.Rows[e.RowIndex].Cells[8].Value.ToString());

                string transactionID = datGVContributions.Rows[e.RowIndex].Cells[8].Value.ToString();
                getContributionDetails(transactionID);
            }
        }

        private void chkMonthYear_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMonthYear.Checked == true)
            {
                cboMonth.Enabled = true;
                cboYear.Enabled = true;
            }
            else if (chkMonthYear.Checked == false)
            {
                cboMonth.Enabled = false;
                cboYear.Enabled = false;
            }
        }

        private void getContributionDetails(string transactionID)
        {
            
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select c.ContributionID,c.SavingsID,c.PaymentModeID,c.OtherPayment,c.BankID,c.TellerNo,c.Comment,c.SavingsAcctID,c.TransactionID,"+
                "s.SavingsID,s.MemberID,s.SavingSource,s.Amount,s.Month,s.Year,s.TransactionID " +
                "from Savings s inner join Contributions c on s.TransactionID=c.TransactionID and s.SavingSource='Contribution' and s.TransactionID='" + transactionID + "'";

            SqlCommand cmd = new SqlCommand(strQuery,conn);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        if (reader["BankID"].ToString() != string.Empty)
                        {
                            cboBank.SelectedIndex = Convert.ToInt16(reader["BankID"]);
                        }
                        //MessageBox.Show(reader["BankID"].ToString());
                        cboPaymentMode.SelectedIndex = (int) reader["PaymentModeID"];
                        txtAmount.Text = CheckForNumber.formatCurrency(reader["Amount"].ToString());
                        cboMemberSavingsType.SelectedValue = reader["SavingsAcctID"];
                        txtTellerNo.Text = reader["TellerNo"].ToString();
                        txtOtherPayments.Text = reader["OtherPayment"].ToString();
                        txtComment.Text = reader["Comment"].ToString();
                        cboYear.Text = reader["Year"].ToString();

                        int specifiedMonth = Convert.ToInt16(reader["Month"]);
                        string monthByName = null;
                        switch (specifiedMonth)
                        {
                            case 1:
                                monthByName = "January";
                                break;
                            case 2:
                                monthByName = "February";
                                break;
                            case 3:
                                monthByName = "March";
                                break;
                            case 4:
                                monthByName = "April";
                                break;
                            case 5:
                                monthByName = "May";
                                break;
                            case 6:
                                monthByName = "June";
                                break;
                            case 7:
                                monthByName = "July";
                                break;
                            case 8:
                                monthByName = "August";
                                break;
                            case 9:
                                monthByName = "September";
                                break;
                            case 10:
                                monthByName = "October";
                                break;
                            case 11:
                                monthByName = "November";
                                break;
                            case 12:
                                monthByName = "December";
                                break;
                        }

                        cboMonth.Text = monthByName;

                        btnEditRecord.Enabled = true;
                        lblSelTransactionalID.Text = reader["TransactionID"].ToString();
                        lblSavingsID.Text = reader["SavingsID"].ToString();



                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getContributionDetails : - " + ex.Message);
            }
            finally
            {
                conn.Close();
            }


        }

        private void btnEditRecord_Click(object sender, EventArgs e)
        {
            if (btnEditRecord.Text == "Edit Record")
            {
                groupBox2.Enabled = true;
                btnEditRecord.Text = "Cancel Edit";
            }
            else if (btnEditRecord.Text == "Cancel Edit")
            {
                groupBox2.Enabled = false;
                btnEditRecord.Text = "Edit Record";
            }

           
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strContribution = "Update Contributions set PaymentModeID=@PaymentModeID,OtherPayment=@OtherPayment,BankID=@BankID,TellerNo=@TellerNo,Comment=@Comment,SavingsAcctID=@SavingsAcctID where TransactionID=@TransactionID and SavingsID=@SavingsID";
            string strSavings = "Update Savings set Amount=@Amount, Month=@Month, Year=@Year where TransactionID=@TransactionID and SavingsID=@SavingsID";

            #region strContribution Parameters and strSavings Parameters
            SqlCommand cmdContribution = new SqlCommand(strContribution, conn);
            cmdContribution.Parameters.Add("@PaymentModeID", SqlDbType.Int);
            cmdContribution.Parameters["@PaymentModeID"].Value = cboPaymentMode.SelectedValue;

            cmdContribution.Parameters.Add("@OtherPayment", SqlDbType.NVarChar, 50);
            cmdContribution.Parameters["@OtherPayment"].Value = txtOtherPayments.Text;

            cmdContribution.Parameters.Add("@BankID", SqlDbType.NVarChar, 5);
            cmdContribution.Parameters["@BankID"].Value = cboBank.SelectedValue;

            cmdContribution.Parameters.Add("@TellerNo", SqlDbType.NVarChar, 50);
            cmdContribution.Parameters["@TellerNo"].Value = txtTellerNo.Text;

            cmdContribution.Parameters.Add("@Comment", SqlDbType.NVarChar, 100);
            cmdContribution.Parameters["@Comment"].Value = txtComment.Text;

            cmdContribution.Parameters.Add("@TransactionID", SqlDbType.NVarChar,50);
            cmdContribution.Parameters["@TransactionID"].Value = lblSelTransactionalID.Text;

            cmdContribution.Parameters.Add("@SavingsID", SqlDbType.Int);
            cmdContribution.Parameters["@SavingsID"].Value = lblSavingsID.Text;

            cmdContribution.Parameters.Add("@SavingsAcctID", SqlDbType.Int);
            cmdContribution.Parameters["@SavingsAcctID"].Value = cboMemberSavingsType.SelectedValue;


            SqlCommand cmdSavings = new SqlCommand(strSavings, conn);
            cmdSavings.Parameters.Add("@Amount", SqlDbType.Decimal);
            cmdSavings.Parameters["@Amount"].Value = txtAmount.Text;


            string selectedMonthValue = pickMonthValue(cboMonth.Text);
            cmdSavings.Parameters.Add("@Month", SqlDbType.NVarChar,5);
            cmdSavings.Parameters["@Month"].Value = selectedMonthValue;

            cmdSavings.Parameters.Add("@Year", SqlDbType.NVarChar, 5);
            cmdSavings.Parameters["@Year"].Value = cboYear.Text;

            cmdSavings.Parameters.Add("@TransactionID", SqlDbType.NVarChar, 50);
            cmdSavings.Parameters["@TransactionID"].Value = lblSelTransactionalID.Text;

            cmdSavings.Parameters.Add("@SavingsID", SqlDbType.Int);
            cmdSavings.Parameters["@SavingsID"].Value = lblSavingsID.Text;
            #endregion End of strContribution Parameters and end of strSavings Parameters

            SqlTransaction sqlTrans = null;

            try
            {
                conn.Open();
                sqlTrans = conn.BeginTransaction();
                int rowsAffected = 0;
                bool dbOperationSuccess = true;

                cmdContribution.Transaction = sqlTrans;
                rowsAffected = cmdContribution.ExecuteNonQuery();

                 //MessageBox.Show("No. of Record Updated in Contributions: " + rowsAffected);
                if (rowsAffected > 0)
                {
                    rowsAffected = 0;
                    cmdSavings.Transaction = sqlTrans;   //attaching the cmdSavings Object to Transaction

                    rowsAffected = cmdSavings.ExecuteNonQuery();
                    //MessageBox.Show("No. of Record Updated in Savings: " + rowsAffected);
                    if (rowsAffected==0)
                    {
                        dbOperationSuccess = false;
                    }
                    
                }
                else
                {
                    //if update operation fail writing to contributions turn dbOperationSuccess status to false
                    dbOperationSuccess = false;
                }


                //perform commit or rollback depending on the outcome of operations.
                if (dbOperationSuccess == true)
                {
                    
                    MessageBox.Show("Contribution has been Successfully Updated.","Edit/Update Contributions", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sqlTrans.Commit();                    
                }
                else
                {
                    MessageBox.Show("An Error has Occurred!", "Edit/Update Contributions", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    sqlTrans.Rollback();
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

            fetchMemberContributions(conn, memberID);
            
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            
            if (btnEditRecord.Text == "Edit Record")
            {
                groupBox2.Enabled = true;
                btnEditRecord.Text = "Cancel Edit";
            }
            else if (btnEditRecord.Text == "Cancel Edit")
            {
                groupBox2.Enabled = false;
                btnEditRecord.Text = "Edit Record";
            }

            
        }

        private void txtTransactionID_TextChanged(object sender, EventArgs e)
        {
            if (txtTransactionID.Text != string.Empty)
            {
                btnSearchByTransactionID.Enabled = true;
            }
            else
            {
                btnSearchByTransactionID.Enabled = false;
            }
        }

        private void btnSearchByTransactionID_Click(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select p.PaymentMode [Payment Mode],m.Month,s.Year,s.Amount,b.BankName [Bank],c.OtherPayment [Other Payment],c.TellerNo [Teller No.], c.Comment, s.TransactionID [Transaction ID],s.Date " +
                "from Savings s left join Contributions c on s.SavingsID=c.SavingsID " +
                "left join PaymentMode p on c.PaymentModeID=p.PaymentModeID " +
                "left join MonthByName m on s.Month=m.MonthID " +
                "left join Banks b on c.BankID=b.BankID " +
                "where SavingSource='Contribution' and MemberID=" + memberID + " and c.TellerNo='"+ txtTransactionID.Text.Trim() +"' or s.TransactionID='"+ txtTransactionID.Text.Trim() +"' order by s.SavingsID desc";

            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                conn.Open();
                da.Fill(ds, "Contributions");
                DataTable dt = ds.Tables["Contributions"];

                

                if (dt.Rows.Count > 0)
                {
                    datGVContributions.DataSource = null;
                    datGVContributions.Columns.Clear();
                    datGVContributions.Rows.Clear();
                    datGVContributions.Refresh();
                    datGVContributions.DataSource = dt;

                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    datGVContributions.Columns.Add(btn);
                    btn.HeaderText = "Action";
                    btn.Text = "Select Record";
                    btn.Name = "btn";
                    btn.UseColumnTextForButtonValue = true;
                }
                else
                {
                    MessageBox.Show("Sorry, that Transaction ID does not exist for this member", "Edit/Update Contributuons", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void getMemberSavingsType()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select MemberID, SavingsTypeID, Remark from MemberSavingsTypeAcct where MemberID=@MemberID";
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

                cboMemberSavingsType.DisplayMember = "Remark";
                cboMemberSavingsType.ValueMember = "SavingsTypeID";

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
