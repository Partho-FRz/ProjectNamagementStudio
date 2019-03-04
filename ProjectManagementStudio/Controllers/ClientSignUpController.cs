using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmsEntity;
using EmsService;
using System.Security.Cryptography;
using System.Text;
using System.IO;

namespace ProjectManagementStudio.Controllers
{
    public class ClientSignUpController : Controller
    {
        private ClientService repo = new ClientService();
  //      private IClientService repo;
   //     private ClientRepository repo = new ClientRepository();
        // GET: ClientSignUp
        [HttpGet]
        public ActionResult Index()
        {
            return View();
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

        [HttpPost]
        public ActionResult Index(FormCollection collection, HttpPostedFileBase file1)
        {
            {
                Client cl = new Client();

                Employee emp = new Employee();

                string filename = "";

                byte[] bytes;

                int BytestoRead;

                int numBytesRead;

                if (file1 != null)

                {

                    filename = Path.GetFileName(file1.FileName);

                    bytes = new byte[file1.ContentLength];

                    BytestoRead = (int)file1.ContentLength;

                    numBytesRead = 0;

                    while (BytestoRead > 0)

                    {

                        int n = file1.InputStream.Read(bytes, numBytesRead, BytestoRead);

                        if (n == 0) break;

                        numBytesRead += n;

                        BytestoRead -= n;

                    }

                    cl.Picture = bytes;

                }






                cl.FirstName = collection["FirstName"];
                cl.LastName = collection["LastName"];
                cl.Email = collection["Email"];
                cl.Budget = Convert.ToDouble(collection["Budget"]);
                cl.Address = collection["Address"];
                cl.MobileNo = collection["MobileNo"];
                cl.DOB = Convert.ToDateTime(collection["DOB"]);
                cl.NID = collection["NationalId"];
                cl.Password = encryption(collection["Password"]);
                cl.LoginId = (DateTime.Now.Day + "-" + DateTime.Now.Second).ToString();

                this.repo.Insert(cl);
                Response.Write("<script>alert('Data inserted Succesfully')</script>");

            }
            return View("Index");
        }
            
    }
}