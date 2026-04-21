using MediatR;
using Property.Application.Dto.Propiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.UseCases.Propiedad.Query.GetPropiedadist
{
    public class GetPropiedadListQuery: IRequest<ICollection<PropiedadDto>>
    {
        public string SearchTerm { get; set; }
    }
}
