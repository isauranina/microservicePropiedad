using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Property.Domain.Model.Servicio;

namespace Property.Domain.Factories
{
    public class ServicioFactory : IServicioFactory
    {
        public Servicio Create(string descripcion)
        {
            return new Servicio(descripcion);
        }
    }
}
