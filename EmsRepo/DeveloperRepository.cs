using EmsEntity;
using EmsRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsRepo
{
    public class DeveloperRepository : Repository<Developer>, IDeveloperRepository
    {
        private DataContext context;
        public Developer Get(string id)
        {
            return this.context.Developers.SingleOrDefault(d => d.UserId == id);
        }
    }
}
