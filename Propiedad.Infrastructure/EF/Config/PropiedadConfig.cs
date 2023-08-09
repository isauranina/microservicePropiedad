using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Propiedad.Domain.Model.Propiedades;
using Propiedad.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Infrastructure.EF.Config;

    internal class PropiedadConfig: IEntityTypeConfiguration<Propiedadd>
    {     

        public void Configure(EntityTypeBuilder<Propiedadd> builder)
        {
            builder.ToTable("propiedad");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id)
                .HasColumnName("propiedadId");

        builder.Property(x => x.Descripcion)          
           .HasColumnName("descripcion");

        builder.Property(x => x.Direccion)
           .HasColumnName("direccion");
    

        builder.Property(x => x.EsVerificado)               
          .HasColumnName("esVerificado");

        var TipoPropiedadConverter= new ValueConverter<TipoPropiedad, string>(
            tipoEnumValue=> tipoEnumValue.ToString(),
            tipo=>(TipoPropiedad) Enum.Parse(typeof(TipoPropiedad),tipo)
            );
        builder.Property(x => x.Tipo)
            .HasConversion(TipoPropiedadConverter)
            .HasColumnName("tipo")
            .HasMaxLength(20)
            .IsRequired();
    }
}

