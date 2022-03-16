using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;

namespace API.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Item GetItem(Guid Id);
        IEnumerable<Item> GetItems();
    }
}