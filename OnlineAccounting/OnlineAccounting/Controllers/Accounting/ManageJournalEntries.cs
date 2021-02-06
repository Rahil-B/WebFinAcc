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

namespace OnlineAccounting
{
    public class ManageJournalEntries : Controller
    {
        private readonly OnlineAccountingDbContext _context;
        private readonly IJournalEntryRepository journalEntryRepository;
        private readonly IFinancialAccountRepository financialAccountRepository;

        public ManageJournalEntries(OnlineAccountingDbContext context,IJournalEntryRepository journalEntryRepository,IFinancialAccountRepository financialAccountRepository)
        {
            _context = context;
            this.journalEntryRepository = journalEntryRepository;
            this.financialAccountRepository = financialAccountRepository;
        }

        // GET: ManageJournalEntries
        public IActionResult Index()
        {
            var JEList = journalEntryRepository.GetAllJournalEntries();
            return View(JEList);
        }

        // GET: ManageJournalEntries/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journalEntry = journalEntryRepository.GetJournalEntry((int)id); 
            if (journalEntry == null)
            {
                return NotFound();
            }

            return View(journalEntry);
        }

        // GET: ManageJournalEntries/Create
        public IActionResult Create()
        {
            ViewData["CreditAccountId"] = new SelectList(financialAccountRepository.GetAllFinancialAccounts(), "Id", "Name");
            ViewData["DebitAccountId"] = new SelectList(financialAccountRepository.GetAllFinancialAccounts(), "Id", "Name");
            return View();
        }

        // POST: ManageJournalEntries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create( JournalEntry journalEntry)
        {
            if (ModelState.IsValid)
            {
                journalEntryRepository.Add(journalEntry);
                return RedirectToAction(nameof(Index));
            }
            ViewData["CreditAccountId"] = new SelectList(financialAccountRepository.GetAllFinancialAccounts(), "Id", "Id", journalEntry.CreditAccountId);
            ViewData["DebitAccountId"] = new SelectList(financialAccountRepository.GetAllFinancialAccounts(), "Id", "Id", journalEntry.DebitAccountId);
            return View(journalEntry);
        }

        // GET: ManageJournalEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journalEntry = journalEntryRepository.GetJournalEntry((int)id);
            if (journalEntry == null)
            {
                return NotFound();
            }
            ViewData["CreditAccountId"] = new SelectList(financialAccountRepository.GetAllFinancialAccounts(), "Id", "Id", journalEntry.CreditAccountId);
            ViewData["DebitAccountId"] = new SelectList(financialAccountRepository.GetAllFinancialAccounts(), "Id", "Id", journalEntry.DebitAccountId);
            return View(journalEntry);
        }

        // POST: ManageJournalEntries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, JournalEntry journalEntry)
        {
            if (id != journalEntry.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    journalEntryRepository.Update(journalEntry);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JournalEntryExists(journalEntry.Id))
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
            ViewData["CreditAccountId"] = new SelectList(financialAccountRepository.GetAllFinancialAccounts(), "Id", "Id", journalEntry.CreditAccountId);
            ViewData["DebitAccountId"] = new SelectList(financialAccountRepository.GetAllFinancialAccounts(), "Id", "Id", journalEntry.DebitAccountId);
            return View(journalEntry);
        }

        // GET: ManageJournalEntries/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var journalEntry = journalEntryRepository.GetJournalEntry((int)id);
            if (journalEntry == null)
            {
                return NotFound();
            }

            return View(journalEntry);
        }

        // POST: ManageJournalEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            journalEntryRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool JournalEntryExists(int id)
        {
            return _context.JournalEntries.Any(e => e.Id == id);
        }
    }
}
