using System.Threading.Tasks;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Services
{
    public interface IClienteServices
    {
        Task Add(ClienteDto dto);

        Task Delete(int id);

        Task Update(ClienteDto dto);

        ClienteDto GetById(int id);
    }
}