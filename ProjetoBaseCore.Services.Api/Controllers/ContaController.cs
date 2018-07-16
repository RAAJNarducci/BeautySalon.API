using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoBaseCore.Application.ViewModels.identity;
using ProjetoBaseCore.Infra.CrossCutting.Identity.Models;
using static ProjetoBaseCore.Application.ViewModels.jwt.JwtModels;

namespace ProjetoBaseCore.Services.Api.Controllers
{
    [Route("api/Conta")]
    public class ContaController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ContaController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("registrar")]
        public async Task<IActionResult> Register([FromBody] RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return NotFound();

            var user = new AppUser { UserName = model.Email, Email = model.Email };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded) { 
                _userManager.AddToRoleAsync(user, Roles.ROLE_API_ADMIN).Wait();
            return Ok();
            }

            return Unauthorized();
        }
    }
}