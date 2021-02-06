using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineAccounting.Models;
using OnlineAccounting.Models.Sales;
using OnlineAccounting.Models.Sales.Repositories;

namespace OnlineAccounting.Controllers.Sales
{
    public class ManageDeliveryChallans : Controller
    {
        private readonly OnlineAccountingDbContext _context;
        private readonly IDeliveryChallanRepository deliveryChallanRepository;

        public ManageDeliveryChallans(OnlineAccountingDbContext context, IDeliveryChallanRepository deliveryChallanRepository)
        {
            _context = context;
            this.deliveryChallanRepository = deliveryChallanRepository;
        }

        // GET: ManageDeliveryChallans
        public IActionResult Index()
        {
            var dcList = deliveryChallanRepository.GetAllDeliveryChallans();
            return View(dcList);
        }

        // GET: ManageDeliveryChallans/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryChallan = deliveryChallanRepository.GetDeliveryChallan((int)id);
            if (deliveryChallan == null)
            {
                return NotFound();
            }

            return View(deliveryChallan);
        }

        // GET: ManageDeliveryChallans/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.customers, "Id", "CompanyName");
            return View();
        }

        // POST: ManageDeliveryChallans/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,userId,CustomerId,CustomerName,Date,Type,SubTotal,Adjustment,Total")] DeliveryChallan deliveryChallan)
        {
            if (ModelState.IsValid)
            {
                deliveryChallanRepository.Add(deliveryChallan);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.customers, "Id", "CompanyName", deliveryChallan.CustomerId);
            return View(deliveryChallan);
        }

        // GET: ManageDeliveryChallans/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryChallan = deliveryChallanRepository.GetDeliveryChallan((int)id);
            if (deliveryChallan == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.customers, "Id", "CompanyName", deliveryChallan.CustomerId);
            return View(deliveryChallan);
        }

        // POST: ManageDeliveryChallans/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,userId,CustomerId,CustomerName,Date,Type,SubTotal,Adjustment,Total")] DeliveryChallan deliveryChallan)
        {
            if (id != deliveryChallan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    deliveryChallanRepository.Update(deliveryChallan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryChallanExists(deliveryChallan.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.customers, "Id", "CompanyName", deliveryChallan.CustomerId);
            return View(deliveryChallan);
        }

        // GET: ManageDeliveryChallans/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deliveryChallan = deliveryChallanRepository.GetDeliveryChallan((int)id);
            if (deliveryChallan == null)
            {
                return NotFound();
            }

            return View(deliveryChallan);
        }

        // POST: ManageDeliveryChallans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            deliveryChallanRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryChallanExists(int id)
        {
            return _context.deliveryChallans.Any(e => e.Id == id);
        }
    }
}
