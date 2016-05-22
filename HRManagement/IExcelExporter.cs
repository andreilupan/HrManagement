using System.Collections.Generic;

namespace HRManagement
{
    public interface IExcelExporter<T>
    {
        string Export(IEnumerable<T> data, string filename);
    }
}
