using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineAccounting.Models.Purchase.Repositories
{
    public interface IExpenseRepository
    {
        Expense GetExpense(int Id);
        IEnumerable<Expense> GetAllExpenses();
        Expense Add(Expense expense);
        Expense Update(Expense expenseChanged);
        Expense Delete(int Id);
    }
}
