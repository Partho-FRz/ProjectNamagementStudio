using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmsEntity;
using EmsService;
using System.Security.Cryptography;
using System.Text;


namespace ProjectManagementStudio.Controllers
{
    public class HomepageController : Controller
    {
        // GET: Homepage

        //   private IEmployeeService repo;

        //EmployeeRepository repo = new EmployeeRepository();
        private EmployeeService repo = new EmployeeService();
        private FeedService feedrepo = new FeedService();
        public string encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }
        public ActionResult Index()
        {       
            
            using (var db =new DataContext())
            {
                if (!db.Projects.Any())
                {
                    // The table is empty
                    var usr = repo.Get(1);
                    if (usr == null)
                    {
                        Employee emp = new Employee();
                        emp.FirstName = "Admin";
                        emp.LastName = "Admin";
                        emp.WorkingSince = DateTime.Now;
                        emp.Email = "Admin@Admin.com";
                        emp.Address = "Company";
                        emp.MobileNo = "Admin";
                        emp.DOB = DateTime.Now;
                        emp.UserId = "Admin";
                        emp.UserType = "Admin";
                        emp.NID = "Admin";
                        emp.Password = encryption("Admin");
                        emp.Picture = null;
                        repo.InsertEmp(emp);
                    }

                }
            }
            var feed = this.feedrepo.GetAll();
            if ((Session["Log"])==null)
            {
                return View(feed);
            }
            /*else if((Session["Log"]).ToString()=="001")
            {

                return View("IndexLogged");

            }*/
            else
            {
                return View(feed);

            }
            
        }

        /*[HttpGet]
        public ActionResult IndexLogged()
        {
            return View();
        }
        */
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            DateTime now = DateTime.Now;
            Feed fd = new Feed();

            fd.UserId = Session["UserId"].ToString();

            fd.Homepost = collection["Homepost"].ToString();

            fd.Fname = Session["FName"].ToString();


            fd.Lname = Session["LName"].ToString();

            fd.time = now.ToString();

            this.feedrepo.InsertFeed(fd);

            return RedirectToAction("Index", "Homepage");
        }

    }
}