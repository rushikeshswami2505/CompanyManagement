﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CompanyManagement.Models
{
    public class EmployeeDetailsModel
    {
        [Key]
        public int empId { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(20, ErrorMessage = "Name should be less than 20 characters")]
        public string empName { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        public DateTime empDob { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(15, ErrorMessage = "City name should be less than 15 characters")]
        public string empCity { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(15, ErrorMessage = "State name should be less than 15 characters")]
        public string empState { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(15, ErrorMessage = "Country name should be less than 15 characters")]
        public string empCountry { get; set; }

        [Required(ErrorMessage = "Blood Group is required")]
        [RegularExpression(@"^(A|B|AB|O)[+-]$", ErrorMessage = "Invalid blood group format")]
        public string empBloodGroup { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        [StringLength(10, ErrorMessage = "Contact name should be up to 10 characters")]
        public string empContact { get; set; }
    }
}
