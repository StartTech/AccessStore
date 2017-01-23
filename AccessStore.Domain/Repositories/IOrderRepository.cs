using System;
using AccessStore.Domain.Entities;

namespace AccessStore.Domain.Repositories
{
    public interface IOrderRepository
    {
        void Save(Order order);
        Order Get(Guid id);
    }
}
