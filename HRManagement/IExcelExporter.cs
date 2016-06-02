using HRManagement.Controllers;
using System.Collections.Generic;

namespace HRManagement
{
    public interface IExcelExporter
    {
        string ExportEmployees(IEnumerable<EmployeeExportViewModel> data, string filename);
    }
}
