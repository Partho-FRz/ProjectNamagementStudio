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
    public class LoginController : Controller
    {

 //       IEmployeeService repo;
  //      IAdminService repoAd;
        private EmployeeService repo = new EmployeeService();

   //     private EmployeeRepository repo = new EmployeeRepository();
   //     private AdminRepository adrepo = new AdminRepository();
        // GET: Login
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
        [HttpGet]
        public ActionResult Index()
        {
            if (Session["UserId"] == null)
            {
                return View();
            }
            else
            {
                if(Session["ConName"] == "Adminacc")
                {
                    return RedirectToAction("Index", "Adminacc");
                }
                else if (Session["ConName"] == "Ceoacc")
                {
                    return RedirectToAction("CeoCon", "Ceoacc");
                }
                else if (Session["ConName"] == "Devacc")
                {
                    return RedirectToAction("DevCon", "Devacc");
                }
                else if (Session["ConName"] == "Designacc")
                {
                    return RedirectToAction("DesignCon", "Designacc");
                }
                else
                {
                    return View();
                }
            }
        }
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            //Employee emp = new Employee();
            //Admin ad = new Admin();
            //emp.UserId =(collection["LoginId"]).ToString();
            string Password = encryption(collection["Password"]);
            //emp.UserType = (collection["UserType"]);
            var usr = repo.Get(collection["LoginId"]);

            if (usr != null)
            {
                if (usr.Password == Password)
                {
                    Session["UserId"] = usr.UserId.ToString();
                    Session["Password"] = encryption(usr.Password.ToString());
                    Session["UserType"] = usr.UserType;
                    Session["PrimaryId"] = usr.Id;
                    Session["FName"] = usr.FirstName;
                    Session["LName"] = usr.LastName;


                    if (usr.UserType == "Admin")
                    {
                        Session["Log"] = "001";
                        Session["AdminLog"] = "002";
                        Session["UserAcc"] = "Adminacc";
                        Session["ConName"] = "Adminacc";
                        Session["LogoutAcc"] = "Adminacc/Logout";
                        Response.Write("<script>alert('Succesfully LoggedIN')</script>");
                        return RedirectToAction("Index", "Adminacc");

                    }
                    else if (usr.UserType == "CEO")
                    {
                        Session["Log"] = "001";
                        Session["ConName"] = "Ceoacc";
                        Session["UserAcc"] = "Ceoacc/CeoCon";
                        Session["LogoutAcc"] = "Ceoacc/Logout";
                        Response.Write("<script>alert('Succesfully LoggedIN')</script>");
                        return RedirectToAction("CeoCon", "Ceoacc");

                    }
                    else if (usr.UserType == "Developer")
                    {
                        Session["Log"] = "001";
                        Session["UserAcc"] = "Devacc/Devcon";
                        Session["ConName"] = "Devacc";
                        Session["LogoutAcc"] = "Devacc/Logout";
                        Response.Write("<script>alert('Succesfully LoggedIN')</script>");
                        return RedirectToAction("DevCon", "Devacc");
                    }

                    else if (usr.UserType == "Designer")
                    {
                        Session["Log"] = "001";
                        Session["ConName"] = "Designacc";
                        Session["UserAcc"] = "Designacc/DesignCon";
                        Session["LogoutAcc"] = "Designacc/Logout";
                        Response.Write("<script>alert('Succesfully LoggedIN')</script>");
                        return RedirectToAction("DesignCon", "Designacc");
                    }
                    else if (usr.UserType == "Project manager")
                    {
                        Session["Log"] = "001";
                        Session["ConName"] = "ProjectManager";
                        Session["UserAcc"] = "ProjectManager/ProManCon";
                        Session["LogoutAcc"] = "ProjectManager/Logout";
                        Response.Write("<script>alert('Succesfully LoggedIN')</script>");
                        return RedirectToAction("ProManCon", "ProjectManager");

                    }
                    else if (usr.UserType.ToString() == "Tester")
                    {
                        Session["Log"] = "001";
                        Session["ConName"] = "Testeracc";
                        Session["UserAcc"] = "Testeracc/TesterCon";
                        Session["LogoutAcc"] = "Testeracc/Logout";
                        Response.Write("<script>alert('Succesfully LoggedIN')</script>");
                        return RedirectToAction("TesterCon", "Testeracc");

                    }
                    else if (usr.UserType.ToString() == "Head of software dept")
                    {
                        Session["Log"] = "001";
                        Session["ConName"] = "Headofsoft";
                        Session["UserAcc"] = "Headofsoft/HeadsoftCon";
                        Session["LogoutAcc"] = "Headofsoft/Logout";
                        Response.Write("<script>alert('Succesfully LoggedIN')</script>");
                        return RedirectToAction("HeadsoftCon", "Headofsoft");

                    }
                    else if (usr.UserType.ToString() == "Head of QAT dept")
                    {
                        Session["Log"] = "001";
                        Session["ConName"] = "Headofqlt";
                        Session["UserAcc"] = "Headofqlt/HeadqltCon";
                        Session["LogoutAcc"] = "Headofqlt/Logout";
                        Response.Write("<script>alert('Succesfully LoggedIN')</script>");
                        return RedirectToAction("HeadqltCon", "Headofqlt");

                    }
                }
                else
                {
                    Response.Write("<script>alert('Wrong Password')</script>");
                    return View("Index");
                }


            }
            else
            {
                Response.Write("<script>alert('Invalid User ID')</script>");
                return View("Index");
            }
            Response.Write("<script>alert('Login Failed')</script>");
            return View("Index");

        }
        [HttpGet]
        public ActionResult ForgetPass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgetPass(FormCollection collection)
        {
            var usr = repo.Get(collection["LoginId"]);
            if (usr != null)
            {
                usr.Password = encryption((collection["Password"]));
                repo.UpdateEmp(usr);
                Response.Write("<script>alert('Password Changed Successfully')</script>");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Response.Write("<script>alert('No Account Exists')</script>");
                return View();
            }
        }
    }
}