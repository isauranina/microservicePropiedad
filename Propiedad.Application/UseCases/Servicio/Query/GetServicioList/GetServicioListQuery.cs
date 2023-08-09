using System;
using MediatR;
using Propiedad.Application.Dto.Servicio;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Application.UseCases.Servicio.Query.GetServicioList
{
    internal class GetServicioListQuery: IRequest<ICollection<ServicioDto>>        
    {
        public string SearchTerm { get; set; }
    }
}
