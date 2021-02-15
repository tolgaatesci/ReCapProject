using Business.Abstract;
using Business.Constants;
using Core.Ultities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;
        public RentalManager(IRentalDal entity)
        {
            _rentalDal = entity;
        }

        public IResult Add(Rental entity)
        {
            Rental carRentalStatus = _rentalDal.Get(r => r.CarId == entity.CarId);
            if (carRentalStatus.ReturnDate == null)
            {
                return new ErrorResult(Messages.RentalNotAdded);
            }
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.RentalDeleted);
        }


        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
