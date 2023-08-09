using MediatR;
using Propiedad.Domain.Factories;
using Propiedad.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.SharedKernel.Core;

namespace Propiedad.Application.UseCases.Servicio.Command.CrearServicio
{
    internal class CrearServicioHandler : IRequestHandler<CrearServicioCommand, Guid>
    {
        private readonly IServicioRepository _servicioRepository;
        private readonly IServicioFactory _servicioFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearServicioHandler(IServicioRepository servicioRepository,
            IServicioFactory servicioFactory,
            IUnitOfWork unitOfWork)
        {
            _servicioRepository = servicioRepository;
            _servicioFactory = servicioFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearServicioCommand request, CancellationToken cancellationToken)
        {
            var servicioCreado = _servicioFactory.Create(request.Descripcion);
            await _servicioRepository.CreateAsync(servicioCreado);
            await _unitOfWork.Commit();
            return servicioCreado.Id;
        }


    }
}
