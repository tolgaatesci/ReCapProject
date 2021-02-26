using Business.Abstract;
using Core.Ultities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _imageDal;
        public ImageManager(IImageDal imageDal)
        {
            _imageDal = imageDal;
        }
        public IResult Add(Image entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Image entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Image>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Image entity)
        {
            throw new NotImplementedException();
        }
    }
}
