using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using WebAppClientes.Domain.Builders;
using WebAppClientes.Domain.Commands;
using WebAppClientes.Domain.Interfaces;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Domain.Handlers
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, bool>
    {
        private readonly IClienteForCommandRepository _clienteForCommandRepository;
        private readonly IClienteForQueryRepository _clienteForQueryRepository;
        private readonly IMapper _mapper;

        public CreateClienteCommandHandler(IMapper mapper,
            IClienteForCommandRepository clienteForCommandRepository,
            IClienteForQueryRepository clienteForQueryRepository)
        {
            _mapper = mapper;
            _clienteForCommandRepository = clienteForCommandRepository;
            _clienteForQueryRepository = clienteForQueryRepository;
        }

        public Task<bool> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new ClienteBuilder()
                .WithBairro(request.Bairro)
                .WithCidade(request.Cidade)
                .WithCpf(request.Cpf)
                .WithNome(request.Nome)
                .WithObservacoes(request.Observacoes)
                .WithRua(request.Rua)
                .Build();

            if (!cliente.IsValid())
                return Task.FromResult(false);

            _clienteForCommandRepository.Add(cliente);
            // TODO Aqui vou ter que ver como retornar o id inserido

            _clienteForQueryRepository.Add(_mapper.Map<ClienteDto>(cliente));

            return Task.FromResult(true);
        }
    }
}