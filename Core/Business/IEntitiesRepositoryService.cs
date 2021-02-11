using Core.Entities;
using Core.Ultities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public interface IEntitiesRepositoryService<TEntity> where TEntity : class, IEntity, new() //CRUD operasyonlarını arayüz yönetiminde standartlaştırmak için oluşturduk, tekrarlama yapmamak için
    {
        IDataResult<List<TEntity>> GetAll();
        IResult Add(TEntity entity);
        IResult Update(TEntity entity);
        IResult Delete(TEntity entity);
    }
}
