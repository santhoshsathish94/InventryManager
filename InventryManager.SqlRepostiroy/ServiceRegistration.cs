using InventryManager.SqlRepostiroy.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventryManager.SqlRepostiroy
{
    public static class ServiceRegistration
    {
        public static void AddSqlRepository(this IServiceCollection services)
        {
            services.AddTransient(typeof(ISqlRepository<>), typeof(SqlRepository<>));
            services.AddTransient(typeof(ISqlRepository<Product>), typeof(SqlRepository<Product>));
            services.AddTransient(typeof(ISqlRepository<Order>), typeof(SqlRepository<Order>));
            services.AddTransient(typeof(ISqlRepository<OrderDetail>), typeof(SqlRepository<OrderDetail>));
            services.AddTransient(typeof(ISqlRepository<Customer>), typeof(SqlRepository<Customer>));
            services.AddTransient(typeof(ISqlRepository<User>), typeof(SqlRepository<User>));
        }
    }
}
