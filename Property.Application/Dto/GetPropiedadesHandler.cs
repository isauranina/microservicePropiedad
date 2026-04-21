using MediatR;
using Property.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Property.Application.Dto
{
    public class GetPropiedadesHandler : IRequestHandler<GetPropiedadesQuery, IEnumerable<PropiedadDto>>
    {
        private readonly IPropiedadRepository _repository;

        public GetPropiedadesHandler(IPropiedadRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PropiedadDto>> Handle(GetPropiedadesQuery request, CancellationToken cancellationToken)
        {
            var propiedades = await _repository.GetAllAsync();

            return propiedades.Select(p => new PropiedadDto
            {
                Id = p.Id,
                Descripcion = p.Descripcion,
                Direccion = p.Direccion,
                EsVerificado = p.EsVerificado,
                Tipo = p.Tipo.ToString()
            });
        }
    }
}