using Dimchev.DiceRoller.Operative.Core.Contracts.Services;
using Dimchev.DiceRoller.Operative.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dimchev.DiceRoller.Operative.WebApi.Controllers
{
    [ApiController]
    [Route("api/dice")]
    [Authorize]
    public class DiceRollController(IDiceRollService diceRollService) : Controller
    {
        [HttpPost("roll")]
        public async Task<IActionResult> DiceRoll()
        {
            var userId = Guid.Parse(User.FindFirst("id").Value);
            var result = await diceRollService.DiceRollAsync(userId);
            return Ok(result);
        }

        [HttpGet("report")]
        public async Task<IActionResult> GetReport([FromQuery] GetDiceRollsRequest getRollsRequest)
        {
            var userId = Guid.Parse(User.FindFirst("id").Value);
            var results = await diceRollService.GetRollsAsync(userId, getRollsRequest);
            return Ok(results);
        }
    }
}
