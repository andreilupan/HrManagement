using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModels.Employee
{
   public class GetContactInformationForEmployeeViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string WorkPhone { get; set; }
        public string PrivatePhone { get; set; }
        public string WorkEmail { get; set; }
        public string PrivateEmail { get; set; }
        public int EmployeeId { get; set; }
    }
}
