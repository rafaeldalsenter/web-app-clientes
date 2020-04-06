using System.Linq;
using WebAppClientes.Domain;
using WebAppClientes.Domain.Interfaces;
using WebAppClientes.Infra.Data;

namespace WebAppClientes.Repositories
{
    public class ClienteForCommandRepository : IClienteForCommandRepository
    {
        private readonly DatabaseContext _context;

        public ClienteForCommandRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(Cliente cliente) => _context.Clientes.Add(cliente);

        public void Delete(int id) => _context.Clientes.Remove(GetById(id));

        public Cliente GetById(int id)
            => _context.Clientes.FirstOrDefault(x => x.Id.Equals(id));

        public void SaveChanges() => _context.SaveChanges();

        public void Update(Cliente cliente) => _context.Set<Cliente>().Update(cliente);
    }
}