using System;
using AccessStore.Domain.Entities;

namespace AccessStore.Domain.Repositories
{
    public interface ICustomerRepository
    {
        Customer Get(Guid id);
    }
}
