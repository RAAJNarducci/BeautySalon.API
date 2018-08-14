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

        public IEnumerable<Pessoa> BuscarPessoa(string nome, string cpf, int pagina, int quantidadePagina, out int total)
        {
            return _repository.BuscarPessoa(nome, cpf, pagina, quantidadePagina, out total);
        }
    }
}
