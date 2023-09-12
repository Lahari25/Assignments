using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Models
{
    public class Product
    {
       
            public int ProductId { get; set; }
            public string ProductName { get; set; }
            public int Quantity { get; set; }
            public int UnitPrice { get; set; }
        public string Category { get; set; }
    }

        public class PProductDbContext : DbContext
        {
            public DbSet<Product> Products { get; set; }

            public PProductDbContext(DbContextOptions<PProductDbContext> options)
             : base(options)
            {

            }
        }
    }

