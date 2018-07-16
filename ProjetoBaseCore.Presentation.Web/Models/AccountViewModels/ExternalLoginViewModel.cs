using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoBaseCore.Presentation.Web.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required(ErrorMessage = "Email Obrigatório")]
        [EmailAddress(ErrorMessage = "É necessário um Email válido para o cadastro")]
        public string Email { get; set; }
    }
}
