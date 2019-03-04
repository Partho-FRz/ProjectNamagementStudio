using EmsEntity;
using EmsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ApiNew.Attributes
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
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
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                string encodedCredential = actionContext.Request.Headers.Authorization.Parameter;
                string decodedCredential = Encoding.UTF8.GetString(Convert.FromBase64String(encodedCredential));
                string[] arr = decodedCredential.Split(':');
                string username = arr[0];
                string password = encryption(arr[1]);

                DataContext context = new DataContext();
                //    User user = context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
                Employee emp = context.Employees.SingleOrDefault(u => u.FirstName == username && u.Password == password);
                if (emp == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
                else
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(emp.FirstName, emp.UserType), new string[] { emp.UserType});
                }
            }
        }
    }
}