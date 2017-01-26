using System;
using System.Collections.Generic;
using System.Linq;
using AccessStore.Data.Contexts;
using AccessStore.Domain.Entities;
using AccessStore.Domain.Repositories;

namespace AccessStore.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDataContext _context;

        public ProductRepository(AppDataContext context)
        {
            _context = context;
        }


        public Product Get(Guid id)
        {
            return _context.Products.Find(id);
        }

        public IEnumerable<Product> Get()
        {
            return _context.Products.ToList();
        }
    }
}
