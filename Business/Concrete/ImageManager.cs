using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Ultities.Business;
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
        [ValidationAspect(typeof(ImageValidator))]
        public IResult Add(Image entity)
        {
            var result = BusinessRules.Run(CheckCarImageCount(entity.CarID));
            if (result != null)
            {
                return result;
            }
            _imageDal.Add(entity);

            return new SuccessResult();
        }

        [ValidationAspect(typeof(ImageValidator))]
        public IResult Delete(Image entity)
        {
            _imageDal.Delete(entity);
            return new SuccessResult();
        }

        public IDataResult<List<Image>> GetAll()
        {
            throw new NotImplementedException();
        }

        [ValidationAspect(typeof(ImageValidator))]
        public IResult Update(Image entity)
        {
            _imageDal.Update(entity);
            return new SuccessResult();
        }

        private IResult CheckCarImageCount(int carId)
        {
            var result = _imageDal.GetAll(x => x.CarID == carId);
            if (result.Count >= 5)
            {
                return new ErrorResult("Bir arabanın en fazla 5 resmi olabilir. ");
            }
            return new SuccessResult();
        }
    }
}
