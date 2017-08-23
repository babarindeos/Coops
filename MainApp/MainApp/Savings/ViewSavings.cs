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
    public partial class ViewSavings : Form
    {
        string strFilter = null;

        string addFilter = null;
        string addFilter2 = null;
        DataTable dtSavings;
        DataTable dtSavingsDetails;

        public ViewSavings()
        {
            InitializeComponent();
        }

        private void clearParameters()
        {
            strFilter = null;
            addFilter2 = null;
            addFilter = null;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void ViewSavings_Load(object sender, EventArgs e)
        {
            displayAllMembersSavings(strFilter);
            displayAllMembersSavingsDetails(strFilter);
            getTotalSavings(strFilter);
            getSelectedDetailsTotalSavings(strFilter);
        }

        private void displayAllMembersSavings(string strFilter)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select m.MemberID, m.FileNo, m.Title + ' ' + m.LastName + ' ' + m.FirstName + ' ' + m.MiddleName as Fullname, SUM(s.Amount) as Amount " +
                "from Members m left join savings s on m.MemberID=s.MemberID " + strFilter + 
                " group by m.MemberID,m.FileNo,m.Title,m.MiddleName,m.FirstName,m.LastName order by m.FileNo";

            //MessageBox.Show(strQuery);
            
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            datGridViewSavings.DataSource = null;
            datGridViewSavings.Columns.Clear();
            datGridViewSavings.Rows.Clear();
            datGridViewSavings.Refresh();            

            try
            {
                conn.Open();
                da.Fill(ds, "Savings");
                dtSavings = ds.Tables["Savings"];
                datGridViewSavings.DataSource = dtSavings;

                datGridViewSavings.Columns["MemberID"].Visible = false;
                datGridViewSavings.Columns["FileNo"].HeaderText = "File No.";
                datGridViewSavings.Columns["Fullname"].HeaderText = "First Name";
                datGridViewSavings.Columns["Fullname"].Width = 300;
                
                datGridViewSavings.Columns["Amount"].DefaultCellStyle.Format = "N2";
                datGridViewSavings.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                datGridViewSavings.Columns.Add(btn);
                btn.HeaderText = "View";
                btn.Text = "View Details";
                btn.Name = "btn";
                btn.UseColumnTextForButtonValue = true;

                lblSavingsRecordNo.Text = "No. of Records: " + ds.Tables["Savings"].Rows.Count;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Display All Members Savings -- " + ex.Message);
            }
            finally
            {
                conn.Close();
            }


        }

        private void displayAllMembersSavingsDetails(string strFilter)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select m.MemberID, m.FileNo, m.Title + ' ' + m.LastName + ' ' + m.FirstName + ' ' + m.MiddleName as Fullname, " +
                "s.SavingSource as Source, s.Amount, d.Month, s.year as Year, s.TransactionID, s.Date from Members m left join Savings s on m.MemberID=s.MemberID " +
                "left join MonthByName d on s.Month=d.MonthID " + strFilter +
                " order by s.SavingsID desc";
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            datGridSavingsDetails.DataSource = null;
            datGridSavingsDetails.Columns.Clear();
            datGridSavingsDetails.Rows.Clear();
            datGridSavingsDetails.Refresh();

            try
            {
                conn.Open();
                da.Fill(ds, "Savings");
                dtSavingsDetails = ds.Tables["Savings"];               

                datGridSavingsDetails.DataSource = dtSavingsDetails;

                datGridSavingsDetails.Columns["MemberID"].Visible = false;
                datGridSavingsDetails.Columns["Fullname"].Width = 200;
                datGridSavingsDetails.Columns["FileNo"].Width = 80;
                datGridSavingsDetails.Columns["FileNo"].HeaderText = "File No.";
                datGridSavingsDetails.Columns["Amount"].DefaultCellStyle.Format = "N2";
                datGridSavingsDetails.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                datGridSavingsDetails.Columns["TransactionID"].Width = 150;
                datGridSavingsDetails.Columns["Month"].Width = 80;
                datGridSavingsDetails.Columns["Year"].Width = 80;

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                datGridSavingsDetails.Columns.Add(btn);
                btn.HeaderText = "Action";
                btn.Text = "View Details";
                btn.Name = "btnDetails";
                btn.UseColumnTextForButtonValue = true;

                lblSavingsRecordDetail.Text = "No of Records: " + ds.Tables["Savings"].Rows.Count;

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

        private void getTotalSavings(string strFilter)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select SUM(Amount) as Total from Savings " + strFilter;
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            //MessageBox.Show(strQuery);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        lblTotalSavings.Text = "Total Savings:  " + CheckForNumber.formatCurrency2(reader["Total"].ToString());
                    }
                }
               
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Total Savings: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void datGridViewSavings_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int memberID;
            string theID = null;
            string totalSavings = string.Empty;

            //MessageBox.Show(e.ColumnIndex.ToString());
            if (e.ColumnIndex == 0)
            {
                theID = datGridViewSavings.Rows[e.RowIndex].Cells[1].Value.ToString();
                totalSavings = datGridViewSavings.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
            }
            else if (e.ColumnIndex==4)
            {
                theID = datGridViewSavings.Rows[e.RowIndex].Cells[0].Value.ToString();
                
            }
            //MessageBox.Show(totalSavings.ToString());
            if (e.ColumnIndex == 0 && totalSavings != string.Empty)
            {
                memberID = Convert.ToInt16(theID);

                strFilter = "where m.MemberID=" + memberID + addFilter;
                displayAllMembersSavingsDetails(strFilter);

                strFilter = "where MemberID=" + memberID + addFilter2;
                getSelectedDetailsTotalSavings(strFilter);
            }
            else
            {
                MessageBox.Show("There is no Savings yet for the Selected Member", "View Savings", MessageBoxButtons.OK, MessageBoxIcon.Information);
                datGridSavingsDetails.DataSource = null;
                datGridSavingsDetails.Columns.Clear();
                datGridSavingsDetails.Rows.Clear();

                lblSelectedSavingsTotal.Text = "Total: 0.0";
                lblSavingsRecordDetail.Text = "No. of Records: 0";

            }

        }



        private void getSelectedDetailsTotalSavings(string strFilter)
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select SUM(Amount) as Total from Savings " + strFilter;
            SqlCommand cmd = new SqlCommand(strQuery, conn);

            //MessageBox.Show(strQuery);
            try
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    if (reader.Read())
                    {
                        lblSelectedSavingsTotal.Text = "Total Savings:  " + CheckForNumber.formatCurrency2(reader["Total"].ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Total Savings: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void txtFileNoSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtFileNoSearch.Text != string.Empty)
            {
                clearParameters();

                string memberIDList = string.Empty;

                SqlConnection conn = ConnectDB.GetConnection();
                string strQuery = "Select MemberID from Members where FileNo LIKE '%" + txtFileNoSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (memberIDList==string.Empty)
                            {
                                memberIDList = reader["MemberID"].ToString();
                            }
                            else
                            {
                                memberIDList += "," + reader["MemberID"].ToString(); 
                            }
                        }

                        strFilter = " where m.FileNo LIKE '%" + txtFileNoSearch.Text + "%'";
                        

                        displayAllMembersSavings(strFilter);
                        displayAllMembersSavingsDetails(strFilter);
                        


                        strFilter = " where MemberID in (" + memberIDList + ")";
                        getTotalSavings(strFilter);

                        getSelectedDetailsTotalSavings(strFilter);
                        

                    }
                    else
                    {
                        datGridViewSavings.DataSource = null;
                        datGridViewSavings.Columns.Clear();
                        datGridViewSavings.Rows.Clear();
                        datGridViewSavings.Refresh();

                        datGridSavingsDetails.DataSource = null;
                        datGridSavingsDetails.Columns.Clear();
                        datGridSavingsDetails.Rows.Clear();
                        datGridSavingsDetails.Refresh();
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
        }

        private void cboSourceSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSourceSearch.SelectedIndex != 0)
            {
                strFilter = " where s.SavingSource='" + cboSourceSearch.Text + "'";
                addFilter = " and s.SavingSource='" + cboSourceSearch.Text + "'";
                addFilter2 = " and SavingSource='" + cboSourceSearch.Text + "'";

                displayAllMembersSavings(strFilter);
                displayAllMembersSavingsDetails(strFilter);

                strFilter = " where SavingSource='" + cboSourceSearch.Text + "'";
                getTotalSavings(strFilter);
                getSelectedDetailsTotalSavings(strFilter);
            }
            else
            {
                clearParameters();
                
                displayAllMembersSavings(strFilter);
                displayAllMembersSavingsDetails(strFilter);
                getTotalSavings(strFilter);
                getSelectedDetailsTotalSavings(strFilter);
            }
        }

        private void cboMonthSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            strFilter = " where s.Month='" + (cboMonthSearch.SelectedIndex) + "'";
            addFilter = " and s.Month='" + (cboMonthSearch.SelectedIndex) + "'";
            displayAllMembersSavings(strFilter);
            displayAllMembersSavingsDetails(strFilter);

            if (datGridViewSavings.Rows.Count != 0)
            {

                strFilter = " where Month='" + (cboMonthSearch.SelectedIndex) + "'";
                addFilter2 = " and Month='" + (cboMonthSearch.SelectedIndex) + "'";
                getTotalSavings(strFilter);
                getSelectedDetailsTotalSavings(strFilter);
            }
            else
            {
                lblTotalSavings.Text = "Total Savings:  0";
                lblSelectedSavingsTotal.Text = "Total Savings:  0";
            }

        }

        private void cboYearSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(cboYearSearch.Text.ToString());
            //int val;
            //bool result = int.TryParse(cboYearSearch.Text, out val);

            //MessageBox.Show(result.ToString());

            strFilter = " where s.Year='" + cboYearSearch.Text.Trim() + "' ";
            addFilter = " and s.Year='" + cboYearSearch.Text.Trim() + "' ";
            displayAllMembersSavings(strFilter);
            displayAllMembersSavingsDetails(strFilter);

            if (datGridViewSavings.Rows.Count != 0)
            {
                strFilter = " where Year='" + cboYearSearch.Text.Trim() + "' ";
                addFilter2 = " and Year='" + cboYearSearch.Text.Trim() + "' ";
                getTotalSavings(strFilter);
                getSelectedDetailsTotalSavings(strFilter);
            }
            else
            {
                lblTotalSavings.Text = "Total Savings:  0";
                lblSelectedSavingsTotal.Text = "Total Savings:  0";
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string searchCriteria = string.Empty;
            string searchCriteriaTotal = string.Empty;           


            if (txtFileNoSearch.Text != string.Empty)
            {
                searchCriteria = " m.FileNo LIKE '%" + txtFileNoSearch.Text + "%'";
                searchCriteriaTotal = " MemberID in (" + getMemberSearchListByFileNo() + ") ";
            }

            if (cboSourceSearch.Text != string.Empty)
            {
                if (searchCriteria != string.Empty)
                {
                    searchCriteria += " and ";
                    searchCriteriaTotal += " and ";
                }
                searchCriteria += " s.SavingSource='" + cboSourceSearch.Text + "'";
                searchCriteriaTotal += " SavingSource='" + cboSourceSearch.Text + "'";
            }

            
            if (cboMonthSearch.Text != string.Empty)
            {
                if (searchCriteria != string.Empty)
                {
                    searchCriteria += " and ";
                    searchCriteriaTotal += " and ";
                }
                searchCriteria += " s.Month='" + cboMonthSearch.SelectedIndex + "'";
                searchCriteriaTotal += " Month='" + cboMonthSearch.SelectedIndex + "'";
            }


            if (cboYearSearch.Text != string.Empty)
            {
                if (searchCriteria != string.Empty)
                {
                    searchCriteria += " and ";
                    searchCriteriaTotal += " and ";
                }
                searchCriteria += "s.Year='" + cboYearSearch.Text + "'";
                searchCriteriaTotal += " Year='" + cboYearSearch.Text + "'";
            }   



            if (searchCriteria != string.Empty)
            {
                searchCriteria = " where " + searchCriteria + " ";
                searchCriteriaTotal = "where " + searchCriteriaTotal + " ";

                displayAllMembersSavings(searchCriteria);
                displayAllMembersSavingsDetails(searchCriteria);

                getTotalSavings(searchCriteriaTotal);
                getSelectedDetailsTotalSavings(searchCriteriaTotal);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            strFilter = string.Empty;
            ViewSavings_Load(sender, e);
        }

        private string getMemberSearchListByFileNo()
        {
            string memberIDList = string.Empty;

                SqlConnection conn = ConnectDB.GetConnection();
                string strQuery = "Select MemberID from Members where FileNo LIKE '%" + txtFileNoSearch.Text + "%'";
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            if (memberIDList == string.Empty)
                            {
                                memberIDList = reader["MemberID"].ToString();
                            }
                            else
                            {
                                memberIDList += "," + reader["MemberID"].ToString();
                            }
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

                return memberIDList;
        }

        private void btnDateFilter_Click(object sender, EventArgs e)
        {
            if ((cboFromMonthSearch.Text != string.Empty) && (cboFromYearSearch.Text != string.Empty) && (cboToMonthSearch.Text != string.Empty) && (cboToYearSearch.Text != string.Empty))
            {
                int toYear = Convert.ToInt16(cboToYearSearch.Text);
                int fromYear = Convert.ToInt16(cboFromYearSearch.Text);

                MessageBox.Show(cboToMonthSearch.SelectedIndex.ToString());

                if (toYear > fromYear)
                {
                    strFilter = " where s.Month between " + cboFromMonthSearch.SelectedIndex + " and " + cboToMonthSearch.SelectedIndex +
                        " or s.Year between " + cboFromYearSearch.Text + " and " + cboToYearSearch.Text + " " ;

                    displayAllMembersSavings(strFilter);
                    displayAllMembersSavingsDetails(strFilter);

                    strFilter = " where Month between " + cboFromMonthSearch.SelectedIndex + " and " + cboToMonthSearch.SelectedIndex +
                        " or Year between " + cboFromYearSearch.Text + " and " + cboToYearSearch.Text + " ";

                    getTotalSavings(strFilter);
                    getSelectedDetailsTotalSavings(strFilter);
                }
                else
                {
                    MessageBox.Show("The Date period has to be in the proper order", "Savings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Select the Date periods to perform this search", "Savings", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExportSavings_Click(object sender, EventArgs e)
        {
            ExportData exportSavings = new ExportData();
            exportSavings.ExportToExcel(dtSavings,saveFD);
        }

        private void btnExportSavingsDetails_Click(object sender, EventArgs e)
        {
            ExportData exportSavingsDetails = new ExportData();
            exportSavingsDetails.ExportToExcel(dtSavingsDetails, saveFD);
        }

        private void btnDateFilter_Click_1(object sender, EventArgs e)
        {

        }

        



    }
}
