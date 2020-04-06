using System.Linq;
using System.Threading.Tasks;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Infra.Data
{
    public interface IMongoDbClient
    {
        IQueryable<T> Get<T>() where T : BaseDto;

        Task InsertOneAsync<T>(T obj) where T : BaseDto;

        Task ReplaceOneAsync<T>(T obj) where T : BaseDto;

        Task DeleteOneAsync<T>(int id) where T : BaseDto;
    }
}