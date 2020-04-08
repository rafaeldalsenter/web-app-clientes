using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebAppClientes.Domain.Commands;
using WebAppClientes.Domain.Interfaces;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Domain.Handlers
{
    public class RemoveClienteCommandHandler : IRequestHandler<RemoveClienteCommand, CommandReturnDto>
    {
        private readonly IClienteForCommandRepository _clienteForCommandRepository;
        private readonly IClienteForQueryRepository _clienteForQueryRepository;

        public RemoveClienteCommandHandler(IClienteForCommandRepository clienteForCommandRepository,
            IClienteForQueryRepository clienteForQueryRepository)
        {
            _clienteForCommandRepository = clienteForCommandRepository;
            _clienteForQueryRepository = clienteForQueryRepository;
        }

        public Task<CommandReturnDto> Handle(RemoveClienteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                _clienteForCommandRepository.Delete(request.Id);

                _clienteForQueryRepository.Delete(request.Id);

                return Task.FromResult(new CommandReturnDto());
            }
            catch (Exception ex)
            {
                var retornoComErro = new CommandReturnDto();
                retornoComErro.AddError(ex.Message);
                return Task.FromResult(retornoComErro);
            }
        }
    }
}