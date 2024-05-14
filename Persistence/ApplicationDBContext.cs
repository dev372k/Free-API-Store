using Microsoft.EntityFrameworkCore;
using Persistence.Entities;
using System.Data;

namespace Persistence
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> opt) : base(opt) { }
        public DbSet<User> Users => Set<User>();
        public DbSet<Category> Categories => Set<Category>();
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Todo> Todos => Set<Todo>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(_ => !_.IsDeleted);
            modelBuilder.Entity<Order>().HasQueryFilter(_ => !_.IsDeleted);
            modelBuilder.Entity<Category>().HasQueryFilter(_ => !_.IsDeleted);
            modelBuilder.Entity<Product>().HasQueryFilter(_ => !_.IsDeleted);
            modelBuilder.Entity<Todo>().HasQueryFilter(_ => !_.IsDeleted);
        }
    }
}
