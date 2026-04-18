using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Infrastructure.EF.ReadModel
{

    [Table("pais")]
    internal class PaisReadModel
    {
        [Key]
        [Column("paisId")]
        public Guid Id { get; set; }

        [Column("nombre")]
        [StringLength(250)]
        [Required]
        public string Nombre { get; set; }
    }
}
