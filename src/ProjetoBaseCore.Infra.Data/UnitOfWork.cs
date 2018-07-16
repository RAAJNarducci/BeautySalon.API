using ProjetoBaseCore.Domain.Core.Interfaces;
using ProjetoBaseCore.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _context;

        public UnitOfWork(MainContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
