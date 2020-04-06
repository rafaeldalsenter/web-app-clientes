using System.Linq;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Infra.Data
{
    public interface IMongoDbClient
    {
        IQueryable<T> Get<T>() where T : BaseDto;

        void InsertOne<T>(T obj) where T : BaseDto;

        void ReplaceOne<T>(T obj) where T : BaseDto;

        void DeleteOne<T>(int id) where T : BaseDto;
    }
}