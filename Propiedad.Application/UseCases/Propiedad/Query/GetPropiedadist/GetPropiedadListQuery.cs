using MediatR;
using Propiedad.Application.Dto.Propiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Application.UseCases.Propiedad.Query.GetPropiedadist
{
    public class GetPropiedadListQuery: IRequest<ICollection<PropiedadDto>>
    {
        public string SearchTerm { get; set; }
    }
}
