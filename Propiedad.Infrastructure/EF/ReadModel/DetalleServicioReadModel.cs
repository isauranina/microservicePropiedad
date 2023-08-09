using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Infrastructure.EF.ReadModel
{
    [Table("detalleServicio")]
    internal class DetalleServicioReadModel
    {

        [Key]
        [Column("detalleServicioId")]
        public Guid Id { get; set; }

        [Required]
        [Column("propiedadId")]
        public Guid propiedadId { get; set; }
        public PropiedadReadModel Propiedad { get; set; }


        [Required]
        [Column("servicioId")]
        public Guid servicioId { get; set; }
        public ServicioReadModel Servicio { get; set; }

        [Required]
        [Column("observacion")]
        [MaxLength(500)]
        public string observacion { get; set; }
    }
}
