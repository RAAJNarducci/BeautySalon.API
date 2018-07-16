using AutoMapper;
using ProjetoBaseCore.Application.Interfaces;
using ProjetoBaseCore.Application.ViewModels;
using ProjetoBaseCore.Domain.Core.Interfaces;
using ProjetoBaseCore.Domain.Entities;
using ProjetoBaseCore.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Application.Services
{
    public class PessoaAppService : AppServicebase<Pessoa, PessoaViewModel, IPessoaService>, IPessoaAppService
    {
        public PessoaAppService(IUnitOfWork uow, IPessoaService service, IMapper mapper) : base(uow, service, mapper)
        {
        }

        public PessoaViewModel BuscarPessoaPorEmail(string email)
        {
            var pessoaMapper = _mapper.Map<PessoaViewModel>(_service.BuscarPessoaPorEmail(email));
            return pessoaMapper;
        }
    }
}
