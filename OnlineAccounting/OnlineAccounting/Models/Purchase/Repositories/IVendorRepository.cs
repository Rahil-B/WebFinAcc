using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase.Repositories
{
    public interface IVendorRepository
    {
        Vendor GetVendor(int Id);
        IEnumerable<Vendor> GetAllVendors();
        Vendor Add(Vendor vendor);
        Vendor Update(Vendor vendorChanged);
        Vendor Delete(int Id);
    }
}
