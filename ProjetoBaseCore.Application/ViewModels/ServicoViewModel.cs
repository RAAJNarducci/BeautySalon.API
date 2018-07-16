using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProjetoBaseCore.Application.ViewModels
{
    public class ServicoViewModel: ViewModelBase
    {
        [Required(ErrorMessage = "Descrição deve ser informado")]
        [MaxLength(150, ErrorMessage = "O tamanho maximo da descrição é 150 caracteres")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Valor deve ser informado")]
        public string Valor { get; set; }

        [Required(ErrorMessage = "Tempo previsto deve ser informado")]
        [DisplayName("Tempo Previsto")]
        public int TempoPrevisto { get; set; }

        public decimal ValorSemMascara { get; set; }
    }
}
