using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAppClientes.Infra.CrossCutting;
using WebAppClientes.Infra.CrossCutting.AutoMapper;
using WebAppClientes.Infra.CrossCutting.Ioc;
using WebAppClientes.Infra.Data;

namespace WebAppClientes.Ui.Web
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IHostEnvironment env)
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();

            services.AddMediatR(typeof(Startup));

            services.RegisterMappers();

            IocBootstrapper.RegisterServices(services, _configuration);
        }

        public void MigrateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            using (var context = serviceScope.ServiceProvider.GetService<DatabaseContext>())
                context.Database.Migrate();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            MigrateDatabase(app);

            app.UseRouting();

            app.UseHealthChecks("/check");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}