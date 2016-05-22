
using HRManagement.DataAccess.Models.Models;
using System;

namespace HRManagement.ViewModels.Training
{
    public class EmployeesAssignedToTrainingViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TrainingStatus Status { get; set; }
        public string StatusDescription { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
    }
}
