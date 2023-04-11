using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcVeve.Models;

namespace Carrosserie_Veve.Areas.Identity.Data;

public class Carrosserie_VeveIdentityDbContext : IdentityDbContext<IdentityUser>
{
     public DbSet<Prestation> Prestations { get; set; } = null!;
    public DbSet<Realisation> Realisations { get; set; } = null!;
    public DbSet<Horaire> Horaires { get; set; } = null!;
    public Carrosserie_VeveIdentityDbContext(DbContextOptions<Carrosserie_VeveIdentityDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<IdentityUser>()
        .ToTable("AspNetUsers", t => t.ExcludeFromMigrations());
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
