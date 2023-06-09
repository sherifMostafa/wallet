using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wallet.Dto;
using Wallet.JWT;
using Wallet.Repository.Report;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class ReportController : ControllerBase
    {
        private IReportRepository _reportRepository;
        public ReportController(IReportRepository reportRepository)
        {
             _reportRepository = reportRepository;
        }
        // GET: api/<ReportController>

        [HttpGet("GetUserTransAction/{userId}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<UserTransactionDto>> Get(string userId)
        {
            return Ok(await _reportRepository.GetUserTransAction(userId));
        }

        // POST api/<ReportController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReportController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReportController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
