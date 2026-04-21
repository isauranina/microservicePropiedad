using MediatR;
using Property.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Property.Domain.Model.Propiedades
{
    public class ValidarPropiedadHandler : IRequestHandler<ValidarPropiedadCommand, Guid>
    {
        private readonly IPropiedadRepository _propiedadRepository;

        public ValidarPropiedadHandler(IPropiedadRepository propiedadRepository)
        {
            _propiedadRepository = propiedadRepository;
        }

        public async Task<Guid> Handle(ValidarPropiedadCommand request, CancellationToken cancellationToken)
        {
            // Buscamos la entidad (Nota: verifica si tu método se llama FindByIdAsync o GetByIdAsync en SharedKernel)
            var propiedad = await _propiedadRepository.FindByIdAsync(request.PropiedadId);
            if (propiedad == null)
            {
                throw new Exception($"La propiedad con id {request.PropiedadId} no fue encontrada.");
            }

            // Ejecutamos la lógica de negocio en la capa de Dominio
            propiedad.ValidarPropiedad();

            // Guardamos el cambio de estado (EsVerificado = true)
            await _propiedadRepository.UpdateAsync(propiedad);

            return propiedad.Id;
        }
    }
}