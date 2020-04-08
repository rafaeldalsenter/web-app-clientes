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

        public void OnGet(int id)
        {
            var dto = _clienteServices.GetById(id);

            if (dto is null)
            {
                RedirectToPage("/Index");
                return;
            }

            Id = dto.Id;
            NomeDoCliente = dto.Nome;
        }

        [BindProperty]
        public int Id { get; set; }

        [BindProperty]
        public string NomeDoCliente { get; set; }

        public async Task<IActionResult> OnPost()
        {
            var retorno = await _clienteServices.Delete(Id);

            if (!retorno.IsValid())
            {
                ViewData.Add("Errors", retorno.ErrorMessages.ToErrorMessage());
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}