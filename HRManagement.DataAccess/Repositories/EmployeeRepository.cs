using HRManagement.DataAccess.Models.Models;
using System.Linq;
using System;

namespace HRManagement.DataAccess.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private HrContext _dbContext;
        public EmployeeRepository(HrContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Employee> GetAllEmployees()
        {
            return _dbContext.Employees;
        }

        public Employee GetById(int? id)
        {
            return _dbContext.Employees.Find(id);
        }

        public void SetChangesForEmployee(int employeeId, int positionId, int projectId, string lastName, string middleName, string firstName, DateTime dateOfBirth, Gender gender, string nationality, string nID)
        {
            var employee = _dbContext.Employees.Find(employeeId);
            var position = _dbContext.Positions.Find(positionId);
            var project = _dbContext.Projects.Find(projectId);

            employee.Position = position;
            employee.Project = project;
            employee.FirstName = firstName;
            employee.MiddleName = middleName;
            employee.LastName = lastName;
            employee.DateOfBirth = dateOfBirth;
            employee.Gender = gender;
            employee.Nationality = nationality;
            employee.NationalIdentificationNumber = nID;

            _dbContext.SaveChanges();
        }

        public Employee CreateEmployee(int positionId, int projectId, string lastName, string middleName, string firstName, DateTime dateOfBirth, Gender gender, string nationality, Language language, string nID)
        {
            var position = _dbContext.Positions.Find(positionId);
            var project = _dbContext.Projects.Find(projectId);

            var employee = _dbContext.Employees.Add(new Employee
            {
                Position = position,
                Project = project,
                LastName = lastName,
                MiddleName = middleName,
                FirstName = firstName,
                DateOfBirth = dateOfBirth,
                Gender = gender,
                Nationality = nationality,
                Languages = language,
                NationalIdentificationNumber = nID,
            });

            _dbContext.SaveChanges();

            return employee;
        }

        public ContactInformation AddContactInformation(int employeeId, string address, string city, string postalCode, string state, string workPhone, string privatePhone, string workEmail, string privateEmail)
        {
            var user = _dbContext.Employees.Find(employeeId);

            var contactInformation = new ContactInformation
            {
                Address = address,
                City = city,
                PostalCode = postalCode,
                State = state,
                PrivateEmail = privateEmail,
                PrivatePhone = privatePhone,
                WorkEmail = workEmail,
                WorkPhone = workPhone
            };

            user.ContactInformation = contactInformation;
            _dbContext.SaveChanges();

            return user.ContactInformation;
        }

        public FinancialInformation AddFinancialInformation(int employeeId, Decimal salary, DateTime nextSalaryDiscussion, string accountNumber, string bank)
        {
            var user = _dbContext.Employees.Find(employeeId);

            var financialInformation = new FinancialInformation
            {
                Salary = salary,
                NextSalaryIncrease = nextSalaryDiscussion,
                AccountNumber = accountNumber,
                Bank = bank
            };

            user.FinancialInformation = financialInformation;
            _dbContext.SaveChanges();

            return user.FinancialInformation;
        }

        public void EditFinancialInformation(int employeeId, Decimal salary, DateTime nextSalaryDiscussion, string accountNumber, string bank)
        {
            var employee = _dbContext.Employees.Find(employeeId);

            employee.FinancialInformation.Salary = salary;
            employee.FinancialInformation.NextSalaryIncrease = nextSalaryDiscussion;
            employee.FinancialInformation.AccountNumber = accountNumber;
            employee.FinancialInformation.Bank = bank;

            _dbContext.SaveChanges();

        }

        public void EditContactInformation(int employeeId, string address, string city, string postalCode, string state, string workPhone, string privatePhone, string workEmail, string privateEmail)
        {
            var employee = _dbContext.Employees.Find(employeeId);

            employee.ContactInformation.Address = address;
            employee.ContactInformation.City = city;
            employee.ContactInformation.PostalCode = postalCode;
            employee.ContactInformation.State = state;
            employee.ContactInformation.WorkPhone = workPhone;
            employee.ContactInformation.PrivatePhone = privatePhone;
            employee.ContactInformation.WorkEmail = workEmail;
            employee.ContactInformation.PrivateEmail = privateEmail;

            _dbContext.SaveChanges();

        }

        public void EditEmploymentInformation(int employeeId, DateTime employmentDate, DateTime jubileeDate, DateTime dateProfessionalCompetence, DateTime dateTeachingSkills)
        {
            var employee = _dbContext.Employees.Find(employeeId);

            employee.EmploymentInformation.EmploymentDate = employmentDate;
            employee.EmploymentInformation.JubileeDate = jubileeDate;
            employee.EmploymentInformation.DateForFormalProfessionalCompetence = dateProfessionalCompetence;
            employee.EmploymentInformation.DateForFormalTeachingSkills = dateTeachingSkills;

            _dbContext.SaveChanges();
        }

        public EmploymentInformation AddEmploymentInformation(int employeeId, DateTime employmentDate, DateTime jubileeDate, DateTime dateProfessionalCompetence, DateTime dateTeachingSkills)
        {
            var user = _dbContext.Employees.Find(employeeId);

            var employmentInformation = new EmploymentInformation
            {
               EmploymentDate = employmentDate,
               JubileeDate = jubileeDate,
               DateForFormalProfessionalCompetence = dateProfessionalCompetence,
               DateForFormalTeachingSkills = dateTeachingSkills
            };

            user.EmploymentInformation = employmentInformation;
            _dbContext.SaveChanges();

            return user.EmploymentInformation;
        }

        public void AttachImage(int employeeId, string imageUrl)
        {
            var employee = _dbContext.Employees.Find(employeeId);

            if(employee!= null)
            {
                employee.ImageUrl = imageUrl;
                _dbContext.SaveChanges();
            }
        }
    }
}
