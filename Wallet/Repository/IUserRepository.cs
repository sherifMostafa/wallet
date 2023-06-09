using Microsoft.AspNetCore.Identity;
using Wallet.Dto;
using Wallet.Models.Identity;

namespace Wallet.Repository
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserByEmailAsync(string moblie);
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        Task<SignInResult> PasswordSignInAsync(LoginVM login);
        Task SignOutAsync();
        Task<List<UserDto>> GetAllUser();
    }
}
