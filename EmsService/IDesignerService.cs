using EmsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsService
{
    public interface IDesignerService : IService<Designer>
    {
        Designer Get(string id);
    }
}
