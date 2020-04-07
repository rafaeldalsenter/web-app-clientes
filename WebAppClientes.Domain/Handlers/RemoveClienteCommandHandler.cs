using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAppClientes.Domain.Commands;
using WebAppClientes.Domain.Interfaces;

namespace WebAppClientes.Domain.Handlers
{
    public class RemoveClienteCommandHandler : IRequestHandler<RemoveClienteCommand, bool>
    {
        private readonly IClienteForCommandRepository _clienteForCommandRepository;
        private readonly IClienteForQueryRepository _clienteForQueryRepository;

        public RemoveClienteCommandHandler(IClienteForCommandRepository clienteForCommandRepository,
            IClienteForQueryRepository clienteForQueryRepository)
        {
            _clienteForCommandRepository = clienteForCommandRepository;
            _clienteForQueryRepository = clienteForQueryRepository;
        }

        public Task<bool> Handle(RemoveClienteCommand request, CancellationToken cancellationToken)
        {
            _clienteForCommandRepository.Delete(request.Id);

            _clienteForQueryRepository.DeleteAsync(request.Id);

            return Task.FromResult(true);
        }
    }
}