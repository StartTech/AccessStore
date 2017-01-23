using FluentValidator.Validation;

namespace AccessStore.Domain.Entities
{
    public sealed class OrderItem : Entity
    {
        protected OrderItem() { }
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;

            new ValidationContract<OrderItem>(this)
                .IsGreaterThan(x => x.Quantity, 0);
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }

        public decimal Total()
        {
            return Product.Price * Quantity;
        }
    }
}
