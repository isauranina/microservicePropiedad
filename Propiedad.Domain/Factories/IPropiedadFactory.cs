using Propiedad.Domain.Model.Propiedades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Domain.Factories
{
    public interface IPropiedadFactory
    {

        Propiedadd Create(string descripcion, string direccion, bool EsVerificado, TipoPropiedad tipo);
        
    }
}
