using Microsoft.AspNetCore.Mvc;
using MiniRater.BL;
using MiniRater.BL.Dto;
using System.Threading.Tasks;

namespace MiniRater.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RateController : ControllerBase
    {
        private readonly IRateService _rateService;

        public RateController(IRateService rateService)
        {
            _rateService = rateService;
        }

        [HttpPost]
        [Route("Get-Total-Premium")]
        [ProducesResponseType(typeof(PremiumResponseDto), 200)]
        public async Task<IActionResult> GetTotalPremium(PremiumRequestDto premiumRequestDto)
        {
            return new OkObjectResult(await _rateService.GetTotalPremium(premiumRequestDto));
        }
    }
}
