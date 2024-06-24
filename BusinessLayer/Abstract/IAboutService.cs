﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        List<About> GetList();
        void AboutAdd(About p);
        About GetByID(int id);
        void AboutDelete(About p);
        void AboutUpdate(About p);
    }
}
