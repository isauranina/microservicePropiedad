using MediatR;
using Property.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Events
{
    public record ValidarPropiedad: DomainEvent
    {
        public Guid PropiedadId { get; set; }
        public bool esValidado { get; set; }
        public ValidarPropiedad(Guid propiedadId,bool esValido): base(DateTime.Now)
        {
            PropiedadId= propiedadId;
            esValidado= esValido;
        }
    }
}
