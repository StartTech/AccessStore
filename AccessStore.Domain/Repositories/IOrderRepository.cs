using System;
using System.Collections.Generic;
using AccessStore.Domain.Entities;
using AccessStore.Domain.QueryResults;

namespace AccessStore.Domain.Repositories
{
    public interface IOrderRepository
    {
        void Save(Order order);
        Order Get(Guid id);
        IEnumerable<GetOrderQueryResult> Get(string number);
    }
}
