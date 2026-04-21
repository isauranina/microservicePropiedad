using MediatR;
using System.Collections.Generic;

namespace Property.Application.Dto
{
    public class GetPropiedadesQuery : IRequest<IEnumerable<PropiedadDto>>
    {
    }
}