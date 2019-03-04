using EmsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsRepo
{
    public class FeedRepository : Repository<Feed>, IFeedRepository
    {
        private DataContext context;

        public FeedRepository()
        {
            this.context = new DataContext();
        }



        public Feed Get(string id)
        {
            return this.context.Feeds.SingleOrDefault(f => f.UserId == id);
        }

        public int InsertFeed(Feed fd)
        {
            //      var usr= this.context.Employees.SingleOrDefault(e => e.Id == emp.Id);
            //        emp.LoginId = (emp.LoginId + "-");
            this.context.Feeds.Add(fd);
            return this.context.SaveChanges();
        }

    }
}



