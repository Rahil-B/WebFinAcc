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
    public class ManageSalesOrders : Controller
    {
        private readonly OnlineAccountingDbContext _context;
        private readonly ISalesOrderRepository salesOrderRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IItemDetailRepository itemDetailRepository;

        public ManageSalesOrders(OnlineAccountingDbContext context,ISalesOrderRepository salesOrderRepository,ICustomerRepository customerRepository,IItemDetailRepository itemDetailRepository)
        {
            _context = context;
            this.salesOrderRepository = salesOrderRepository;
            this.customerRepository = customerRepository;
            this.itemDetailRepository = itemDetailRepository;
        }

        // GET: ManageSalesOrders
        public IActionResult Index()
        {
            return View(salesOrderRepository.GetAllSalesOrders());
        }

        // GET: ManageSalesOrders/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrder = salesOrderRepository.GetSalesOrder((int)id); 

            if (salesOrder == null)
            {
                return NotFound();
            }
            return View(salesOrder);
        }

        // GET: ManageSalesOrders/Create
        public IActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(customerRepository.GetAllCustomers().ToList<Customer>(), "Id", "Name");
            ViewBag.itemCount = 2;  
            return View();
        }

        // POST: ManageSalesOrders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SalesOrder salesOrder)
        {
            
            if (salesOrder is null)
            {
                throw new ArgumentNullException(nameof(salesOrder));
            }

            if (ModelState.IsValid)
            {
                salesOrder.TotalItems = salesOrder.ItemList.Count;
                salesOrderRepository.Add(salesOrder);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.CustomerId = new SelectList(customerRepository.GetAllCustomers().ToList<Customer>(), "Id", "Name");
            ViewBag.itemCount = ViewBag.itemCount;
            return View();
        }

        // GET: ManageSalesOrders/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            SalesOrder salesOrder = salesOrderRepository.GetSalesOrder((int)id);
            salesOrder.ItemList = (IList<ItemDetail>)itemDetailRepository.GetAllItemDetailsBySalesOrderId(salesOrder.Id);
            ViewBag.CustomerId = new SelectList(customerRepository.GetAllCustomers().ToList<Customer>(), "Id", "Name");
            if (salesOrder == null)
            {
                return NotFound();
            }
            return View(salesOrder);
        }

        // POST: ManageSalesOrders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id,SalesOrder salesOrder)
        {
            if (id != salesOrder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    salesOrderRepository.Update(salesOrder);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesOrderExists(salesOrder.Id))
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
            return View(salesOrder);
        }

        // GET: ManageSalesOrders/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesOrder = salesOrderRepository.GetSalesOrder((int)id);
            if (salesOrder == null)
            {
                return NotFound();
            }

            return View(salesOrder);
        }

        // POST: ManageSalesOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            salesOrderRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SalesOrderExists(int id)
        {
            return _context.salesOrders.Any(e => e.Id == id);
        }
    }
}
