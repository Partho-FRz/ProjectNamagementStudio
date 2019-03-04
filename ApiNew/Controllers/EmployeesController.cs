using EmsEntity;
using EmsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiNew.Controllers
{
    public class EmployeesController : ApiController
    {
       DataContext context = new DataContext();

        /*
            api/Employees
         */
        public IHttpActionResult Get()
        {
           // return Content(HttpStatusCode.OK, "Welcome");
            return Ok(context.Set<Employee>().ToList());
        }


        //  api/Employees/{id}
        public IHttpActionResult Get([FromUri]int id)
        {
            Employee emp = context.Set<Employee>().Find(id);
            if (emp == null)
            {
                return StatusCode(HttpStatusCode.NoContent);
            }
            return Ok(emp);
        }

         //     api/Employees
         /*
        public IHttpActionResult Post([FromBody]Employee emp)
        {
            context.Set<Employee>().Add(emp);
            context.SaveChanges();
            return Created("/Employees/" + emp.Id, emp);
        }
           */



        //     api/Employees/5
        /*
        public IHttpActionResult Put([FromBody]Employee emp, [FromUri]int id)
        {
            emp.Id = id;
            context.Entry<Employee>(emp).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return Ok(emp);
        }*/

        /*
        api/Employees/5
     */
        public IHttpActionResult Delete([FromUri]int id)
        {
            Employee emp = context.Set<Employee>().Find(id);
            if (emp != null)
            {
                context.Set<Employee>().Remove(emp);
                context.SaveChanges();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        /*
          api/Employees/Search/empname
       */
        [Route("api/Employees/Search/{name}")]
        public IHttpActionResult GetEmployeeByName([FromUri]string name)
        {
            List<Employee> emplist = context.Set<Employee>().Where(d => d.FirstName.Contains(name)).ToList();
            return Ok(emplist);
        }


        /*
         api/Employees/5/Project
      */
        [Route("api/Employees/{id}/Project")]
        public IHttpActionResult GetProject([FromUri]int id)
        {
        //    Project pro = new Project();
            Employee emp = context.Set<Employee>().Find(id);
            //          var query = from c in Project where c.ProjectId.Equals(emp.ProjectId) select c;
            //      Project pro = context.Set<Project>().equa(emp.ProjectId==pro.ProjectId);
            Project pro = context.Set<Project>().SingleOrDefault(e => e.ProjectId == emp.ProjectId);
            return Ok(pro);
        }


    }
}
