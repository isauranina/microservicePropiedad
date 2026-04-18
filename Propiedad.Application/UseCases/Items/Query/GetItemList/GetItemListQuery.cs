using MediatR;
using  Propiedad.Application.Dto.Item;
using Propiedad.Application.Dto.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Application.UseCases.Items.Query.GetItemList
{
    public class GetServicioListQuery : IRequest<ICollection<ItemDto>>
    {
        public string SearchTerm { get; set; }

    }
}
