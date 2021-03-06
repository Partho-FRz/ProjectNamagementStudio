﻿using EmsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsRepo
{
    public interface IDesignerRepository : IRepository<Designer>
    {
        Designer Get(string id);
    }
}
