using System.Collections.Generic;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Repositories
{
    public interface IClienteForQueryRepository
    {
        IEnumerable<ClienteForQueryDto> Get();

        ClienteForQueryDto GetById(int id);

        void Add(ClienteForQueryDto cliente);

        void Update(ClienteForQueryDto cliente);

        void Delete(int id);
    }
}