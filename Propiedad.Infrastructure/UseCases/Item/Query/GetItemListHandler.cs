using MediatR;
using Microsoft.EntityFrameworkCore;
using  Propiedad.Application.Dto.Item;
using  Propiedad.Application.UseCases.Items.Query.GetItemList;
using  Propiedad.Domain.Model.Items;
using  Propiedad.Infrastructure.EF.Contexts;
using  Propiedad.Infrastructure.EF.ReadModel;

namespace Propiedad.Infrastructure.UseCases.Item.Query;

internal class GetItemListHandler :
    IRequestHandler<GetServicioListQuery, ICollection<ItemDto>>
{
    private readonly DbSet<ItemReadModel> _items;

    public GetItemListHandler(ReadDbContext context)
    {
        _items = context.Item;
    }

    public async Task<ICollection<ItemDto>> Handle(GetServicioListQuery request, CancellationToken cancellationToken)
    {
        var query = _items.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.SearchTerm))
        {            
            query = query.Where(x => x.Nombre.Contains(request.SearchTerm));            
        }
        
        return await query.Select(item => 
            new ItemDto
            {
                ItemId = item.Id,
                Nombre = item.Nombre,
                Codigo = item.Codigo
            }).ToListAsync(cancellationToken);
    }

}
