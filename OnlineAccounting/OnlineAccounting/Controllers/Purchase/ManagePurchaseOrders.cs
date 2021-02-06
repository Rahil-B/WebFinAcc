using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineAccounting.Models;
using OnlineAccounting.Models.Purchase;
using OnlineAccounting.Models.Purchase.Repositories;

namespace OnlineAccounting.Controllers.Purchase
{
    public class ManagePurchaseOrders : Controller
    {
        private readonly OnlineAccountingDbContext _context;
        readonly IPurchaseOrderRepository purchaseOrderRepository;
        readonly IPOrderItemDetailRepository pOrderItemDetailRepository;

        public ManagePurchaseOrders(OnlineAccountingDbContext context,IPurchaseOrderRepository purchaseOrderRepository,IPOrderItemDetailRepository pOrderItemDetailRepository)
        {
            _context = context;
            this.purchaseOrderRepository= purchaseOrderRepository ;
            this.pOrderItemDetailRepository = pOrderItemDetailRepository;
        }

        // GET: ManagePurchaseOrders
        public IActionResult Index()
        {
            var POList = purchaseOrderRepository.GetAllPurchaseOrders();
            return View(POList);
        }

        // GET: ManagePurchaseOrders/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = purchaseOrderRepository.GetPurchaseOrder((int)id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }
            purchaseOrder.ItemList = (IList<POrderItemDetail>)pOrderItemDetailRepository.GetAllPOrderItemDetailByPOrderId(purchaseOrder.Id);
            return View(purchaseOrder);
        }

        // GET: ManagePurchaseOrders/Create
        public IActionResult Create(int id)
        {
            ViewData["VendorIds"] = new SelectList(_context.vendors, "Id", "CompanyName");
            ViewData["ItemIds"] = new SelectList(_context.Items, "Id", "Name");
            ViewBag.itemCount = id;
            return View();
        }

        // POST: ManagePurchaseOrders/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                purchaseOrderRepository.Add(purchaseOrder);
                return RedirectToAction(nameof(Index));
            }
            ViewData["VendorIds"] = new SelectList(_context.vendors, "Id", "CompanyName");
            ViewData["ItemIds"] = new SelectList(_context.Items, "Id", "Name");
            ViewBag.itemCount = purchaseOrder.ItemList.Count;
            return View(purchaseOrder);
        }

        // GET: ManagePurchaseOrders/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = purchaseOrderRepository.GetPurchaseOrder((int)id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }
            purchaseOrder.ItemList = (IList<POrderItemDetail>)pOrderItemDetailRepository.GetAllPOrderItemDetailByPOrderId(purchaseOrder.Id);
            ViewData["VendorIds"] = new SelectList(_context.vendors, "Id", "CompanyName");
            ViewData["ItemIds"] = new SelectList(_context.Items, "Id", "Name");
            return View(purchaseOrder);
        }

        // POST: ManagePurchaseOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PurchaseOrder purchaseOrder)
        {
            if (id != purchaseOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    purchaseOrderRepository.Update(purchaseOrder);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseOrderExists(purchaseOrder.Id))
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
            ViewData["VendorId"] = new SelectList(_context.vendors, "Id", "CompanyName", purchaseOrder.VendorId);
            return View(purchaseOrder);
        }

        // GET: ManagePurchaseOrders/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = purchaseOrderRepository.GetPurchaseOrder((int)id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        // POST: ManagePurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            purchaseOrderRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseOrderExists(int id)
        {
            return _context.purchaseOrders.Any(e => e.Id == id);
        }
    }
}
