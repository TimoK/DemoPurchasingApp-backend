using DemoPurchasingAppBackEnd.DTOs;
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
        public async Task<ActionResult<IEnumerable<BuyProcedure>>> GetAllAsync()
        {
            return Ok(await buyProcedureService.GetAllAsync());
        }

        [HttpPost("{title}")]
        public async Task<CreatedAtActionResult> CreateAsync(string title)
        {
            var dto = await buyProcedureService.CreateAsync(title);
            return new CreatedAtActionResult(nameof(CreateAsync), nameof(BuyProcedureController), $"{dto.ID}", dto);
        }

        [HttpPost]
        public async Task<CreatedAtActionResult> CreateAsync()
        {
            var dto = await buyProcedureService.CreateAsync();
            return new CreatedAtActionResult(nameof(CreateAsync), nameof(BuyProcedureController), $"{dto.ID}", dto);
        }

        [HttpPut]
        public async Task<ActionResult<BuyProcedureDto>> Update([FromBody] BuyProcedureDto buyProcedureDto)
        {
            try
            {
                return await buyProcedureService.UpdateAsync(buyProcedureDto);
            }
            // For a larger project, replace with Exception filter and a custom error object (translation key, readable message)
            catch (KeyNotFoundException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await buyProcedureService.DeleteAsync(id);
                return Ok();
            }
            // For a larger project, replace with Exception filter and a custom error object (translation key, readable message)
            catch(KeyNotFoundException e)
            {
                return StatusCode(StatusCodes.Status400BadRequest, e.Message);
            }
        }
    }
}