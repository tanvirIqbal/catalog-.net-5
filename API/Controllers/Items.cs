using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Repositories;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("[controller]")]
    public class Items : Controller
    {
        private readonly ILogger<Items> _logger;
        private readonly IItemRepository _itemRepository;

        public Items(ILogger<Items> logger, IItemRepository itemRepository)
        {
            _logger = logger;
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return _itemRepository.GetItems();
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = _itemRepository.GetItem(id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}