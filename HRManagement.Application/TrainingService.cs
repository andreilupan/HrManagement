using HRManagement.DataAccess.Models.Models;
using HRManagement.DataAccess.Repositories;
using HRManagement.ViewModels.Training;
using System.Collections.Generic;
using System.Linq;

namespace HRManagement.Application
{
    public class TrainingService : ITrainingService
    {
        private ITrainingRepository _trainingRepository;
        public TrainingService(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
        }
        public List<Training> GetAllTrainings()
        {
           return _trainingRepository.GetAllTrainings().ToList();
        }
        public List<EmployeesAssignedToTrainingViewModel> GetEmployeesForTraining(int? id)
        {
            var trainingEmployees = _trainingRepository.GetTrainingById(id).Employees;

            return trainingEmployees.Select(x => new EmployeesAssignedToTrainingViewModel
            {   Id = x.Id,
                EmployeeFirstName=x.FirstName,
                EmployeeLastName=x.LastName
            }).ToList();
        }
    }
}
