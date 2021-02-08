using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Add(Color color)
        {
            if (color.ColorType == "Rich")
            {
                _colorDal.Add(color);
                Console.WriteLine("Renk eklendi.");
            }
            else
            {
                Console.WriteLine("Renk tipi Rich'den farklı olmamalıdır :" + color.ColorType);
            }
        }

        public void Delete(Color color)
        {
                _colorDal.Delete(color);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public List<Color> GetColorsByColorType(string ColorType)
        {
            return _colorDal.GetAll(c => c.ColorType == ColorType);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            //Color colorToUpdate = _colors.SingleOrDefault(c => c.ColorId == color.ColorId);
            //colorToUpdate.ColorName = color.ColorName;
            //colorToUpdate.ColorType = color.ColorType;
        }
    }
}
