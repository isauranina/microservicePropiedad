using Microsoft.EntityFrameworkCore;
using  Propiedad.Domain.Events;
using  Propiedad.Domain.Model.Items;
using Propiedad.Domain.Model.Propiedades;
using Propiedad.Domain.Model.Servicio;
using  Propiedad.Domain.Model.Transaciones;
using  Propiedad.Infrastructure.EF.Config;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Infrastructure.EF.Contexts
{
    internal class WriteDbContext : DbContext
    {
        public virtual DbSet<Item> Item { set; get; }
        public virtual DbSet<Transaccion> Transaccion { set; get; }
        public virtual DbSet<Servicio> Servicio { set; get; }
        public virtual DbSet<Propiedadd> Propiedad { set; get; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var itemConfig = new ItemConfig();
            modelBuilder.ApplyConfiguration(itemConfig);

            var transaccionConfig = new TransaccionConfig();
            modelBuilder.ApplyConfiguration<Transaccion>(transaccionConfig);
            modelBuilder.ApplyConfiguration<TransaccionItem>(transaccionConfig);

            var servicioConfig = new ServicioConfig();
            modelBuilder.ApplyConfiguration(servicioConfig);

            var propiedadConfig = new PropiedadConfig();
            modelBuilder.ApplyConfiguration(propiedadConfig);


            modelBuilder.Ignore<DomainEvent>();
            modelBuilder.Ignore<TransaccionConfirmada>();
        }
    }
}
