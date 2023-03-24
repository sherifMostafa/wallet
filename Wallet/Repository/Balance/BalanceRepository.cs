using Wallet.Models;
using Wallet.Models.Identity;
using Wallet.Persistence;

namespace Wallet.Repository.Balance
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<BalanceRepository> _logger;
        private readonly ApplicationDbContext _context;


        public BalanceRepository(IConfiguration configuration , ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public void GreatingBalance(ApplicationUser user)
        {
            Wallet.Models.Balance balance = new Models.Balance()
            {
                Id = new Guid(user.Id),
                Balance_Amount = Decimal.Parse(_configuration["GreatingBalance"]),
                UserId =  user.Id
            };

            _context.Balance.Add(balance);
        }
    }
}
