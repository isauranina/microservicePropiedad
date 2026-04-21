using System;

namespace Property.Application.Dto
{
    public class PropiedadDto
    {
        public Guid Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Direccion { get; set; }
        public bool EsVerificado { get; set; }
        public string? Tipo { get; set; }
    }
}