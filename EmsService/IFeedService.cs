using EmsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsService
{
    public interface IFeedService : IService<Feed>
    {
        Feed Get(string id);

        int InsertFeed(Feed fd);


    }
}
