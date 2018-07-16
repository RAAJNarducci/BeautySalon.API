using AutoMapper;
using ProjetoBaseCore.Application.Interfaces;
using ProjetoBaseCore.Domain.Core;
using ProjetoBaseCore.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Application.Services
{
    public abstract class AppServicebase<TEntity, TEntityViewModel, TService> 
        : IAppServiceBase<TEntityViewModel> 
        where TEntity : EntityBase<TEntity> 
        where TEntityViewModel : class 
        where TService : IServiceBase<TEntity>
    {
        protected readonly IUnitOfWork _uow;
        protected readonly TService _service;
        protected readonly IMapper _mapper;

        public AppServicebase(IUnitOfWork uow, TService service, IMapper mapper)
        {
            _uow = uow;
            _service = service;
            _mapper = mapper;
        }

        public virtual TEntityViewModel Add(TEntityViewModel entityViewModel)
        {
            var entityMapper = _mapper.Map<TEntity>(entityViewModel);
            var entity = _service.Add(entityMapper);

            if (entity.ValidationResult.IsValid)
                Commit();

            return _mapper.Map<TEntityViewModel>(entity);
        }

        public virtual TEntityViewModel FindById(int id)
        {
            return _mapper.Map<TEntityViewModel>(_service.FindById(id));
        }

        public virtual IEnumerable<TEntityViewModel> GetAll()
        {
            return _mapper.Map<IEnumerable<TEntityViewModel>>(_service.GetAll());
        }

        public virtual TEntityViewModel Update(TEntityViewModel entityViewModel)
        {
            var entity = _service.Update(_mapper.Map<TEntity>(entityViewModel));

            if (entity.ValidationResult.IsValid)
                Commit();

            return _mapper.Map<TEntityViewModel>(entity);
        }

        public virtual void Delete(int id)
        {
            _service.Delete(id);
            Commit();
        }

        protected void Commit()
        {
            _uow.Commit();
        }

        public virtual void Dispose()
        {
            _service.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
