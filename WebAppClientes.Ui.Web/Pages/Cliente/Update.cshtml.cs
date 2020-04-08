using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppClientes.Infra.CrossCutting.Dtos;
using WebAppClientes.Services;
using WebAppClientes.Ui.Web.Extensions;
using WebAppClientes.Ui.Web.Models;

namespace WebAppClientes.Ui.Web.Pages.Cliente
{
    public class UpdateModel : PageModel
    {
        private readonly IClienteServices _clienteServices;

        public UpdateModel(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [BindProperty]
        public ClienteModel Cliente { get; set; }

        public void OnGet(int id)
        {
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

            var retorno = await _clienteServices.Update(dto);

            if (!retorno.IsValid())
            {
                ViewData.Add("Errors", retorno.ErrorMessages.ToErrorMessage());
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}