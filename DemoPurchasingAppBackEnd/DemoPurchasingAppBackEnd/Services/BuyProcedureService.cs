using DemoPurchasingAppBackEnd.Database;
using DemoPurchasingAppBackEnd.Entities;

namespace DemoPurchasingAppBackEnd.Services
{
    public interface IBuyProcedureService
    {
        IEnumerable<BuyProcedure> GetAll();
    }


    public class BuyProcedureService : IBuyProcedureService
    {
        private readonly DatabaseContext dbContext;

        public BuyProcedureService(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<BuyProcedure> GetAll()
        {
            return dbContext.BuyProcedures;
        }
    }
}
