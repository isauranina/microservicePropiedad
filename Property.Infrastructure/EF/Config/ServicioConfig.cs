using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Property.Domain.Model.Servicio;
using Property.Domain.ValueObjects;

namespace Property.Infrastructure.EF.Config
{
    internal class ServicioConfig : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> builder)
        {
            builder.ToTable("servicio");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
           .HasColumnName("ServicioId");


            builder.Property(x => x.Descripcion)
                .HasColumnName("descripcion");
        }
    }
}