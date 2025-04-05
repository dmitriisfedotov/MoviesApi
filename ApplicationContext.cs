namespace MoviesApi;
using Microsoft.EntityFrameworkCore;


public class ApplicationContext : DbContext
{
    public DbSet<Movie> Movies => Set<Movie>();
    public ApplicationContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=helloapp;Username=postgres;Password=eK193/iT4r-pr");
    }
}