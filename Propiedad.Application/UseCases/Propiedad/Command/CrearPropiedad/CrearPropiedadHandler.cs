using MediatR;
using Propiedad.Domain.Factories;
using Propiedad.Domain.Repositories;
using Restaurant.SharedKernel.Core;


namespace Propiedad.Application.UseCases.Propiedad.Command.CrearPropiedad
{
    internal class CrearPropiedadHandler : IRequestHandler<CrearPropiedadCommand, Guid>
    {
        private readonly IPropiedadRepository _propiedadRepository;
        private readonly IPropiedadFactory _propiedadFactory;
        private readonly IUnitOfWork _unitOfWork;
        public CrearPropiedadHandler(IPropiedadRepository propiedadRepository, IPropiedadFactory propiedadFactory, IUnitOfWork unitOfWork)
        {
            _propiedadRepository = propiedadRepository;
            _propiedadFactory = propiedadFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearPropiedadCommand request, CancellationToken cancellationToken)
        {
            var propiedadCreado = _propiedadFactory.Create(request.Descripcion, request.Direccion, request.EsVerificado, (Domain.Model.Propiedades.TipoPropiedad)request.Tipo);
            await _propiedadRepository.CreateAsync(propiedadCreado);
            await _unitOfWork.Commit();
            return propiedadCreado.Id;
            
        }
    }
}
