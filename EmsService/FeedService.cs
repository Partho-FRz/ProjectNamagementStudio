using System;
using EmsEntity;
using EmsRepo;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsService
{
    public class FeedService : Service<Feed>, IFeedService
    {

        private DataContext context;


        public FeedService()
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
