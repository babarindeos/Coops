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
    public partial class EditSavingsForward : Form
    {
        int memberID;
        string userId;

        public EditSavingsForward(string UserID)
        {
            InitializeComponent();

            userId = UserID;

            lstVwSavingDetails.View = View.Details;
            lstVwSavingDetails.FullRowSelect = true;

            lstVwSavingDetails.Columns.Add("SavingsForwardID", 0);
            lstVwSavingDetails.Columns.Add("SavingsTypeID", 0);
            lstVwSavingDetails.Columns.Add("Savings Acct", 150);
            lstVwSavingDetails.Columns.Add("Amount", 100);
            lstVwSavingDetails.Columns.Add("Comment", 150);

            lstVwSavingDetails.Columns[3].TextAlign = HorizontalAlignment.Right;

            lblSavingsID.Text = string.Empty;
            lblSavingsForwardID.Text = string.Empty;
        }

        private void btnFindMember_Click(object sender, EventArgs e)
        {
            lblSavingsForwardID.Text = string.Empty;
            lblSavingsID.Text = string.Empty;

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
                    string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                    if (reader["Photo"].ToString() != null || reader["Photo"].ToString() == string.Empty)
                    {
                        picMember.Image = Image.FromFile(paths + "//photos//" + reader["Photo"].ToString());
                    }
                    picMember.Visible = true;
                    lblMemberProfile.Visible = true;


                    grpBoxSavingsInfo.Enabled = true;
                    loadDataSetSavingsForward();
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


        private void loadDataSetSavingsForward()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select m.Month, sf.Year, sf.Amount, sf.TransactionID, sf.Date from Savings sf " +
                "left join MonthByName m on sf.Month=m.MonthID " +
                "where MemberID=" + memberID + " and sf.SavingSource='SavingsForward' order by savingsID desc";

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            dtGrdVwSavings.DataSource = null;
            dtGrdVwSavings.Columns.Clear();
            dtGrdVwSavings.Rows.Clear();
            dtGrdVwSavings.Refresh();

            try
            {
                conn.Open();
                da.Fill(ds, "Savings");
                DataTable dt = ds.Tables["Savings"];
                dtGrdVwSavings.DataSource = dt;

                dtGrdVwSavings.Columns["Amount"].DefaultCellStyle.Format = "N2";
                dtGrdVwSavings.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dtGrdVwSavings.Columns["Year"].Width = 60;

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dtGrdVwSavings.Columns.Add(btn);
                btn.HeaderText = "Action";
                btn.Text = "View Details";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;
                
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

        private void dtGrdVwSavings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string savingsAcct;
            decimal savingsTotal = 0;
            btnUpdate.Enabled = true;
            //MessageBox.Show(e.ColumnIndex.ToString());
            if (e.ColumnIndex == 5)
            {
                string transactionID = dtGrdVwSavings.Rows[e.RowIndex].Cells[3].Value.ToString();
                grpBoxDetails.Text = "Savings Details [" + transactionID + "]";
                lblSavingsID.Text = transactionID;

                SqlConnection conn = ConnectDB.GetConnection();
                string strQuery = "Select SavingsForwardID, SavingsTypeID, Amount, Comment from SavingsForward where TransactionID='" + transactionID + "'";

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = strQuery;

                lstVwSavingDetails.Items.Clear();

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            

                            if ((reader["SavingsTypeID"].ToString()) == "99")
                            {
                                savingsAcct = "Personal Savings";
                            }
                            else
                            {
                                savingsAcct = getSavingsAcctName(reader["SavingsTypeID"].ToString());
                            }
                            string[] row = { reader["SavingsForwardID"].ToString(), reader["SavingsTypeID"].ToString(), savingsAcct, CheckForNumber.formatCurrency2(reader["Amount"].ToString()), reader["Comment"].ToString() };
                            ListViewItem item = new ListViewItem(row);
                            lstVwSavingDetails.Items.Add(item);
                            savingsTotal = savingsTotal + Convert.ToDecimal(reader["Amount"].ToString()); 
                        }
                    }

                    lblSavingsTotal.Text = CheckForNumber.formatCurrency2(savingsTotal.ToString());
                    
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




        private string getSavingsAcctName(string savingsTypeID)
        {
            SqlConnection conn2 = ConnectDB.GetConnection();
            string strQuery = "Select SavingsName from SavingsType where SavingsTypeID=" + savingsTypeID;
            SqlCommand cmd2 = new SqlCommand(strQuery, conn2);

            conn2.Open();

            SqlDataReader reader2 = cmd2.ExecuteReader();
            reader2.Read();
            string savingsTypeName = reader2["SavingsName"].ToString();

            return savingsTypeName;

        }

        private void lstVwSavingDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstVwSavingDetails.SelectedItems.Count > 0)
            {
                //MessageBox.Show(lstVwSavingDetails.SelectedItems[0].SubItems[3].Text.ToString());
                
                string savingsTypeID = lstVwSavingDetails.SelectedItems[0].SubItems[1].Text.ToString();
                cboSavingsType.SelectedValue = Convert.ToInt16(savingsTypeID);
                txtComment.Text = lstVwSavingDetails.SelectedItems[0].SubItems[4].Text.ToString();
                txtAmount.Text = lstVwSavingDetails.SelectedItems[0].SubItems[3].Text.ToString();
                lblSavingsForwardID.Text = lstVwSavingDetails.SelectedItems[0].SubItems[0].Text.ToString();

                btnChange.Enabled = true;
            }
            else
            {
                cboSavingsType.SelectedIndex = 0;
                txtAmount.Text = string.Empty;
                txtComment.Text = string.Empty;
                btnChange.Enabled = false;
            }
        }

        private void EditSavingsForward_Load(object sender, EventArgs e)
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
                da.Fill(ds,"SavingsType");
                DataTable dt = ds.Tables["SavingsType"];

                cboSavingsType.DisplayMember = "SavingsName";
                cboSavingsType.ValueMember = "SavingsTypeID";

                cboSavingsType.DataSource = dt;

                DataRow row = dt.NewRow();
                row["SavingsName"] = "Personal Savings";
                row["SavingsTypeID"] = 99;

                dt.Rows.InsertAt(row, 0);

                row = dt.NewRow();
                row["SavingsName"] = "";
                row["SavingsTypeID"] = 0;
                dt.Rows.InsertAt(row, 0);

                cboSavingsType.SelectedIndex = 0;


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

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (lstVwSavingDetails.SelectedItems.Count > 0)
            {
                lstVwSavingDetails.SelectedItems[0].SubItems[1].Text = cboSavingsType.SelectedValue.ToString();
                lstVwSavingDetails.SelectedItems[0].SubItems[2].Text = cboSavingsType.Text;
                lstVwSavingDetails.SelectedItems[0].SubItems[3].Text = txtAmount.Text;
                lstVwSavingDetails.SelectedItems[0].SubItems[4].Text = txtComment.Text;

                calculateSavingsTotal();
            }
            else
            {
                MessageBox.Show("Select a Savings Accoount Type to maake an Update", "Savings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void calculateSavingsTotal()
        {
            decimal savingsTotal = 0;
            if (lstVwSavingDetails.Items.Count > 0)
            {
                for (int i = 0; i < lstVwSavingDetails.Items.Count; i++)
                {
                    //MessageBox.Show(lstVwSavingDetails.Items[i].SubItems[2].Text.ToString());
                    savingsTotal = savingsTotal + Convert.ToDecimal(lstVwSavingDetails.Items[i].SubItems[3].Text.ToString());
                }

                lblSavingsTotal.Text = CheckForNumber.formatCurrency2(savingsTotal.ToString());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lblSavingsID.Text != string.Empty)
            {
                DialogResult res = MessageBox.Show("Do you wish to Update this record?", "Savings", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    UpdateSavings();
                }

            }
            else
            {
                MessageBox.Show("No record has been selected to effect an Update.","Savings",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }


        private void UpdateSavings()
        {
            int rowAffected = 0;
            bool errorflag = false;

            int savingsTypeID = 0;
            int savingsForwardID = 0;
            string temp = string.Empty;
            decimal amount = 0;
            string comment = string.Empty;
            string strQuery = string.Empty;
  

            SqlConnection conn = ConnectDB.GetConnection();
            strQuery = "Update Savings set Amount=@Amount where TransactionID=@TransactionID";

            conn.Open();
            SqlTransaction sqlTrans = conn.BeginTransaction();

            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;
            
            cmd.Parameters.Add("@Amount", SqlDbType.Decimal);
            cmd.Parameters["@Amount"].Value = Convert.ToDecimal(lblSavingsTotal.Text);

            cmd.Parameters.Add("@TransactionID", SqlDbType.NVarChar, 100);
            cmd.Parameters["@TransactionID"].Value = lblSavingsID.Text;

            cmd.Transaction = sqlTrans;

            try
            {
                
                rowAffected = cmd.ExecuteNonQuery();

                if (rowAffected > 0)
                {
                    for (int i = 0; i < lstVwSavingDetails.Items.Count; i++)
                    {
                        strQuery = "Update SavingsForward set SavingsTypeID=@SavingsTypeID,Amount=@Amount,Comment=@Comment where SavingsForwardID=@SavingsForwardID" +
                            " and TransactionID=@TransactionID";
                        cmd.CommandText = strQuery;

                        #region cmd parameters
                        savingsForwardID = Convert.ToInt16(lstVwSavingDetails.Items[i].SubItems[0].Text.ToString());
                        savingsTypeID = Convert.ToInt16(lstVwSavingDetails.Items[i].SubItems[1].Text.ToString());
                        temp =  lstVwSavingDetails.Items[i].SubItems[3].Text.ToString();
                        amount = Convert.ToDecimal(temp);
                        comment = lstVwSavingDetails.Items[i].SubItems[4].Text.ToString();

                        cmd.Parameters.Clear();
                        //MessageBox.Show("Savings TypeID - " + savingsTypeID.ToString() + " - " + amount.ToString());

                        cmd.Parameters.Add("@SavingsTypeID", SqlDbType.Int);
                        cmd.Parameters["@SavingsTypeID"].Value = savingsTypeID;

                        cmd.Parameters.Add("@Amount", SqlDbType.Decimal);   
                        cmd.Parameters["@Amount"].Value = amount;

                        cmd.Parameters.Add("@Comment", SqlDbType.NVarChar, 400);
                        cmd.Parameters["@Comment"].Value = comment;

                        cmd.Parameters.Add("@TransactionID", SqlDbType.NVarChar, 400);
                        cmd.Parameters["@TransactionID"].Value = lblSavingsID.Text;

                        cmd.Parameters.Add("@SavingsForwardID", SqlDbType.Int);
                        cmd.Parameters["@SavingsForwardID"].Value = savingsForwardID;


                        #endregion


                        rowAffected = cmd.ExecuteNonQuery();

                        if (rowAffected == 0)
                        {
                            errorflag = true;
                        }

                    }
                }
                else
                {
                    errorflag = true;
                }


                //check if there was no error and commit, if there is error rollback
                if (errorflag == false)
                {
                    sqlTrans.Commit();
                    ActivityLog.logActivity(userId, "SavingsForward", "Update Savings Record " + lblSavingsID.Text);
                    MessageBox.Show("Savings has been successfully Updated", "Savings", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    sqlTrans.Rollback();
                    MessageBox.Show("An error occurred! Update has been cancelled.", "Savings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //reset view
                loadDataSetSavingsForward();
                lstVwSavingDetails.Items.Clear();
                cboSavingsType.SelectedIndex = 0;
                txtAmount.Text = string.Empty;
                txtComment.Text = string.Empty;
                lblSavingsTotal.Text = "0.00";

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
