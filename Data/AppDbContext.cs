using Microsoft.EntityFrameworkCore;
using Forecast.Api.Models;

namespace Forecast.Api.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<CsvImport> CsvImports { get; set; }
    public DbSet<SimulatedProject> SimulatedProjects { get; set; }
    public DbSet<UserCommitment> UserCommitments { get; set; }
}
