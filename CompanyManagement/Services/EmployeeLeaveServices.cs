using CompanyManagement.Data;
using CompanyManagement.Models;
using CompanyManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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

            int leaveDuration = (model.leaveEndDate - model.leaveStartDate).Days + 1;
            var leaveDetails = await db.LeaveDetails.FirstOrDefaultAsync(ld => ld.empId == model.empId);
            if (leaveDetails != null)
            {
                if(leaveDetails.leavePaidRemain < leaveDuration)
                {
                    leaveDetails.leaveLOP = leaveDuration - leaveDetails.leavePaidRemain;
                    leaveDetails.leavePaidRemain = 0;
                    leaveDetails.leavePaidTaken = 20;

                }
                else
                {
                    leaveDetails.leavePaidTaken += leaveDuration;
                    leaveDetails.leavePaidRemain -= leaveDuration;
                }
            }
            else
            {
                leaveDetails = new LeaveDetails
                {
                    empId = model.empId,
                    leavePaidRemain = 20 - leaveDuration,
                    leavePaidTaken = leaveDuration,
                    leaveLOP = 0 
                };
                await db.LeaveDetails.AddAsync(leaveDetails);
            }

            await db.SaveChangesAsync();

            await db.SaveChangesAsync();
        }

        public async Task<List<EmployeeLeave>> GetAllLeaveHistoryById(int empId)
        {
            return await (from leaveHistory in db.EmployeeLeaves
                          where leaveHistory.empId == empId
                          select leaveHistory).ToListAsync();
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
