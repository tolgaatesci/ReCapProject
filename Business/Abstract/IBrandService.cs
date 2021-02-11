using Core.Business;
using Core.Ultities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService : IEntitiesRepositoryService<Brand>
    {
        IDataResult<List<Brand>> GetCarsByBrandId(int id);
    }
}
