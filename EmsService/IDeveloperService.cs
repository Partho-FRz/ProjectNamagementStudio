﻿using EmsEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmsService
{
    public interface IDeveloperService : IService<Developer>
    {
        Developer Get(string id);
    }
}
