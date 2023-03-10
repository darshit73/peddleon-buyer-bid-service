using ClassLibrary1;
using Microsoft.EntityFrameworkCore;

namespace SumuraiApp.Data;

public class SamuraiContext: DbContext
{

    public DbSet<Samurai> Samurais { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<Battle> Battles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //whenever you use windows authentication integrated security must be true
        optionsBuilder.UseSqlServer(
            "Data Source=DESKTOP-1VJLI7P;Initial Catalog=SamuraiApplicationDb;TrustServerCertificate=True;Integrated Security=True");
    }

   

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<Samurai>()
            .HasMany(s => s.Battles)
            .WithMany(b => b.Samurais)
            .UsingEntity<BattleSamurai>
            (bs => bs.HasOne<Battle>().WithMany(),
                bs => bs.HasOne<Samurai>().WithMany())
        .Property(bs => bs.DateJoined)
        .HasDefaultValueSql("getdate()");
    }
}