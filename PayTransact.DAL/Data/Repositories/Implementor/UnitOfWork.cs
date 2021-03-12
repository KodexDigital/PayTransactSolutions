using PayTransact.Persistence.DAL;
using PayTransact.Persistence.Data.Repositories.Interfaces;
using System.Threading.Tasks;

namespace PayTransact.Persistence.Data.Repositories.Implementor
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IProductRepository ProductRepository => new ProductRepository(dbContext);
        public IApplicationUserRepository ApplicationUserRepository => new ApplicationUserRepository(dbContext);
        public ITransactionRepository TransactionRepository => new TransactionRepository(dbContext);

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public async Task SaveAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
