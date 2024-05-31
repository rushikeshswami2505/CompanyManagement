using CompanyManagement.Data;
using CompanyManagement.Models;
using CompanyManagement.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Services
{
    public class LeaveDetailsServices : ILeaveDetails
    {
        private Context db;

        public LeaveDetailsServices(Context context)
        {
            db = context;
        }
        public async Task AddNewLeave(LeaveDetailsModel model)
        {
            LeaveDetails leaveDetails = ModelToLeaveDetails(model);
            await db.LeaveDetails.AddAsync(leaveDetails);
            await db.SaveChangesAsync();
        }



        public async Task DeleteLeave(int id)
        {
            var row = await db.LeaveDetails.FindAsync(id);
            if (row == null) return;
            db.LeaveDetails.Remove(row);
            await db.SaveChangesAsync();
        }

        public async Task EditLeave(LeaveDetailsModel model)
        {
            LeaveDetails leaveDetails = ModelToLeaveDetails(model);
            db.Entry(leaveDetails).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<List<LeaveDetails>> GetAllLeavesDetails()
        {
            return await db.LeaveDetails.ToListAsync();
        }

        public async Task<LeaveDetailsModel> GetLeaveDetailsByLeaveId(int leaveId)
        {
            var row = await db.LeaveDetails.Where(i => i.leaveId == leaveId).FirstOrDefaultAsync();
            if (row == null) return null;
            LeaveDetailsModel model = LeaveDetailsToModel(row);
            return model;
        }
        private LeaveDetails ModelToLeaveDetails(LeaveDetailsModel model)
        {
            LeaveDetails leaveDetails = new LeaveDetails();
            leaveDetails.leaveId = model.leaveId;
            leaveDetails.empId = model.empId;
            leaveDetails.leavePaidRemain = model.leavePaidRemain;
            leaveDetails.leavePaidTaken = model.leavePaidTaken;
            leaveDetails.leaveLOP = model.leaveLOP;
            return leaveDetails;
        }
        private LeaveDetailsModel LeaveDetailsToModel(LeaveDetails leaveDetails)
        {
            LeaveDetailsModel model = new LeaveDetailsModel();
            model.leaveId = leaveDetails.leaveId;
            model.empId = leaveDetails.empId;
            model.leavePaidRemain = leaveDetails.leavePaidRemain;
            model.leavePaidTaken = leaveDetails.leavePaidTaken;
            model.leaveLOP = leaveDetails.leaveLOP;
            return model;
        }

        public async Task<LeaveDetailsModel> GetLeaveDetailsByEmpId(int empId)
        {
            var row = await db.LeaveDetails.Where(i => i.empId == empId).FirstOrDefaultAsync();
            if (row == null) return null;
            LeaveDetailsModel model = LeaveDetailsToModel(row);
            return model;
        }
    }
}
