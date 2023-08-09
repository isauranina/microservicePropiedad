using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Infrastructure.EF.ReadModel
{
    [Table("ciudad")]
    internal class CiudadReadModel
    {
        [Key]
        [Column("itemId")]
        public Guid Id { get; set; }

        [Column("nombre")]
        [StringLength(250)]
        [Required]
        public string Nombre { get; set; }

        [Required]
        [Column("paisId")]
        public Guid paisId { get; set; }
        public PaisReadModel Pais { get; set; }

    }
}
