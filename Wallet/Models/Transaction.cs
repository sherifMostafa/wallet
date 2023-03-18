using Wallet.Models.Identity;

namespace Wallet.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal TransferAmound { get; set; }
        public Guid BalanceId { get; set; }
        public string TransferTo { get; set; }
        public DateTime Transfer_date { get; set; }

        public Balance Balance { get; set; }
        public ApplicationUser User { get; set; }

    }
}
