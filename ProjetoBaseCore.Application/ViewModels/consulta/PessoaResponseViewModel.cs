using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Application.ViewModels.consulta
{
    public class PessoaResponseViewModel: ParametrosConsultaViewModel
    {
        public List<PessoaViewModel> Pessoas { get; set; }
    }
}
