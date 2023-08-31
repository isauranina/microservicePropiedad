using MediatR;
using  Propiedad.Domain.Events;
using  Propiedad.Domain.Exceptions;
using  Propiedad.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Application.UseCases.Items.EventHandlers;

public class ActualizarInventarioWhenTransaccionConfirmada
    : INotificationHandler<TransaccionConfirmada>
{
    private readonly IItemRepository _itemRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ActualizarInventarioWhenTransaccionConfirmada(IItemRepository itemRepository, 
        IUnitOfWork unitOfWork)
    {
        _itemRepository = itemRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(TransaccionConfirmada evento, CancellationToken cancellationToken)
    {
        foreach (var item in evento.Detalle)
        {
            var storedItem = await _itemRepository.FindByIdAsync(item.ItemId);
            if (storedItem == null)
            {
                throw new TransactionCreationException("Item con ID: " + item.ItemId + " no existe");
            }

            storedItem.ActualizarStockYCostoPromedio(item.Cantidad, item.CostoUnitario);

        }

        await _unitOfWork.Commit();


    }
}
