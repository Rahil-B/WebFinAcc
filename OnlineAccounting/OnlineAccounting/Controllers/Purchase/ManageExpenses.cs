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
    public class ManageExpenses : Controller
    {
        private readonly OnlineAccountingDbContext _context;
        readonly IExpenseRepository expenseRepository;
        public ManageExpenses(OnlineAccountingDbContext context,IExpenseRepository expenseRepository)
        {
            _context = context;
            this.expenseRepository = expenseRepository;
        }

        // GET: ManageExpenses
        public IActionResult Index()
        {
            var expList = expenseRepository.GetAllExpenses();//_context.expenses.Include(e => e.Vendor);
            return View(expList);
        }

        // GET: ManageExpenses/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = expenseRepository.GetExpense((int)id);
                
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // GET: ManageExpenses/Create
        public IActionResult Create()
        {
            ViewData["VendorIds"] = new SelectList(_context.vendors, "Id", "CompanyName");
            ViewData["ExpenseAccountIds"] = new SelectList(_context.FinancialAccounts.Where(a => a.Type == PrimaryAccountType.Expense), "Id", "Name");
            ViewData["PaidFromAccountIds"] = new SelectList(_context.FinancialAccounts.Where(a => a.Type == PrimaryAccountType.Assets), "Id", "Name");
            return View();
        }

        // POST: ManageExpenses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                expenseRepository.Add(expense);
                return RedirectToAction(nameof(Index));
            }
            ViewData["VendorIds"] = new SelectList(_context.vendors, "Id", "CompanyName", expense.VendorId);
            ViewData["ExpenseAccountIds"] = new SelectList(_context.FinancialAccounts.Where(a => a.Type == PrimaryAccountType.Expense), "Id", "Name", expense.ExpenseAccountId);
            ViewData["PaidFromAccountIds"] = new SelectList(_context.FinancialAccounts.Where(a => a.Type == PrimaryAccountType.Assets), "Id", "Name", expense.PaidFromAccountId);
            return View(expense);
        }

        // GET: ManageExpenses/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = expenseRepository.GetExpense((int)id);/*await _context.expenses.FindAsync(id);*/
            if (expense == null)
            {
                return NotFound();
            }
            ViewData["VendorIds"] = new SelectList(_context.vendors, "Id", "CompanyName", expense.VendorId);
            ViewData["ExpenseAccountIds"] = new SelectList(_context.FinancialAccounts.Where(a => a.Type==PrimaryAccountType.Expense), "Id", "Name", expense.ExpenseAccountId);
            ViewData["PaidFromAccountIds"] = new SelectList(_context.FinancialAccounts.Where(a => a.Type == PrimaryAccountType.Assets), "Id", "Name", expense.PaidFromAccountId);
            return View(expense);
        }

        // POST: ManageExpenses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Expense expense)
        {
            if (id != expense.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    expenseRepository.Update(expense);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseExists(expense.Id))
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
            ViewData["VendorIds"] = new SelectList(_context.vendors, "Id", "CompanyName", expense.VendorId);
            ViewData["ExpenseAccountIds"] = new SelectList(_context.FinancialAccounts, "Id", "Name", expense.ExpenseAccountId);
            ViewData["PaidFromAccountIds"] = new SelectList(_context.FinancialAccounts, "Id", "Name", expense.PaidFromAccountId);
            return View(expense);
        }

        // GET: ManageExpenses/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expense = expenseRepository.GetExpense((int)id);
            if (expense == null)
            {
                return NotFound();
            }

            return View(expense);
        }

        // POST: ManageExpenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            expenseRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseExists(int id)
        {
            return _context.expenses.Any(e => e.Id == id);
        }
    }
}
