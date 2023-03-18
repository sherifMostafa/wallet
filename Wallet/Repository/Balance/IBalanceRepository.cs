namespace Wallet.Repository.Balance
{
    public interface IBalanceRepository
    {
        Task GreatingBalance(int Balance , string UserId);
    }
}
