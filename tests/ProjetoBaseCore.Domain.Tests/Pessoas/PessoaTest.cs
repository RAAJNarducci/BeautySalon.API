using Moq;
using ProjetoBaseCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace ProjetoBaseCore.Domain.Tests.Pessoas
{
    public class PessoaTest
    {
        const string NOME_VALIDO = "Nome";
        const string EMAIL_VALIDO = "email@prov.com";
        const string CPF_VALIDO = "41281804835";
        const string TELEFONE_VALIDO = "1632524973";

        Mock<Endereco> _enderecoMock;

        public PessoaTest()
        {
            _enderecoMock = new Mock<Endereco>();
            _enderecoMock.Setup(x => x.EstaValido()).Returns(true);
        }

        [Theory]
        [InlineData(null, "Informe o nome da pessoa.")]
        [InlineData("", "Informe o nome da pessoa.")]
        [InlineData("a", "O nome do pessoa precisa ter entre 2 e 150 caracteres.")]
        [InlineData("ab", "")]
        [InlineData("ashdgaskhdgas jagsdjgas dgajsgd kasgd gsad asgd aksgd kasgdkjasgdj gasjkdg ajskgd kasgd aksgd aksjgd akjsgd askgd askgd askdg aksdg askdg aksdg askgda", "")]
        public void Nome_DeveTerEntre2e150Caracteres(string nome, string mensagemEsperada)
        {
            var dataNascimento = Convert.ToDateTime("13/05/1994");
            var pessoa = new Pessoa
            {
                Id = 1,
                Ativo = true,
                Cpf = CPF_VALIDO,
                DataCadastro = DateTime.Now,
                DataNascimento = dataNascimento,
                Email = EMAIL_VALIDO,
                Nome = nome,
                Telefone = TELEFONE_VALIDO,
            };

            pessoa.AtribuirEndereco(_enderecoMock.Object);
            pessoa.EstaValido();

            AssertMensagemEsperada(mensagemEsperada, pessoa);
        }

        private static void AssertMensagemEsperada(string mensagemEsperada, Pessoa pessoa)
        {
            Assert.Equal(pessoa.ValidationResult.IsValid, string.IsNullOrEmpty(mensagemEsperada));

            if (string.IsNullOrEmpty(mensagemEsperada))
                Assert.Empty(pessoa.ValidationResult.Errors);
            else
                Assert.Contains(pessoa.ValidationResult.Errors, e => e.ErrorMessage == mensagemEsperada);
        }
    }
}
