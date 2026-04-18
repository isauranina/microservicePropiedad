using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Propiedad.Domain.Model.Items;
using Propiedad.Domain.Model.Servicio;
using Propiedad.Domain.ValueObjects;

namespace Propiedad.Infrastructure.EF.Config
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