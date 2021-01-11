using grpc.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace grpc.Infrastructure
{
    public class EShoppingContext : DbContext
    {
        public EShoppingContext(DbContextOptions<EShoppingContext> options) : base(options)
        {
        }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }

    }
}
