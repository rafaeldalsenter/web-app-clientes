using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAppClientes.Infra.Data;
using WebAppClientes.Repositories;
using WebAppClientes.Services;

namespace WebAppClientes.Infra.CrossCutting.Ioc
{
    public class IocBootstrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IClienteServices, ClienteServices>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
        }
    }
}