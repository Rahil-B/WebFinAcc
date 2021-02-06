using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Repositories
{
    public class SQLItemRepository : IItemRepository
    {
        OnlineAccountingDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SQLItemRepository(OnlineAccountingDbContext context,IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public Item Add(Item item)
        {
            item.userId = httpContextAccessor.HttpContext.User.Identity.Name;
            context.Items.Add(item);
            context.SaveChanges();
            return item;
        }

        public Item Delete(int Id)
        {
            Item item = context.Items.Find(Id);
            if (item != null && item.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                context.Items.Remove(item);
                context.SaveChanges();
                return item;
            }
            return null;
        }

        public IEnumerable<Item> GetAllItems()
        {
            return context.Items.Where(i => i.userId == httpContextAccessor.HttpContext.User.Identity.Name).ToList();
        }

        public Item GetItem(int Id)
        {
            return context.Items.Where(i => i.userId== httpContextAccessor.HttpContext.User.Identity.Name).FirstOrDefault(i=>i.Id == Id);
        }

        public Item Update(Item ItemChanges)
        {
            if (ItemChanges.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                var item = context.Items.Attach(ItemChanges);
                item.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return ItemChanges;
            }
            return null;
        }
    }
}