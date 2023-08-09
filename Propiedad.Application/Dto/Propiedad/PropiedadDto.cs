using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Application.Dto.Propiedad
{
    public class PropiedadDto
    {
        public Guid PropiedadId { get; set; }
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public bool EsVerificado { get; set; }
        public TipoPropiedad Tipo { get; set; }
    }
}
