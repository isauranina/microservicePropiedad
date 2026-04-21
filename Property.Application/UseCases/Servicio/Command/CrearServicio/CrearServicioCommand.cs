using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.UseCases.Servicio.Command.CrearServicio
{
    public class CrearServicioCommand : IRequest<Guid>
    {
        public string? Descripcion { get; set; }
    }
}
