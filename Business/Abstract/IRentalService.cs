using Core.Business;
using Core.Ultities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService : IEntitiesRepositoryService<Rental>
    {
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
    }
}
