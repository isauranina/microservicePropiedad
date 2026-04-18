using  Propiedad.Domain.Model.Transaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Domain.Factories
{
    public interface ITransaccionFactory
    {
        Transaccion CrearTransaccionIngreso();
        Transaccion CrearTransaccionSalida();
    }
}
