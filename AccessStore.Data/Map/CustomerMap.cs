using System.Data.Entity.ModelConfiguration;
using AccessStore.Domain.Entities;

namespace AccessStore.Data.Map
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customer");
            HasKey(x => x.Id);
            Property(x => x.Name).IsRequired().HasMaxLength(60);
        }
    }
}
