using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmsEntity;
using EmsService;

namespace ProjectManagementStudio.Controllers
{   
    
    public class AdminController : Controller
    {
  //      public IAdminService repo;
  //      public IEmployeeService repoEmp;
        public AdminService repo = new AdminService();
        public EmployeeService repoEmp = new EmployeeService();
        //  private AdminRepository repo = new AdminRepository();
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            // creating dropdwonlist for employee
           
          //  EmployeeRepository repo = new EmployeeRepository();
            List<SelectListItem> empList = new List<SelectListItem>();

            foreach (Employee emp in repoEmp.GetAll())
            {
                SelectListItem option = new SelectListItem();
                option.Text = emp.UserType;
                option.Value = emp.Id.ToString();
                empList.Add(option);
            }

            ViewBag.Employees = empList;


            return View();
        }

        [HttpPost]
        public ActionResult Create(Admin ad)
        {
            //   IEmployeeService repo;
            // EmployeeRepository repo = new EmployeeRepository();
            EmployeeService repo = new EmployeeService();
            Employee emp = new Employee();

            if (ModelState.IsValid)
            {

                this.repo.Insert(ad);
                return RedirectToAction("Index");
            }
            else
            {
                return View(ad);
            }
        }


    }
}