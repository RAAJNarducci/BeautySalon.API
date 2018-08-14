using ProjetoBaseCore.Application.ViewModels;
using ProjetoBaseCore.Application.ViewModels.consulta;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Application.Interfaces
{
    public interface IPessoaAppService: IAppServiceBase<PessoaViewModel>
    {
        PessoaViewModel BuscarPessoaPorEmail(string email);
        PessoaResponseViewModel BuscarPessoa(PessoaConsultaViewModel pessoaConsultaViewModel);
    }
}
