using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PayTransact.Persistence.Data.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        IApplicationUserRepository ApplicationUserRepository { get; }
        ITransactionRepository TransactionRepository { get; }
        Task SaveAsync();
    }
}
