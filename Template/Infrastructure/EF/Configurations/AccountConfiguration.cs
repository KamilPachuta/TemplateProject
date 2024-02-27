using Domain.Accounts;
using Domain.Accounts.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EF.Configurations;

internal sealed class AccountConfiguration :  IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable(TableNames.Accounts);
        builder.HasKey(a => a.Id);

        builder
            .Property(a => a.Email)
            .HasConversion(e => e.Value, e => new AccountEmail(e));

        builder
            .Property(a => a.PasswordHash)
            .HasConversion(ph => ph.Value, ph => AccountPasswordHash.Create(ph));

        builder
            .Property(a => a.Role)
            .HasConversion(r => r.Value, r => new AccountRole(r));


    }
}