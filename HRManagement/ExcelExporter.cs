using ExporterObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HRManagement
{
    public class ExcelExporter<T> : IExcelExporter<T> where T : class
    {
        private string uploadDir = @"/EmployeeData/Reports";

        public string Export(IEnumerable<T> data, string filename)
        {
            ExportList<T> exp = new ExportList<T>();
            exp.PathTemplateFolder = Path.Combine(HttpContext.Current.Server.MapPath(uploadDir));
            exp.ExportTo(data, ExportToFormat.Excel2003XML, Path.Combine(HttpContext.Current.Server.MapPath(uploadDir) , filename + ".xls"));
            return exp.PathTemplateFolder + "\\" + filename + ".xls";
        }
    }
}