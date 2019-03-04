using EmsEntity;
using EmsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsService
{
    public class ProjectManagerService : Service<ProjectManager>, IProjectManagerService
    {
        private DataContext context;


        public ProjectManagerService()
        {
            this.context = new DataContext();
        }





        public ProjectManager Get(string id)
        {
            return this.context.ProjectManagers.SingleOrDefault(e => e.UserId == id);
        }

        public ProjectManager Get_project(string id)
        {
            return this.context.ProjectManagers.SingleOrDefault(e => e.ProjectId == id);
        }
    }
}
