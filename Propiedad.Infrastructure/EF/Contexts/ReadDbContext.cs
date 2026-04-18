using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using  Propiedad.Domain.Events;
using  Propiedad.Domain.Model.Transaciones;
using  Propiedad.Infrastructure.EF.ReadModel;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Infrastructure.EF.Contexts;

internal class ReadDbContext : DbContext
{
    public virtual DbSet<ItemReadModel> Item { set; get; }
    public virtual DbSet<TransaccionReadModel> Transaccion { set; get; }

    public virtual DbSet<TransaccionItemReadModel> TransactionItem { set; get; }
    //public virtual DbSet<PaisReadModel> Pais { set; get; }
    //public virtual DbSet<CiudadReadModel> Ciudad { set; get; }
    //public virtual DbSet<TipoPropiedadReadModel> TipoPropiedad { set; get; }
    public virtual DbSet<ServicioReadModel> Servicio { set; get; }
    public virtual DbSet<PropiedadReadModel> Propiedad { set; get; }
    //public virtual DbSet<PropiedadReadModel> Propiedad { set; get; }
    //public virtual DbSet<ReglasReadModel> Regla { set; get; }
    //public virtual DbSet<DetalleServicioReadModel> DetalleServicio { set; get; }
    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        
    }
}
