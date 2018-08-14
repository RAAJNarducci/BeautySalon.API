using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjetoBaseCore.Application.ViewModels
{
    public class PessoaViewModel: ViewModelBase
    {
        public PessoaViewModel()
        {
            Endereco = new EnderecoViewModel();
        }

        public string Email { get; set; }

        [Required(ErrorMessage = "Nome deve ser informado")]
        [MaxLength(150, ErrorMessage = "O tamanho maximo do nome é 150 caracteres")]
        [MinLength(2, ErrorMessage = "O tamanho minimo do nome é 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "CPF deve ser informado")]
        [StringLength(14, ErrorMessage = "O CPF deve ter 14 caracteres")]
        [DisplayName("CPF")]
        public string Cpf { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }

        [DisplayName("Data de Nascimento")]
        [Required(ErrorMessage = "Data de nascimento deve ser informada")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DataNascimento { get; set; }

        [ScaffoldColumn(false)]
        public string DataNascimentoSemMascara
        {
            get { return DataNascimento.HasValue ? Regex.Replace(DataNascimento.Value.ToShortDateString(), "[^0-9a-zA-Z]+", "") : null; }
            set { }
        }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; private set; }

        [ScaffoldColumn(false)]
        public int EnderecoId { get; set; }

        [MinLength(14, ErrorMessage = "Telefone/Celular inválido")]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        [ScaffoldColumn(false)]
        public string CpfSemMascara
        {
            get { return Cpf != null ? Regex.Replace(Cpf, "[^0-9a-zA-Z]+", "") : null; }
            set { }
        }

        [ScaffoldColumn(false)]
        public string TelefoneSemMascara
        {
            get { return Telefone !=  null ? Regex.Replace(Telefone, "[^0-9a-zA-Z]+", "") : null; }
            set { }
        }

        public virtual EnderecoViewModel Endereco { get; set; }
    }
}
