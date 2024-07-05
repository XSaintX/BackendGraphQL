using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace API.GraphQL
{
    public class Query
    {
        [UseFiltering]
        public IQueryable<Customer> GetCustomers([Service] ICustomerService customerService)
        {
            return customerService.GetCustomersAndOrders();
            //context.Database.EnsureCreated();
            //return context.Customers
            //    .Include(o => o.Orders)
            //    .Include(a => a.Address);
        }

        [UseFiltering]        
        public IQueryable<Order> GetOrders([Service] IOrderService orderService)
        {
            return orderService.GetOrders();
            //context.Database.EnsureCreated();
            //return context.Orders
            //    .Include(c => c.Customer);
        }
    }
}
