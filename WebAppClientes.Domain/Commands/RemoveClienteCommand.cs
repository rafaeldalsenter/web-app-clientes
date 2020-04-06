using MediatR;

namespace WebAppClientes.Domain.Commands
{
    public class RemoveClienteCommand : IRequest<bool>
    {
        public int Id { get; private set; }

        public RemoveClienteCommand(int id)
        {
            Id = id;
        }
    }
}