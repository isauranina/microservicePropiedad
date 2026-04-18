using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using  Propiedad.Application.UseCases.Items.Command.CrearItem;
using  Propiedad.Application.UseCases.Items.Query.GetItemList;

namespace Propiedad.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateItem([FromBody] CrearItemCommand command)
    {
        var itemId = await _mediator.Send(command);
        
        return Ok(itemId);
    }

    [HttpGet]
    public async Task<IActionResult> SearchItems(string searchTerm = "")
    {
        var items = await _mediator.Send(new GetServicioListQuery()
        {
            SearchTerm = searchTerm
        });

        return Ok(items);
    }
}
