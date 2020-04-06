using System.Collections.Generic;
using System.Linq;
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

        public void Add(ClienteForQueryDto cliente)
            => _mongoDbClient.InsertOne(cliente);

        public void Delete(int id)
            => _mongoDbClient.DeleteOne<ClienteForQueryDto>(id);

        public IEnumerable<ClienteForQueryDto> Get()
            => _mongoDbClient.Get<ClienteForQueryDto>().ToList();

        public ClienteForQueryDto GetById(int id)
            => _mongoDbClient.Get<ClienteForQueryDto>().FirstOrDefault(x => x.Id.Equals(id));

        public void Update(ClienteForQueryDto cliente)
            => _mongoDbClient.ReplaceOne(cliente);
    }
}