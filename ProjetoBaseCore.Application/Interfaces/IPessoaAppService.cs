using ProjetoBaseCore.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Application.Interfaces
{
    public interface IPessoaAppService: IAppServiceBase<PessoaViewModel>
    {
        PessoaViewModel BuscarPessoaPorEmail(string email);
    }
}
