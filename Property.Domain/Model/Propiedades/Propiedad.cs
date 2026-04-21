﻿using Property.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Property.Domain.ValueObjects;
using Property.SharedKernel.Core;

namespace Property.Domain.Model.Propiedades
{
    public class Propiedad : AggregateRoot
    {
        public PropiedadDescripcionValue Descripcion { get; private set; }
        public PropiedadDireccionValue Direccion { get; private set; }
        public bool EsVerificado { get; set; }

        private readonly ICollection<PropiedadServicio> _servicios;
        public IEnumerable<PropiedadServicio> Servicio => _servicios;

        public TipoPropiedad Tipo { get;private set; }
        public EstadoPropiedad Estado { get; set; }

        internal Propiedad(string descripcion, string direccion, bool esVerificado, TipoPropiedad tipo)
        {
            Id = Guid.NewGuid();
            Descripcion = new PropiedadDescripcionValue(descripcion);
            Direccion = new PropiedadDireccionValue(direccion);
            EsVerificado = esVerificado;
            Tipo = tipo;
            _servicios = new List<PropiedadServicio>();
        }
        public void Edit(string descripcion, string direccion, bool esVerificado)
        {
            Descripcion = new PropiedadDescripcionValue(descripcion);
            Direccion = new PropiedadDireccionValue(direccion);
            EsVerificado = esVerificado;
          
        }
       
        public void ValidarPropiedad()
        {
            if (_servicios.Count == 0)
            {
                throw new BussinessRuleValidationException("La propiedad no tiene Servicios");
            }
            EsVerificado = true;            
        }

            private Propiedad() { }
    }
}
