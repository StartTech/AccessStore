using System;
using System.Collections.Generic;

namespace AccessStore.Domain.Commands
{
    public class RegisterOrderCommand : ICommand
    {
        public RegisterOrderCommand()
        {
            Items = new List<RegiterOrderItemCommand>();
        }

        public Guid Customer { get; set; }
        public decimal Discount { get; set; }
        public decimal DeliveryFee { get; set; }
        public IList<RegiterOrderItemCommand> Items { get; set; }
    }

    public class RegiterOrderItemCommand : ICommand
    {
        public Guid Product { get; set; }
        public int Quantity { get; set; }
    }
}
