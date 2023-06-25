using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Wallet.JWT
{
    public class TokenResponse
    {
        public JwtSecurityToken Token { get; set; }
        public bool IsAdmin { get; set; }
    }
}
