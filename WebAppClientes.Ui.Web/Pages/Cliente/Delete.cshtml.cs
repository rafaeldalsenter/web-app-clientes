using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppClientes.Services;
using WebAppClientes.Ui.Web.Extensions;

namespace WebAppClientes.Ui.Web.Pages.Cliente
{
    public class DeleteModel : PageModel
    {
        private readonly IClienteServices _clienteServices;

        public DeleteModel(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var retorno = await _clienteServices.Delete(1);

            if (!retorno.IsValid())
            {
                ViewData.Add("Errors", retorno.ErrorMessages.ToErrorMessage());
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}