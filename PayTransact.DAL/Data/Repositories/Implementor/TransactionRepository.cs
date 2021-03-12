using PayTransact.Models.Models;
using PayTransact.Persistence.DAL;
using PayTransact.Persistence.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace PayTransact.Persistence.Data.Repositories.Implementor
{
    public class TransactionRepository : GenericRepository<Models.Models.Transaction>, ITransactionRepository
    {
        private readonly AppDbContext dbContext;

        public TransactionRepository(AppDbContext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Models.Models.Transaction> GetAllTransactionByUser(string customerId)
            => dbContext.Transactions.Where(x => x.CustomerId.Equals(customerId)).ToList();

        public double TotalTransaction(string customerId)
        {
            var cust = dbContext.Transactions.Where(x => x.CustomerId.Equals(customerId));
            return cust.Sum(x => x.InvestedAmount);
        }
    }
}
