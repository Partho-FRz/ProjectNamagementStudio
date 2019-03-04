
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmsEntity;
using EmsService;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;

namespace ProjectManagementStudio.Controllers
{
    
    public class SignUpController : Controller
    {
   //     IEmployeeService repo;
 //       IProjectManagerService repoPro;
  //      IDeveloperService repoDev;
 //       IDesignerService repoDes;
        private EmployeeService repo = new EmployeeService();
        private ProjectManagerService repoPro = new ProjectManagerService();
        private DeveloperService repoDev = new DeveloperService();
        private DesignerService repoDes = new DesignerService();
        /*
        private EmployeeRepository repo = new EmployeeRepository();
        private ProjectManagerRepository repoPm = new ProjectManagerRepository();
        private DeveloperRepository repoDv = new DeveloperRepository();
        private DesignerRepository repoDes = new DesignerRepository();
        */
        public string str;
        //public static int i;
        //private const string FILE_NAME = "Test.data";
        //public int yy = 0;
        //  public int j = 0;

        

        

        // GET: SignUp
        [HttpGet]
        public ActionResult Index()
        {

            if ((Session["AdminLog"]) == null && Session["UserId"] == null)
            {


                return RedirectToAction("Index", "Login");

            }
            else if ((Session["AdminLog"]).ToString() == "002")
            {
                if (Session["UserId"] != null)
                {
                    //if(Session["UserId"] != null)
                    Session["AdminLog"] = "002";
                    

                    return View();
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }

            }
            else if ((Session["AdminLog"])==null && Session["UserId"] == null)
            {


                return RedirectToAction("Index", "Login");

            }


            else
            {
                return RedirectToAction("Index", "Login");

            }
        }
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
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }

        public int generateID()
        {
            string id = "001";
            int yr = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int ids = int.Parse(id);
            ids++;
            string genid = yr.ToString() + month.ToString() + ids.ToString();
            int result = int.Parse(genid);
            return result;
        }
        

       


        [HttpPost]
        public ActionResult GetId(Employee emp)
        {

            return View(emp.UserId);
        }
        [HttpPost]

        public ActionResult Index(FormCollection collection, HttpPostedFileBase file1)
        {
            Employee emp = new Employee();
            ProjectManager pro = new ProjectManager();
            Developer dev = new Developer();
            Designer des = new Designer();

            if(file1!=null)
            {
                emp.Picture = new byte[file1.ContentLength];
                file1.InputStream.Read(emp.Picture, 0, file1.ContentLength);
            }
            emp.FirstName = collection["FirstName"];
            emp.LastName = collection["LastName"];
            emp.Email = collection["Email"];
            emp.Address = collection["Address"];
            emp.MobileNo = collection["MobileNo"];
            emp.WorkingSince = DateTime.Now;
            emp.DOB = Convert.ToDateTime(collection["DOB"]);
            emp.NID = collection["NationalId"];
            emp.UserType = collection["Type"];
            emp.Password = encryption(collection["Password"]);
            //  string pkey = null;
            // string pKey = this.Context.

            //   var userId = WebSecurity.GetUserId(User.Identity.Name);
            //
            //   var usr = this.context.Employees.SingleOrDefault(e => e.Id == emp.Id);


            //Random r = new Random();

            string str = DateTime.Now.Minute + "-" + RandomNumber(100, 900).ToString() + "-" + DateTime.Now.Second;

            emp.UserId = str;

            //this.adrepo.Insert(emp);

            //ad.EmployeeId= DateTime.Now.Minute + "-" + RandomNumber(100, 900).ToString() + "-" + DateTime.Now.Second;
            //   ad.LoginId = RandomNumber(100, 900).ToString();


            //projectManager
            pro.UserId = str;
            pro.Status = "Available";
            pro.FirstName = collection["FirstName"];
            pro.LastName = collection["LastName"];



            //Developer
            dev.UserId = str;
            dev.Status = "Available";
            dev.FirstName = collection["FirstName"];
            dev.LastName = collection["LastName"];



            //Developer
            des.UserId = str;
            des.Status = "Available";
            des.FirstName = collection["FirstName"];
            des.LastName = collection["LastName"];





            if (collection["Type"] == "Project manager")
            {
                this.repo.Insert(emp);
                this.repoPro.Insert(pro);

            }



            else if (collection["Type"] == "Developer")
            {
                this.repo.Insert(emp);
                this.repoDev.Insert(dev);
            }


            else if (collection["Type"] == "Designer")
            {
                this.repo.Insert(emp);
                this.repoDes.Insert(des);
            }

            else
            {
                this.repo.Insert(emp);
            }

            Response.Write("<script>alert('Data inserted Succesfully')</script>");
            return RedirectToAction("Index", "Adminacc");
        }
        
        
    }
}