using Microsoft.AspNetCore.Identity;

namespace Wallet.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string MobileNumber { get; set; }
    }
}
