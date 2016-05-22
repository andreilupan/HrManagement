
using HRManagement.DataAccess.Models.Models;
using HRManagement.DataAccess.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;
using HRManagement.ViewModels.Employee;
using HRManagement.ViewModels.Extensions;

namespace HRManagement.Application
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _employeeRepository;
        private IPositionRepository _positionRepository;
        private IProjectRepository _projectRepository;
        //private IContactInformationRepository _contactInformationRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IPositionRepository positionRepository, IProjectRepository projectRepository/*, IContactInformationRepository contactInformationRepository*/)
        {
            _employeeRepository = employeeRepository;
            _positionRepository = positionRepository;
            _projectRepository = projectRepository;
            // _contactInformationRepository = contactInformationRepository;

        }
        public List<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees().ToList();
        }

        public GetContactInformationForEmployeeViewModel GetContactInformationForEmployee(int? id)
        {
            var employee = _employeeRepository.GetById(id).ContactInformation;
            var model = new GetContactInformationForEmployeeViewModel
            {
                Id = employee.Id,
                Address = employee.Address,
                City = employee.City,
                PostalCode = employee.PostalCode,
                PrivateEmail = employee.PrivateEmail,
                PrivatePhone = employee.PrivatePhone,
                State = employee.State,
                WorkEmail = employee.WorkEmail,
                WorkPhone = employee.WorkPhone
            };

            return model;
        }
        public GetTrainingForEmployeeViewModel GetTrainingForEmployee(int? id)
        {
            var employeeTrainings = _employeeRepository.GetById(id).Trainings;
            var model = new GetTrainingForEmployeeViewModel();

            model.EmployeeId = id.Value;
            model.Trainings = employeeTrainings.Select(x => new GetTrainingListForEmployeeViewModel
            {
                Id = x.Id,
                Name = x.Name,
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Status = x.Status,
                StatusDescription = x.Status.GetDescription()
            }).ToList();

            return model;
        }

        public EditEmployeeViewModel GetEmployeeForEdit(int? id)
        {
            var employee = _employeeRepository.GetById(id);
            var positions = _positionRepository.GetAll();
            var projects = _projectRepository.GetAllProjects();

            var model = new EditEmployeeViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                MiddleName = employee.MiddleName,
                Positions = positions.ToList(),
                Projects = projects.ToList(),
                ImageUrl = employee.ImageUrl
            };

            if (employee.Position != null)
            {
                model.PositionId = employee.Position.Id;
            }
            if (employee.Project != null)
            {
                model.ProjectId = employee.Project.Id;
            }

            return model;

        }

        public void SetChangesForEmployee(int employeeId, int positionId, int projectId, string lastName, string middleName, string firstName)
        {
            _employeeRepository.SetChangesForEmployee(employeeId, positionId, projectId, lastName, middleName, firstName);
        }

        public CreateEmployeeViewModel GetEmployeeForCreate()
        {
            var positions = _positionRepository.GetAll();
            var projects = _projectRepository.GetAllProjects();

            var model = new CreateEmployeeViewModel
            {
                Positions = positions.ToList(),
                Projects = projects.ToList()
            };

            return model;
        }
        public int CreateEmployee(CreateEmployeeViewModel input)
        {
            var employee = _employeeRepository.CreateEmployee(input.PositionId, input.ProjectId, input.LastName, input.MiddleName, input.FirstName, input.DateOfBirth, input.Gender, input.Nationality, input.Languages, input.NationalIdentificationNumber);
            _employeeRepository.AddContactInformation(employee.Id, input.Address, input.City, input.PostalCode, input.State, input.WorkPhone, input.PrivatePhone, input.WorkEmail, input.PrivateEmail);
            return employee.Id;
        }

        public void AttachImage(int employeeId, string imageUrl)
        {
            _employeeRepository.AttachImage(employeeId, imageUrl);
        }

        /* public void CreateContactInformationForEmployee(string address, string city, string postalCode, string state, string workPhone, string privatePhone, string workEmail, string privateEmail)
         {
             _contactInformationRepository.CreateContactInformation(address, city, postalCode, state, workPhone, privatePhone, workEmail, privateEmail);
         } */

    }
}
