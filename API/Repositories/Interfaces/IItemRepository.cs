using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task<Item> GetItemAsync(Guid Id);
        Task<IEnumerable<Item>> GetItemsAsync();
        Task CreateAsync(Item item);
        Task UpdateAsync(Item item);
        Task DeleteAsync(Guid id);
    }
}