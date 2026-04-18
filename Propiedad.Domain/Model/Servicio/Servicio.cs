using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Domain.Model.Servicio
{
    public class Servicio : AggregateRoot
    {
        public string Descripcion {get; set;} 
        internal Servicio(string descripcion)
        {
            Id = Guid.NewGuid();
            Descripcion = descripcion;
        }
        public void Edit(string descripcion)
        {
            Descripcion = descripcion;
        }
        private Servicio() { }
    }
}
