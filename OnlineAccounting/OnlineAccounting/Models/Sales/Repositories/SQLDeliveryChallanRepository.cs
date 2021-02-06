using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Sales.Repositories
{
    public class SQLDeliveryChallanRepository:IDeliveryChallanRepository
    {
        OnlineAccountingDbContext context;
        private readonly IHttpContextAccessor httpContextAccessor;

        public SQLDeliveryChallanRepository(OnlineAccountingDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.context = context;
            this.httpContextAccessor = httpContextAccessor;
        }
        public DeliveryChallan Add(DeliveryChallan deliveryChallan)
        {
            deliveryChallan.userId = httpContextAccessor.HttpContext.User.Identity.Name;
            context.deliveryChallans.Add(deliveryChallan);
            context.SaveChanges();
            return deliveryChallan;
        }

        public DeliveryChallan Delete(int Id)
        {
            DeliveryChallan deliveryChallan = context.deliveryChallans.Find(Id);
            if (deliveryChallan != null && deliveryChallan.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                context.deliveryChallans.Remove(deliveryChallan);
                context.SaveChanges();
                return deliveryChallan;
            }
            return null;
        }

        public IEnumerable<DeliveryChallan> GetAllDeliveryChallans()
        {
            return context.deliveryChallans.Include(d => d.customer).Where(dc => dc.userId == httpContextAccessor.HttpContext.User.Identity.Name).ToList();
        }

        public DeliveryChallan GetDeliveryChallan(int Id)
        {
            return context.deliveryChallans.Include(d => d.customer).Where(dc => dc.userId == httpContextAccessor.HttpContext.User.Identity.Name).FirstOrDefault(dc => dc.Id == Id);
        }

        public DeliveryChallan Update(DeliveryChallan deliveryChallanChanges)
        {
            if (deliveryChallanChanges.userId == httpContextAccessor.HttpContext.User.Identity.Name)
            {
                var deliveryChallan = context.deliveryChallans.Attach(deliveryChallanChanges);
                deliveryChallan.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();
                return deliveryChallanChanges;
            }
            return null;
        }
    }
}
