using Propiedad.Domain.Model.Items;
using Propiedad.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Propiedad.Test.Application.UseCases.Items.EventHandler
{
    public class ItembRepositoryStub: IItemRepository
    {
        private  List<Item> _items;

        public ItembRepositoryStub(List<Item> items)
        {
            _items = items;
        }
        public async Task<IEnumerable<Item>> GetAllItems()
        {
            return await Task.FromResult(_items);
        }
        public async Task<Item> GetItemById(Guid id)
        {
            return  _items.FirstOrDefault(Item => Item.Id == id);
        }

        public async Task<bool> SaveItem(Item item)
        {
            _items.Add(item);
            return true;
        }

        public async Task<bool> UpdateItem(Item item)
        {
            var existingItem = await GetItemById(item.Id);
            if (existingItem == null)
            {
                return false;
            }

            existingItem.Edit(item.Nombre);
            existingItem.Stock = item.Stock;
            return true;
        }
        public async Task<bool> DeleteItem(Guid id)
        {
            var existingItem = await GetItemById(id);
            if (existingItem == null)
            {
                return false;
            }
            _items.Remove(existingItem);
            return true;
        }


        public Task UpdateAsync(Item item)
        {
            return Task.Run(()=> UpdateItem(item));
        }

        public Task<Item?> FindByIdAsync(Guid id)
        {
            return Task.Run(() => GetItemById(id));
        }

        public Task CreateAsync(Item obj)
        {
            return Task.Run(() => SaveItem(obj));
        }
    }
}
