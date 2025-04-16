namespace MoviesApi.Shared;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<Movie> Movies => Set<Movie>();

    public DbSet<Director> Directors => Set<Director>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=moviesdb;Username=movies-user;Password=password");
    }
}