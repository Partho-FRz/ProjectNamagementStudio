using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementStudio.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            if ((Session["Log"]) == null)
            {
                return View();
            }
            else if ((Session["Log"]).ToString() == "001")
            {

                return View("IndexLogged");

            }
            else
            {
                return View();

            }
        }
    }
}