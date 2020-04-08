using System.Threading.Tasks;
using WebAppClientes.Infra.CrossCutting.Dtos;

namespace WebAppClientes.Services
{
    public interface IClienteServices
    {
        Task<CommandReturnDto> Add(ClienteDto dto);

        Task<CommandReturnDto> Delete(int id);

        Task<CommandReturnDto> Update(ClienteDto dto);

        ClienteDto GetById(int id);
    }
}