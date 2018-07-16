using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
