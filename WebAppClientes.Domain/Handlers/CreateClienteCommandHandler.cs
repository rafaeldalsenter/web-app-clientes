using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAppClientes.Domain.Commands;

namespace WebAppClientes.Domain.Handlers
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, bool>
    {
        public Task<bool> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}