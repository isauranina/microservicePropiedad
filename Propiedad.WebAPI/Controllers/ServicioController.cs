using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Propiedad.Application.UseCases.Items.Query.GetItemList;
using Propiedad.Application.UseCases.Servicio.Command.CrearServicio;
using Propiedad.Application.UseCases.Servicio.Query.GetServicioList;

namespace Propiedad.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServicioController (IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateServicio([FromBody] CrearServicioCommand command)
        {
            var ServicioId = await _mediator.Send(command);

            return Ok(ServicioId);
        }

        [HttpGet]
        public async Task<IActionResult>  SearchServicios(string searchTerm = "")
        {
            var servivios = await _mediator.Send(new GetServicioListQuery()
            {
                SearchTerm = searchTerm
            });

            return Ok(servivios);
        }
    }
}
