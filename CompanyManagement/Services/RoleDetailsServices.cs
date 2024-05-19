using CompanyManagement.Data;
using CompanyManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Services
{
    public class RoleDetailsServices : IRoleDetails
    {
        Context db;
        public RoleDetailsServices(Context context) {
            db = context;
        }

        public  async Task AddNewRole(RoleDetailsModel model)
        {
            RoleDetails roleDetails = ModelToRoleDetails(model);
            await db.RoleDetails.AddAsync(roleDetails);
            await db.SaveChangesAsync();
        }

        private RoleDetails ModelToRoleDetails(RoleDetailsModel model)
        {
            RoleDetails roleDetails = new RoleDetails();
            roleDetails.roleId = model.roleId;
            roleDetails.roleName = model.roleName;
            return roleDetails;
        }

        public async Task DeleteRole(int id)
        {
            var row = await db.RoleDetails.FindAsync(id);
            if (row == null) return;
            db.RoleDetails.Remove(row);
            await db.SaveChangesAsync();
        }

        public async Task EditRole(RoleDetailsModel model)
        {
            RoleDetails roleDetails = ModelToRoleDetails(model);
            db.Entry(roleDetails).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }

        public async Task<List<RoleDetails>> GetAllRole()
        {
            return await db.RoleDetails.ToListAsync();
        }

        public async Task<RoleDetailsModel> GetRoleDetailsById(int id)
        {
            var row = await db.RoleDetails.Where(i => i.roleId == id).FirstOrDefaultAsync();
            if (row == null) return null;
            RoleDetailsModel model = RoleDetailsToModel(row);
            return model;
        }

        private RoleDetailsModel RoleDetailsToModel(RoleDetails roleDetails)
        {
            RoleDetailsModel model = new RoleDetailsModel();
            model.roleId = roleDetails.roleId;
            model.roleName = roleDetails.roleName;
            return model;
        }
    }
}
