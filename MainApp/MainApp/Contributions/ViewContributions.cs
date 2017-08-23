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
    public partial class ViewContributions : Form
    {
        SqlConnection conn;
        SqlCommand cmd, cmdTotal;
        SqlDataAdapter da;
        DataSet ds;
        DataTable dt;

        string totalContributionOfDataSet = null;

        public ViewContributions()
        {
            InitializeComponent();
        }

        private void ViewContributions_Load(object sender, EventArgs e)
        {
            loadAllContributions();
            loadMonthIntoComboBox();
            loadYearIntoComboBox();
            loadPaymentModeIntoComboBox();
            loadBanksIntoComboBox();
        }

        private void loadAllContributions()
        {
            selectQueryMethod();
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds,"Contributions");
                
                dt = ds.Tables["Contributions"];
                datGrdVContributions.DataSource = dt;
                datGrdVContributions.Columns[1].Width = 200;
                datGrdVContributions.Columns[3].DefaultCellStyle.Format = "N2";
                datGrdVContributions.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                lblRecordNo.Text = "No. of Records: " + dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            displayTotalOfDataSet();
        }

        private void displayTotalOfDataSet()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            cmdTotal = new SqlCommand(totalContributionOfDataSet, conn);

            try
            {
                conn.Open();
                SqlDataReader reader = cmdTotal.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    lblTotalAmountOfDataSet.Text = "Total:   " + CheckForNumber.formatCurrency2(reader["TotalAmount"].ToString());

                }
                else
                {
                    lblTotalAmountOfDataSet.Text = "Total:   0.0";
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


        private void loadMonthIntoComboBox()
        {
            conn = ConnectDB.GetConnection();
            string strQuery = "Select MonthID, Month from MonthByName";
            cmd = new SqlCommand(strQuery, conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Months");
                DataTable dt = ds.Tables["Months"];
                cboMonth.DisplayMember = "Month";
                cboMonth.ValueMember = "MonthID";

                cboFromMonth.DisplayMember = "Month";
                cboFromMonth.ValueMember = "MonthID";               
                                
                DataRow row = dt.NewRow();
                row["Month"] = "--Select--";
                dt.Rows.InsertAt(row, 0);

                cboMonth.DataSource = dt;

                
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

        private void loadYearIntoComboBox()
        {
            conn = ConnectDB.GetConnection();
            string strQuery = "Select distinct year from savings order by year";
            cmd = new SqlCommand(strQuery, conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Year");
                DataTable dt = ds.Tables["Year"];
                cboYear.DisplayMember = "year";
                cboYear.ValueMember = "year";
                     

                DataRow row = dt.NewRow();
                row["year"] = "--Select--";
                dt.Rows.InsertAt(row, 0);
                cboYear.DataSource = dt;

                
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

        private void loadPaymentModeIntoComboBox()
        {
            conn = ConnectDB.GetConnection();
            string strQuery = "select PaymentModeID, PaymentMode from PaymentMode";
            cmd = new SqlCommand(strQuery, conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "PaymentMode");
                DataTable dt = ds.Tables["PaymentMode"];
                cboPaymentMode.DisplayMember = "PaymentMode";
                cboPaymentMode.ValueMember = "PaymentModeID";

                DataRow row = dt.NewRow();
                row["PaymentMode"] = "--Select--";
                dt.Rows.InsertAt(row, 0);
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

        private void loadBanksIntoComboBox()
        {

            conn = ConnectDB.GetConnection();
            string strQuery = "Select BankID, BankName from Banks order by BankName";
            cmd = new SqlCommand(strQuery, conn);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            try
            {
                conn.Open();
                da.Fill(ds, "Banks");
                DataTable dt = ds.Tables["Banks"];

                cboBanks.DisplayMember = "BankName";
                cboBanks.ValueMember = "BankID";

                DataRow row = dt.NewRow();
                row["BankName"] = "--Select--";
                dt.Rows.InsertAt(row, 0);

                cboBanks.DataSource = dt;
                
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

        private SqlCommand selectQueryMethod()
        {
            conn = ConnectDB.GetConnection();
            string strQuery = "Select m.FileNo, m.Title + ' ' + m.LastName + ' ' + m.MiddleName + ' ' +  m.FirstName as [Full Name], " +
                "mst.Remark [Account],s.Amount, d.Month, s.Year, p.PaymentMode [Payment Mode], c.OtherPayment [Other Payment], " +
                "b.BankName [Bank], c.TellerNo [Teller No.], c.Comment, c.TransactionID, s.Date " +
                "from Savings s left join Contributions c on s.SavingsID=c.SavingsID " +
                "left join Members m on s.MemberID = m.MemberID " +
                "left join MonthByName d on s.Month=d.MonthID " +
                "left join PaymentMode p on c.PaymentModeID=p.PaymentModeID " +
                "left join Banks b on c.BankID=b.BankID " +
                "left join MemberSavingsTypeAcct mst on c.SavingsAcctID=mst.SavingsTypeID and m.MemberID=mst.MemberID " +
                "where s.SavingSource='Contribution' order by s.SavingsID desc";


            //Get TotalAmount of DataSet
            totalContributionOfDataSet = "Select SUM(s.Amount) as TotalAmount " +
                "from Savings s left join Contributions c on s.SavingsID=c.SavingsID " +
                "left join Members m on s.MemberID = m.MemberID " +
                "left join MonthByName d on s.Month=d.MonthID " +
                "left join PaymentMode p on c.PaymentModeID=p.PaymentModeID " +
                "left join Banks b on c.BankID=b.BankID where s.SavingSource='Contribution' ";

            cmd = new SqlCommand(strQuery, conn);
            cmdTotal = new SqlCommand(totalContributionOfDataSet, conn);
            return cmd;
        }

        private SqlCommand selectQueryMethod(string searchCriteria, string sender)
        {
            //MessageBox.Show(searchCriteria.ToString());
            string searchFilter = null;
            switch (sender)
            {
                case "FileNoAndName":
                    searchFilter = "m.FileNo LIKE '%" + searchCriteria + "%' OR " +
                                    "m.LastName LIKE '%" + searchCriteria + "%' OR " +
                                    "m.MiddleName LIKE '%" + searchCriteria + "%' OR " +
                                    "m.FirstName LIKE '%" + searchCriteria + "%'";
                    break;
                case "Month":
                    searchFilter = "s.Month='" + searchCriteria + "'";
                    break;
                case "Year":
                    searchFilter = "s.Year='" + searchCriteria + "'";
                    break;
                case "PaymentMode":
                    searchFilter = "c.PaymentModeID=" + searchCriteria ;
                    break;
                case "OtherPaymentMode":
                    searchFilter = "c.OtherPayment LIKE '%" + searchCriteria + "%'";
                    break;
                case "Banks":
                    searchFilter = "c.BankID='" + searchCriteria + "'";
                    break;
                case "TellerNo":
                    searchFilter = "c.TellerNo LIKE '%" + searchCriteria + "%'";
                    break;
                case "DateInterval":
                    searchFilter = searchCriteria;
                    break;

                case "Filter":
                    searchFilter = searchCriteria;
                    break;
            }

             //Configure search string for Total of DataSet
            totalContributionOfDataSet = "Select SUM(s.Amount) as TotalAmount " +
                "from Savings s left join Contributions c on s.SavingsID=c.SavingsID " +
                "left join Members m on s.MemberID = m.MemberID " +
                "left join MonthByName d on s.Month=d.MonthID " +
                "left join PaymentMode p on c.PaymentModeID=p.PaymentModeID " +
                "left join Banks b on c.BankID=b.BankID where s.SavingSource='Contribution' ";

            totalContributionOfDataSet = totalContributionOfDataSet + " AND " + searchFilter;
            //MessageBox.Show(totalContributionOfDataSet.ToString());

            conn = ConnectDB.GetConnection();
            string strQuery = "Select m.FileNo, m.Title + ' ' + m.LastName + ' ' + m.MiddleName + ' ' +  m.FirstName as [Full Name], " +
                "mst.Remark [Account],s.Amount, d.Month, s.Year, p.PaymentMode [Payment Mode], c.OtherPayment [Other Payment], b.BankName [Bank], c.TellerNo [Teller No.], c.Comment, c.TransactionID, s.Date " +
                "from Savings s left join Contributions c on s.SavingsID=c.SavingsID " +
                "left join Members m on s.MemberID = m.MemberID " +
                "left join MonthByName d on s.Month=d.MonthID " +
                "left join PaymentMode p on c.PaymentModeID=p.PaymentModeID " +
                "left join Banks b on c.BankID=b.BankID " +
                "left join MemberSavingsTypeAcct mst on c.SavingsAcctID=mst.SavingsTypeID and m.MemberID=mst.MemberID " +
                "where s.SavingSource='Contribution' and " + searchFilter  + " order by s.SavingsID desc";
            cmd = new SqlCommand(strQuery, conn);
            return cmd;
        }

        private void txtSearchByFileNoAndName_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearchByFileNoAndName.Text != string.Empty)
            {
                selectQueryMethod(txtSearchByFileNoAndName.Text, "FileNoAndName");
                displaySearchResult();               
            }
            else
            {
                loadAllContributions();
            }
        }

        private void cboMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboMonth.SelectedIndex != 0)
            {
                selectQueryMethod(cboMonth.SelectedValue.ToString(), "Month");
                displaySearchResult();
            }
            else
            {
                loadAllContributions();
            }
        }

        private void cboYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboYear.SelectedIndex != 0)
            {
                selectQueryMethod(cboYear.SelectedValue.ToString(), "Year");
                displaySearchResult();
            }
            else
            {
                loadAllContributions();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cboPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboPaymentMode.SelectedIndex != 0)
            {
                selectQueryMethod(cboPaymentMode.SelectedValue.ToString(), "PaymentMode");
                displaySearchResult();
            }
            else
            {
                loadAllContributions();
            }
        }

        private void txtOtherPaymentMode_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtOtherPaymentMode.Text != string.Empty)
            {
                selectQueryMethod(txtOtherPaymentMode.Text, "OtherPaymentMode");
                displaySearchResult();
            }
            else
            {
                loadAllContributions();
            }
        }

        private void displaySearchResult()
        {
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();

            datGrdVContributions.DataSource = null;
            try
            {
                conn.Open();
                da.Fill(ds, "Contributions");               
                
                dt = ds.Tables["Contributions"];
                
                    datGrdVContributions.DataSource = dt;
                    datGrdVContributions.Columns[1].Width = 200;
                    datGrdVContributions.Columns[3].DefaultCellStyle.Format = "N2";
                    datGrdVContributions.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
              
                lblRecordNo.Text = "No. of Records: " + dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


            //Call Method to display totalAmount of Displayed DataSet
            if (dt.Rows.Count != 0)
            {
                displayTotalOfDataSet();
            }
            else
            {
                lblRecordNo.Text = "No. of Records: " + dt.Rows.Count.ToString();
                lblTotalAmountOfDataSet.Text = "Total: 0.0";
            }
        }

        private void cboBanks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboBanks.SelectedIndex != 0)
            {
                selectQueryMethod(cboBanks.SelectedValue.ToString(), "Banks");
                displaySearchResult();
            }
            else
            {
                loadAllContributions();
            }
        }

        private void txtTellerNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtTellerNo.Text != string.Empty)
            {
                selectQueryMethod(txtTellerNo.Text, "TellerNo");
                displaySearchResult();
            }
            else
            {
                loadAllContributions();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string searchCriteria = string.Empty;
            if (txtSearchByFileNoAndName.Text != string.Empty)
            {
                searchCriteria += "(m.FileNo LIKE '%" + txtSearchByFileNoAndName.Text + "%' OR " +
                                    "m.LastName LIKE '%" + txtSearchByFileNoAndName.Text + "%' OR " +
                                    "m.MiddleName LIKE '%" + txtSearchByFileNoAndName.Text + "%' OR " +
                                    "m.FirstName  LIKE '%" + txtSearchByFileNoAndName.Text + "%') ";
            }

            if (cboMonth.SelectedIndex != 0)
            {
                if (searchCriteria != string.Empty)
                {
                    searchCriteria += " and " ;
                }
                searchCriteria += "(s.Month='" + cboMonth.SelectedValue + "')";
            }

            if (cboYear.SelectedIndex != 0)
            {
                if (searchCriteria != string.Empty)
                {
                    searchCriteria += " and ";
                }
                searchCriteria += "(s.Year='" + cboYear.SelectedValue + "')";
            }

            if (cboPaymentMode.SelectedIndex != 0)
            {
                if (searchCriteria != string.Empty)
                {
                    searchCriteria += " and ";
                }
                searchCriteria += "(c.PaymentModeID=" + cboPaymentMode.SelectedValue + ") ";
            }

            if (txtOtherPaymentMode.Text != string.Empty)
            {
                if (searchCriteria != string.Empty)
                {
                    searchCriteria += " and ";
                }
                searchCriteria += "(c.OtherPayment LIKE '%" + txtOtherPaymentMode.Text + "%') ";

            }

            if (cboBanks.SelectedIndex != 0)
            {
                if (searchCriteria != string.Empty)
                {
                    searchCriteria += " and ";
                }
                searchCriteria += "(c.BankID='" + cboBanks.SelectedValue.ToString() + "') ";
            }

            if (txtTellerNo.Text != string.Empty)
            {
                if (searchCriteria != string.Empty)
                {
                    searchCriteria += " and ";
                }
                searchCriteria += "(c.TellerNo LIKE '%" + txtTellerNo.Text + "%') ";
            }

            if (searchCriteria != string.Empty)
            {
                selectQueryMethod(searchCriteria, "Filter");
                displaySearchResult();
               
            }
            else
            {
                loadAllContributions();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnDatePeriodSearch_Click(object sender, EventArgs e)
        {
            if (cboFromMonth.Text != string.Empty && cboFromYear.Text != string.Empty && cboToMonth.Text != string.Empty && cboYear.Text != string.Empty)
            {
                int fromYear = int.Parse(cboFromYear.Text);
                int toYear = int.Parse(cboToYear.Text);

                int fromMonth = cboFromMonth.SelectedIndex;
                int toMonth = cboToMonth.SelectedIndex;

                if (fromYear>toYear)
                {
                    MessageBox.Show("Please ensure to select the dates in the proper order", "Contribution", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }else{
                    string strQuery = "((s.Month between '" + fromMonth + "' and '" + toMonth + "') AND (s.Year between '" + fromYear + "' and '" + toYear + "'))";
                    selectQueryMethod(strQuery, "DateInterval");
                    displaySearchResult();     
                    //MessageBox.Show(strQuery.ToString());
                }
            }
            else
            {
                MessageBox.Show("Please select the Months and Year Period to make this search","Contribution",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                if (dt.Columns.Count > 0)
                {
                    ExportData newExport = new ExportData();
                    newExport.ExportToExcel(dt, saveFD);
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

      
    }
}
