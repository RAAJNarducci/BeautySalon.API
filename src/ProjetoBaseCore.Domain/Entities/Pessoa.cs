using ProjetoBaseCore.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoBaseCore.Domain.Entities
{
    public class Pessoa : EntityBase<Pessoa>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public bool Ativo { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Telefone { get; set; }
        public int EnderecoId { get; set; }

        public virtual Endereco Endereco { get; set; }

        public override bool EstaValido()
        {
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
