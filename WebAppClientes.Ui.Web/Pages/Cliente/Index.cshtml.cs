using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using WebAppClientes.Infra.CrossCutting.Dtos;
using WebAppClientes.Services;
using WebAppClientes.Ui.Web.Extensions;
using WebAppClientes.Ui.Web.Models;

namespace WebAppClientes.Ui.Web.Pages.Cliente
{
    public class IndexModel : PageModel
    {
        private readonly IClienteServices _clienteServices;

        public IndexModel(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        public void OnGet(int id)
        {
            if (id == 0)
            {
                Cliente = new ClienteModel();
                return;
            }

            var dto = _clienteServices.GetById(id);

            if (dto is null)
            {
                RedirectToPage("/Index");
                return;
            }

            Cliente = new ClienteModel
            {
                Id = dto.Id,
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                Cpf = dto.Cpf,
                Nome = dto.Nome,
                Observacoes = dto.Observacoes,
                Rua = dto.Rua
            };
        }

        [BindProperty]
        public ClienteModel Cliente { get; set; }

        public async Task<IActionResult> OnPost()
        {
            var dto = new ClienteDto
            {
                Id = Cliente.Id,
                Bairro = Cliente.Bairro,
                Cidade = Cliente.Cidade,
                Rua = Cliente.Rua,
                Cpf = Cliente.Cpf,
                Nome = Cliente.Nome,
                Observacoes = Cliente.Observacoes
            };

            var retorno = Cliente.Id.Equals(0) ?
                await _clienteServices.Add(dto) :
                await _clienteServices.Update(dto);

            if (!retorno.IsValid())
            {
                ViewData.Add("Errors", retorno.ErrorMessages.ToErrorMessage());
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}