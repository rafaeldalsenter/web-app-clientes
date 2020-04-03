using System;
using System.Collections.Generic;
using WebAppClientes.Domain;

namespace WebAppClientes.Repositories
{
    public interface IClienteRepository
    {
        Cliente GetById(Guid id);

        IEnumerable<Cliente> Get();

        void Add(Cliente cliente);

        void Update(Cliente cliente);

        void SaveChanges();
    }
}