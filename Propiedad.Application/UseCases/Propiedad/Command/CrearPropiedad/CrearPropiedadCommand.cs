using MediatR;
using Propiedad.Application.Dto.Propiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Application.UseCases.Propiedad.Command.CrearPropiedad
{
    public class CrearPropiedadCommand : IRequest<Guid>
    {
        public string Descripcion { get; set; }
        public string Direccion { get; set; }
        public bool EsVerificado { get; set; }
        public TipoPropiedad Tipo { get; set; }
    }
}
