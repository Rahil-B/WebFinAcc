using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Repositories
{
    public interface IFinancialAccountRepository
    {
        FinancialAccount GetFinancialAccount(int Id);
        IEnumerable<FinancialAccount> GetAllFinancialAccounts();
        FinancialAccount Add(FinancialAccount financialAccount);
        FinancialAccount Update(FinancialAccount financialAccountChanges);
        FinancialAccount Delete(int Id);
    }
}
