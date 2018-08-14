using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Application.ViewModels.consulta
{
    public class AgendamentoResponse: ViewModelBase
    {
        public PessoaViewModel Cliente { get; set; }

        public ServicoViewModel Servico { get; set; }

        public StatusAgendamentoViewModel StatusAgendamento { get; set; }

        public string DataFormatada { get; set; }

        public TimeSpan HorarioInicio { get; set; }

        public int Minutos { get; set; }
    }
}
