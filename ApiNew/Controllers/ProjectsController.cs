using ApiNew.Attributes;
using EmsEntity;
using EmsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiNew.Controllers
{
    [RoutePrefix("api/Projects")]
//    [BasicAuthentication]
 //   [EnableCors("*", "*", "*")]
    public class ProjectsController : ApiController
    {
        DataContext context = new DataContext();
        
        /*
            /Projects
         */
        [Route("")]
  //      [RoleAuthorization]
        public IHttpActionResult Get()
        {


            List<Project> plist = context.Set<Project>().ToList();
            List<Project> prolist = new List<Project>();
            foreach (Project d in plist)
            {
                d.Links = new List<Link>()
                {
                    new Link(){
                        Href = "/api/Projects/" + d.Id + "/Employees",
                        Rel = "employees"
                    }
                };
                prolist.Add(d);
            }
            //return Content(HttpStatusCode.OK, "Welcome");
            return Ok(prolist);




        }

        // projects/5
        [Route("{id}",Name = "FindProject")]
 //       [AllowAnonymous]
        public IHttpActionResult Get([FromUri]int id)
        {
            Project pro = context.Set<Project>().Find(id);
            if (pro == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(pro);
        }

        // projects/5
        [Route("{id}")]
        public IHttpActionResult Delete([FromUri]int id)
        {
            Project pro = context.Set<Project>().Find(id);
            if (pro != null)
            {
                context.Set<Project>().Remove(pro);
                context.SaveChanges();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }





        /*
            /Projects
         */
         /*
        [Route("")]
        public IHttpActionResult Post([FromBody]Project pro)
        {

            context.Set<Project>().Add(pro);
            context.SaveChanges();
            return Created("dummy location", pro);
            //return Content(HttpStatusCode.OK, Url.Route("FindDepartment", 1));
        }*/

        /*
    /Projects/5
 */ 

            /*
        [Route("{id}")]
        [DisableCors]
        public IHttpActionResult Put([FromBody]Project pro, [FromUri]int id)
        {
            pro.Id = id;
            context.Entry<Project>(pro).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return Ok(pro);
        }*/


        /*
          /Projects/Search/ProjectName
       */
        [Route("Search/{name}")]
        public IHttpActionResult GetProjectByName([FromUri]string name)
        {
            List<Project> projectlist = context.Set<Project>().Where(d => d.Name.Contains(name)).ToList();
            return Ok(projectlist);
        }

        /*
    /Projects/5/Employees
 */
 
        [Route("{id}/Employees", Name = "EmployeeList")]
        public IHttpActionResult GetEmployees([FromUri]int id)
        {
      //      Project pro = new Project();
            Project pro = context.Set<Project>().Find(id);
            List<Employee> emplist = context.Set<Employee>().Where(e => e.ProjectId == pro.ProjectId ).ToList();
            return Ok(emplist);
        }
        






    }
}
