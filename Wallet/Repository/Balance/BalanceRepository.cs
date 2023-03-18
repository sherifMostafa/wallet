namespace Wallet.Repository.Balance
{
    public class BalanceRepository : IBalanceRepository
    {
        private readonly IBalanceRepository _balanceRepository;

        public BalanceRepository(IBalanceRepository balanceRepository, IConfiguration configuration)
        {
            _balanceRepository = balanceRepository;
            _configuration = configuration;
        }

        public Task GreatingBalance(int Balance)
        {
            throw new NotImplementedException();
        }

        public Task GreatingBalance(string UserId)
        {
            var user 

            throw new NotImplementedException();
        }
    }
}
