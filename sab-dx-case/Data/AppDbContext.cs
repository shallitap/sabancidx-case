using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using sab_dx_case.Data.ApiModels;

namespace sab_dx_case.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Urun> Urunler { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Urun>()
                .Property(u => u.Fiyat)
                .HasColumnType("decimal(18,2)");

            builder.Entity<Urun>().Property(u => u.IsDeleted).HasDefaultValue(false);
        }
    }
}
