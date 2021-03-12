using PayTransact.Models.Models;
using PayTransact.Persistence.DAL;
using PayTransact.Persistence.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PayTransact.Persistence.Data.Repositories.Implementor
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDbContext dbContext;

        public ProductRepository(AppDbContext dbContext): base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
