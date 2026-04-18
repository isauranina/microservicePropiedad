using MediatR;
using Propiedad.Domain.Factories;
using Propiedad.Domain.Model.Propiedades;
using Propiedad.Domain.Model.Transaciones;
using Propiedad.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Application.UseCases.PropiedadServicio.CrearServicio
{
    internal class CrearPropiedadServicioHandler: IRequestHandler<CrearPropiedadServicioCommand,Guid>
    {
        private readonly IPropiedadFactory _propiedadFactory;
        private readonly IPropiedadRepository _propiedadRepository;
        private readonly IServicioRepository _servicioRepository;
        private readonly IUnitOfWork _unitOfWork;
        private Guid ID;

        public CrearPropiedadServicioHandler (IPropiedadFactory propiedadFactory, 
            IPropiedadRepository propiedadRepository, 
            IServicioRepository servicioRepository, 
            IUnitOfWork unitOfWork)
        {
            _propiedadFactory = propiedadFactory;
            _propiedadRepository = propiedadRepository;
            _servicioRepository = servicioRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CrearPropiedadServicioCommand request, CancellationToken cancellationToken) 
        {
            //Propiedadd propiedad= request.des
            return ID;
        }
    }
}
