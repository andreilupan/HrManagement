using HRManagement.DataAccess.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManagement.ViewModels.Employee
{
 public class GetTrainingForEmployeeViewModel
    {   public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TrainingStatus Status { get; set; }
        public string StatusDescription { get; set; }
    }
}
