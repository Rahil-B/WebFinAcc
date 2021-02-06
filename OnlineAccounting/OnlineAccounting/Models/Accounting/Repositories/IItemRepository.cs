using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Repositories
{
    public interface IItemRepository
    {
        Item GetItem(int Id);
        IEnumerable<Item> GetAllItems();
        Item Add(Item item);
        Item Update(Item ItemChanges);
        Item Delete(int Id);
    }
}
