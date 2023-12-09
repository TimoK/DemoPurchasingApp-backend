using DemoPurchasingAppBackEnd.Entities;
using DemoPurchasingAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;

namespace DemoPurchasingAppBackEnd.Controllers
{
    [ApiController]
    [Route("buyprocedures")]
    public class BuyProcedureController : ControllerBase
    {
        private readonly IBuyProcedureService buyProcedureService;
        private readonly ILogger<BuyProcedureController> logger;

        public BuyProcedureController(IBuyProcedureService buyProcedureService, ILogger<BuyProcedureController> logger)
        {
            this.buyProcedureService = buyProcedureService;
            this.logger = logger;
        }

        [HttpGet(Name = "GetBuyProcedures")]
        public IEnumerable<BuyProcedure> Get()
        {
            return buyProcedureService.GetAll();
        }
    }
}