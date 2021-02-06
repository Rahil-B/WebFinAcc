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
    public class ManagePaymentsMades : Controller
    {
        private readonly OnlineAccountingDbContext _context;
        private readonly IVendorRepository vendorRepository;
        private readonly IPaymentsMadeRepository paymentsMadeRepository;

        public ManagePaymentsMades(OnlineAccountingDbContext context, IVendorRepository vendorRepository, IPaymentsMadeRepository paymentsMadeRepository)
        {
            _context = context;
            this.vendorRepository = vendorRepository;
            this.paymentsMadeRepository = paymentsMadeRepository;
        }

        // GET: ManagePaymentsMades
        public IActionResult Index()
        {
            var paymentList = paymentsMadeRepository.GetAllPaymentsMades();//_context.paymentsMades.Include(p => p.Vendor);
            return View(paymentList);
        }

        // GET: ManagePaymentsMades/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentsMade = paymentsMadeRepository.GetPaymentsMade((int)id);
            if (paymentsMade == null)
            {
                return NotFound();
            }

            return View(paymentsMade);
        }

        // GET: ManagePaymentsMades/Create
        public IActionResult Create()
        {
            ViewData["VendorId"] = new SelectList(vendorRepository.GetAllVendors(), "Id", "CompanyName");
            ViewData["PaymentFromAccountIds"] = new SelectList(_context.FinancialAccounts.Where(a => a.Type == PrimaryAccountType.Assets), "Id", "Name");
            ViewData["PaymentToAccountIds"] = new SelectList(_context.FinancialAccounts.Where(a => a.Type == PrimaryAccountType.Liability), "Id", "Name");
            return View();
        }

        // POST: ManagePaymentsMades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,userId,VendorId,Amount,Date,Mode,ReceiptReferance")] PaymentsMade paymentsMade)
        {
            if (ModelState.IsValid)
            {
                paymentsMadeRepository.Add(paymentsMade);
                return RedirectToAction(nameof(Index));
            }
            ViewData["VendorId"] = new SelectList(vendorRepository.GetAllVendors(), "Id", "CompanyName", paymentsMade.VendorId);
            ViewData["PaymentFromAccountIds"] = new SelectList(_context.FinancialAccounts.Where(a => a.Type == PrimaryAccountType.Assets), "Id", "Name");
            ViewData["PaymentToAccountIds"] = new SelectList(_context.FinancialAccounts.Where(a => a.Type == PrimaryAccountType.Liability), "Id", "Name");
            return View(paymentsMade);
        }

        // GET: ManagePaymentsMades/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentsMade = paymentsMadeRepository.GetPaymentsMade((int)id);
            if (paymentsMade == null)
            {
                return NotFound();
            }
            ViewData["VendorId"] = new SelectList(vendorRepository.GetAllVendors(), "Id", "CompanyName", paymentsMade.VendorId);
            ViewData["PaymentFromAccountIds"] = new SelectList(_context.FinancialAccounts.Where(a => a.Type == PrimaryAccountType.Assets), "Id", "Name");
            ViewData["PaymentToAccountIds"] = new SelectList(_context.FinancialAccounts.Where(a => a.Type == PrimaryAccountType.Liability), "Id", "Name");
            return View(paymentsMade);
        }

        // POST: ManagePaymentsMades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,userId,VendorId,Amount,Date,Mode,ReceiptReferance")] PaymentsMade paymentsMade)
        {
            if (id != paymentsMade.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    paymentsMadeRepository.Update(paymentsMade);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentsMadeExists(paymentsMade.Id))
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
            ViewData["VendorId"] = new SelectList(vendorRepository.GetAllVendors(), "Id", "CompanyName", paymentsMade.VendorId);
            ViewData["PaymentFromAccountIds"] = new SelectList(_context.FinancialAccounts.Where(a => a.Type == PrimaryAccountType.Assets), "Id", "Name");
            ViewData["PaymentToAccountIds"] = new SelectList(_context.FinancialAccounts.Where(a => a.Type == PrimaryAccountType.Liability), "Id", "Name");
            return View(paymentsMade);
        }

        // GET: ManagePaymentsMades/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentsMade = paymentsMadeRepository.GetPaymentsMade((int)id);
            if (paymentsMade == null)
            {
                return NotFound();
            }

            return View(paymentsMade);
        }

        // POST: ManagePaymentsMades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            paymentsMadeRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentsMadeExists(int id)
        {
            return _context.paymentsMades.Any(e => e.Id == id);
        }
    }
}
