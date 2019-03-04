using EmsEntity;
using EmsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementStudio.Controllers
{
    public class HeadofsoftController : Controller
    {   
        // GET: Allacc
        private EmployeeService repo = new EmployeeService();
//        private IEmployeeService repo;

 //       private EmployeeRepository repo = new EmployeeRepository();
        // GET: Account
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
            return View();
        }
        public ActionResult HeadsoftCon()
        {
            var usr = repo.Get(Convert.ToInt32(Session["PrimaryId"]));
            if ((Session["Log"]) == null)
            {



                return RedirectToAction("Index", "Login");


            }
            else if ((Session["Log"]).ToString() == "001")
            {
                if (Session["UserId"] != null)
                {
                    //if(Session["UserId"] != null)
                    Session["Log"] = "001";
                    if (usr.Picture != null)
                    {
                        var base64 = Convert.ToBase64String(usr.Picture);
                        Session["image"] = string.Format("data:image/gif;base64,{0}", base64);
                    }

                    return View("HeadsoftCon");
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }

            else
            {
                return RedirectToAction("Index", "Login");

            }
        }
        public ActionResult DashBoard()
        {
            int Id = Convert.ToInt32(Session["PrimaryId"]);
            return View(this.repo.Get(Id));
        }
        public ActionResult Profile()
        {
            int Id = Convert.ToInt32(Session["PrimaryId"]);
            Employee emp = new Employee();
            emp = this.repo.Get(Id);
            //Session["img"] = emp.Picture;
            //ViewBag.Picture = Session["img"];
            /* var image = (from m in repo.GetAll()
                          where m.Id == Id
                          select m.Picture).FirstOrDefault();

             var stream = new MemoryStream(image.ToArray());

             //return new FileStreamResult(stream, "image/jpeg");
             Session["img"] =new FileStreamResult(stream, "image/jpeg");
             */
            if (emp.Picture != null)
            {
                var base64 = Convert.ToBase64String(emp.Picture);
                Session["image"] = string.Format("data:image/gif;base64,{0}", base64);
            }
            return View(emp);
            //Employee emp = new Employee();
            //emp=this.repo.Get(Id);
            /*var image = (from m in repo.GetAll()
                         where m.Id == Id
                         select m.Picture).FirstOrDefault();

            var stream = new MemoryStream(image.ToArray());

            return new FileStreamResult(stream, "image/jpeg");*/

        }
        [HttpGet]
        public ActionResult EditProfile()
        {
            int Id = Convert.ToInt32(Session["PrimaryId"]);
            return View(this.repo.Get(Id));
        }
        [HttpPost]
        public ActionResult EditProfile(Employee emp)
        {
            if (ModelState.IsValid)
            {
                this.repo.UpdateEmp(emp);
                Session["FName"] = emp.FirstName;
                Session["LName"] = emp.LastName;

                return RedirectToAction("Profile");
            }
            else
            {
                return View(emp);
            }

        }
        public ActionResult ChangeProPic()
        {
            return View("");
        }
        [HttpPost]
        public ActionResult ChangeProPic(HttpPostedFileBase file1)
        {
            //Employee emp = new Employee();
            var usr = repo.Get(Convert.ToInt32(Session["PrimaryId"]));
            if (file1 != null)
            {
                usr.Picture = new byte[file1.ContentLength];
                file1.InputStream.Read(usr.Picture, 0, file1.ContentLength);
                Response.Write("<script>alert('Picture Updated Successfully')</script>");
            }
            repo.UpdateEmp(usr);
            return RedirectToAction("Profile");
        }
        [HttpGet]
        public ActionResult ChangePass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePass(FormCollection collection)
        {
            int Id = Convert.ToInt32(Session["PrimaryId"]);
            var usr = this.repo.Get(Id);
            if (usr.Password == encryption(collection["CPass"].ToString()))
            {
                Response.Write("<script>alert('Password Successfully Changed')</script>");
                usr.Password = encryption(collection["NPass"]);
                this.repo.UpdateEmp(usr);

                return RedirectToAction("HeadsoftCon");
            }
            else
            {
                Response.Write("<script>alert('Old Password MisMatch')</script>");
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session["Log"] = "000";
            return RedirectToAction("Index", "Login");

        }
    }
}