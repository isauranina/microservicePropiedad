using MediatR;
using Property.Application.Dto.Propiedad;
using Property.Application.Dto.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Application.UseCases.PropiedadServicio.CrearServicio
{
    public class CrearPropiedadServicioCommand : IRequest<Guid>
    {
        public List<PropiedadDetalleServicioDto> Servicios { get; set; }
        
        public TipoPropiedad Tipo { get; set; }
        public bool CrearYConfirmar { get; set; }

        public CrearPropiedadServicioCommand(List<PropiedadDetalleServicioDto> servicios, TipoPropiedad tipo)
        {
            Servicios = servicios;
            Tipo = tipo;
        }
        public CrearPropiedadServicioCommand(List<PropiedadDetalleServicioDto> servicios,TipoPropiedad tipo, bool crearYConfirmar): this(servicios,tipo) 
        {
            CrearYConfirmar = crearYConfirmar;
        }
        public CrearPropiedadServicioCommand() { }
    }
}
