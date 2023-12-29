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

        [HttpGet]
        public ActionResult<IEnumerable<BuyProcedure>> GetAll()
        {
            return Ok(buyProcedureService.GetAll());
        }

        [HttpPost("{title}")]
        public IActionResult Create(string title)
        {
            var id = buyProcedureService.Create(title);
            return Ok(id);
        }

        [HttpPost]
        public IActionResult Create()
        {
            var id = buyProcedureService.Create();
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(buyProcedureService.Delete(id))
            {
                return Ok();
            }
            else
            {
                logger.LogError("No object found with id {Id}", id);
                return StatusCode(StatusCodes.Status400BadRequest);
            }
        }
    }
}