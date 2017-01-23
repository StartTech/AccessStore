using System;
using AccessStore.Data.Contexts;
using AccessStore.Data.Repositories;
using AccessStore.Domain.CommandHandlers;
using AccessStore.Domain.Commands;
using AccessStore.Domain.Repositories;

namespace AccessStore.Ui
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new AppDataContext();
            IOrderRepository orderRepository = new OrderRepository(context);
            ICustomerRepository customerRepository = new CustomerRepository(context);
            IProductRepository productRepository = new ProductRepository(context);
            var handler = new OrderHandler(orderRepository, customerRepository, productRepository);
            var command = new RegisterOrderCommand
            {
                Customer = new Guid("39B5DCE8-3E5C-4D11-9F1A-27A34A5BB0EE"),
                DeliveryFee = 5,
                Discount = 2.98M
            };

            command.Items.Add(new RegiterOrderItemCommand
            {
                Product = new Guid("1F126C38-174B-437F-AD6E-B4F56819A2B7"),
                Quantity = 1
            });
            handler.Handle(command);
            
            Console.WriteLine("Pedido Salvo");
            Console.ReadKey();
        }
    }
}
