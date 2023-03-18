using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Wallet.Models.Identity;

namespace Wallet.Extenstions
{
    public static class UserManagerExtensions
    {
        public static async Task<ApplicationUser> FindByMobileNumberAsync(this UserManager<ApplicationUser> userManager, string mobileNumber)
        {
            var user = await userManager.Users.SingleOrDefaultAsync(x => x.MobileNumber == mobileNumber);
            return user;
        }
    }
}
