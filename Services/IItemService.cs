using System.Collections.Generic;
using System.Threading.Tasks;
using DataShopMVC.Data;

namespace DataShopMVC.Services
{
    public interface IItemService
    {
         public void AddItem(Item item);
         public Task<Item> GetItemById(int id);
         public Task<List<Item>> GetItems();
         public void DeleteItemById(int id);
         
         //TO DO: Add Update Item Method
    }
}