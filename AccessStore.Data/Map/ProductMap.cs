using System.Data.Entity.ModelConfiguration;
using AccessStore.Domain.Entities;

namespace AccessStore.Data.Map
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");
            HasKey(x => x.Id);
            Property(x => x.Title).IsRequired().HasMaxLength(80);
        }
    }
}
