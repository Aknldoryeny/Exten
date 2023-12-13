using Exten.Models.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Exten.Models
{
    public class AppCtx : IdentityDbContext<User>
    {
        public AppCtx(DbContextOptions<AppCtx> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<CategoryProduct> CategoriesProduct { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoriesForum> CategoriesForum { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Forum> User { get; set; }
    }
}
