using Microsoft.EntityFrameworkCore;
using  Propiedad.Domain.Model.Items;
using  Propiedad.Domain.Repositories;
using Propiedad.Infrastructure.EF.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Infrastructure.EF.Repositories
{
    internal class ItemRepository : IItemRepository
    {
        private readonly WriteDbContext _context;

        public ItemRepository(WriteDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Item obj)
        {
            await _context.Item.AddAsync(obj);
        }

        public async Task<Item?> FindByIdAsync(Guid id)
        {            
            return  await _context.Item.
                SingleOrDefaultAsync(x => x.Id == id);
    }

        public Task UpdateAsync(Item item)
        {
            _context.Item.Update(item);
            return Task.CompletedTask;
        }
    }
}
