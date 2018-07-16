using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoBaseCore.Presentation.Web.Models.ManageViewModels
{
    public class IndexViewModel
    {
        [Display(Name = "Login")]
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required(ErrorMessage = "Email Obrigatório")]
        [EmailAddress(ErrorMessage = "Email inválido!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [MinLength(14, ErrorMessage = "Telefone/Celular inválido")]
        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }

        public string StatusMessage { get; set; }
    }
}
