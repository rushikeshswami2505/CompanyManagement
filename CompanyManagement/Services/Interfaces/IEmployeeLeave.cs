﻿using CompanyManagement.Data;
using CompanyManagement.Models;

namespace CompanyManagement.Services.Interfaces
{
    public interface IEmployeeLeave
    {
        Task AddNewLeave(EmployeeLeavesModel model);
        Task<List<EmployeeLeave>> GetAllLeaveHistoryById(int empId);
        /*Task DeleteEmployee(int id);
Task EditEmployee(EmployeeDetailsModel model);
Task<List<EmployeeDetails>> GetAllEmployees();
Task<IEnumerable<EmployeeDetails>> GetAllEmployeesByProjectId(int id);
Task<EmployeeDetailsModel> GetEmployeeDetailsById(int id);*/
    }
}
