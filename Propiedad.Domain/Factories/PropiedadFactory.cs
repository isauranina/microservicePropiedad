using Propiedad.Domain.Model.Propiedades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Domain.Factories
{
    public class PropiedadFactory : IPropiedadFactory
    {
        public Propiedadd Create(string descripcion, string direccion, bool esVerificado, TipoPropiedad tipo)
        {
            return new  Propiedadd(descripcion, direccion, esVerificado,tipo);                
        }
    }
}
