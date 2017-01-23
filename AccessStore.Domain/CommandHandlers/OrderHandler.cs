using System;
using AccessStore.Domain.Commands;
using AccessStore.Domain.Entities;
using AccessStore.Domain.Repositories;

namespace AccessStore.Domain.CommandHandlers
{
    public class OrderHandler : ICommandHandler<RegisterOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;

        public OrderHandler(IOrderRepository orderRepository, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public void Handle(RegisterOrderCommand command)
        {
            var customer = _customerRepository.Get(command.Customer);
            var order = new Order(command.Discount, command.DeliveryFee, customer);
            foreach (var item in command.Items)
            {
                var product = _productRepository.Get(item.Product);
                var orderItem = new OrderItem(product, item.Quantity);
                order.AddItem(orderItem);
            }

            try
            {
                _orderRepository.Save(order);
                // Envia e-mail confirmando
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
