using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineAccounting.Models;
using OnlineAccounting.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Components;

namespace OnlineAccounting.Controllers
{
    public class ManageItems : Controller
    {
        private IItemRepository itemRepository;
        private IFinancialAccountRepository accountRepository;
        public ManageItems(IItemRepository itemRepository, IFinancialAccountRepository accountRepository)
        {
            this.itemRepository = itemRepository;
            this.accountRepository = accountRepository;
        }
        public IActionResult Index()
        {
            List<Item> items = itemRepository.GetAllItems().ToList<Item>();
            items.ForEach(i =>
            {
                i.Account = accountRepository.GetFinancialAccount(i.AccountId);
            });
            return View(items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Console.WriteLine(accountRepository.GetAllFinancialAccounts().Count());
            Console.WriteLine("###########################$$$$$$$$$$$$$$$$$$$$$$$$$$$");
            ViewBag.AccountId = new SelectList(accountRepository.GetAllFinancialAccounts().ToList<FinancialAccount>(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Item newItem)
        {
            //Console.WriteLine("Item Created");
            if (ModelState.IsValid)
            {
                /*
                var itm = new Item()
                {
                    AccountId=newItem.AccountId,
                    Account=accountRepository.GetFinancialAccount(newItem.AccountId),
                    CostPrice=newItem.CostPrice,
                    DefaultTaxRate=newItem.DefaultTaxRate,
                    HSNCode=newItem.HSNCode,
                    IsTaxable=newItem.IsTaxable,
                    Name=newItem.Name,
                    SellingPrice=newItem.SellingPrice
                };
                */
                newItem.Account = accountRepository.GetFinancialAccount(newItem.AccountId);
                Console.WriteLine(newItem.Account.Id);
                var itm=itemRepository.Add(newItem);
                return RedirectToAction(controllerName: "ManageItems", actionName: "Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Item itm = itemRepository.GetItem(id);
            ViewBag.AccountId = new SelectList(accountRepository.GetAllFinancialAccounts().ToList<FinancialAccount>(), "Id", "Name");
            return View(itm);
        }
        [HttpPost]
        public IActionResult Edit(Item updatedItem)
        {
            if (ModelState.IsValid)
            {
                itemRepository.Update(updatedItem);
                return RedirectToAction(controllerName: "ManageItems", actionName: "Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Item itm = itemRepository.GetItem(id);
            itm.Account = accountRepository.GetFinancialAccount(itm.AccountId);
            return View(itm);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            itemRepository.Delete(id);
            return RedirectToAction(controllerName: "ManageItems", actionName: "Index");
        }
    }
}
