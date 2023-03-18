using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Wallet.Models;

namespace Wallet.Persistence.DomainsMapping
{
    public class TransactionMap : IEntityTypeConfiguration<Transaction>
    {

        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transactions", "dbo");

            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.User).WithMany().HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Balance).WithMany().HasForeignKey(p => p.BalanceId).OnDelete(DeleteBehavior.Restrict);

        }


    }
}
