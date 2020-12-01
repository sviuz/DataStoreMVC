using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataShopMVC.Data;
using Microsoft.EntityFrameworkCore;

namespace DataShopMVC.Services
{
    public class ItemService : IItemService
    {
        private ItemContext _dbContext;

        public ItemService( ItemContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async void AddItem(Item item)
        {
            if(item!=null)
            {
                _dbContext.Items.Add(new Item
                {
                    Id = item.Id, 
                    Name = item.Name, 
                    Description = item.Description, 
                    Price = item.Price,Available = 
                    item.Available, 
                    Size = item.Size 
                });

                await _dbContext.SaveChangesAsync();
            }
        }

        public async void DeleteItemById(int id)
        {
            var data = _dbContext.Items.FirstOrDefault(item => item.Id== id);

            if(data != null)
            {
                _dbContext.Items.Remove(data);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _dbContext.Items.FirstOrDefaultAsync(item => item.Id==id);
        }

        public async Task<List<Item>> GetItems()
        {
            return await _dbContext.Items.ToListAsync<Item>();
        }

    }
}