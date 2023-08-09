using Restaurant.SharedKernel.Core;
using Propiedad.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Propiedad.Domain.Exceptions;
using Propiedad.Domain.Model.Items;

namespace Propiedad.Domain.Model.Propiedades
{
    public class Propiedadd : AggregateRoot
    {
        public string Descripcion { get; private set; }
        public string Direccion { get; private set; }
        public bool EsVerificado { get; set; }

        private readonly ICollection<PropiedadServicio> _servicios;
        public IEnumerable<PropiedadServicio> Servicio => _servicios;

        public TipoPropiedad Tipo { get;private set; }
        public EstadoPropiedad Estado { get; set; }

        internal Propiedadd(string descripcion, string direccion, bool esVerificado, TipoPropiedad tipo)
        {
            Id = Guid.NewGuid();
            Descripcion = descripcion;
            Direccion = direccion;
            EsVerificado = esVerificado;
            Tipo = tipo;
            _servicios = new List<PropiedadServicio>();
        }
        public void Edit(string descripcion, string direccion, bool esVerificado)
        {
            Descripcion = descripcion;
            Direccion = direccion;
            EsVerificado = esVerificado;
          
        }
        public void AgregarItem(Guid servicoId, string descripcion, string direccion, bool esVerificado)
        {
            if (_servicios.Any(servicio => servicio.ServicioId == servicoId)) 
            {
                throw new ArgumentException("El Servicio ya esta asignado a la propiedad");
            }
            PropiedadServicio servicio = new PropiedadServicio(servicoId, descripcion);
            _servicios.Add(servicio);
        }
        public void ValidarPropiedad()
        {
            if (_servicios.Count == 0)
            {
                throw new ConfirmationTransacctionException("La propiedad no tiene Servicios");
            }
            EsVerificado = true;            
        }

            private Propiedadd() { }
    }
}
