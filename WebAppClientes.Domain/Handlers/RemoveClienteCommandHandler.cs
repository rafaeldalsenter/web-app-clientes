using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAppClientes.Domain.Commands;

namespace WebAppClientes.Domain.Handlers
{
    public class RemoveClienteCommandHandler : IRequestHandler<RemoveClienteCommand, bool>
    {
        public Task<bool> Handle(RemoveClienteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}