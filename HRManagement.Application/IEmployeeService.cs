﻿using HRManagement.DataAccess.Models.Models;
using HRManagement.ViewModels.Employee;
using System;
using System.Collections.Generic;

namespace HRManagement.Application
{
    public interface IEmployeeService
    {
        List<Employee> GetAllEmployees();
        EditEmployeeViewModel GetEmployeeForEdit(int? id);
        void SetChangesForEmployee(int id, int positionId, int projectId, string lastName, string middleName, string firstName);
        CreateEmployeeViewModel GetEmployeeForCreate();
        void CreateEmployee(CreateEmployeeViewModel input);
        List<GetTrainingForEmployeeViewModel> GetTrainingForEmployee(int? id);
        GetContactInformationForEmployeeViewModel GetContactInformationForEmployee(int? id);
        //void CreateContactInformationForEmployee(string address, string city, string postalCode, string state, string workPhone, string privatePhone, string workEmail, string privateEmail);
    }
}