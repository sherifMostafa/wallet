using Wallet.Dto;

namespace Wallet.Repository.Report
{
    public interface IReportRepository
    {
        Task<UserTransactionDto> GetUserTransAction(string UserId);
    }
}
