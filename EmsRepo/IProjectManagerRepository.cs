using EmsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsRepo
{
    public interface IProjectManagerRepository : IRepository<ProjectManager>
    {
        ProjectManager Get(string id);
        ProjectManager Get_project(string id);
    }
}
