using Microsoft.EntityFrameworkCore;
using Wallet.Dto;
using Wallet.Persistence;

namespace Wallet.Repository.Report
{
    public class ReportRepository : IReportRepository
    {

        private readonly ApplicationDbContext _context;

        public ReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<UserTransactionDto> GetUserTransAction(string UserId)
        {
            var result = await _context.Transaction
            .Where(p => p.UserId == UserId)
            .Include(p => p.User)
            .Include(p => p.Balance)
            .Select(p => new
            {
                p.UserId,
                p.User.MobileNumber,
                p.Balance.Balance_Amount,
                p.TransferTo,
                p.TransferAmound,
                p.Transfer_date,
                RecipientMobileNumber = _context.User.FirstOrDefault(u => u.Id == p.TransferTo).MobileNumber
            })
            .ToListAsync();

            List<UserTransactionDto> userTransactions = result
            .GroupBy(t => new { t.UserId, t.MobileNumber, t.Balance_Amount })
            .Select(group => new UserTransactionDto
            {
            UserId = group.Key.UserId,
            MobileNumber = group.Key.MobileNumber,
            Balance_Amount = group.Key.Balance_Amount,
            TransactionOperations = group.Select(t => new TransactionOperationsDto
            {
                ToUserId = t.TransferTo,
                MobileNumber = t.RecipientMobileNumber,
                Transfer_date = t.Transfer_date,
                Amount = t.TransferAmound
            }).ToList()
            })
            .ToList();

            return userTransactions.FirstOrDefault();
        }
    }
}
