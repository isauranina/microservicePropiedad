﻿using MediatR;
using Property.Application.Dto;
using System.Collections.Generic;

namespace Property.Application.UseCases.Servicio.Query.GetServicioList
{
    public class GetServicioListQuery : IRequest<IEnumerable<ServicioDto>>
    {
        public string? SearchTerm { get; set; }
    }
}