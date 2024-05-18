using CompanyManagement.Data;
using CompanyManagement.Models;

namespace CompanyManagement.Services
{
    public class EmployeeLeaveServices : IEmployeeLeave
    {
        Context db;
        public EmployeeLeaveServices(Context context) {
            db = context;
        }
        public async Task AddNewLeave(EmployeeLeavesModel model)
        {
            EmployeeLeave employeeLeave = ModelToEmployeeLeave(model);
            await db.EmployeeLeaves.AddAsync(employeeLeave);
            await db.SaveChangesAsync();
        }

        private EmployeeLeave ModelToEmployeeLeave(EmployeeLeavesModel model)
        {
            EmployeeLeave employeeLeave = new EmployeeLeave();
            employeeLeave.leaveStartDate = model.leaveStartDate;
            employeeLeave.leaveEndDate = model.leaveEndDate;
            employeeLeave.leaveReason = model.leaveReason;
            employeeLeave.employeeLeaveId = model.employeeLeaveId;
            employeeLeave.empId = model.empId;
            return employeeLeave;
        }
    }
}
