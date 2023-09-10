
using Moq;
using Propiedad.Application.UseCases.Items.EventHandlers;
using Propiedad.Domain.Events;
using Propiedad.Domain.Exceptions;
using Propiedad.Domain.Model.Items;
using Propiedad.Domain.Repositories;
using Restaurant.SharedKernel.Core;

namespace Propiedad.Test.Application.UseCases.Items.EventHandler

{
    public class ActualizarInventarioWhenTransaccionConfirmada_IntTest
    {
        Mock<IItemRepository> _itemRepository;
        Mock<IUnitOfWork> _unitOfWork;
        public ActualizarInventarioWhenTransaccionConfirmada_IntTest()
        {
            _itemRepository = new Mock<IItemRepository>();
            _unitOfWork = new Mock<IUnitOfWork>();
        }
        [Fact]
        public void ActualizacionValidaStock()
        {
            var items = ItemMockFactory.getItems();
            var item = items[0];
            var item2 = items[1];
            var item3 = items[2];


            int valorEsperado1 = 10;
            int valorEsperado2 = 20;
            int valorEsperado3 = 30;
            Guid transaccionId = Guid.NewGuid();

            var detalleTransaccion = new List<TransaccionConfirmada.DetalleTransaccionConfirmada>
                {
                    new TransaccionConfirmada.DetalleTransaccionConfirmada(item.Id,valorEsperado1,10),
                    new TransaccionConfirmada.DetalleTransaccionConfirmada(item2.Id,valorEsperado2,20),
                    new TransaccionConfirmada.DetalleTransaccionConfirmada(item3.Id,valorEsperado3,30)
                };
            var itemRepository = ItemMockFactory.getRepositoryImplementation();

            var handler = new ActualizarInventarioWhenTransaccionConfirmada(
                itemRepository,
                _unitOfWork.Object
                );

            var tcs = new CancellationTokenSource(1000);

            TransaccionConfirmada evento = new TransaccionConfirmada(
                transaccionId,
                detalleTransaccion
                );
            handler.Handle(evento, tcs.Token);

            Assert.Equal(valorEsperado1, item.Stock);
            Assert.Equal(valorEsperado2, item2.Stock);
            Assert.Equal(valorEsperado3, item3.Stock);
        }
        [Fact]
        public  void ActualizacionStockMultiple()
        {
            var itemRepository= ItemMockFactory.getRepositoryImplementation();

           
            var items = itemRepository.GetAllItems().Result;
           
            var item = items.ElementAt(0);


            int valorEsperado1 = 30;


            Guid transaccionId = Guid.NewGuid();
            var detalleTransaccion1 = new List<TransaccionConfirmada.DetalleTransaccionConfirmada>
            {
                new TransaccionConfirmada.DetalleTransaccionConfirmada(item.Id,10,10)
            };
            var detalleTransaccion2 = new List<TransaccionConfirmada.DetalleTransaccionConfirmada>
            {
                new TransaccionConfirmada.DetalleTransaccionConfirmada(item.Id,20,10)
            };
           


            var handler = new ActualizarInventarioWhenTransaccionConfirmada(
                _itemRepository.Object,
                _unitOfWork.Object
                );
            var tcs = new CancellationTokenSource(1000);

            TransaccionConfirmada evento1 = new TransaccionConfirmada(
                transaccionId,
                detalleTransaccion1
                );
            handler.Handle(evento1, tcs.Token);

            TransaccionConfirmada evento2 = new TransaccionConfirmada(
               transaccionId,
               detalleTransaccion2
               );
            handler.Handle(evento2, tcs.Token);


            var itemResultado= itemRepository.GetItemById(item.Id).Result; 
            Assert.Equal(valorEsperado1, itemResultado.Stock);
        }
        [Fact]
        public void ItemNoEncontrado()
        {


            Guid transaccionId = Guid.NewGuid();
            Guid itemId = Guid.NewGuid();

            var detalleTransaccion = new List<TransaccionConfirmada.DetalleTransaccionConfirmada>
            {
                new TransaccionConfirmada.DetalleTransaccionConfirmada(itemId,10,10)
            };

            Item? item = null;
            var itemRepository = ItemMockFactory.getRepositoryImplementation();




            var handler = new ActualizarInventarioWhenTransaccionConfirmada(
                _itemRepository.Object,
                _unitOfWork.Object
                );
            var tcs = new CancellationTokenSource(1000);

            TransaccionConfirmada evento = new TransaccionConfirmada(
                transaccionId,
                detalleTransaccion
                );

            Assert.ThrowsAsync<TransactionCreationException>(() => handler.Handle(evento, tcs.Token));
        }
    }
}
