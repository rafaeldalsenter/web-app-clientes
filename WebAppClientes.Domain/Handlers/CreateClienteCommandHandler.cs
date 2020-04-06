using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebAppClientes.Domain.Builders;
using WebAppClientes.Domain.Commands;
using WebAppClientes.Domain.Interfaces;

namespace WebAppClientes.Domain.Handlers
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, bool>
    {
        private readonly IClienteForCommandRepository _clienteForCommandRepository;
        private readonly IClienteForQueryRepository _clienteForQueryRepository;

        public CreateClienteCommandHandler(IClienteForCommandRepository clienteForCommandRepository,
            IClienteForQueryRepository clienteForQueryRepository)
        {
            _clienteForCommandRepository = clienteForCommandRepository;
            _clienteForQueryRepository = clienteForQueryRepository;
        }

        public Task<bool> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var domain = new ClienteBuilder()
                .WithBairro(request.Bairro)
                .WithCidade(request.Cidade)
                .WithCpf(request.Cpf)
                .WithNome(request.Nome)
                .WithObservacoes(request.Observacoes)
                .WithRua(request.Rua)
                .Build();

            if (!domain.IsValid())
                return Task.FromResult(false);

            _clienteForCommandRepository.Add(domain);
            // Aqui vou ter que ver como retornar o id inserido

            _clienteForQueryRepository.AddAsync(null);

            return Task.FromResult(true);
        }
    }
}