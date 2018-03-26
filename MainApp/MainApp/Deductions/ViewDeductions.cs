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
    public partial class ViewDeductions : Form
    {
        private string month;
        private string year;
        private string strFilter;
        DataTable dt;


        public ViewDeductions(string month, string year)
        {
            InitializeComponent();

            this.month = month;
            this.year = year;
            this.strFilter = string.Empty;

        }

        private void ViewDeductions_Load(object sender, EventArgs e)
        {
            SqlConnection conn = ConnectDB.GetConnection();

            string strQuery = string.Empty;
            //MessageBox.Show(month + ' ' + year);
             if (month != string.Empty && year != string.Empty && strFilter==string.Empty)
             {
                 strQuery = "Select m.MemberID, m.FileNo, m.LastName + ' ' + m.FirstName  as 'Full Name'," +
                   "Mon.Month, d.Year, d.Savings, d.Loans, d.Total, d.TransactionID, d.DatePosted, d.DeductionID from Deductions d " +
                   "inner join Members m on d.MemberID=m.MemberID " +
                   "inner join MonthByName Mon on Mon.MonthID=d.Month " +
                   "where d.Month='" + month + "' and d.Year='" + year + "'";
             }
             else if (month != string.Empty && year != string.Empty && strFilter != string.Empty)
             {
                 strQuery = "Select m.MemberID, m.FileNo, m.LastName + ' ' + m.FirstName  as 'Full Name'," +
                   "Mon.Month, d.Year, d.Savings, d.Loans, d.Total, d.TransactionID, d.DatePosted, d.DeductionID from Deductions d " +
                   "inner join Members m on d.MemberID=m.MemberID " +
                   "inner join MonthByName Mon on Mon.MonthID=d.Month " +
                   "where d.Month='" + month + "' and d.Year='" + year + "' " +
                   "and (m.FileNo LIKE '%" + strFilter + "%' or  m.LastName LIKE '%" + strFilter + "%' or m.FirstName LIKE '%" + strFilter + "%')";
             }
             else if (month == string.Empty && year == string.Empty && strFilter ==string.Empty)
             {
                 strQuery = "Select m.MemberID, m.FileNo, m.LastName + ' ' + m.FirstName  as 'Full Name'," +
                  "Mon.Month, d.Year, d.Savings, d.Loans, d.Total, d.TransactionID, d.DatePosted, d.DeductionID from Deductions d " +
                  "inner join Members m on d.MemberID=m.MemberID " +
                  "inner join MonthByName Mon on Mon.MonthID=d.Month";
             }
             else if (month == string.Empty && year == string.Empty && strFilter != string.Empty)
             {
                 strQuery = "Select m.MemberID, m.FileNo, m.LastName + ' ' + m.FirstName  as 'Full Name'," +
                  "Mon.Month, d.Year, d.Savings, d.Loans, d.Total, d.TransactionID, d.DatePosted, d.DeductionID from Deductions d " +
                  "inner join Members m on d.MemberID=m.MemberID " +
                  "inner join MonthByName Mon on Mon.MonthID=d.Month " +
                  "and (m.FileNo like '%" + strFilter + "%' or  m.LastName LIKE '%" + strFilter + "%' or m.FirstName LIKE '%" + strFilter + "%')";
             }

             //MessageBox.Show(strQuery);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = strQuery;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            datGrdVwDeductions.DataSource = null;
            datGrdVwDeductions.Refresh();

            try
            {
                conn.Open();
                da.Fill(ds, "Deductions");

                dt = ds.Tables["Deductions"];
                datGrdVwDeductions.DataSource = dt;

                datGrdVwDeductions.Columns["Savings"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdVwDeductions.Columns["Savings"].DefaultCellStyle.Format = "N2";

                datGrdVwDeductions.Columns["Full Name"].Width = 250;

                datGrdVwDeductions.Columns["MemberID"].Visible = false;

                datGrdVwDeductions.Columns["Loans"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdVwDeductions.Columns["Loans"].DefaultCellStyle.Format = "N2";

                datGrdVwDeductions.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                datGrdVwDeductions.Columns["Total"].DefaultCellStyle.Format = "N2";

                datGrdVwDeductions.Columns["DeductionID"].Visible = false;                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            
            getDeductionMonthIntoCombo();
            getDeductionYearIntoCombo();

        }

        

        private void getDeductionMonthIntoCombo()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select distinct(d.Month) as id, m.Month as Mon  from Deductions d " +
                "inner join MonthByName m on d.Month=m.MonthID order by id asc";

            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Month");
                DataTable dt = ds.Tables["Month"];               
                

                DataRow row = dt.NewRow();
                row["Mon"] = "--Select Month--";
                dt.Rows.InsertAt(row, 0);
                cboMonth.DisplayMember = "Mon";
                cboMonth.ValueMember = "id";
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

        private void getDeductionYearIntoCombo()
        {
            SqlConnection conn = ConnectDB.GetConnection();
            string strQuery = "Select distinct(Year) as yearField from Deductions";

            SqlCommand cmd = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                da.Fill(ds, "Year");
                DataTable dt = ds.Tables["Year"];


                cboYear.DisplayMember = "yearField";
                cboYear.ValueMember =  "yearField";              

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
         
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != string.Empty)
            {
                strFilter = txtSearch.Text;
                ViewDeductions_Load(sender, e);
            }
        }

        private void btnDateSearch_Click(object sender, EventArgs e)
        {
            if (cboMonth.SelectedValue.ToString() != string.Empty)
            {
                SqlConnection conn = ConnectDB.GetConnection();
                string strQuery = "Select m.MemberID, m.FileNo, m.LastName + ' ' + m.FirstName  as 'Full Name'," +
                   "Mon.Month, d.Year, d.Savings, d.Loans, d.Total, d.TransactionID, d.DatePosted from Deductions d " +
                   "inner join Members m on d.MemberID=m.MemberID " +
                   "inner join MonthByName Mon on Mon.MonthID=d.Month " +
                   "where d.Month='" + cboMonth.SelectedValue.ToString() + "' and d.Year='" + cboYear.Text + "'";


                //MessageBox.Show(strQuery);
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = strQuery;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                datGrdVwDeductions.DataSource = null;
                datGrdVwDeductions.Refresh();

                try
                {
                    conn.Open();
                    da.Fill(ds, "Deductions");
                    dt = ds.Tables["Deductions"];
                    datGrdVwDeductions.DataSource = dt;

                    datGrdVwDeductions.Columns["Savings"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    datGrdVwDeductions.Columns["Savings"].DefaultCellStyle.Format = "N2";

                    datGrdVwDeductions.Columns["Full Name"].Width = 250;

                    datGrdVwDeductions.Columns["MemberID"].Visible = false;

                    datGrdVwDeductions.Columns["Loans"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    datGrdVwDeductions.Columns["Loans"].DefaultCellStyle.Format = "N2";

                    datGrdVwDeductions.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    datGrdVwDeductions.Columns["Total"].DefaultCellStyle.Format = "N2";



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

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportData exportDeductions = new ExportData();
            exportDeductions.ExportToExcel(dt, saveFD);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            ViewDeductions_Load(sender, e);
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            string selectedDeductionID = datGrdVwDeductions.SelectedRows[0].Cells[10].Value.ToString();
            ViewDeductionDetails viewDeductionDetails = new ViewDeductionDetails(selectedDeductionID);
            viewDeductionDetails.MdiParent = this.ParentForm;
            viewDeductionDetails.Show();


        }
    }
}
