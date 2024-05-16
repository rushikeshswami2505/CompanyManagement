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
        public List<EmployeeDetails> GetAllEmployees()
        {
            return db.EmployeeDetails.ToList();
        }

        public void AddNewEmployee(EmployeeDetailsModel model)
        {
            EmployeeDetails employeeDetails = ModelToEmployeeDetails(model);
            db.EmployeeDetails.Add(employeeDetails);
            db.SaveChanges();
        }


        public EmployeeDetailsModel GetEmployeeDetailsById(int id)
        {
            var row = db.EmployeeDetails.Where(i => i.empId ==  id).FirstOrDefault();
            EmployeeDetailsModel model = EmployeeDetailsToModel(row);
            return model;
        }
        public void EditEmployee(EmployeeDetailsModel model)
        {
            EmployeeDetails employeeDetails = ModelToEmployeeDetails(model);
            db.Entry(employeeDetails).State = EntityState.Modified;
            db.SaveChanges();
        }

        private EmployeeDetailsModel EmployeeDetailsToModel(EmployeeDetails? row)
        {
            EmployeeDetailsModel model = new EmployeeDetailsModel();
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
