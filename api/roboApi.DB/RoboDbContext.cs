using Microsoft.EntityFrameworkCore;
using roboApi.DB.Entities;

namespace roboApi.DB;

public class RoboDbContext : DbContext
{
    public RoboDbContext(DbContextOptions options) : base(options)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.Entity<Robo>().Navigation(x => x.Direito).AutoInclude();
        modelBuilder.Entity<Robo>().Navigation(x => x.Esquerdo).AutoInclude();
        modelBuilder.Entity<Robo>().Navigation(x => x.Cabeca).AutoInclude();
    }
    public DbSet<Robo> Robos { get; set; }
    private DbSet<Braco> Bracos { get; set; }
    private DbSet<Cabeca> Cabecas { get; set; }
}
