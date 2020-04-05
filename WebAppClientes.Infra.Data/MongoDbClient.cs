using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Linq;
using WebAppClientes.Domain;

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

        public IQueryable<T> Get<T>() where T : BaseDomain
            => GetCollection<T>().AsQueryable();

        public void InsertOne<T>(T obj) where T : BaseDomain
            => GetCollection<T>().InsertOne(obj);

        public void ReplaceOne<T>(int id, T obj) where T : BaseDomain
            => GetCollection<T>().ReplaceOne(x => x.Id.Equals(id), obj);

        public void DeleteOne<T>(int id) where T : BaseDomain
            => GetCollection<T>().DeleteOne(x => x.Id.Equals(id));
    }
}