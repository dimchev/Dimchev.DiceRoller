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
        public async Task<IActionResult> RollDice()
        {
            var userId = Guid.Parse(User.FindFirst("id").Value);
            var result = await diceRollService.RollDiceAsync(userId);
            return Ok(result);
        }

        [HttpGet("rolls")]
        public async Task<IActionResult> GetRolls([FromQuery] GetRollsRequest getRollsRequest)
        {
            var userId = Guid.Parse(User.FindFirst("id").Value);
            var results = await diceRollService.GetRollsAsync(userId, getRollsRequest);
            return Ok(results);
        }
    }
}
