using ExporterObjects;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Data;

using Excel = Microsoft.Office.Interop.Excel;
using ExcelAutoFormat = Microsoft.Office.Interop.Excel.XlRangeAutoFormat;
using HRManagement.Controllers;
using HRManagement;

namespace HRManagement
{
    public class ExcelExporter : IExcelExporter
    {
        private string uploadDir = @"/EmployeeData/Reports";

        public string ExportEmployees(IEnumerable<EmployeeExportViewModel> data, string filename)
        {
            var path = Path.Combine(HttpContext.Current.Server.MapPath(uploadDir)) + "\\" + filename + ".xlsx";
            if (File.Exists(path))
            {
                File.Delete(path);
            }
            Excel.Application xlAppToExport = new Excel.Application();
            xlAppToExport.Workbooks.Add("");

            // ADD A WORKSHEET.
            Excel.Worksheet xlWorkSheetToExport = default(Excel.Worksheet);
            xlWorkSheetToExport = (Excel.Worksheet)xlAppToExport.Sheets["Sheet1"];

            // ROW ID FROM WHERE THE DATA STARTS SHOWING.
            int iRowCnt = 8;

            // SHOW THE HEADER.
            xlWorkSheetToExport.Cells[1, 1] = "Employee Details";

            Excel.Range range = xlWorkSheetToExport.Cells[1, 1] as Excel.Range;
            range.EntireRow.Font.Name = "Calibri";
            range.EntireRow.Font.Bold = true;
            range.EntireRow.Font.Size = 20;

            xlWorkSheetToExport.Range["A1:D1"].MergeCells = true;       // MERGE CELLS OF THE HEADER.

            // SHOW COLUMNS ON THE TOP.
            xlWorkSheetToExport.Cells[iRowCnt - 1, 1] = "Name";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 2] = "Date of birth";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 3] = "Gender";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 4] = "Nationality";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 5] = "Positions";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 6] = "Languages";
            xlWorkSheetToExport.Cells[iRowCnt - 1, 7] = "Trainings";

            int i;
            for (i = 0; i <= data.Count() - 1; i++)
            {
                xlWorkSheetToExport.Cells[iRowCnt, 1] = data.ElementAt(i).Name;
                xlWorkSheetToExport.Cells[iRowCnt, 2] = data.ElementAt(i).DateOfBirth;
                xlWorkSheetToExport.Cells[iRowCnt, 3] = data.ElementAt(i).Gender;
                xlWorkSheetToExport.Cells[iRowCnt, 4] = data.ElementAt(i).Nationality;
                xlWorkSheetToExport.Cells[iRowCnt, 5] = data.ElementAt(i).Positions;
                xlWorkSheetToExport.Cells[iRowCnt, 6] = data.ElementAt(i).Languages;
                xlWorkSheetToExport.Cells[iRowCnt, 7] = data.ElementAt(i).Trainings;


                iRowCnt = iRowCnt + 1;
            }

            // SAVE THE FILE IN A FOLDER.
            xlWorkSheetToExport.SaveAs(path);

            // CLEAR.
            xlAppToExport.Workbooks.Close();
            xlAppToExport.Quit();
            xlAppToExport = null;
            return path;
        }
    }
}