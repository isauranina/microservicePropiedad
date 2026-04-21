using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Property.Infrastructure.EF.ReadModel;
using Property.Domain.Events;
using Property.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Infrastructure.EF.Contexts;

internal class ReadDbContext : DbContext
{
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
