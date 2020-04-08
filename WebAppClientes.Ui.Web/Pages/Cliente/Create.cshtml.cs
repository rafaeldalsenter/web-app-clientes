using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebAppClientes.Infra.CrossCutting.Dtos;
using WebAppClientes.Services;
using WebAppClientes.Ui.Web.Extensions;
using WebAppClientes.Ui.Web.Models;

namespace WebAppClientes.Ui.Web.Pages.Cliente
{
    public class CreateModel : PageModel
    {
        private readonly IClienteServices _clienteServices;

        public CreateModel(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public ClienteModel Cliente { get; set; }

        public async Task<IActionResult> OnPost()
        {
            var retorno = await _clienteServices.Add(new ClienteDto
            {
                Nome = Cliente.Nome,
                Bairro = Cliente.Bairro,
                Cidade = Cliente.Cidade,
                Cpf = Cliente.Cpf,
                Observacoes = Cliente.Observacoes,
                Rua = Cliente.Rua
            });

            if (!retorno.IsValid())
            {
                ViewData.Add("Errors", retorno.ErrorMessages.ToErrorMessage());
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}