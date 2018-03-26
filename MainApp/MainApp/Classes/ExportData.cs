using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MainApp
{
    public class ExportData
    {
        

        public void ExportToExcel(DataTable dt, SaveFileDialog saveFD)
        {
            object misValue = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            app.Visible = false;

            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;

            //Headers
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                ws.Cells[1, i + 1] = dt.Columns[i].ColumnName;
            }

            //content
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    ws.Cells[i + 2, j + 1] = dt.Rows[i][j].ToString();
                }
            }

            ws.Name = dt.TableName;

            string SavedFile = string.Empty;
            saveFD.InitialDirectory = "C:";
            saveFD.Title = "Export File to Location with FileName";
            saveFD.FileName = "";
            saveFD.Filter = "Excel Files|*.xls|All Files|*.*";

            try
            {
                if (saveFD.ShowDialog() != DialogResult.Cancel)
                {
                    SavedFile = saveFD.FileName;
                    //wb.SaveAs(@"C:\Users\seyibabs\Documents\exportData.xls", Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    wb.SaveAs(@SavedFile, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    wb.Close(true, misValue, misValue);
                    app.Quit();
                    MessageBox.Show("Information item has been exported to the Saved File and Location", "Contribution", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            

        }
    }
}
