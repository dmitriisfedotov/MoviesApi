namespace MoviesApi.Shared;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<Movie> Movies => Set<Movie>();

    public DbSet<Director> Directors => Set<Director>();

    public ApplicationContext()
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=sandbox-db;Port=5432;Database=sandboxdb;Username=sandboxdb-user;Password=password");
    }
}