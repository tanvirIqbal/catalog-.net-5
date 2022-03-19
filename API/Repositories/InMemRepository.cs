using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Repositories.Interfaces;

namespace API.Repositories
{
    public class InMemRepository : IItemRepository
    {
        private readonly List<Item> items = new()
        {
            new Item() { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTime.Now },
            new Item() { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTime.Now },
            new Item() { Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreatedDate = DateTime.Now }
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }

        public async Task<Item> GetItemAsync(Guid Id)
        {
            return await Task.FromResult(items.Where(x => x.Id == Id).SingleOrDefault());
        }

        public async Task CreateAsync(Item item)
        {
            items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Item item)
        {
            int index = items.FindIndex(x => x.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            int index = items.FindIndex(x => x.Id == id);
            items.RemoveAt(index);
            await Task.CompletedTask;
        }
    }
}