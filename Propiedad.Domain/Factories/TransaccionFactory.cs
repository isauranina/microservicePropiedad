using  Propiedad.Domain.Model.Transaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Domain.Factories
{
    public class TransaccionFactory : ITransaccionFactory
    {
        public Transaccion CrearTransaccionIngreso()
        {
            return new Transaccion(TipoTransaccion.Ingreso);
        }

        public Transaccion CrearTransaccionSalida()
        {
            return new Transaccion(TipoTransaccion.Salida);
        }
    }
}
