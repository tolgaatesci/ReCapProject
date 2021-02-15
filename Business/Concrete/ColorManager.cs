using Business.Abstract;
using Business.Constants;
using Core.Ultities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;
        List<Car> _colors;
        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }
        public IResult Add(Color color)
        {
            if (color.ColorType == "Rich")
            {
                return new ErrorResult(Messages.ColorNotAdded);
            }
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        public IResult Delete(Color color)
        {
                _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }


        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<List<Color>> GetColorsByColorType(string ColorType)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.ColorType == ColorType));
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
            //Color colorToUpdate = _colors.SingleOrDefault(c => c.ColorId == color.ColorId);
            //colorToUpdate.ColorName = color.ColorName;
            //colorToUpdate.ColorType = color.ColorType;
        }
    }
}
