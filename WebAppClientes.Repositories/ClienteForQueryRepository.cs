using System.Collections.Generic;
using System.Linq;
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

        public void Add(ClienteDto cliente)
            => _mongoDbClient.InsertOne(cliente);

        public void Delete(int id)
            => _mongoDbClient.DeleteOne<ClienteDto>(id);

        public IEnumerable<ClienteDto> Get()
            => _mongoDbClient.Get<ClienteDto>().ToList();

        public ClienteDto GetById(int id)
            => _mongoDbClient.Get<ClienteDto>().FirstOrDefault(x => x.Id.Equals(id));

        public void Update(ClienteDto cliente)
            => _mongoDbClient.ReplaceOne(cliente);
    }
}