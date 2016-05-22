using HRManagement.DataAccess.Models.Models;
using System;
using System.Linq;


namespace HRManagement.DataAccess.Repositories
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> GetAllEmployees();
        Employee GetById(int? id);
        void SetChangesForEmployee(int employeeId, int positionId, int projectId, string lastName, string middleName, string firstName);
        Employee CreateEmployee (int positionId, int projectId, string lastName, string middleName, string firstName, DateTime dateOfBirth, Gender gender, string nationality, Language language, string nID);
        ContactInformation AddContactInformation(int employeeId, string address, string city, string postalCode, string state, string workPhone, string privatePhone, string workEmail, string privateEmail);
        void AttachImage(int employeeId, string imageUrl);
    }

}
