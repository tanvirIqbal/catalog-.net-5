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
        public async Task<IEnumerable<ItemDTO>> GetItemsAsync()
        {
            return (await _itemRepository.GetItemsAsync()).Select(item => item.ConvertToDTO());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDTO>> GetItemAsync(Guid id)
        {
            var item = await _itemRepository.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item.ConvertToDTO());
        }

        [HttpPost]
        public async Task<ActionResult<ItemDTO>> CreateItemAsync(CreateItemDTO createItemDTO)
        {
            Item item = new Item()
            {
                Id = Guid.NewGuid(),
                Name = createItemDTO.Name,
                Price = createItemDTO.Price,
                CreatedDate = DateTime.Now
            };
            await _itemRepository.CreateAsync(item);
            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id}, item.ConvertToDTO());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDTO updateItemDTO)
        {
            Item existingItem = await _itemRepository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            existingItem.Name = updateItemDTO.Name;
            existingItem.Price = updateItemDTO.Price;

            await _itemRepository.UpdateAsync(existingItem);

            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItemAsync(Guid id)
        {
            Item existingItem = await _itemRepository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            await _itemRepository.DeleteAsync(id);

            return NoContent();
        }
    }
}