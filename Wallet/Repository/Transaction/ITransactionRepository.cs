using Wallet.Dto;

namespace Wallet.Repository.Transaction
{
    public interface ITransactionRepository
    {
        Task<bool> TransferFund(TransactionDto transaction);
    }
}
