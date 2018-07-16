using ProjetoBaseCore.Domain.Entities;
using ProjetoBaseCore.Domain.Interfaces;
using ProjetoBaseCore.Infra.Data.Context;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Infra.Data.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(MainContext mainContext) : base(mainContext)
        {
        }

        public Pessoa BuscarPessoaPorEmail(string email)
        {
            var pessoa = (from pe in Db.Pessoas
                          join end in Db.Enderecos on pe.EnderecoId equals end.Id
                          where pe.Email.ToLower() == email.ToLower()
                          select new Pessoa
                          {
                              Id = pe.Id,
                              Email = pe.Email,
                              Ativo = pe.Ativo,
                              Cpf = pe.Cpf,
                              DataCadastro = pe.DataCadastro,
                              DataNascimento = pe.DataNascimento,
                              Nome = pe.Nome,
                              Telefone = pe.Telefone,
                              EnderecoId = end.Id,
                              Endereco = new Endereco
                              {
                                  Id = end.Id,
                                  Bairro = end.Bairro,
                                  CEP = end.CEP,
                                  Cidade = end.Cidade,
                                  Complemento = end.Complemento,
                                  Estado = end.Estado,
                                  Logradouro = end.Logradouro,
                                  Numero = end.Numero,
                              }
                          }).FirstOrDefault();
            return pessoa;
        }
    }
}
