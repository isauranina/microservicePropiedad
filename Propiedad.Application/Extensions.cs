using Microsoft.Extensions.DependencyInjection;
using  Propiedad.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Application
{
    public static class Extensions
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddSingleton<IItemFactory, ItemFactory>();
            services.AddSingleton<ITransaccionFactory, TransaccionFactory>();
            services.AddSingleton<IServicioFactory, ServicioFactory>();
            services.AddSingleton<IPropiedadFactory, PropiedadFactory>();
           
            return services;
        }
    }
}
