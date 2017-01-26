using System;
using System.Collections.Generic;
using AccessStore.Domain.Entities;

namespace AccessStore.Domain.Repositories
{
    public interface IProductRepository
    {
        Product Get(Guid id);
        IEnumerable<Product> Get();
    }
}
