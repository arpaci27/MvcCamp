﻿using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        Context _context = new Context();

        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content p)
        {
             _contentDal.Insert(p); 
        }

        public void ContentDelete(Content p)
        {
            _contentDal.Delete(p);
        }

        public void ContentUpdate(Content p)
        {
            _contentDal.Update(p);
        }

        public Content GetByID(int id)
        {
            return _contentDal.Get(x => x.ContentID == id);
        }

        public List<Content> GetList(string p)
        {
            return _contentDal.List().Select(h => new Content
            {
                ContentID = h.ContentID,
                ContentValue = h.ContentValue,
                ContentDate = h.ContentDate,
                WriterID = h.WriterID,
                Writer = _context.Writers.FirstOrDefault(w => w.WriterID == h.WriterID),
                HeadingID = h.HeadingID,
                Heading = _context.Headings.FirstOrDefault(c => c.HeadingID == h.HeadingID),
            }).ToList();
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _contentDal.List()
            .Where(x => x.HeadingID == id)
            .Select(h => new Content
            {
                ContentID = h.ContentID,
                ContentValue = h.ContentValue,
                ContentDate = h.ContentDate,
                WriterID = h.WriterID,
                Writer = _context.Writers.FirstOrDefault(w => w.WriterID == h.WriterID),
                HeadingID = h.HeadingID,
                Heading = _context.Headings.FirstOrDefault(c => c.HeadingID == h.HeadingID),
            }).ToList();
        }
        List<Content> IContentService.GetListById(int id)
        {
            return _contentDal.List(x => x.HeadingID == id);
        }

        public List<Content> GetListByWriter(int writerId)
        {
            return _context.Contents
                .Where(x => x.WriterID == writerId)
                .Select(c => new Content
                {
                    ContentID = c.ContentID,
                    ContentValue = c.ContentValue,
                    ContentDate = c.ContentDate,
                    WriterID = c.WriterID,
                    Writer = _context.Writers.FirstOrDefault(w => w.WriterID == c.WriterID),
                    HeadingID = c.HeadingID,
                    Heading = _context.Headings.FirstOrDefault(h => h.HeadingID == c.HeadingID),
                }).ToList();
        }


        List<Content> IContentService.GetListByWriter(int id)
        {
            throw new NotImplementedException();
        }

        List<Content> IContentService.GetList()
        {
            throw new NotImplementedException();
        }

        List<Content> IContentService.GetListBySearch(string p)
        {
            throw new NotImplementedException();
        }
        public List<Content> GetListBySearch(string p)
        {
            return _contentDal.List(x => x.ContentValue.Contains(p));
        }
    }
}
