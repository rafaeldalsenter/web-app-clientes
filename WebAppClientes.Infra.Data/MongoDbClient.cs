using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Linq;
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

        public void InsertOne<T>(T obj) where T : BaseDto
            => GetCollection<T>().InsertOne(obj);

        public void ReplaceOne<T>(T obj) where T : BaseDto
            => GetCollection<T>().ReplaceOne(x => x.Id.Equals(obj.Id), obj);

        public void DeleteOne<T>(int id) where T : BaseDto
            => GetCollection<T>().DeleteOne(x => x.Id.Equals(id));
    }
}