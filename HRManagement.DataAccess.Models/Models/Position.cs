using System.Collections.Generic;

namespace HRManagement.DataAccess.Models.Models
{
  public class Position : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Employee> Employees { get; set; }

    }
}
