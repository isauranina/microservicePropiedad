using MediatR;
using Property.Application.Dto;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Property.Domain.Repositories;

namespace Property.Application.UseCases.Servicio.Query.GetServicioList
{
    public class GetServicioListHandler : IRequestHandler<GetServicioListQuery, IEnumerable<ServicioDto>>
    {
        private readonly IServicioRepository _servicioRepository;

        public GetServicioListHandler(IServicioRepository servicioRepository)
        {
            _servicioRepository = servicioRepository;
        }

        public async Task<IEnumerable<ServicioDto>> Handle(GetServicioListQuery request, CancellationToken cancellationToken)
        {
            var servicioList = await _servicioRepository.GetAllAsync(request.SearchTerm);

            return servicioList.Select(servicio => new ServicioDto 
            { 
                Id = servicio.Id, 
                Nombre = servicio.Descripcion, 
            });
        }
    }
}