using HRManagement.DataAccess.Models.Models;
using HRManagement.ViewModels.Employee;
using System;
using System.Collections.Generic;

namespace HRManagement.Application
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        EditEmployeeViewModel GetEmployeeForEdit(int? id);
        EditContactInformationForEmployeeViewModel GetContactInformationForEdit(int? id);
        void EditContactInformation(int employeeId, string address, string city, string postalCode, string state, string workPhone, string privatePhone, string workEmail, string privateEmail);
        void SetChangesForEmployee(int id, int positionId, int projectId, string lastName, string middleName, string firstName, DateTime dateOfBirth, Gender gender, string nationality, string nID);
        CreateEmployeeViewModel GetEmployeeForCreate();
        int CreateEmployee(CreateEmployeeViewModel input);
        GetTrainingForEmployeeViewModel GetTrainingForEmployee(int? id);
        GetContactInformationForEmployeeViewModel GetContactInformationForEmployee(int? id);
        GetEmploymentInformationForEmployeeViewModel GetEmploymentInformationForEmployee(int? id);
        void AttachImage(int employeeId, string imageUrl);
        //void CreateContactInformationForEmployee(string address, string city, string postalCode, string state, string workPhone, string privatePhone, string workEmail, string privateEmail);
    }
}
