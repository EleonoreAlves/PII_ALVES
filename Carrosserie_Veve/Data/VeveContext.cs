using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MvcVeve.Models;

namespace MvcVeve.Data;

public class MvcVeveContext : DbContext
{
    public DbSet<Prestation> Prestations { get; set; } = null!;
    public DbSet<Realisation> Realisations { get; set; } = null!;
    public DbSet<Horaire> Horaires { get; set; } = null!;


    public string DbPath { get; private set; }

    public MvcVeveContext()
    {
        // Path to SQLite database file
        DbPath = "MvcVeve.db";
    }

    // The following configures EF to create a SQLite database file locally
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // Use SQLite as database
        options.UseSqlite($"Data Source={DbPath}");
        // Optional: log SQL queries to console
        //options.LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information);
    }
}