using MarcasAutos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarcasAutos.Infrastructure.Persistence;

public class AutosMarcasDbContext : DbContext
{
    private readonly string _defaultSchema;
    public AutosMarcasDbContext(DbContextOptions<AutosMarcasDbContext> options, IConfiguration configuration) : base(options)
    {
        _defaultSchema = configuration.GetSection("Database")["Schema"] ?? "public";
    }

    public DbSet<MarcaAutoEntity> MarcasAutos => Set<MarcaAutoEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(_defaultSchema);

        modelBuilder.Entity<MarcaAutoEntity>().HasData(
        new
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Name = "Toyota",
            CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc),
            UpdatedAt = (DateTime?)null,
            DeletedAt = (DateTime?)null,
            IsActive = true
        },
        new
        {
            Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            Name = "Honda",
            CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc),
            UpdatedAt = (DateTime?)null,
            DeletedAt = (DateTime?)null,
            IsActive = true
        },
        new
        {
            Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            Name = "Mazda",
            CreatedAt = new DateTime(2025, 01, 01, 0, 0, 0, DateTimeKind.Utc),
            UpdatedAt = (DateTime?)null,
            DeletedAt = (DateTime?)null,
            IsActive = true
        }
    );

        base.OnModelCreating(modelBuilder);
    }
}
