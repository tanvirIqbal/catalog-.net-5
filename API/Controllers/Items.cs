using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [Route("[controller]")]
    public class Items : Controller
    {
        private readonly ILogger<Items> _logger;
        private readonly InMemRepository _inMemRepository;

        public Items(ILogger<Items> logger)
        {
            _logger = logger;
            _inMemRepository = new();
        }

        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            return _inMemRepository.GetItems();
        }

        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = _inMemRepository.GetItem(id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }
    }
}