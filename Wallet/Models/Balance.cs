using Wallet.Models.Identity;

namespace Wallet.Models
{
    public class Balance
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public decimal Balance_Amount { get; set; }

        public ApplicationUser User { get; set; }


        #region Audits
        public DateTime? CreatedAt { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        #endregion
    }
}
