using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataShopMVC.Data;
using DataShopMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DataShopMVC.Controllers
{
    public class ItemController: ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly ILogger<ItemController> _logger;
        public ItemController(IItemService itemService, ILogger<ItemController> logger)
        {
            _itemService = itemService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<Item>> GetAll()
        {
            try
            {
                _logger.LogInformation("Getting all items");
                return await _itemService.GetItems();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error was caught while getting a whole list of items.");
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }

        [HttpPost]
        public void Add(Item item)
        {
            try
            {
                if (item!=null)
                {
                    _itemService.AddItem(new Item{
                        Id = item.Id, 
                        Name = item.Name, 
                        Description = item.Description, 
                        Price = item.Price,Available = 
                        item.Available, 
                        Size = item.Size }
                    );
                    _logger.LogInformation($"Item {item.Name} added.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("An error was caught while adding a new item.");
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            try
            {
                if (id>0)
                {
                    _itemService.DeleteItemById(id);
                    _logger.LogInformation($"Item with id: {id} deleted.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"An error was caught while deleting item with id: {id}.");
                _logger.LogError($"Error: {ex.Message}");
                throw;
            }
        }


    }
}