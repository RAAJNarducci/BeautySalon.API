using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoBaseCore.Application.Interfaces;
using ProjetoBaseCore.Application.ViewModels;
using ProjetoBaseCore.Application.ViewModels.consulta;

namespace ProjetoBaseCore.Services.Api.Controllers
{
    public class PessoaController : BaseController
    {
        private readonly IPessoaAppService _pessoaAppServiceBase;

        public PessoaController(IPessoaAppService pessoaAppServiceBase)
        {
            _pessoaAppServiceBase = pessoaAppServiceBase;
        }

        [HttpGet]
        public IEnumerable<PessoaViewModel> Get()
        {
            return _pessoaAppServiceBase.GetAll();
        }

        [HttpGet]
        [Route("GetById")]
        public PessoaViewModel GetById(int id)
        {
            return _pessoaAppServiceBase.FindById(id);
        }


        [HttpGet]
        [Route("BuscarPessoas")]
        public PessoaResponseViewModel BuscarPessoas(PessoaConsultaViewModel pessoaConsultaViewModel)
        {
            return _pessoaAppServiceBase.BuscarPessoa(pessoaConsultaViewModel);
        }

        [HttpPost]
        public void Post([FromBody] PessoaViewModel pessoaViewModel)
        {
            try
            {
                _pessoaAppServiceBase.Add(pessoaViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public void Put([FromBody] PessoaViewModel pessoaViewModel)
        {
            try
            {
                _pessoaAppServiceBase.Update(pessoaViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}   