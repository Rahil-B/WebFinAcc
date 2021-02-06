using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineAccounting.Models;
using OnlineAccounting.Models.Purchase;
using OnlineAccounting.Models.Purchase.Repositories;
using OnlineAccounting.Models.Repositories;

namespace OnlineAccounting.Controllers.Purchase
{
    public class ManageVendors : Controller
    {
        private readonly OnlineAccountingDbContext _context;
        private readonly IVendorRepository vendorRepository;
        private readonly IFinancialAccountRepository financialAccountRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public ManageVendors(OnlineAccountingDbContext context, IVendorRepository vendorRepository, IFinancialAccountRepository financialAccountRepository,IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            this.vendorRepository = vendorRepository;
            this.financialAccountRepository = financialAccountRepository;
            this.httpContextAccessor = httpContextAccessor;
        }

        // GET: ManageVendors
        public IActionResult Index()
        {
            return View(vendorRepository.GetAllVendors());
        }

        // GET: ManageVendors/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = vendorRepository.GetVendor((int)id);
            if (vendor == null)
            {
                return NotFound();
            }

            return View(vendor);
        }

        // GET: ManageVendors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManageVendors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendor vendor)
        {
            if (ModelState.IsValid)
            {
                vendorRepository.Add(vendor);
                
                return RedirectToAction(nameof(Index));
            }
            return View(vendor);
        }

        // GET: ManageVendors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = vendorRepository.GetVendor((int)id);
            if (vendor == null)
            {
                return NotFound();
            }
            return View(vendor);
        }

        // POST: ManageVendors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendor vendor)
        {
            if (id != vendor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    vendorRepository.Update(vendor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VendorExists(vendor.Id))
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
            return View(vendor);
        }

        // GET: ManageVendors/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vendor = vendorRepository.GetVendor((int)id);
            if (vendor == null)
            {
                return NotFound();
            }
            return View(vendor);
        }

        // POST: ManageVendors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            vendorRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool VendorExists(int id)
        {
            return _context.vendors.Any(e => e.Id == id);
        }
    }
}
