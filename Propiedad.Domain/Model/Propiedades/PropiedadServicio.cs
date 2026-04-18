using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Domain.Model.Propiedades
{
    public class PropiedadServicio: Entity
    {
        public Guid ServicioId { get; private set; }
        public string Observacion { get; set; }

        internal PropiedadServicio(Guid servicioId, string observacion)
        {
            Id = Guid.NewGuid();
            ServicioId = servicioId;
            Observacion = observacion;
        }
        private PropiedadServicio() { }  
    }
}
