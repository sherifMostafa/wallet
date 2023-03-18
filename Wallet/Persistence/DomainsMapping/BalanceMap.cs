using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Wallet.Models;

namespace Wallet.Persistence.DomainsMapping
{
    public class BalanceMap : IEntityTypeConfiguration<Balance>
    {

        public void Configure(EntityTypeBuilder<Balance> builder)
        {
            builder.ToTable("Balance", "dbo");

            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);

        }


    }
}
