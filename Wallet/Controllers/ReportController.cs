using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Wallet.Dto;
using Wallet.JWT;
using Wallet.Repository;
using Wallet.Repository.Report;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Wallet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = UserRoles.Admin)]
    public class ReportController : ControllerBase
    {
        private readonly IReportRepository _reportRepository;
        private readonly IUserRepository _userRepository;

        public ReportController(IReportRepository reportRepository, IUserRepository userRepository)
        {
             _reportRepository = reportRepository;
             _userRepository = userRepository;
        }
        // GET: api/<ReportController>

        [HttpGet("GetUserTransAction/{userId}")]
        public async Task<ActionResult<UserTransactionDto>> Get(string userId)
        {
            return Ok(await _reportRepository.GetUserTransAction(userId));
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            return Ok(await _userRepository.GetAllUser());
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
