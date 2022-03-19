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

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid Id)
        {
            return items.Where(x => x.Id == Id).SingleOrDefault();
        }

        public void Create(Item item)
        {
            items.Add(item);
        }

        public void Update(Item item)
        {
            int index = items.FindIndex(x => x.Id == item.Id);
            items[index] = item;
        }

        public void Delete(Guid id)
        {
            int index = items.FindIndex(x => x.Id == id);
            items.RemoveAt(index);
        }
    }
}