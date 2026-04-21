using Microsoft.EntityFrameworkCore;
using Property.Domain.Events;
using Property.Domain.Model.Servicio;
using PropertyModel = Property.Domain.Model.Propiedades.Propiedad;
using Property.Infrastructure.EF.Config;
using Property.SharedKernel.Core;


namespace Property.Infrastructure.EF.Contexts
{
    internal class WriteDbContext : DbContext
    {
        public virtual DbSet<Servicio> Servicio { set; get; }
        public virtual DbSet<PropertyModel> Propiedad { set; get; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            var servicioConfig = new ServicioConfig();
            modelBuilder.ApplyConfiguration(servicioConfig);

            var propiedadConfig = new PropiedadConfig();
            modelBuilder.ApplyConfiguration(propiedadConfig);


            modelBuilder.Ignore<DomainEvent>();
        }
    }
}
