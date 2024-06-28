using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IIMageFileDal _imageFileDal;

        public ImageFileManager(IIMageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public ImageFile GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<ImageFile> GetList()
        {
            return _imageFileDal.List();
        }

        public void ImageFileAdd(ImageFile p)
        {
            throw new NotImplementedException();
        }

        public void ImageFileDelete(ImageFile p)
        {
            throw new NotImplementedException();
        }

        public void ImageFileUpdate(ImageFile p)
        {
            throw new NotImplementedException();
        }
    }
}
