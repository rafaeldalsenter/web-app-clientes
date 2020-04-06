using System.Collections.Generic;
using System.Threading.Tasks;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Domain.Interfaces
{
    public interface IClienteForQueryRepository
    {
        IEnumerable<ClienteForQueryDto> Get();

        ClienteForQueryDto GetById(int id);

        Task AddAsync(ClienteForQueryDto cliente);

        Task UpdateAsync(ClienteForQueryDto cliente);

        Task DeleteAsync(int id);
    }
}