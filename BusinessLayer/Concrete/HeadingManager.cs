﻿using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        Context _context = new Context();
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetByID(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id); 
        }

        public List<Heading> GetList()
        {
            return _headingDal.List().Select(h => new Heading
            {
                HeadingID = h.HeadingID,
                HeadingName = h.HeadingName,
                HeadingDate = h.HeadingDate,
                HeadingStatus = h.HeadingStatus,
                CategoryID = h.CategoryID,
                Category = _context.Categories.FirstOrDefault(c => c.CategoryID == h.CategoryID),
                WriterID = h.WriterID,
                Writer = _context.Writers.FirstOrDefault(w => w.WriterID == h.WriterID)
            }).ToList();
        }

        public void HeadingAdd(Heading p)
        {
             _headingDal.Insert(p);
        }

        public void HeadingDelete(Heading p)
        {
            p.HeadingStatus = false;   
            _headingDal.Update(p);
            
        }

        public void HeadingUpdate(Heading p)
        {
            _headingDal.Update(p);
        }

        public List<Heading> GetListByWriter(int writerID)
        {
            // WriterID'ye göre filtrelenmiş başlıkları getirir
            var filteredHeadings = _headingDal.List(x => x.WriterID == writerID);

            // Başlıkları projekte ederken ilişkili kategoriyi ve yazarı da dahil eder
            return filteredHeadings.Select(h => new Heading
            {
                HeadingID = h.HeadingID,
                HeadingName = h.HeadingName,
                HeadingDate = h.HeadingDate,
                HeadingStatus = h.HeadingStatus,
                CategoryID = h.CategoryID,
                // İlgili kategoriyi veri tabanından getirir
                Category = _context.Categories.FirstOrDefault(c => c.CategoryID == h.CategoryID),
                WriterID = h.WriterID,
                // İlgili yazarı veri tabanından getirir
                Writer = _context.Writers.FirstOrDefault(w => w.WriterID == h.WriterID)
            }).ToList();
        }


        List<Heading> IHeadingService.GetListByWriter(int writerID)
        {
            throw new NotImplementedException();
        }
    }
}
