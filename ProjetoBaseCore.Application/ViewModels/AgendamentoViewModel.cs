using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Application.ViewModels
{
    public class AgendamentoViewModel: ViewModelBase
    {
        public int IdCliente { get; set; }

        public int IdServico { get; set; }

        public int TempoPrevisto { get; set; }

        public string HorarioAgendamento { get; set; }

        public string DataAgendamento { get; set; }
    }
}
