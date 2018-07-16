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
    }
}