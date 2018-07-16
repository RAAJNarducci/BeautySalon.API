using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Application.Interfaces
{
    public interface IAppServiceBase<TEntityViewModel> : IDisposable where TEntityViewModel : class
    {
        TEntityViewModel Add(TEntityViewModel entityViewModel);
        void Delete(int id);
        TEntityViewModel FindById(int id);
        IEnumerable<TEntityViewModel> GetAll();
        TEntityViewModel Update(TEntityViewModel entityViewModel);
    }
}
