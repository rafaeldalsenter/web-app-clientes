using MediatR;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Domain.Commands
{
    public class RemoveClienteCommand : IRequest<CommandReturnDto>
    {
        public int Id { get; private set; }

        public RemoveClienteCommand(int id)
        {
            Id = id;
        }
    }
}