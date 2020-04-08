using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebAppClientes.Domain.Builders;
using WebAppClientes.Domain.Commands;
using WebAppClientes.Domain.Interfaces;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Domain.Handlers
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, CommandReturnDto>
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

        private CommandReturnDto MapDto(Cliente cliente) => _mapper.Map<CommandReturnDto>(cliente);

        public Task<CommandReturnDto> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
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
                return Task.FromResult(MapDto(cliente));

            try
            {
                _clienteForCommandRepository.Add(cliente);

                _clienteForQueryRepository.Add(_mapper.Map<ClienteDto>(cliente));

                return Task.FromResult(MapDto(cliente));
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