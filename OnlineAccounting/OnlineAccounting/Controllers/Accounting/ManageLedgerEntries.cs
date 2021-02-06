using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineAccounting.Models;
using OnlineAccounting.Models.Accounting;
using OnlineAccounting.Models.Accounting.Repositories;
using OnlineAccounting.Models.Repositories;

namespace OnlineAccounting.Controllers.Accounting
{
    public class ManageLedgerEntries : Controller
    {
        private readonly OnlineAccountingDbContext _context;
        private readonly ILedgerEntryRepository ledgerEntryRepository;
        private readonly IFinancialAccountRepository financialAccountRepository;

        public ManageLedgerEntries(OnlineAccountingDbContext context,ILedgerEntryRepository ledgerEntryRepository,IFinancialAccountRepository financialAccountRepository)
        {
            _context = context;
            this.ledgerEntryRepository = ledgerEntryRepository;
            this.financialAccountRepository = financialAccountRepository;
        }

        // GET: ManageLedgerEntries
        public  IActionResult Index()
        {
            var LedgerList = ledgerEntryRepository.GetAllLedgerEntries();
            return View(LedgerList);
        }

        // GET: ManageLedgerEntries/Details/5
        public  IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ledgerEntry = ledgerEntryRepository.GetLedgerEntry((int)id);
            if (ledgerEntry == null)
            {
                return NotFound();
            }

            return View(ledgerEntry);
        }

        // GET: ManageLedgerEntries/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(financialAccountRepository.GetAllFinancialAccounts(), "Id", "Name");
            return View();
        }

        // POST: ManageLedgerEntries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("Id,AccountId,TargetAccountId,type,Amount,Date,Description")] LedgerEntry ledgerEntry)
        {
            if (ModelState.IsValid)
            {
                ledgerEntryRepository.Add(ledgerEntry);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(financialAccountRepository.GetAllFinancialAccounts(), "Id", "Name", ledgerEntry.AccountId);
            return View(ledgerEntry);
        }

        // GET: ManageLedgerEntries/Edit/5
        public  IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ledgerEntry = ledgerEntryRepository.GetLedgerEntry((int)id);
            if (ledgerEntry == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(financialAccountRepository.GetAllFinancialAccounts(), "Id", "Name", ledgerEntry.AccountId);
            return View(ledgerEntry);
        }

        // POST: ManageLedgerEntries/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, [Bind("Id,AccountId,TargetAccountId,type,Amount,Date,Description")] LedgerEntry ledgerEntry)
        {
            if (id != ledgerEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ledgerEntryRepository.Update(ledgerEntry);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LedgerEntryExists(ledgerEntry.Id))
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
            ViewData["AccountId"] = new SelectList(financialAccountRepository.GetAllFinancialAccounts(), "Id", "Name", ledgerEntry.AccountId);
            return View(ledgerEntry);
        }

        // GET: ManageLedgerEntries/Delete/5
        public  IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ledgerEntry = ledgerEntryRepository.Delete((int)id);
            if (ledgerEntry == null)
            {
                return NotFound();
            }

            return View(ledgerEntry);
        }

        // POST: ManageLedgerEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            ledgerEntryRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool LedgerEntryExists(int id)
        {
            return _context.LedgerEntries.Any(e => e.Id == id);
        }
    }
}
