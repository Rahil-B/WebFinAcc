using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineAccounting.Models;
using OnlineAccounting.Models.Repositories;
using OnlineAccounting.Models.Sales;
using OnlineAccounting.Models.Sales.Repositories;

namespace OnlineAccounting.Controllers.Sales
{
    public class ManagePaymentReceiveds : Controller
    {
        private readonly OnlineAccountingDbContext _context;
        private readonly IPaymentReceivedRepository paymentReceivedRepository;
        private readonly IFinancialAccountRepository financialAccountRepository;

        public ManagePaymentReceiveds(OnlineAccountingDbContext context,IPaymentReceivedRepository paymentReceivedRepository,IFinancialAccountRepository financialAccountRepository)
        {
            _context = context;
            this.paymentReceivedRepository = paymentReceivedRepository;
            this.financialAccountRepository = financialAccountRepository;
        }

        // GET: ManagePaymentReceiveds
        public IActionResult Index()
        {
            var PRList = paymentReceivedRepository.GetAllPaymentReceiveds();//_context.paymentReceiveds;
            return View(PRList);
        }

        // GET: ManagePaymentReceiveds/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentReceived = paymentReceivedRepository.GetPaymentReceived((int)id);
            if (paymentReceived == null)
            {
                return NotFound();
            }

            return View(paymentReceived);
        }

        // GET: ManagePaymentReceiveds/Create
        public IActionResult Create()
        {
            ViewData["DepositedToAccountId"] = new SelectList(financialAccountRepository.GetAllFinancialAccounts(), "Id", "Name");
            return View();
        }

        // POST: ManagePaymentReceiveds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,CustomerId,CustomerName,Amount,BankCharges,ReferanceNumber,DepositedToAccountId")] PaymentReceived paymentReceived)
        {
            if (ModelState.IsValid)
            {
                paymentReceivedRepository.Add(paymentReceived);
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepositedToAccountId"] = new SelectList(financialAccountRepository.GetAllFinancialAccounts(), "Id", "Name", paymentReceived.DepositedToAccountId);
            return View(paymentReceived);
        }

        // GET: ManagePaymentReceiveds/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentReceived = paymentReceivedRepository.GetPaymentReceived((int)id);
            if (paymentReceived == null)
            {
                return NotFound();
            }
            ViewData["DepositedToAccountId"] = new SelectList(financialAccountRepository.GetAllFinancialAccounts(), "Id", "Name", paymentReceived.DepositedToAccountId);
            return View(paymentReceived);
        }

        // POST: ManagePaymentReceiveds/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,CustomerId,CustomerName,Amount,BankCharges,ReferanceNumber,DepositedToAccountId")] PaymentReceived paymentReceived)
        {
            if (id != paymentReceived.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    paymentReceivedRepository.Update(paymentReceived);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentReceivedExists(paymentReceived.Id))
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
            ViewData["DepositedToAccountId"] = new SelectList(financialAccountRepository.GetAllFinancialAccounts(), "Id", "Name", paymentReceived.DepositedToAccountId);
            return View(paymentReceived);
        }

        // GET: ManagePaymentReceiveds/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentReceived = paymentReceivedRepository.GetPaymentReceived((int)id);
            if (paymentReceived == null)
            {
                return NotFound();
            }

            return View(paymentReceived);
        }

        // POST: ManagePaymentReceiveds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            paymentReceivedRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentReceivedExists(int id)
        {
            return _context.paymentReceiveds.Any(e => e.Id == id);
        }
    }
}
