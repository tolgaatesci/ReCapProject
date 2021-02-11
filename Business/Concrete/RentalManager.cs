using Business.Abstract;
using Core.Ultities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal rentaldal)
        {
            _rentalDal = rentaldal;
        }

        public IResult Add(Car entity)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Car>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IResult Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
