using Core.Business;
using Core.Ultities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService 
    {
        IDataResult<List<RentalDetailDto>> GetRentalDetails();

        IDataResult<List<Rental>> GetAll();
        IResult Add(Rental entity);
        IResult Update(Rental entity);
        IResult Delete(Rental entity);
    }
}
