using PayTransact.Models.Models;
using PayTransact.Persistence.DAL;
using PayTransact.Persistence.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayTransact.Persistence.Data.Repositories.Implementor
{
    public class ApplicationUserRepository : GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        private readonly AppDbContext dbContext;

        public ApplicationUserRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
