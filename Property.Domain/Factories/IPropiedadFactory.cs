using Property.Domain.Model.Propiedades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Domain.Factories
{
    public interface IPropiedadFactory
    {

        Propiedad Create(string descripcion, string direccion, bool EsVerificado, TipoPropiedad tipo);
        
    }
}
