using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public interface IEntitiesRepositoryService<TEntity> where TEntity : class, IEntity, new() //CRUD operasyonlarını arayüz yönetiminde standartlaştırmak için oluşturduk, tekrarlama yapmamak için
    {
        List<TEntity> GetAll();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
