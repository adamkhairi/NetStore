using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NetStore.Shared.Models;

namespace NetStore.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // public virtual DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public virtual DbSet<CartItem> CartItems { get; set; }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }

    }
}