using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Application.ViewModels.consulta
{
    public class AgendamentoResponse: ViewModelBase
    {
        public string NomeCliente { get; set; }

        public string DataFormatada { get; set; }

        public string DescricaoServico { get; set; }

        public TimeSpan HorarioInicio { get; set; }

        public int Minutos { get; set; }
    }
}
