using HRManagement.DataAccess.Models.Models;
using System;

namespace HRManagement.ViewModels.Employee
{
 public class GetTrainingListForEmployeeViewModel
    {   public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TrainingStatus Status { get; set; }
        public string StatusDescription { get; set; }
    }
}
