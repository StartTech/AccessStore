using System.Data.Entity.ModelConfiguration;
using AccessStore.Domain.Entities;

namespace AccessStore.Data.Map
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("Order");
            HasKey(x => x.Id);
            HasMany(x => x.Items);
        }
    }
}
