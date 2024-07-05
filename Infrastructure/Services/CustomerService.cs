using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IDbContextFactory<OMAContext> _contextFactory;
        public CustomerService(IDbContextFactory<OMAContext> contextFactory)
        {
            _contextFactory=contextFactory;


        }
        public IQueryable<Customer> GetCustomersAndOrders()
        {
            var context = _contextFactory.CreateDbContext();
            context.Database.EnsureCreated();
            return context.Customers
                .Where(c => !c.IsDeleted)
                .Include(c => c.Orders)
                .Include(c => c.Address);
            
        }
    }
}
