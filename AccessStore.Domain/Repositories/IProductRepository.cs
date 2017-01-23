using System;
using AccessStore.Domain.Entities;

namespace AccessStore.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(Guid id);
    }
}
