using Microsoft.EntityFrameworkCore;
using System.Security.Principal;
using Wallet.Dto;
using Wallet.Models;
using Wallet.Persistence;

namespace Wallet.Repository.Transaction
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> TransferFund(TransactionDto transaction)
        {
            using (var transactionScope = _context.Database.BeginTransaction())
            {
                try
                {
                    // Deduct amount from sender's account
                    var senderBalance = await _context.Balance.FirstOrDefaultAsync(p => p.User.MobileNumber == transaction.FromMobile);          // FirstOrDefaultAsync(a => a.Mobile == transaction.FromMobile);
                    if (senderBalance == null || senderBalance.Balance_Amount < transaction.Amount)
                    {
                        transactionScope.Rollback();
                        return false;
                    }

                    senderBalance.Balance_Amount -= transaction.Amount;

                   

                    // Add amount to receiver's account
                    var receiverBalance = await _context.Balance.FirstOrDefaultAsync(a => a.User.MobileNumber == transaction.ToMobile);

                  

                    if (receiverBalance == null)
                    {
                        var userReceiver = await _context.User.FirstOrDefaultAsync(a => a.MobileNumber == transaction.ToMobile);

                        if(userReceiver == null) { transactionScope.Rollback(); return false; }

                        receiverBalance = new Wallet.Models.Balance { UserId = userReceiver.Id , Balance_Amount = transaction.Amount };
                        _context.Balance.Add(receiverBalance);
                    }
                    else
                    {
                        receiverBalance.Balance_Amount += transaction.Amount;
                    }

                    // Create Transction object and Save it
                    var transactionObj = new Wallet.Models.Transaction { UserId = senderBalance.UserId, TransferAmound = transaction.Amount, BalanceId = senderBalance.Id, Transfer_date = DateTime.UtcNow, TransferTo = receiverBalance.UserId };
                    _context.Transaction.Add(transactionObj);


                    transactionScope.Commit();
                    return true;
                }
                catch (Exception)
                {
                    transactionScope.Rollback();
                    return false;
                }
            }
        }
    }
}
