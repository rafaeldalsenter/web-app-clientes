using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace WebAppClientes.Infra.CrossCutting.AutoMapper
{
    public static class AutoMapperBootstrapper
    {
        public static void RegisterMappers(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }
    }
}