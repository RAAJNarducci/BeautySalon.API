using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoBaseCore.Presentation.Web.Models.AccountViewModels
{
    public class ExternalLoginViewModel
    {
        [Required(ErrorMessage = "Email Obrigat�rio")]
        [EmailAddress(ErrorMessage = "� necess�rio um Email v�lido para o cadastro")]
        public string Email { get; set; }
    }
}
