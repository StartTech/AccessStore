using System;
using AccessStore.Data.Contexts;
using AccessStore.Domain.Entities;
using AccessStore.Domain.Repositories;

namespace AccessStore.Data.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDataContext _context;

        public CustomerRepository(AppDataContext context)
        {
            _context = context;
        }
        
        public Customer Get(Guid id)
        {
            return _context.Customers.Find(id);
        }
    }
}
