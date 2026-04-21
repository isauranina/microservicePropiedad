﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Property.Application.UseCases.Servicio.Query.GetServicioList;
using System.Threading.Tasks;

namespace Property.WebApi.Controllers
{
    [ApiController]
    [Route("api/servicio")]
    public class ServicioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServicios([FromQuery] string? searchTerm)
        {           
            var query = new GetServicioListQuery { SearchTerm = searchTerm };
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}