using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoBaseCore.Application.ViewModels;

namespace ProjetoBaseCore.Services.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        protected new IActionResult Response(ViewModelBase viewModel = null, object result = null)
        {
            if (ModelState.IsValid && (viewModel == null || viewModel.ValidationResult.IsValid))
            {
                return Ok(new
                {
                    success = true,
                    data = result ?? viewModel
                });
            }

            var errorMessages = new List<string>();

            viewModel?
                .ValidationResult
                .Errors.ToList()
                .ForEach(e => errorMessages.Add(e.ErrorMessage));

            ModelState
                .Values
                .SelectMany(v => v.Errors).ToList()
                .ForEach(error =>
                {
                    var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                    errorMessages.Add(errorMsg);
                });

            return BadRequest(new
            {
                success = false,
                errors = errorMessages
            });
        }

        protected void AdicionarErrosIdentity(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }
    }
}