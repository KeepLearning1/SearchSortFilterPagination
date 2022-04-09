using Company.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Company.DataLayer
{
    public class EmployeeContext : DbContext
    {

        public EmployeeContext() : base("name=mycon")
        {

        }

        public DbSet<Employee> Employees { get; set; }
    }
}