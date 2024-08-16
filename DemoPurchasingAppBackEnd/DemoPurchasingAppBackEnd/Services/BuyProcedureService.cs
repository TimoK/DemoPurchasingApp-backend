using CSharpTest.Net;
using System.Linq;
using DemoPurchasingAppBackEnd.Database;
using DemoPurchasingAppBackEnd.Entities;
using DemoPurchasingAppBackEnd.DTOs;
using Microsoft.EntityFrameworkCore;
using DemoPurchasingAppBackEnd.Controllers;

namespace DemoPurchasingAppBackEnd.Services
{
    public interface IBuyProcedureService
    {
        Task<IEnumerable<BuyProcedureDto>> GetAllAsync();
        Task<BuyProcedureDto> CreateAsync(string? title);
        Task<BuyProcedureDto> CreateAsync();
        Task DeleteAsync(int id);
        Task<BuyProcedureDto> UpdateAsync(BuyProcedureDto updatedBuyProcedureDto);
    }


    public class BuyProcedureService : IBuyProcedureService
    {
        private readonly DatabaseContext dbContext;
        private readonly ILogger<BuyProcedureService> logger;

        public BuyProcedureService(DatabaseContext dbContext, ILogger<BuyProcedureService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public async Task<IEnumerable<BuyProcedureDto>> GetAllAsync()
        {
            return (await dbContext.BuyProcedures.ToListAsync()).Select(x => GetDto(x));
        }

        public async Task<BuyProcedureDto> CreateAsync(string? title)
        {
            var buyProcedure = new BuyProcedure()
            {
                Title = title
            };
            dbContext.BuyProcedures.Add(buyProcedure);
            await dbContext.SaveChangesAsync();
            return GetDto(buyProcedure);
        }

        public async Task<BuyProcedureDto> CreateAsync()
        {
            return await CreateAsync(title: null);
        }

        public async Task DeleteAsync(int id)
        {
            var buyProcedure = dbContext.BuyProcedures.SingleOrDefault(x => x.Id == id);
            if (buyProcedure == null)
            {
                var errorMessage = string.Format("No object found with id {0}", id);
                logger.LogError(errorMessage);
                throw new KeyNotFoundException(errorMessage);
            }
            dbContext.BuyProcedures.Remove(buyProcedure);
            await dbContext.SaveChangesAsync();
        }

        public async Task<BuyProcedureDto> UpdateAsync(BuyProcedureDto updatedBuyProcedureDto)
        {
            var buyProcedure = dbContext.BuyProcedures.SingleOrDefault(x => x.Id == updatedBuyProcedureDto.ID);
            if (buyProcedure == null)
            {
                var errorMessage = string.Format("No object found with id {0}", updatedBuyProcedureDto.ID);
                logger.LogError(errorMessage);
                throw new KeyNotFoundException(errorMessage);
            }
                
            buyProcedure.Price = updatedBuyProcedureDto.Price;
            buyProcedure.Title = updatedBuyProcedureDto.Title;
            buyProcedure.CostEnumerationType = updatedBuyProcedureDto.CostEnumerationType;
            await dbContext.SaveChangesAsync();
            return GetDto(buyProcedure);
        }

        private BuyProcedureDto GetDto(BuyProcedure buyProcedure)
        {
            return new BuyProcedureDto(buyProcedure.Id, buyProcedure.Title, buyProcedure.Price, buyProcedure.CostEnumerationType);
        }
    }
}
