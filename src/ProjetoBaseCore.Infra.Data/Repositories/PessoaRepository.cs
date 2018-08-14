using ProjetoBaseCore.Domain.Entities;
using ProjetoBaseCore.Domain.Interfaces;
using ProjetoBaseCore.Infra.Data.Context;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.IO;

namespace ProjetoBaseCore.Infra.Data.Repositories
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        private IConfiguration _config;

        public PessoaRepository(MainContext mainContext, IConfiguration configuration) : base(mainContext)
        {
            _config = configuration;
        }

        public override Pessoa FindById(int id)
        {
            using (SqlConnection conexao = new SqlConnection(
                   GetConnectionString()))
            {
                StringBuilder sbQuerySelect = new StringBuilder();
                StringBuilder sbQueryWhere = new StringBuilder();
                sbQuerySelect.Append(
                    "SELECT * " +
                    "FROM dbo.Pessoa P " +
                    "INNER JOIN dbo.Endereco E ON P.EnderecoId = E.Id ");
                #region WHERE
                var condicaoWhere = "WHERE ";
                sbQueryWhere.Append($"{condicaoWhere} P.Id = {id} ");
                #endregion

                var query = string.Concat(sbQuerySelect.ToString(), sbQueryWhere.ToString());

                return conexao.Query<Pessoa, Endereco, Pessoa>(query, (p, e) =>
                {
                    p.Endereco = e;
                    return p;
                }, splitOn: "EnderecoId").FirstOrDefault();
            }
        }

        public IEnumerable<Pessoa> BuscarPessoa(string nome, string cpf, int pagina, int quantidadePagina, out int total)
        {
            using (SqlConnection conexao = new SqlConnection(
                GetConnectionString()))
            {
                StringBuilder sbQuerySelect = new StringBuilder();
                StringBuilder sbQueryWhere = new StringBuilder();
                StringBuilder sbQueryPaginate = new StringBuilder();
                sbQuerySelect.Append(
                    "SELECT * " +
                    "FROM dbo.Pessoa P " +
                    "INNER JOIN dbo.Endereco E ON P.EnderecoId = E.Id ");

                #region WHERE
                var condicaoWhere = "WHERE ";
                if (nome != null)
                {
                    sbQueryWhere.Append($"{condicaoWhere} P.Nome LIKE '%{nome}%' collate Latin1_General_CI_AI ");
                    condicaoWhere = "AND ";
                }
                if (cpf != null)
                {
                    sbQueryWhere.Append($"{condicaoWhere} P.Cpf = {cpf} ");
                    condicaoWhere = "AND ";
                }
                #endregion

                #region PAGINATE
                sbQueryPaginate.Append("ORDER BY P.Nome ");
                sbQueryPaginate.Append($"OFFSET {(pagina - 1) * quantidadePagina} ROWS ");
                sbQueryPaginate.Append($"FETCH NEXT {quantidadePagina} ROWS ONLY ");
                #endregion

                var query = string.Concat(sbQuerySelect.ToString(), sbQueryWhere.ToString(), sbQueryPaginate.ToString());

                var pessoasJoin = conexao.Query<Pessoa, Endereco, Pessoa>(query, (p, e) =>
                {
                    p.Endereco = e;
                    return p;
                }, splitOn: "EnderecoId");

                var queryCount = string.Concat("SELECT COUNT(P.Id) FROM dbo.Pessoa P INNER JOIN dbo.Endereco E ON P.EnderecoId = E.Id ", sbQueryWhere.ToString());

                total = conexao.Query<int>(queryCount).SingleOrDefault();
                return pessoasJoin;
            }
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

        public string GetConnectionString()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return config.GetConnectionString("DefaultConnection");
        }
    }
}
