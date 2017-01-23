using FluentValidator.Validation;

namespace AccessStore.Domain.Entities
{
    public sealed class Customer : Entity
    {
        protected Customer()
        {
        }

        public Customer(string name)
        {
            Name = name;

            new ValidationContract<Customer>(this).IsRequired(x => x.Name);
        }

        public string Name { get; private set; }
    }
}
