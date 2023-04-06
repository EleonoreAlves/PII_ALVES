using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcVeve.Models;

namespace Carrosserie_Veve.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Prestation> Prestations { get; set; } = null!;
    public DbSet<Realisation> Realisations { get; set; } = null!;
    public DbSet<Horaire> Horaires { get; set; } = null!;
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
