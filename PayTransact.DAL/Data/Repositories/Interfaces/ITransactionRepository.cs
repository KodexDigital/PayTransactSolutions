using PayTransact.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace PayTransact.Persistence.Data.Repositories.Interfaces
{
    public interface ITransactionRepository : IGenericRepository<Models.Models.Transaction>
    {
        double TotalTransaction(string customerId);
        IEnumerable<Models.Models.Transaction> GetAllTransactionByUser(string customerId);
    }
}
