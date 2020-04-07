using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using WebAppClientes.Domain.Interfaces;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Ui.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IClienteForQueryRepository _clienteForQueryRepository;

        public IEnumerable<ClienteDto> Clientes { get; private set; }

        public IndexModel(IClienteForQueryRepository clienteForQueryRepository)
        {
            _clienteForQueryRepository = clienteForQueryRepository;
        }

        public void OnGet()
        {
            Clientes = _clienteForQueryRepository.Get();
        }
    }
}