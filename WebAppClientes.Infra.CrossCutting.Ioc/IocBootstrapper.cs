using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAppClientes.Domain.Commands;
using WebAppClientes.Domain.Handlers;
using WebAppClientes.Domain.Interfaces;
using WebAppClientes.Infra.CrossCutting.Dtos;
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

            services.AddScoped<IMongoDbClient, MongoDbClient>();
            services.AddScoped<IClienteServices, ClienteServices>();
            services.AddScoped<IClienteForCommandRepository, ClienteForCommandRepository>();
            services.AddScoped<IClienteForQueryRepository, ClienteForQueryRepository>();

            services.AddScoped<IRequestHandler<CreateClienteCommand, CommandReturnDto>, CreateClienteCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveClienteCommand, CommandReturnDto>, RemoveClienteCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateClienteCommand, CommandReturnDto>, UpdateClienteCommandHandler>();
        }
    }
}