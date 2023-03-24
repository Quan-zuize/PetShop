using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetShop.Models;

namespace PetShopAdmin.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PetShop.Models.CauHinh> CauHinh { get; set; }
        public DbSet<PetShop.Models.Category> Category { get; set; }
        public DbSet<PetShop.Models.BannerImage> BannerImage { get; set; }
        public DbSet<PetShop.Models.Product> Product { get; set; }

    }
}