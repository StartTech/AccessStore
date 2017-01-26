using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Data.SqlClient;
using AccessStore.Data.Contexts;
using AccessStore.Domain.Entities;
using AccessStore.Domain.QueryResults;
using AccessStore.Domain.Repositories;
using Dapper;

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
            return _context
                .Orders
                .Include(x => x.Items)
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<GetOrderQueryResult> Get(string number)
        {
            using (var conn = new SqlConnection(@"Server=.\sqlexpress;Database=access;User ID=sa;Password=sqlexpress;"))
            {
                return conn.Query<GetOrderQueryResult>("SELECT * FROM [ListOrder] WHERE [Number]=@number", new { number = number});
            }
        }

        public IEnumerable<Order> Get()
        {
            return _context.Orders.ToList();
        }
    }
}
