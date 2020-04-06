using WebAppClientes.Domain;

namespace WebAppClientes.Domain.Interfaces
{
    public interface IClienteForCommandRepository
    {
        Cliente GetById(int id);

        void Add(Cliente cliente);

        void Update(Cliente cliente);

        void Delete(int id);

        void SaveChanges();
    }
}