using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppClientes.Domain.Interfaces;
using WebAppClientes.Infra.CrossCutting.Dtos;
using WebAppClientes.Infra.Data;

namespace WebAppClientes.Repositories
{
    public class ClienteForQueryRepository : IClienteForQueryRepository
    {
        private readonly IMongoDbClient _mongoDbClient;

        public ClienteForQueryRepository(IMongoDbClient mongoDbClient)
        {
            _mongoDbClient = mongoDbClient;
        }

        public Task AddAsync(ClienteForQueryDto cliente)
            => _mongoDbClient.InsertOneAsync(cliente);

        public Task DeleteAsync(int id)
            => _mongoDbClient.DeleteOneAsync<ClienteForQueryDto>(id);

        public IEnumerable<ClienteForQueryDto> Get()
            => _mongoDbClient.Get<ClienteForQueryDto>().ToList();

        public ClienteForQueryDto GetById(int id)
            => _mongoDbClient.Get<ClienteForQueryDto>().FirstOrDefault(x => x.Id.Equals(id));

        public Task UpdateAsync(ClienteForQueryDto cliente)
            => _mongoDbClient.ReplaceOneAsync(cliente);
    }
}