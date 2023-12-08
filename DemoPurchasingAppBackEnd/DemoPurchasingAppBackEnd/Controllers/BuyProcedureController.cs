using Microsoft.AspNetCore.Mvc;

namespace DemoPurchasingAppBackEnd.Controllers
{
    [ApiController]
    [Route("buyprocedure")]
    public class BuyProcedureController : ControllerBase
    {
        private readonly ILogger<BuyProcedureController> _logger;

        public BuyProcedureController(ILogger<BuyProcedureController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBuyProcedure")]
        public IEnumerable<BuyProcedure> Get()
        {
            var buyProcedures = new List<BuyProcedure>
            {
                new BuyProcedure()
                {
                    Title = "Moersleutels",
                    MaxPrice = 25000
                },
                new BuyProcedure()
                {
                    Title = "Bedrijfsauto's",
                    MaxPrice = 200340
                }
            };
            return buyProcedures;
        }

        [HttpGet("newroute")]
        public IEnumerable<BuyProcedure> GetNewThings()
        {
            var buyProcedures = new List<BuyProcedure>
            {
                new BuyProcedure()
                {
                    Title = "Andere dingen",
                    MaxPrice = 2500
                },
                new BuyProcedure()
                {
                    Title = "Spullen",
                    MaxPrice = 4567
                }
            };
            return buyProcedures;
        }
    }
}