using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Repositories;
using API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("[controller]")]
    public class ItemsController : Controller
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly IItemRepository _itemRepository;

        public ItemsController(ILogger<ItemsController> logger, IItemRepository itemRepository)
        {
            _logger = logger;
            _itemRepository = itemRepository;
        }

        [HttpGet]
        public IEnumerable<ItemDTO> GetItems()
        {
            return _itemRepository.GetItems().Select(item => item.ConvertItemToItemDTO());
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDTO> GetItem(Guid id)
        {
            var item = _itemRepository.GetItem(id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item.ConvertItemToItemDTO());
        }
    }
}