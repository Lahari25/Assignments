using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class EmployeeController : Controller
    {
        UserEmpDbContext dbContext;
        public EmployeeController(UserEmpDbContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            return View(dbContext.Employees.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            dbContext.Employees.Add(obj);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Employee obj = dbContext.Employees.Find(id);
            return View(obj);
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee obj = dbContext.Employees.Find(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            dbContext.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee obj = dbContext.Employees.Find(id);
            return View(obj);
        }


        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            Employee obj = dbContext.Employees.Find(id);
            dbContext.Employees.Remove(obj);
            dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            // Logic to verify uid, pwd
            return View();
        }

        [HttpPost]
        public IActionResult Login(User u)
        {
            string uname = u.UserName;
            string password = u.Password;



            var usersList = dbContext.Users.ToList();



            User us = dbContext.Users.SingleOrDefault(x => x.UserName == uname && x.Password == password);
            if (us == null)
            {
                ViewBag.Message = "Invalid Username or Password";
                return View();
            }
            else
            {
                ViewBag.Message = "Login Successful";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult DepartmentDetails()
        {
            List<string> depdetails = dbContext.Employees.Select(x => x.Department).Distinct().ToList();
            ViewBag.DepartmentDetails = depdetails;
            return View();
        }
        [HttpGet]
        public IActionResult EmpsByDept(string id)
        {
            ViewBag.dept = id;
            List<Employee> empList = dbContext.Employees.Where(x => x.Department == id).ToList();
            ViewBag.Emps = empList;
            return View();
        }

    }
}