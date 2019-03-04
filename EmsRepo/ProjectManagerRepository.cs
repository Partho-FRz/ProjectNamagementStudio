using EmsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsRepo
{
    public class ProjectManagerRepository : Repository<ProjectManager>, IProjectManagerRepository
    {

        private DataContext context;


        public ProjectManagerRepository()
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
