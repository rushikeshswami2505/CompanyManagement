﻿using CompanyManagement.Data;
using CompanyManagement.Models;
using CompanyManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Services
{
    public class EmployeeDetailsServices : IEmployeeDetails
    {
        private Context db;

        public EmployeeDetailsServices(Context context)
        {
            db = context;
        }
        public async Task <List<EmployeeDetails>> GetAllEmployees()
        {
            return await db.EmployeeDetails.ToListAsync();
        }

        public async Task AddNewEmployee(EmployeeDetailsModel model)
        {
            EmployeeDetails employeeDetails = ModelToEmployeeDetails(model);
            await db.EmployeeDetails.AddAsync(employeeDetails);
            await db.SaveChangesAsync();
        }


        public async Task<EmployeeDetailsModel> GetEmployeeDetailsById(int id)
        {
            var row = await db.EmployeeDetails.Where(i => i.empId ==  id).FirstOrDefaultAsync();
            if (row == null) return null;
            EmployeeDetailsModel model = EmployeeDetailsToModel(row);
            return model;
        }
        public async Task EditEmployee(EmployeeDetailsModel model)
        {
            EmployeeDetails employeeDetails = ModelToEmployeeDetails(model);
            db.Entry(employeeDetails).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<EmployeeDetails>> GetAllEmployeesByProjectId(int projectId)
        {
            var employees = await (from emp in db.EmployeeDetails
                                   join empMap in db.EmployeeProjectMaps on emp.empId equals empMap.empId
                                   where empMap.projectId == projectId
                                   select emp).ToListAsync();

            return employees;
        }

        public async Task DeleteEmployee(int id)
        {
            var row = await db.EmployeeDetails.FindAsync(id);
            if (row == null) return;
            db.EmployeeDetails.Remove(row);
            await db.SaveChangesAsync();
        }

        private EmployeeDetailsModel EmployeeDetailsToModel(EmployeeDetails? row)
        {
            EmployeeDetailsModel model = new EmployeeDetailsModel();
            model.empId = row.empId;
            model.empName = row.empName;
            model.empCity = row.empCity;
            model.empContact = row.empContact;
            model.empBloodGroup = row.empBloodGroup;
            model.empDob = row.empDob;
            model.empCountry = row.empCountry;
            model.empState = row.empState;
            model.empEmail = row.empEmail;
            model.empPassword = row.empPassword;
            return model;
        }


        private EmployeeDetails ModelToEmployeeDetails(EmployeeDetailsModel model)
        {
            EmployeeDetails employeeDetails = new EmployeeDetails();
            employeeDetails.empId = model.empId;
            employeeDetails.empName = model.empName;
            employeeDetails.empEmail = model.empEmail;
            employeeDetails.empBloodGroup = model.empBloodGroup;
            employeeDetails.empCity = model.empCity;
            employeeDetails.empContact = model.empContact;
            employeeDetails.empCountry = model.empCountry;
            employeeDetails.empState = model.empState;
            employeeDetails.empDob = model.empDob;
            employeeDetails.empPassword = model.empPassword;
            return employeeDetails;
        }

        public async Task<EmployeeDetailsModel> GetEmployeeDetailsByEmail(string empEmail)
        {
            var row = await db.EmployeeDetails.Where(i => i.empEmail == empEmail).FirstOrDefaultAsync();
            if (row == null) return null;
            EmployeeDetailsModel model = EmployeeDetailsToModel(row);
            return model;
        }

        public async Task<EmployeesWithRole> GetAllEmployeesWithRoles()
        {
            var data1 = await GetAllEmployees();
            var data2 = await db.RoleDetails.ToListAsync();
            EmployeesWithRole employeesWithRole = new EmployeesWithRole();
            employeesWithRole.Employees = data1;
            employeesWithRole.Roles = data2;
            return employeesWithRole;
        }
    }
}