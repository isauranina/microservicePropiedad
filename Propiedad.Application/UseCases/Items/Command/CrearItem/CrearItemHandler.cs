﻿using MediatR;
using  Propiedad.Domain.Factories;
using  Propiedad.Domain.Repositories;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Application.UseCases.Items.Command.CrearItem
{
    internal class CrearItemHandler : IRequestHandler<CrearItemCommand, Guid>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IItemFactory _itemFactory;
        private readonly IUnitOfWork _unitOfWork;

        public CrearItemHandler(IItemRepository itemRepository, 
            IItemFactory itemFactory, 
            IUnitOfWork unitOfWork)
        {
            _itemRepository = itemRepository;
            _itemFactory = itemFactory;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CrearItemCommand request, CancellationToken cancellationToken)
        {
            var itemCreado = _itemFactory.Create(request.Nombre, request.Codigo);

            await _itemRepository.CreateAsync(itemCreado);


            await _unitOfWork.Commit();


            return itemCreado.Id;
        }
    }
}
