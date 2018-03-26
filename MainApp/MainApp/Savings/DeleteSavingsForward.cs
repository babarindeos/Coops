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
    public partial class DeleteSavingsForward : Form
    {
        int memberID;

        public DeleteSavingsForward()
        {
            InitializeComponent();

            lstVwSavingDetails.View = View.Details;
            lstVwSavingDetails.FullRowSelect = true;

            lstVwSavingDetails.Columns.Add("SavingsForwardID", 0);
            lstVwSavingDetails.Columns.Add("SavingsTypeID", 0);
            lstVwSavingDetails.Columns.Add("Savings Acct", 150);
            lstVwSavingDetails.Columns.Add("Amount", 100);
            lstVwSavingDetails.Columns.Add("Comment", 150);

            lstVwSavingDetails.Columns[3].TextAlign = HorizontalAlignment.Right;

        }

        private void btnFindMember_Click(object sender, EventArgs e)
        {
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
                    lstVwSavingDetails.Items.Clear();
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

                btn = new DataGridViewButtonColumn();
                dtGrdVwSavings.Columns.Add(btn);
                btn.HeaderText = "Action";
                btn.Text = "Delete";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;

                lblRecordNo.Text = "No. of Records:  " + dt.Rows.Count;
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

        private void DeleteSavingsForward_Load(object sender, EventArgs e)
        {

        }

        private void dtGrdVwSavings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string savingsAcct;
            decimal savingsTotal = 0;

            //MessageBox.Show(e.ColumnIndex.ToString());
            #region View Record
            if (e.ColumnIndex == 5)
            {
                string transactionID = dtGrdVwSavings.Rows[e.RowIndex].Cells[3].Value.ToString();
                grpBoxDetails.Text = "Savings Details [" + transactionID + "]";

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
                                savingsAcct = "Shares Savings";
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
            #endregion end View Record



            #region Delete Record
            if (e.ColumnIndex == 6)
            {
                DialogResult res = MessageBox.Show("Do you wish to Delete the Selected Record?","Savings",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    SqlConnection conn = ConnectDB.GetConnection();
                    string transactionID = dtGrdVwSavings.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string strQuery = "Delete from Savings where transactionID='" + transactionID + "'";

                    SqlCommand cmd = new SqlCommand(strQuery,conn);

                    try{
                        conn.Open();
                        int rowAffected = cmd.ExecuteNonQuery();
                        if (rowAffected > 0)
                        {
                            MessageBox.Show("Record has been deleted","Savings",MessageBoxButtons.OK);
                            loadDataSetSavingsForward();
                            
                            //clear data items in listView
                            lstVwSavingDetails.Items.Clear();
                        }
                        else
                        {
                            MessageBox.Show("An error occurred. Record not deletee", "Savings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }



                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }finally{
                        conn.Close();
                    }
                }
                
            }
            #endregion  end Delete Record
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

    }
}
