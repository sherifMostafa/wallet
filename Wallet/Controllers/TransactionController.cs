using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wallet.Dto;
using Wallet.JWT;
using Wallet.Repository.Transaction;
using Wallet.UnitOfWork;

namespace Wallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TransactionController(ILogger<TransactionController> logger, ITransactionRepository transactionRepository , IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork; 
        }

        [HttpPost]
        public async Task<IActionResult> TransferFund(TransactionDto transaction)
        {
            if (await _transactionRepository.TransferFund(transaction))
            {
                await _unitOfWork.SaveChangesAsync();
                return Ok(new Response { Status = "200", Message = "Transfered Successfully" });
            }
            else { return BadRequest(); }
        }
    }
}
