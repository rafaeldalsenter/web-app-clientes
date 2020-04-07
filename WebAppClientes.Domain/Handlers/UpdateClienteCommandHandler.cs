using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebAppClientes.Domain.Commands;
using WebAppClientes.Domain.Interfaces;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Domain.Handlers
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, bool>
    {
        private readonly IClienteForCommandRepository _clienteForCommandRepository;
        private readonly IClienteForQueryRepository _clienteForQueryRepository;
        private readonly IMapper _mapper;

        public UpdateClienteCommandHandler(IMapper mapper,
            IClienteForCommandRepository clienteForCommandRepository,
            IClienteForQueryRepository clienteForQueryRepository)
        {
            _mapper = mapper;
            _clienteForCommandRepository = clienteForCommandRepository;
            _clienteForQueryRepository = clienteForQueryRepository;
        }

        public Task<bool> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = _clienteForCommandRepository.GetById(request.Id);
            cliente.SetBairro(request.Bairro);
            cliente.SetCidade(request.Cidade);
            cliente.SetCpf(request.Cpf);
            cliente.SetNome(request.Nome);
            cliente.SetObservacoes(request.Observacoes);
            cliente.SetRua(request.Rua);

            if (!cliente.IsValid())
                return Task.FromResult(false);

            _clienteForCommandRepository.Update(cliente);

            _clienteForQueryRepository.Update(_mapper.Map<ClienteDto>(cliente));

            return Task.FromResult(true);
        }
    }
}