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

        public void Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Clientes.Remove(GetById(id));
            _context.SaveChanges();
        }

        public Cliente GetById(int id)
            => _context.Clientes.FirstOrDefault(x => x.Id.Equals(id));

        public void Update(Cliente cliente)
        {
            _context.Set<Cliente>().Update(cliente);
            _context.SaveChanges();
        }
    }
}