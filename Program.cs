using Microsoft.EntityFrameworkCore;
using MoviesApi.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationContext>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();

    ApplyMigration<ApplicationContext>(scope);
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
return;

static void ApplyMigration<TDbContext>(IServiceScope scope)
    where TDbContext : DbContext
{
    using var context = scope.ServiceProvider.GetRequiredService<TDbContext>();
    context.Database.Migrate();
}
