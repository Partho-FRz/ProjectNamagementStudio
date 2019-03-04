using EmsEntity;
using EmsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsService
{
    public class DesignerService : Service<Designer>, IDesignerService
    {
        private DataContext context;
        public Designer Get(string id)
        {
            return this.context.Designers.SingleOrDefault(d => d.UserId == id);
        }
    }
}
