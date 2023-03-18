using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Wallet.Dto
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Mobile is required")]
        public string? Mobile { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

    }
}
