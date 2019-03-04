using EmsEntity;
using EmsService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementStudio.Controllers
{
    public class ProjectController : Controller
    {


        private ProjectService repoPr = new ProjectService();
        private ProjectManagerService repoPrm = new ProjectManagerService();
        private EmployeeService repoEmp = new EmployeeService();
        private DeveloperService repoDev = new DeveloperService();
        private DesignerService repoDes = new DesignerService();



        /*
        IProjectManagerService repoPrm;
        IProjectService repoPr;
        IEmployeeService repoEmp;
        IDeveloperService repoDev;
        IDesignerService repoDes;
        */
        /*
        private ProjectRepository repo = new ProjectRepository();
        private ProjectManagerRepository mrepo = new ProjectManagerRepository();
        private EmployeeRepository emrepo = new EmployeeRepository();
        private DeveloperRepository devrepo = new DeveloperRepository();
        private DesignerRepository disrepo = new DesignerRepository();*/

        // GET: Project
        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        public static int RandomNumber(int min, int max)
        {
            lock (syncLock)
            { // synchronize
                return random.Next(min, max);
            }
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ProjectCon()
        {
            
            var usr = repoPr.Get(Convert.ToInt32(Session["PrimaryId"]));
            var pro = repoPr.GetAll();
            var emp = this.repoEmp.GetAll();
            List<Project> Project = new List<Project>();
            double TotalMoney=0;
            double EarnedMoney = 0;
            double PendingMoney = 0;
            int ProjectManager = 0;
            int Developer = 0;
            int Designer = 0;

            if ((Session["Log"]) == null)
            {



                return RedirectToAction("Index", "Login");


            }
            else if ((Session["Log"]).ToString() == "001")
            {
                if (Session["UserId"] != null)
                {
                    if (pro.Count > 0)
                    {
                        foreach (var item in pro)
                        {
                            Project.Add(item);
                            TotalMoney = TotalMoney + item.Budget;
                            if(item.ProjectStatus=="Running")
                            {
                                PendingMoney = PendingMoney + item.Budget;
                            }
                            else if(item.ProjectStatus=="Finished")
                            {
                                EarnedMoney = EarnedMoney + item.Budget;
                            }
                        }
                        Session["prospace"] = "1";
                    }

                    else if(pro.Count<=0)
                    {
                        Session["prospace"] = "0";
                    }
                    if(emp.Count>0)
                    {
                        foreach(var item in emp)
                        {
                            if(item.UserType== "Project manager")
                            {
                                ProjectManager = ProjectManager + 1;
                            }
                            else if(item.UserType== "Developer")
                            {
                                Developer = Developer + 1;
                            }
                            else if(item.UserType== "Designer")
                            {
                                Designer = Designer + 1;
                            }
                        }
                    }
                    Session["TotalMoney"] = TotalMoney;
                    Session["PendingMoney"] = PendingMoney;
                    Session["EarnedMoney"] = EarnedMoney;
                    Session["ProjectManager"] = ProjectManager;
                    Session["Developer"] = Developer;
                    Session["Designer"] = Designer;
                    Session["Log"] = "001";
                    

                    return View(Project);
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
        [HttpGet]
        public ActionResult CreateProject()
        {
            var man = repoPrm.GetAll();
            int count = 0;
            foreach (var item in man)
            {
                if (item.ProjectId==null)
                {
                    count = count + 1;
                }
            }
            if (count > 0)
            {
                //Response.Write("<script>alert(' Project Manager Is Available')</script>");
                return View(repoPrm.GetAll());
            }
            else
            {
                Session["msg"] ="No Project Manager Is Available";
                return RedirectToAction("ProjectCon","Project");
            }
           
        }
        [HttpPost]
        public ActionResult CreateProject(FormCollection collection)
        {
            Project pro = new Project();
            pro.Name = collection["Name"];
            pro.Budget =Convert.ToDouble(collection["Budget"]);
            pro.ProjectStatus = "Running";
            pro.StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            pro.EndDate = new DateTime(3000, 2, 19);
            string str = RandomNumber(100, 900).ToString();
            pro.ProjectId = str;
            Session["ProjectId"] = str;
            this.repoPr.Insert(pro);
            return RedirectToAction("ProjectManager");
        }
        [HttpGet]
        public ActionResult ProjectManager()
        {
            var pm = repoPrm.GetAll();
            
            List<ProjectManager> List = new List<ProjectManager>();
            
            foreach (var item in pm)
            {
                if(item.Status== "Available")
                {
                    
                    List.Add(item);
                }
            }
            return View(List);
        }
        [HttpPost]
        public ActionResult ProjectManager(FormCollection collection)
        {
            var headSQ = repoEmp.GetAll();


            /*foreach (var item in headSQ)
            {
                if (item.UserType == "Head of software dept")
                {
                    Session["HOS"] = item.UserId;
                }
                else if(item.UserType == "Head of QAT dept")
                {
                    Session["HOQ"] = item.UserId;
                }
            }*/

            //var value = emrepo.Get(collection["Proselect"]);

            //value.ProjectId = Session["PMselected"].ToString();


           // this.emrepo.Update(value);

           // return RedirectToAction("ManageProject", "Project");

            var pm = repoPrm.Get(collection["Proselect"]);
            var em = repoEmp.Get(collection["Proselect"]);

            /*var HOS = emrepo.Get((Session["HOS"]).ToString());
            var HOQ = emrepo.Get((Session["HOQ"]).ToString());*/

            pm.ProjectId= Session["ProjectId"].ToString();

            em.ProjectId= Session["ProjectId"].ToString();

           /* HOQ.ProjectId = Session["ProjectId"].ToString();
            HOS.ProjectId= Session["ProjectId"].ToString();*/
            
            pm.Status = "Unavailable";

            this.repoPrm.Update(pm);
            this.repoEmp.UpdateEmp(em);
           // this.emrepo.Update(HOS);
           // this.emrepo.Update(HOS);

            Session["ProjectId"] = "00";
            Session["msg"] = null;
            return RedirectToAction("ProjectCon", "Project");
        }
        [HttpGet]
        public ActionResult ViewProjects()
        {
            var pro = this.repoPr.GetAll();
            /*List<Project> List = new List<Project>();
            foreach(var item in pro)
            {
                if(item.ProjectStatus=="Running")
                {
                    List.Add(item);
                }

            }*/
            Session["msg"] = null;
            return View(pro);

        }
      
        public ActionResult ProjectDetails(string Id)
        {
            //var pm = this.mrepo.Get_project(Id);// all memeber detail needed
            Session["msg"] = null;

            var alll = this.repoEmp.GetAll();

            List<Employee> List = new List<Employee>();

            foreach (var item in alll)
            {
                if (item.ProjectId == Id)
                {
                    List.Add(item);
                }

            }
            return View(List);
        }
        
        public ActionResult CloseProject()
        {
            ViewBag.msg = null;
            Session["msg"] = null;
            var Projects = this.repoPr.GetAll();
            List<Project> ProjectList = new List<Project>();
            foreach(var item in Projects)
            {
                if(item.ProjectStatus== "Running")
                {
                    ProjectList.Add(item);
                }
            }
            if (ProjectList.Count>0)
            {
                return View(ProjectList);
            }
            else
            {
                
                return RedirectToAction("ProjectCon","Project");
            }

        }
        public ActionResult Close(int ID)
        {
            var Pro = this.repoPr.Get(ID);
            var emp = this.repoEmp.GetAll();
            var man = this.repoPrm.GetAll();
            if(Pro!=null)
            {
                Pro.ProjectStatus = "Finished";
                Pro.EndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                foreach (var item in emp)
                {
                    if(item.ProjectId==Pro.ProjectId)
                    {
                        item.ProjectId = null;
                        repoEmp.Update(item);
                    }
                }
                foreach (var item in man)
                {
                    if (item.ProjectId == Pro.ProjectId)
                    {
                        item.ProjectId = null;
                        item.Status = "Available";
                        repoPrm.Update(item);
                    }
                }
                repoPr.Update(Pro);
                return RedirectToAction("CloseProject","Project");
            }
            else
            {
                ViewBag.msg = "Error";
                Session["msg"] = "Error";
                return RedirectToAction("ProjectCon","Project");
            }

        }
        
        [HttpGet]
        public ActionResult ManageProject()
        {
            var emp = this.repoEmp.GetAll();
            List<Employee> List = new List<Employee>();
            foreach (var item in emp)
            {
                if (item.UserType == "Developer"||item.UserType== "Designer")
                {
                    if(item.ProjectId==null)
                    {
                        List.Add(item);
                    }
                }

            }

            return View(List);
        }
        [HttpPost]
       public ActionResult ManageProject(FormCollection collection)
        {
            
            Employee emp = new Employee();



            var value = repoEmp.Get(collection["Teamselect"]);

            if (Session["PMselected"] != null)
            {
                value.ProjectId = Session["PMselected"].ToString();


                this.repoEmp.UpdateEmp(value);
            }
            else
            {

            }

            return RedirectToAction("ManageProject", "Project");


          

        }
    }
}