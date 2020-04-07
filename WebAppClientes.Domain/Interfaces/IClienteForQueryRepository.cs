using System.Collections.Generic;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Domain.Interfaces
{
    public interface IClienteForQueryRepository
    {
        IEnumerable<ClienteDto> Get();

        ClienteDto GetById(int id);

        void Add(ClienteDto cliente);

        void Update(ClienteDto cliente);

        void Delete(int id);
    }
}