using CompanyManagement.Data;
using CompanyManagement.Models;
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
                                   join empProj in db.EmployeeProjectMaps on emp.empId equals empProj.empId
                                   where empProj.projectId == projectId
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
            return model;
        }


        private EmployeeDetails ModelToEmployeeDetails(EmployeeDetailsModel model)
        {
            EmployeeDetails employeeDetails = new EmployeeDetails();
            employeeDetails.empId = model.empId;
            employeeDetails.empName = model.empName;
            employeeDetails.empBloodGroup = model.empBloodGroup;
            employeeDetails.empCity = model.empCity;
            employeeDetails.empContact = model.empContact;
            employeeDetails.empCountry = model.empCountry;
            employeeDetails.empState = model.empState;
            employeeDetails.empDob = model.empDob;
            return employeeDetails;
        }

    }
}