using MediatR;
using Propiedad.Application.Dto.Transaccion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Application.UseCases.Transacciones.CrearTransaccion
{
    public class CrearTransaccionCommand : IRequest<Guid>
    {
        public List<ItemDetalleTransaccionDto> Items { get; set; }
        public TipoTransaccion Tipo { get; set; }

        public bool CrearYConfirmar { get; set; }

        public CrearTransaccionCommand(List<ItemDetalleTransaccionDto> articulos, TipoTransaccion tipo)
        {
            Items = articulos;
            Tipo = tipo;
        }

        public CrearTransaccionCommand(List<ItemDetalleTransaccionDto> articulos, TipoTransaccion tipo, bool crearYConfirmar) : this(articulos, tipo)
        {
            CrearYConfirmar = crearYConfirmar;
        }

        public CrearTransaccionCommand() { }
    }
}
