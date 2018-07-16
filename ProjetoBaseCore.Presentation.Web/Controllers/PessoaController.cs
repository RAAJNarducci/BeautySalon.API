using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoBaseCore.Application.Interfaces;
using ProjetoBaseCore.Application.ViewModels;
using ProjetoBaseCore.Presentation.Web.Models;

namespace ProjetoBaseCore.Presentation.Web.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class PessoaController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPessoaAppService _pessoaAppService;

        public PessoaController(
            UserManager<ApplicationUser> userManager,
            IPessoaAppService pessoaAppService
            )
        {
            _userManager = userManager;
            _pessoaAppService = pessoaAppService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            PessoaViewModel pessoaViewModel = new PessoaViewModel();
            var idUsuario = _userManager.GetUserId(HttpContext.User);
            var usuario = _userManager.Users.Where(x => x.Id == idUsuario).FirstOrDefault();
            var pessoaCadastrada = _pessoaAppService.BuscarPessoaPorEmail(usuario.Email);
            if (pessoaCadastrada != null)
            {
                if (pessoaCadastrada.Telefone != null)
                    FormatarTelefone(pessoaCadastrada);

                pessoaViewModel = pessoaCadastrada;
            }
            else
            {
                pessoaViewModel.Email = usuario.Email;
                pessoaViewModel.Telefone = usuario.PhoneNumber;
            }
            return View(pessoaViewModel);
        }

        [HttpPost]
        public bool Create(PessoaViewModel pessoaViewModel)
        {
            try
            {
                var pessoa = _pessoaAppService.Add(pessoaViewModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public bool Edit(PessoaViewModel pessoaViewModel)
        {
            try
            {
                _pessoaAppService.Update(pessoaViewModel);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // GET: Pessoa/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Pessoa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        #region HELPERS

        private void FormatarTelefone(PessoaViewModel pessoaViewModel)
        {
            if (pessoaViewModel.Telefone.Length == 10)
                pessoaViewModel.Telefone = pessoaViewModel.Telefone
                    .Insert(0, "(")
                    .Insert(3, ")")
                    .Insert(8, "-");
            else
                pessoaViewModel.Telefone = pessoaViewModel.Telefone
                    .Insert(0, "(")
                    .Insert(3, ")")
                    .Insert(9, "-");
        }

        #endregion
    }
}