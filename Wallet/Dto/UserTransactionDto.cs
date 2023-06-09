namespace Wallet.Dto
{
    public class UserTransactionDto
    {
        public string UserId { get; set; }
        public decimal Balance_Amount { get; set; }
        public string MobileNumber { get; set; }
        public List<TransactionOperationsDto> TransactionOperations { get; set; } = new List<TransactionOperationsDto>();
    }

    public class TransactionOperationsDto
    {
        public string ToUserId { get; set; }
        public string MobileNumber { get; set; }
        public DateTime Transfer_date { get; set; }
        public decimal Amount { get; set; }

    }
}
