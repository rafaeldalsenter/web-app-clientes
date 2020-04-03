using Microsoft.EntityFrameworkCore;
using WebAppClientes.Domain;

namespace WebAppClientes.Infra.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) :
            base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}