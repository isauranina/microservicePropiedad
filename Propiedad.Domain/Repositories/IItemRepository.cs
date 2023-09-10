using  Propiedad.Domain.Model.Items;
using Restaurant.SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Domain.Repositories;

public interface IItemRepository : IRepository<Item, Guid>
{
    //object GetAllItems();
    Task UpdateAsync(Item item);

}
