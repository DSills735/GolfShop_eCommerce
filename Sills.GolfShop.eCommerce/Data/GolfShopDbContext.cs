using Microsoft.EntityFrameworkCore;
using Sills.GolfShop.eCommerceAPI.Models;

namespace Sills.GolfShop.eCommerceAPI.Data
{
    public class GolfShopDbContext(DbContextOptions<GolfShopDbContext> options) : DbContext(options)
    {

            public DbSet<Product> Products { get; set; }
            public DbSet<Categories> Categories { get; set; }
            public DbSet<Sales> Sales { get; set; }
            public DbSet<ProductSales> ProductSales { get; set; }
    }
}


