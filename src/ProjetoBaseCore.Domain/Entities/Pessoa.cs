using FluentValidation;
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
            ValidarNome();
            ValidarEmail();
            ValidationResult = Validate(this);

            ValidarEndereco();
            return ValidationResult.IsValid;
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Informe o nome da pessoa.")
                .Length(2, 150).WithMessage("O nome do pessoa precisa ter entre 2 e 150 caracteres.");
        }

        private void ValidarEmail()
        {
            RuleFor(c => c.Email)
                .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$").WithMessage("E-mail não é válido.")
                .NotEmpty().WithMessage("Informe o e-mail do contato.")
                .MaximumLength(256).WithMessage("O e-mail do contato deve no máximo 256 caracteres.");
        }

        private void ValidarEndereco()
        {
            if (Endereco.EstaValido())
                return;

            foreach (var erro in Endereco.ValidationResult.Errors)
                ValidationResult.Errors.Add(erro);
        }

        public void AtribuirEndereco(Endereco endereco)
        {
            if (!endereco.EstaValido()) return;
            Endereco = endereco;
        }
    }
}
