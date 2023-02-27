using BussinessModel;
using Microsoft.EntityFrameworkCore;

namespace Shopping_center.Models
{
    public class ProductDBContext : DbContext
    {
        public ProductDBContext (DbContextOptions<ProductDBContext> options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<PurchaseProduct> PurchaseProducts { get; set; }
        public string ContentRootPath { get; internal set; }
    }
}
