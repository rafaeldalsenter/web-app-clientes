using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;
using WebAppClientes.Domain;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Infra.Data
{
    public class MongoDbClient : IMongoDbClient
    {
        private readonly IMongoDatabase _mongoDatabase;

        public MongoDbClient(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoConnection"));
            _mongoDatabase = client.GetDatabase("webappclientes");
        }

        private IMongoCollection<T> GetCollection<T>()
            => _mongoDatabase.GetCollection<T>(nameof(T));

        public IQueryable<T> Get<T>() where T : BaseDto
            => GetCollection<T>().AsQueryable();

        public Task InsertOneAsync<T>(T obj) where T : BaseDto
            => GetCollection<T>().InsertOneAsync(obj);

        public Task ReplaceOneAsync<T>(T obj) where T : BaseDto
            => GetCollection<T>().ReplaceOneAsync(x => x.Id.Equals(obj.Id), obj);

        public Task DeleteOneAsync<T>(int id) where T : BaseDto
            => GetCollection<T>().DeleteOneAsync(x => x.Id.Equals(id));
    }
}