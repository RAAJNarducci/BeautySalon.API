using ProjetoBaseCore.Domain.Core;
using ProjetoBaseCore.Domain.Core.Interfaces;
using ProjetoBaseCore.Domain.Entities;
using ProjetoBaseCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Domain.Services
{
    public class PessoaService : ServiceBase<Pessoa, IPessoaRepository>, IPessoaService
    {
        public PessoaService(IPessoaRepository repository) : base(repository)
        {
        }

        public Pessoa BuscarPessoaPorEmail(string email)
        {
            return _repository.BuscarPessoaPorEmail(email);
        }
    }
}
