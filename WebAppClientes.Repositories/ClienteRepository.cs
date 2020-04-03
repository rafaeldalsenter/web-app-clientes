using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAppClientes.Domain;
using WebAppClientes.Infra.Data;

namespace WebAppClientes.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly DatabaseContext _context;

        public ClienteRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(Cliente cliente) => _context.Clientes.Add(cliente);

        public IEnumerable<Cliente> Get() => _context.Clientes.AsNoTracking().ToList();

        public Cliente GetById(Guid id) => _context.Clientes.AsNoTracking().FirstOrDefault(x => x.Id.Equals(id));

        public Cliente GetByName(string name) => _context.Clientes.AsNoTracking().FirstOrDefault(x => x.Nome.Equals(name));

        public void SaveChanges() => _context.SaveChanges();

        public void Update(Cliente cliente) => _context.Set<Cliente>().Update(cliente);
    }
}