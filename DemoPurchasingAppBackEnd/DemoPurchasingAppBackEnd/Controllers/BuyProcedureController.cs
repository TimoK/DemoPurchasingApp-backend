using DemoPurchasingAppBackEnd.DataModels;
using Microsoft.AspNetCore.Mvc;

namespace DemoPurchasingAppBackEnd.Controllers
{
    [ApiController]
    [Route("/")]
    public class BuyProcedureController : ControllerBase
    {
        private readonly ILogger<BuyProcedureController> _logger;

        public BuyProcedureController(ILogger<BuyProcedureController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetBuyProcedure")]
        public IEnumerable<BuyProcedureModel> Get()
        {
            var buyProcedures = new List<BuyProcedureModel>
            {
                new BuyProcedureModel()
                {
                    Title = "Moersleutels",
                    MaxPrice = 25000
                },
                new BuyProcedureModel()
                {
                    Title = "Bedrijfsauto's",
                    MaxPrice = 200340
                }
            };
            return buyProcedures;
        }

        [HttpGet("newroute")]
        public IEnumerable<BuyProcedureModel> GetNewThings()
        {
            var buyProcedures = new List<BuyProcedureModel>
            {
                new BuyProcedureModel()
                {
                    Title = "Andere dingen",
                    MaxPrice = 2500
                },
                new BuyProcedureModel()
                {
                    Title = "Spullen",
                    MaxPrice = 4567
                }
            };
            return buyProcedures;
        }
    }
}