using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Infrastructure.EF.ReadModel
{
    [Table("propiedad")]
    internal class PropiedadReadModel
    {

        [Key]
        [Column("propiedadItemId")]
        public Guid Id { get; set; }


        [Required]
        [Column("descripcion")]
        [MaxLength(500)]
        public string descripcion { get; set; }

        [Required]
        [Column("direccion")]
        [MaxLength(500)]
        public string direccion { get; set; }

        [Required]
        [Column("fueVerificado")]     
        public bool fueVerificado { get; set; }

        [Required]
        [Column("tipoPropiedadId")]
        public Guid tipoPropiedadId { get; set; }
        public TipoPropiedadReadModel TipoPropiedad { get; set; }

        [Required]
        [Column("ciudadId")]
        public Guid ciudadId { get; set; }
        public CiudadReadModel Ciudad { get; set; }

    }
}
