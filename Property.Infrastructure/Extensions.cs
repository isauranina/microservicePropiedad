using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Property.SharedKernel.Core;
using System.Reflection;
using Property.Application;
using Property.Domain.Repositories;
using Property.Infrastructure.EF;
using Property.Infrastructure.EF.Contexts;
using Property.Infrastructure.EF.Repositories;

namespace Property.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, bool isDevelopment)
        {
            services.AddApplication();
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            AddDatabase(services, configuration, isDevelopment);
            
            return services;
        }


        private static void AddDatabase(IServiceCollection services, IConfiguration configuration, bool isDevelopment)
        {
            var connectionString =
                    configuration.GetConnectionString("PropiedadDbConnectionString");
            services.AddDbContext<ReadDbContext>(context =>
                    context.UseSqlServer(connectionString));
            services.AddDbContext<WriteDbContext>(context =>
                context.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IServicioRepository, ServicioRepository>();            
            services.AddScoped<IPropiedadRepository, PropiedadRepository>();

            using var scope = services.BuildServiceProvider().CreateScope();
            if (!isDevelopment)
            {
                var context = scope.ServiceProvider.GetRequiredService<ReadDbContext>();
                context.Database.Migrate();
            }
        }
    }
}