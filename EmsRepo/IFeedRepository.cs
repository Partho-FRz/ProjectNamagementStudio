using System;
using System.Collections.Generic;
using EmsEntity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsRepo
{
    public interface IFeedRepository : IRepository<Feed>
    {
        Feed Get(string id);
        int InsertFeed(Feed fd);
    }
}

