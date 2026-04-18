using MediatR;
using  Propiedad.Domain.Exceptions;
using  Propiedad.Domain.Factories;
using  Propiedad.Domain.Model.Items;
using  Propiedad.Domain.Model.Transaciones;
using  Propiedad.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Application.UseCases.Transacciones.CrearTransaccion
{
    internal class CrearTransaccionHandler : IRequestHandler<CrearTransaccionCommand, Guid>
    {
        private readonly ITransaccionFactory _transaccionFactory;
        private readonly ITransaccionRepository _transaccionRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CrearTransaccionHandler(ITransaccionFactory transaccionFactory, 
            ITransaccionRepository transaccionRepository, 
            IUnitOfWork unitOfWork, 
            IItemRepository itemRepository)
        {
            _transaccionFactory = transaccionFactory;
            _transaccionRepository = transaccionRepository;
            _unitOfWork = unitOfWork;
            _itemRepository = itemRepository;
        }

        public async Task<Guid> Handle(CrearTransaccionCommand request, CancellationToken cancellationToken)
        {
            Transaccion transaccion = request.Tipo == Dto.Transaccion.TipoTransaccion.Salida ?
                _transaccionFactory.CrearTransaccionSalida() :
                _transaccionFactory.CrearTransaccionIngreso();

            foreach (var item in request.Items)
            {
                Item? storedItem = await _itemRepository.FindByIdAsync(item.Id);
                if(storedItem == null)
                {
                    throw new TransactionCreationException("Item con ID: " + item.Id + " no existe" );
                }

                transaccion.AgregarItem(item.Id, item.Cantidad, item.CostoUnitario);
            }

            if (request.CrearYConfirmar)
            {
                transaccion.Confirmar();
            }

            await _transaccionRepository.CreateAsync(transaccion);


            await _unitOfWork.Commit();

            return transaccion.Id;
        }
    }
}
