﻿using Business.Abstract;
using Business.Constants;
using Core.Ultities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager:ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerdal)
        {
            _customerDal = customerdal;
        }

        public IResult Add(Customer entity)
        {
            _customerDal.Add(entity);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer entity)
        {
            _customerDal.Delete(entity);
            return new SuccessResult(Messages.CustomerDeleted);
        }


        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IResult Update(Customer entity)
        {
            _customerDal.Update(entity);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
