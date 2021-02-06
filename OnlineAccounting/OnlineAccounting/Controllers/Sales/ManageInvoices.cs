using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineAccounting.Models;
using OnlineAccounting.Models.Sales;
using OnlineAccounting.Models.Sales.Repositories;

namespace OnlineAccounting.Controllers.Sales
{
    public class ManageInvoices : Controller
    {
        private readonly OnlineAccountingDbContext _context;
        readonly IInvoiceRepository invoiceRepository;
        public ManageInvoices(OnlineAccountingDbContext context,IInvoiceRepository invoiceRepository)
        {
            _context = context;
            this.invoiceRepository = invoiceRepository;
        }

        // GET: ManageInvoices
        public IActionResult Index()
        {
            var InvList = invoiceRepository.GetAllInvoices();
            return View(InvList);
        }

        // GET: ManageInvoices/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = invoiceRepository.GetInvoice((int)id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // GET: ManageInvoices/Create
        public IActionResult Create()
        {
            ViewData["SalesOrderId"] = new SelectList(_context.salesOrders, "Id", "Id");
            return View();
        }

        // POST: ManageInvoices/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Invoice invoice)
        {
            if (ModelState.IsValid)
            {
                invoiceRepository.Add(invoice);
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalesOrderId"] = new SelectList(_context.salesOrders, "Id", "Id", invoice.SalesOrderId);
            return View(invoice);
        }

        // GET: ManageInvoices/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = invoiceRepository.GetInvoice((int)id);
            if (invoice == null)
            {
                return NotFound();
            }
            ViewData["SalesOrderId"] = new SelectList(_context.salesOrders, "Id", "Id", invoice.SalesOrderId);
            return View(invoice);
        }

        // POST: ManageInvoices/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,  Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    invoiceRepository.Update(invoice);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvoiceExists(invoice.Id))
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
            ViewData["SalesOrderId"] = new SelectList(_context.salesOrders, "Id", "Id", invoice.SalesOrderId);
            return View(invoice);
        }

        // GET: ManageInvoices/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var invoice = invoiceRepository.GetInvoice((int)id);
            if (invoice == null)
            {
                return NotFound();
            }

            return View(invoice);
        }

        // POST: ManageInvoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            invoiceRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool InvoiceExists(int id)
        {
            return _context.invoices.Any(e => e.Id == id);
        }
    }
}
