using EmsEntity;
using EmsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsService
{
    public interface IProjectManagerService : IService<ProjectManager>
    {
        ProjectManager Get(string id);
        ProjectManager Get_project(string id);
    }
}
