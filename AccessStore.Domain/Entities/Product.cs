using FluentValidator.Validation;

namespace AccessStore.Domain.Entities
{
    public sealed class Product : Entity
    {
        protected Product()
        {
        }

        public Product(string title, decimal price)
        {
            Title = title;
            Price = price;

            new ValidationContract<Product>(this).IsRequired(x => x.Title).IsGreaterThan(x => x.Price, 0);
        }

        public string Title { get; private set; }
        public decimal Price { get; private set; }
    }
}
