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
    public partial class SavingsForward : Form
    {
        
        int memberID;
        decimal totalAmount = 0;
        string userId;

        public SavingsForward(string UserID)
        {
            InitializeComponent();

            userId = UserID;

            //ListView Properties
            lstVwSavings.View = View.Details;
            lstVwSavings.FullRowSelect = true;

            //Construct Columns
            lstVwSavings.Columns.Add("Id", 10);
            lstVwSavings.Columns.Add("Savings Account", 200);
            lstVwSavings.Columns.Add("Amount", 150);

            lstVwSavings.Columns[0].Width = 0;

        }

        private void btnFindMember_Click(object sender, EventArgs e)
        {

            //Build Savings Table with Personal Savings Account Type and other Savings Account Type using the BuildTempSavingsAcctType Class
            BuildTempSavingsAcctType.Create();

            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select MemberID, FileNo, LastName + ' ' + FirstName + ' ' + MiddleName as FullName, Photo from Members " +
                "where FileNo='" + txtFileNo.Text.Trim() + "'";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;

            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    memberID = Convert.ToInt16(reader["MemberID"].ToString());

                    lblMemberProfile.Text = reader["FullName"].ToString() + "\n" + reader["FileNo"].ToString();

                    //display member photo
                    string paths = PhotoPath.getPath();
                    //MessageBox.Show(reader["Photo"].ToString());
                    if (reader["Photo"].ToString() != string.Empty)
                    {
                        picMember.Image = Image.FromFile(paths + "\\photos\\" + reader["Photo"].ToString());
                    }
                    else
                    {
                        picMember.Image = Image.FromFile(paths + "\\photos\\profile_img.png");
                    }
                    picMember.Visible = true;
                    lblMemberProfile.Visible = true;


                    grpBoxSavingsInfo.Enabled = true;
                    loadDataSetSavingsForward();
                    loadDataSetMemberSavings();
                }
                else
                {
                    MessageBox.Show("Sorry, there is no Member with that File No.", "Savings", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void SavingsForward_Load(object sender, EventArgs e)
        {
            loadSavingsType();
          
        }

        private void loadSavingsType()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select SavingsTypeID, SavingsName from SavingsType";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "SavingsType");
                DataTable dt = ds.Tables["SavingsType"];


                cboSavingsAcct.ValueMember = "SavingsTypeID";
                cboSavingsAcct.DisplayMember = "SavingsName";

                DataRow row = dt.NewRow();
                row["SavingsName"] = "Shares Savings";
                row["SavingsTypeID"] = 99;

                dt.Rows.InsertAt(row, 0);

                cboSavingsAcct.DataSource = dt;
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

        private void loadDataSetSavingsForward()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select sf.SavingsID, m.Month, sf.Year, sf.Amount, sf.TransactionID, sf.Date from Savings sf " +
                "left join MonthByName m on sf.Month=m.MonthID " +                                              
                "where sf.MemberID=" + memberID + " and sf.SavingSource='SavingsForward' order by sf.savingsID desc";

            string strQuery2 = "Select Sum(Amount) as TotalSavingsForward from Savings where MemberID=" + memberID + " and SavingSource='SavingsForward'";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            dtGrdVwSavingsForward.DataSource = null;
            dtGrdVwSavingsForward.Columns.Clear();
            dtGrdVwSavingsForward.Rows.Clear();
            dtGrdVwSavingsForward.Refresh();

            try
            {
                conn.Open();
                da.Fill(ds, "Savings");
                DataTable dt = ds.Tables["Savings"];
                dtGrdVwSavingsForward.DataSource = dt;
                

                int rowFound = dtGrdVwSavingsForward.Rows.Count;

                dtGrdVwSavingsForward.Columns["SavingsID"].Visible = false;
                dtGrdVwSavingsForward.Columns["Amount"].DefaultCellStyle.Format = "N2";
                dtGrdVwSavingsForward.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtGrdVwSavingsForward.Columns["Year"].Width = 60;

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dtGrdVwSavingsForward.Columns.Add(btn);
                btn.HeaderText = "Action";
                btn.Text = "Details";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;

                if (rowFound > 0)
                {
                    cmd.CommandText = strQuery2;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string totalSavingsForward = CheckForNumber.formatCurrency(reader["TotalSavingsForward"].ToString());
                        lblTotalSavingsForward.Text = "Total:  " + totalSavingsForward;
                        reader.Close();
                    }
                    else
                    {
                        lblTotalSavingsForward.Text = "Total: 0.00";
                    }
                }
                else
                {
                    lblTotalSavingsForward.Text = "Total: 0.00";
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

        private void cboSavingsAcct_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void txtAmount_Leave(object sender, EventArgs e)
        {
            if (txtAmount.Text != string.Empty)
            {
                if (CheckForNumber.isNumeric(txtAmount.Text))
                {
                    txtAmount.Text = CheckForNumber.formatCurrency2(txtAmount.Text);
                }
                btnPostSavings.Enabled = true;
            }
            
            
        }

        private void btnAddSavings_Click(object sender, EventArgs e)
        {
            //check if the proper data has been entered
            if (txtAmount.Text != string.Empty)
            {
                if (CheckForNumber.isNumeric(txtAmount.Text.Trim()))
                {
                    addSavingsIntoListView();
                    txtAmount.Text = string.Empty;
                }
            }
            else
            {
                MessageBox.Show("The Amount has to be filled in","Savings",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void addSavingsIntoListView()
        {
            bool alreadyExist = false;
            
            if (lstVwSavings.Items.Count != 0)
            {                
                for (int i = 0; i < lstVwSavings.Items.Count; i++)
                {
                    if (lstVwSavings.Items[i].SubItems[1].Text.Trim() == cboSavingsAcct.Text)
                    {
                        alreadyExist = true;
                    }
                }                
            }


            if (alreadyExist == false)
            {
                String[] row = { cboSavingsAcct.SelectedValue.ToString(), cboSavingsAcct.Text, txtAmount.Text };
                ListViewItem item = new ListViewItem(row);
                lstVwSavings.Items.Add(item);
                
                //Add amount to total
                totalAmount = Convert.ToDecimal(txtAmount.Text) + totalAmount;
                lblTotalSavings.Text = "Total: " + CheckForNumber.formatCurrency2(totalAmount.ToString());


            }
            else
            {
                MessageBox.Show("That Savings Account has already been added", "Savings", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void lstVwSavings_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVwSavings.SelectedItems.Count>0)
            {
                btnRemoveSavings.Enabled = true;
            }
            else
            {
                btnRemoveSavings.Enabled = false;
            }

        }

        private void btnRemoveSavings_Click(object sender, EventArgs e)
        {
            if (lstVwSavings.SelectedItems.Count>0)
            {
                decimal selAmount = Convert.ToDecimal(lstVwSavings.SelectedItems[0].SubItems[2].Text.ToString());
                totalAmount = totalAmount - selAmount;
                lblTotalSavings.Text = "Total:  " + CheckForNumber.formatCurrency2(totalAmount.ToString()); 

                lstVwSavings.Items.RemoveAt(lstVwSavings.SelectedIndices[0]);
            }
            else
            {
                MessageBox.Show("Please select an item to remove from the list", "Savings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnPostSavings_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you wish to execute this posting?", "Savings Forward", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult.Yes == res)
            {
                ExecuteSave();
                //reset totalAmount
                totalAmount = 0;
            }
        }

        private void ExecuteSave()
        {
            SqlConnection conn = null;
            SqlCommand cmd = null;
            bool errorFlag = false;
            int rowAffected;
            string strQuery;

            if ((lstVwSavings.Items.Count != 0) && (totalAmount > 0) && (cboMonth.Text != string.Empty) && (cboYear.Text != string.Empty))
            {
                conn = ConnectDB.GetConnection();

                conn.Open();
                SqlTransaction sqlTrans = conn.BeginTransaction();

                cmd = conn.CreateCommand();

                cmd.Transaction = sqlTrans;

                string transactionID = "SAV" + DateTime.Now.ToString("ddMMyyhhmmss");

                strQuery = "Insert into Savings(MemberID,SavingSource,Amount,Month,Year,TransactionID)" +
                    "values(@MemberID,@SavingSource,@Amount,@Month,@Year,@TransactionID)";
                #region cmd parameters
                cmd.Parameters.Add("@MemberID", SqlDbType.Int);
                cmd.Parameters["@MemberID"].Value = memberID;

                cmd.Parameters.Add("@SavingSource", SqlDbType.NVarChar, 40);
                cmd.Parameters["@SavingSource"].Value = "SavingsForward";

                cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
                cmd.Parameters["@Amount"].Value = totalAmount;

                cmd.Parameters.Add("@Month", SqlDbType.Int);
                cmd.Parameters["@Month"].Value = Convert.ToInt16(cboMonth.SelectedIndex);

                cmd.Parameters.Add("@Year", SqlDbType.Int);
                cmd.Parameters["@Year"].Value = Convert.ToInt16(cboYear.Text);

                cmd.Parameters.Add("@TransactionID", SqlDbType.NVarChar, 50);
                cmd.Parameters["@TransactionID"].Value = transactionID;

                #endregion

                cmd.CommandText = strQuery;

                try
                {
                    rowAffected = cmd.ExecuteNonQuery();

                    #region if Statement of rowAffected
                    if (rowAffected > 0)
                    {
                        //Get SavingsID from the savings Table
                        strQuery = "Select SavingsID from Savings where TransactionID='" + transactionID + "'";
                        cmd.CommandText = strQuery;

                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        string SavingsID = reader["SavingsID"].ToString();
                        reader.Close();

                        cmd.Parameters.Add("@SavingsID", SqlDbType.Int);
                        cmd.Parameters.Add("@SavingsTypeID", SqlDbType.Int);
                        cmd.Parameters.Add("@Comment", SqlDbType.NVarChar, 400);

                        for (int i = 0; i < lstVwSavings.Items.Count; i++)
                        {
                            strQuery = "Insert into SavingsForward(SavingsID,Month,Year,SavingsTypeID,Amount,Comment,TransactionID)" +
                            "values(@SavingsID,@Month,@Year,@SavingsTypeID,@Amount,@Comment,@TransactionID)";

                            #region cmd parameters

                            cmd.Parameters["@SavingsID"].Value = SavingsID;

                            cmd.Parameters["@Month"].Value = Convert.ToInt16(cboMonth.SelectedIndex);

                            cmd.Parameters["@Year"].Value = Convert.ToInt16(cboYear.Text);

                            cmd.Parameters["@SavingsTypeID"].Value = Convert.ToInt16(lstVwSavings.Items[i].SubItems[0].Text.ToString());

                            cmd.Parameters["@Amount"].Value = Convert.ToDecimal(lstVwSavings.Items[i].SubItems[2].Text.ToString());

                            cmd.Parameters["@Comment"].Value = txtComment.Text.Trim();

                            cmd.Parameters["@TransactionID"].Value = transactionID;

                            #endregion

                            cmd.CommandText = strQuery;
                            rowAffected = cmd.ExecuteNonQuery();

                            if (rowAffected == 0)
                            {
                                MessageBox.Show("An error has occurred", "Savings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                errorFlag = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        errorFlag = true;
                    }
                    #endregion end of if statement

                    //Check if Transaction has been successful without error and commit or rollback

                    if (errorFlag == false)
                    {
                        sqlTrans.Commit();
                        ActivityLog.logActivity(userId, "SavingsForward", "Added a new Savings record with TransactionID of " + transactionID);
                        MessageBox.Show("Savings has been successfully posted", "Savings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataSetSavingsForward();
                        loadDataSetMemberSavings();
                    }
                    else
                    {
                        sqlTrans.Rollback();
                        MessageBox.Show("An error has occurred posting savings", "Savings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    clearFields();

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
            else
            {
                MessageBox.Show("Month, Year and Amount are required", "Savings", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void clearFields()
        {
            cboMonth.SelectedIndex = 0;
            cboYear.SelectedIndex = 0;
            txtAmount.Text = string.Empty;
            lblTotalSavings.Text = "Total:  " + 0;
            txtComment.Text = string.Empty;
            lstVwSavings.Items.Clear();

        }

        private void loadDataSetMemberSavings()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select m.Month, sf.Year, sf.Amount, sf.SavingSource, sf.TransactionID, sf.Date from Savings sf " +
                "left join MonthByName m on sf.Month=m.MonthID " +
                "where MemberID=" + memberID + " order by savingsID desc";

            string strQuery2 = "Select Sum(Amount) as TotalSavings from Savings where MemberID=" + memberID;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Savings");
                DataTable dt = ds.Tables["Savings"];
                dtGrdVwSavings.DataSource = dt;

                int rowFound = dtGrdVwSavings.Rows.Count;

                dtGrdVwSavings.Columns["Amount"].DefaultCellStyle.Format = "N2";
                dtGrdVwSavings.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtGrdVwSavings.Columns["Year"].Width = 60;
                dtGrdVwSavings.Columns["Month"].Width = 80;

                if (rowFound > 0)
                {
                    cmd.CommandText = strQuery2;
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        string totalSavings = CheckForNumber.formatCurrency(reader["TotalSavings"].ToString());
                        lblMemberTotalSavings.Text = "Total:  " + totalSavings;
                        reader.Close();
                    }
                    else
                    {
                        lblMemberTotalSavings.Text = "Total: 0.00";
                    }
                }
                else
                {
                    lblMemberTotalSavings.Text = "Total: 0.00";
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

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtGrdVwSavingsForward_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                string savingsID = dtGrdVwSavingsForward.Rows[e.RowIndex].Cells[0].Value.ToString();
                string savingSource = "SavingsForward";
                string transactionID = dtGrdVwSavingsForward.Rows[e.RowIndex].Cells[4].Value.ToString();
                ViewSavingsDetails viewSavingsDetails = new ViewSavingsDetails(savingsID, savingSource, transactionID);
                viewSavingsDetails.MdiParent = this.ParentForm;
                viewSavingsDetails.Show();
            }
        }
       

    }
}
