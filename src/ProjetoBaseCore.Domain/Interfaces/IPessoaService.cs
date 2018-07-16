using ProjetoBaseCore.Domain.Core.Interfaces;
using ProjetoBaseCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Domain.Interfaces
{
    public interface IPessoaService: IServiceBase<Pessoa>
    {
        Pessoa BuscarPessoaPorEmail(string email);
    }
}
