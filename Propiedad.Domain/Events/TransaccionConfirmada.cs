using MediatR;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Domain.Events
{
    public record TransaccionConfirmada : DomainEvent, INotification
    {
        public Guid TransaccionId { get; init; }
        public ICollection<DetalleTransaccionConfirmada> Detalle { get; init; }
        public TransaccionConfirmada(Guid transaccionId, 
            ICollection<DetalleTransaccionConfirmada> detalle) : base(DateTime.Now)
        {
            TransaccionId = transaccionId;
            Detalle = detalle;
        }

        public record DetalleTransaccionConfirmada(Guid ItemId, int Cantidad, decimal CostoUnitario);

    }
}
