using ProjetoBaseCore.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Domain.Core
{
    public abstract class ServiceBase<TEntity, TRepository> : IServiceBase<TEntity> where TEntity : EntityBase<TEntity> where TRepository : IRepositoryBase<TEntity>
    {
        protected TRepository _repository;

        public ServiceBase(TRepository repository)
        {
            _repository = repository;
        }

        public virtual TEntity Add(TEntity entity)
        {
            if (!entity.EstaValido())
                return entity;

            return _repository.Add(entity);
        }

        public virtual TEntity FindById(int id)
        {
            return _repository.FindById(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (!entity.EstaValido())
                return entity;

            return _repository.Update(entity);
        }

        public virtual void Delete(int id)
        {
            _repository.Delete(id);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
