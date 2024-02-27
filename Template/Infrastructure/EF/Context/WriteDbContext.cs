using Domain.Accounts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EF.Context;

internal sealed class WriteDbContext : DbContext
{
    public DbSet<Account> Accounts { get; set; }

    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("Server"); //Change in new project

        modelBuilder.AddEFConfig();
    }
}