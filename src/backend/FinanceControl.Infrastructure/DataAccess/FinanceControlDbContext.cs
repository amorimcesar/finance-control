using FinanceControl.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinanceControl.Infrastructure.DataAccess;

public class FinanceControlDbContext : DbContext
{
    public FinanceControlDbContext(DbContextOptions options) : base(options) {}
    public DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinanceControlDbContext).Assembly);
    }
}