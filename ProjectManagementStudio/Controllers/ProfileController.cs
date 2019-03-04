using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmsEntity;
using EmsService;

namespace ProjectManagementStudio.Controllers
{
    public class ProfileController : Controller
    {

        private EmployeeService repo = new EmployeeService();
      ///  IEmployeeService repo;
   //     EmployeeRepository repo = new EmployeeRepository();
        // GET: Profile
        public ActionResult Index(string id)
        {
            var emp = this.repo.Get(id);
            if (emp.Picture != null)
            {
                var base64 = Convert.ToBase64String(emp.Picture);
                Session["image2"] = string.Format("data:image/gif;base64,{0}", base64);
            }
            else
            {
                Session["image2"] = null;
            }
            return View(emp);
        }
    }
}