using MediatR;
using System;

namespace Property.Domain.Model.Propiedades
{
    public class ValidarPropiedadCommand : IRequest<Guid>
    {
        public Guid PropiedadId { get; set; }
    }
}