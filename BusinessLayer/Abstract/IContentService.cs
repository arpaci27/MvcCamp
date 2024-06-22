﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetListById(int id);
        void ContentAdd(Content p);
        Category GetByID(int id);
        void ContentDelete(Content p);
        void ContentUpdate(Content p);
    }
}
