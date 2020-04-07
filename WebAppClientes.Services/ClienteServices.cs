using AutoMapper;
using MediatR;
using System.Threading.Tasks;
using WebAppClientes.Domain.Commands;
using WebAppClientes.Domain.Interfaces;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IClienteForQueryRepository _clienteForQueryRepository;

        public ClienteServices(IMediator mediator,
            IMapper mapper,
            IClienteForQueryRepository clienteForQueryRepository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _clienteForQueryRepository = clienteForQueryRepository;
        }

        public async Task Add(ClienteDto dto)
        {
            await _mediator.Send(_mapper.Map<CreateClienteCommand>(dto));
        }

        public async Task Delete(int id)
        {
            await _mediator.Send(new RemoveClienteCommand(id));
        }

        public ClienteDto GetById(int id)
        {
            return _clienteForQueryRepository.GetById(id);
        }

        public async Task Update(ClienteDto dto)
        {
            await _mediator.Send(_mapper.Map<UpdateClienteCommand>(dto));
        }
    }
}