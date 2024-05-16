﻿using System.ComponentModel.DataAnnotations;

namespace CompanyManagement.Data
{
    public class EmployeeRoleMap
    {
        [Key]
        public int erId { get; set; }
        public int empId { get; set; }
        public string roleId { get; set; }
    }
}
