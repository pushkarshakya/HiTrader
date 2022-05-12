using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HiTrader.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RewardController : ControllerBase
    {
        //private readonly ILogger<RewardController> _logger;

        public RewardController()   //(ILogger<RewardController> logger)
        {
            //_logger = logger;
        }

        [HttpGet]
        [Route("{purchase}")]
        public int Get(decimal purchase = 0)
        {
            int reward = 0;

            if (purchase > 50)
                reward += (int)purchase - 50;

            if (purchase > 100)
                reward += (int)purchase - 100;

            return reward;
        }
    }
}
