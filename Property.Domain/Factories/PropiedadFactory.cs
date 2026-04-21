using Property.Domain.Model.Propiedades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Factories
{
    public class PropiedadFactory : IPropiedadFactory
    {
        public Propiedad Create(string descripcion, string direccion, bool esVerificado, TipoPropiedad tipo)
        {
            return new  Propiedad(descripcion, direccion, esVerificado,tipo);                
        }
    }
}
