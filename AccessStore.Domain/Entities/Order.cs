using System;
using System.Collections.Generic;
using System.Linq;
using AccessStore.Domain.Enums;
using FluentValidator.Validation;

namespace AccessStore.Domain.Entities
{
    public sealed class Order : Entity
    {
        protected Order()
        {
        }

        public Order(decimal discount, decimal deliveryFee, Customer customer)
        {
            Number = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
            CreateDate = DateTime.Now;
            LastUpdateDate = DateTime.Now;
            Status = EStatus.Created;
            Discount = discount;
            DeliveryFee = deliveryFee;
            Customer = customer;
            Items = new List<OrderItem>();

            new ValidationContract<Order>(this)
                .IsGreaterThan(x => x.Discount, -1)
                .IsGreaterThan(x => x.DeliveryFee, -1);
        }

        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public EStatus Status { get; private set; }
        public decimal Discount { get; private set; }
        public decimal DeliveryFee { get; private set; }
        public Customer Customer { get; private set; }
        public ICollection<OrderItem> Items { get; private set; }

        public decimal SubTotal() => Items.Sum(item => item.Total());

        public decimal Total() => (SubTotal() - Discount + DeliveryFee);

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
            AddNotifications(item.Notifications);
        }
    }
}
