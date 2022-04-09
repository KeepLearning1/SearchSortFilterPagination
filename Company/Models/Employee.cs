using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Company.Models
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int Emp_Id { get; set; }


        [Required]
        public string Emp_Name { get; set; }

        [Required]

        public string Emp_Department { get; set; }

        [Required]
        public int MonthlySalary { get; set; }
    }
}