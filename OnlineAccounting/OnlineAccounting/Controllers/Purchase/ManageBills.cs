using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineAccounting.Models;
using OnlineAccounting.Models.Purchase;
using OnlineAccounting.Models.Purchase.Repositories;

namespace OnlineAccounting.Controllers.Purchase
{
    
    public class ManageBills : Controller
    {
        private readonly OnlineAccountingDbContext _context;
        private readonly IBillRepository billRepository;
        private readonly IBillItemDetailRepository billItemDetailRepository;

        public ManageBills(OnlineAccountingDbContext context,IBillRepository billRepository,IBillItemDetailRepository billItemDetailRepository)
        {
            _context = context;
            this.billRepository = billRepository;
            this.billItemDetailRepository = billItemDetailRepository;
        }

        // GET: ManageBills
        public IActionResult Index()
        {
            var billList = billRepository.GetAllBills();
            return View(billList);
        }

        // GET: ManageBills/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = billRepository.GetBill((int)id);

            if (bill == null)
            {
                return NotFound();
            }
            bill.ItemList = (IList<BillItemDetail>)billItemDetailRepository.GetAllBillItemDetailByBillId(bill.Id);
            return View(bill);
        }

        // GET: ManageBills/Create

        public IActionResult Create(int id)
        {
            //ViewData["PaymentID"] = new SelectList(_context.paymentsMades, "Id", "Id");
            ViewBag.itemCount = id;
            ViewData["VendorIds"] = new SelectList(_context.vendors, "Id", "CompanyName");
            ViewData["CustomerIds"] = new SelectList(_context.customers, "Id", "Name");
            ViewData["ItemIds"] = new SelectList(_context.Items, "Id", "Name");
            ViewData["AccountIds"] = new SelectList(_context.FinancialAccounts, "Id", "Name");
            return View();
        }
        

        // POST: ManageBills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(Bill bill)//[Bind("Id,userId,VendorId,SubTotal,Discount,TDS,Total,PaymentID")] Bill bill)
        {
            if (ModelState.IsValid)
            {
                bill.Id = 0;
                billRepository.Add(bill);
                //_context.Add(bill);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VendorIds"] = new SelectList(_context.vendors, "Id", "CompanyName");
            ViewData["CustomerIds"] = new SelectList(_context.customers, "Id", "Name");
            ViewData["ItemIds"] = new SelectList(_context.Items, "Id", "Name");
            ViewData["AccountIds"] = new SelectList(_context.FinancialAccounts, "Id", "Name");
            return View(bill);
        }

        // GET: ManageBills/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = billRepository.GetBill((int)id);
            if (bill == null)
            {
                return NotFound();
            }
            bill.ItemList = (IList < BillItemDetail > )billItemDetailRepository.GetAllBillItemDetailByBillId(bill.Id);
            ViewData["VendorIds"] = new SelectList(_context.vendors, "Id", "CompanyName");
            ViewData["CustomerIds"] = new SelectList(_context.customers, "Id", "Name");
            ViewData["ItemIds"] = new SelectList(_context.Items, "Id", "Name");
            ViewData["AccountIds"] = new SelectList(_context.FinancialAccounts, "Id", "Name");
            return View(bill);
        }

        // POST: ManageBills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Bill bill)
        {
            if (id != bill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    billRepository.Update(bill);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillExists(bill.Id))
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
            ViewData["VendorIds"] = new SelectList(_context.vendors, "Id", "CompanyName");
            ViewData["CustomerIds"] = new SelectList(_context.customers, "Id", "Name");
            ViewData["ItemIds"] = new SelectList(_context.Items, "Id", "Name");
            ViewData["AccountIds"] = new SelectList(_context.FinancialAccounts, "Id", "Name");
            return View(bill);
        }

        // GET: ManageBills/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bill = billRepository.GetBill((int)id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }

        // POST: ManageBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            billRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GenerateBill(int id)
        {
            var bill = _context.bills
                .Include(b => b.vendor)
                .FirstOrDefault(m => m.Id == id);

            if (bill == null)
            {
                return NotFound();
            }
            bill.ItemList = (IList<BillItemDetail>)billItemDetailRepository.GetAllBillItemDetailByBillId(bill.Id);
            return View(bill);
        }

        private bool BillExists(int id)
        {
            return _context.bills.Any(e => e.Id == id);
        }
    }
}
