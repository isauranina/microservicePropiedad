using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Infrastructure.EF.ReadModel

{
    [Table("tipoPropiedad")]
    internal class TipoPropiedadReadModel
    {
        [Key]
        [Column("tipoPropiedadId")]
        public Guid Id { get; set; }

        [Column("descripcion")]
        [StringLength(500)]
        [Required]
        public string descripcion { get; set; }
    }
}
