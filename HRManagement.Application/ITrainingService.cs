using HRManagement.DataAccess.Models.Models;
using HRManagement.ViewModels.Training;
using System.Collections.Generic;

namespace HRManagement.Application
{
    public interface ITrainingService
    {
        List<Training> GetAllTrainings();
        List<EmployeesAssignedToTrainingViewModel> GetEmployeesForTraining(int? id);
    }
}
