using MediatR;
using Property.Application.Dto.Propiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.UseCases.Propiedad.Command.CrearPropiedad
{
    public class CrearPropiedadCommand : IRequest<Guid>
    {
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public bool EsVerificado { get; set; }
        public TipoPropiedad Tipo { get; set; }
    }
}
