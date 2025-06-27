using Microsoft.EntityFrameworkCore;

namespace AppServiceAzureDotnet9.Data;

public class WeatherContext : DbContext
{
    public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
    {
    }

    public DbSet<WeatherForecastEntity> WeatherForecasts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherForecastEntity>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Date).IsRequired();
            entity.Property(e => e.TemperatureC).IsRequired();
            entity.Property(e => e.Summary).HasMaxLength(100);
        });

        // Seed data
        modelBuilder.Entity<WeatherForecastEntity>().HasData(
            new WeatherForecastEntity { Id = 1, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(1)), TemperatureC = -5, Summary = "Freezing" },
            new WeatherForecastEntity { Id = 2, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(2)), TemperatureC = 2, Summary = "Bracing" },
            new WeatherForecastEntity { Id = 3, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(3)), TemperatureC = 8, Summary = "Chilly" },
            new WeatherForecastEntity { Id = 4, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(4)), TemperatureC = 15, Summary = "Cool" },
            new WeatherForecastEntity { Id = 5, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(5)), TemperatureC = 22, Summary = "Mild" }
        );
    }
}

public class WeatherForecastEntity
{
    public int Id { get; set; }
    public DateOnly Date { get; set; }
    public int TemperatureC { get; set; }
    public string? Summary { get; set; }
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
