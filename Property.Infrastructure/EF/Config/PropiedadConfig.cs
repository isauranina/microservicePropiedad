﻿﻿﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Property.Domain.Model.Propiedades;
using Property.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropiedadEntity = Property.Domain.Model.Propiedades.Propiedad;

namespace Property.Infrastructure.EF.Config;

    internal class PropiedadConfig: IEntityTypeConfiguration<PropiedadEntity>
    {     

        public void Configure(EntityTypeBuilder<PropiedadEntity> builder)
        {
            builder.ToTable("propiedad");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Id)
                .HasColumnName("propiedadId");

            builder.OwnsOne(x => x.Descripcion, descripcionBuilder =>
            {
                descripcionBuilder.Property(y => y.Value)
                    .HasColumnName("descripcion")
                    .HasMaxLength(500)
                    .IsRequired();
            });

            builder.OwnsOne(x => x.Direccion, direccionBuilder =>
            {
                direccionBuilder.Property(y => y.Value)
                    .HasColumnName("direccion")
                    .IsRequired();
            });


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
