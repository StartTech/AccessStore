using System;
using AccessStore.Data.Contexts;
using AccessStore.Domain.Entities;
using AccessStore.Domain.Repositories;

namespace AccessStore.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDataContext _context;

        public OrderRepository(AppDataContext context)
        {
            _context = context;
        }

        public void Save(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public Order Get(Guid id)
        {
            return _context.Orders.Find(id);
        }
    }
}
