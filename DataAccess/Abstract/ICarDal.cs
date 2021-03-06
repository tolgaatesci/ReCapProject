﻿using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal: IEntityRepository<Car>
    {
        //List<Car> GetAll();
        //void Add(Car car);
        //void Update(Car car);
        //void Delete(Car car);
        //List<Car> GetAllById(int Id); IEntityRepository yapısı kullandığım için burasının içini ekstra doldurmam gerekmiyor.
        List<CarDetailDto> GetCarDetails();
    }
}
