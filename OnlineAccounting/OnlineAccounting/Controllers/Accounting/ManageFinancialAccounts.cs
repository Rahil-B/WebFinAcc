using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using OnlineAccounting.Models;
using OnlineAccounting.Models.Repositories;

namespace OnlineAccounting.Controllers
{
    public class ManageFinancialAccounts : Controller
    {
        IFinancialAccountRepository accountRepository;
        public ManageFinancialAccounts(IFinancialAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        
        public IActionResult Index()
        {
            var accounts = accountRepository.GetAllFinancialAccounts().ToList<FinancialAccount>();
            ViewBag.msg = TempData["IndexMsg"];
            TempData["IndexMsg"] = "";
            return View(accounts);
        }
        [HttpGet]
        public IActionResult create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult create(FinancialAccount newAccount)
        {
            if (ModelState.IsValid)
            {
                var ac = accountRepository.Add(newAccount);
                //string msg = "<strong>Created!</strong> new account <i>" + newAccount.Name+"</i>";
                string msg = "Created! new account \"" + newAccount.Name + "\"";
                TempData["IndexMsg"] = msg;
                return RedirectToAction(controllerName: "ManageFinancialAccounts", actionName: "Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            FinancialAccount acc = accountRepository.GetFinancialAccount(id);
            return View(acc);
        }
        [HttpPost]
        public IActionResult Edit(FinancialAccount updatedAccount)
        {
            if (ModelState.IsValid)
            {
                var acc = accountRepository.Update(updatedAccount);
                string msg = "Edited! account \"" + acc.Name +"\"";
                TempData["IndexMsg"] = msg;
                return RedirectToAction(controllerName: "ManageFinancialAccounts", actionName: "Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            FinancialAccount acc = accountRepository.GetFinancialAccount(id);
            return View(acc);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            FinancialAccount acc= accountRepository.Delete(id);
            string msg = "Deleted Account \"" + acc.Name+"\"";
            TempData["IndexMsg"] = msg;
            return RedirectToAction(controllerName:"ManageFinancialAccounts",actionName: "Index");
        }
    }
}