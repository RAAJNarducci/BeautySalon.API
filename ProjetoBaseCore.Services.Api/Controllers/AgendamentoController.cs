using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoBaseCore.Application.ViewModels;
using ProjetoBaseCore.Application.ViewModels.consulta;

namespace ProjetoBaseCore.Services.Api.Controllers
{
    [Authorize("Bearer")]
    public class AgendamentoController : BaseController
    {
        [HttpGet]
        public IActionResult Get(DateTime data)
        {
            List<AgendamentoResponse> response = new List<AgendamentoResponse>();
            response.Add(new AgendamentoResponse
            {
                Id = 1,
                DataFormatada = DateTime.Now.ToShortDateString(),
                HorarioInicio = new TimeSpan(14, 0, 0),
                Minutos = 60,
                StatusAgendamento = new StatusAgendamentoViewModel
                {
                    Id = 1,
                    Descricao = "Agendado"
                },
                Cliente = new PessoaViewModel
                {
                    Id = 1,
                    Nome = "Barbara",
                    Cpf = "412.818.048-35",
                    Telefone = "(16)3252-9887",
                    ValidationResult = new FluentValidation.Results.ValidationResult()
                },
                Servico = new ServicoViewModel
                {
                    Id = 1,
                    Descricao = "Corte",
                    TempoPrevisto = 60,
                    ValorSemMascara = Convert.ToDecimal("99.99"),
                    ValidationResult = new FluentValidation.Results.ValidationResult()
                },
                ValidationResult = new FluentValidation.Results.ValidationResult()
            });

            response.Add(new AgendamentoResponse
            {
                Id = 2,
                DataFormatada = DateTime.Now.ToShortDateString(),
                HorarioInicio = new TimeSpan(14, 0, 0),
                Minutos = 60,
                StatusAgendamento = new StatusAgendamentoViewModel
                {
                    Id = 1,
                    Descricao = "Agendado"
                },
                Cliente = new PessoaViewModel
                {
                    Id = 3,
                    Nome = "Ana",
                    ValidationResult = new FluentValidation.Results.ValidationResult()
                },
                Servico = new ServicoViewModel
                {
                    Id = 1,
                    Descricao = "Corte",
                    TempoPrevisto = 60,
                    ValorSemMascara = Convert.ToDecimal("99.99"),
                    ValidationResult = new FluentValidation.Results.ValidationResult()
                },
                ValidationResult = new FluentValidation.Results.ValidationResult()
            });

            response.Add(new AgendamentoResponse
            {
                Id = 3,
                DataFormatada = "10/08/2018",
                HorarioInicio = new TimeSpan(16, 0, 0),
                Minutos = 120,
                StatusAgendamento = new StatusAgendamentoViewModel
                {
                    Id = 2,
                    Descricao = "Concluído"
                },
                Cliente = new PessoaViewModel
                {
                    Id = 2,
                    Nome = "Gabriele",
                    ValidationResult = new FluentValidation.Results.ValidationResult()
                },
                Servico = new ServicoViewModel
                {
                    Id = 2,
                    Descricao = "Pintura",
                    TempoPrevisto = 120,
                    ValorSemMascara = Convert.ToDecimal("150.00"),
                    ValidationResult = new FluentValidation.Results.ValidationResult()
                },
                ValidationResult = new FluentValidation.Results.ValidationResult()
            });



            return Ok(response);
        }

        [HttpPost]
        public IActionResult Post([FromBody] AgendamentoViewModel agendamentoViewModel)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Put([FromBody] AgendamentoViewModel agendamentoViewModel)
        {
            return Ok();
        }

        [HttpGet]
        [Route("ListarServicos")]
        public IActionResult ListarServicos()
        {
            List<ServicoViewModel> response = new List<ServicoViewModel>();
            response.Add(new ServicoViewModel
            {
                Id = 1,
                Descricao = "Corte",
                TempoPrevisto = 60,
                ValorSemMascara = Convert.ToDecimal("99.99"),
                ValidationResult = new FluentValidation.Results.ValidationResult()
            });

            response.Add(new ServicoViewModel
            {
                Id = 2,
                Descricao = "Pintura",
                TempoPrevisto = 120,
                ValorSemMascara = Convert.ToDecimal("150.00"),
                ValidationResult = new FluentValidation.Results.ValidationResult()
            });

            return Ok(response);
        }
    }
}