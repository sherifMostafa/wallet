using System.ComponentModel.DataAnnotations;

namespace Wallet.Dto
{
    public class TransactionDto
    {
        [Required(ErrorMessage = "From Mobile is required")]
        public string FromMobile { get; set; }
        [Required(ErrorMessage = "To Mobile is required")]
        public string ToMobile { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public decimal Amount { get; set; }
    }
}
