using Company.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Company.Models;
using System.Data.Entity;

namespace Company.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext ctx = new EmployeeContext();
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "name_asc";
            ViewBag.DepartmentSortParm = String.IsNullOrEmpty(sortOrder) ? "Dept_desc" : "Dept_asc";
            ViewBag.MonthlySalarySortParm = String.IsNullOrEmpty(sortOrder) ? "Salary_desc" :  "Salary_asc";
            ViewBag.IDSortParm = String.IsNullOrEmpty(sortOrder) ? "Id_desc" : "";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var employees = from s in ctx.Employees
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                employees = employees.Where(s => s.Emp_Id.ToString().Contains(searchString)
                                       || s.Emp_Department.ToUpper().Contains(searchString.ToUpper()) || s.Emp_Name.ToUpper().Contains(searchString.ToUpper())
                                       || s.MonthlySalary.ToString().Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(s => s.Emp_Name);
                    break;
                case "Dept_desc":
                    employees = employees.OrderByDescending(s => s.Emp_Department);
                    break;
                case "Dept_asc":
                    employees = employees.OrderBy(s => s.Emp_Department);
                    ViewData["DepartmentSortParm"] = "Dept_desc";
                    break;
                case "Salary_desc":
                    employees = employees.OrderByDescending(s => s.MonthlySalary);
                    break;
                case "Salary_asc":
                    employees = employees.OrderBy(s => s.MonthlySalary);
                    ViewData["MonthlySalarySortParm"] = "Salary_desc";
                    break;
                case "Id_desc":
                    employees = employees.OrderByDescending(s => s.Emp_Id);
                    break;
                case "name_asc":
                    employees = employees.OrderBy(s => s.Emp_Name);
                    ViewData["NameSortParm"] = "name_desc";
                    break;
                default:  // Name ascending 
                    employees = employees.OrderBy(s => s.Emp_Id);
                    break;
            }

            int pageSize = 4;
            int pageNumber = (page ?? 1);
            return View(employees.ToPagedList(pageNumber, pageSize));
            
        }



        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            ctx.Employees.Add(employee);
            dynamic a = ctx.SaveChanges();
            if (a > 0)
            {
                ViewBag.CreateMessage = ("<script> alert('Data Saved..')</script>");
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.CreateMessage = ("<script> alert('Data NotSaved..')</script>");
            }
            return View();
        }


    }
}