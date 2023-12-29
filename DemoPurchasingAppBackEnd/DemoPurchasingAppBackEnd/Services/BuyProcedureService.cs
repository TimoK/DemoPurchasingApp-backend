using CSharpTest.Net;
using System.Linq;
using DemoPurchasingAppBackEnd.Database;
using DemoPurchasingAppBackEnd.Entities;

namespace DemoPurchasingAppBackEnd.Services
{
    public interface IBuyProcedureService
    {
        IEnumerable<BuyProcedure> GetAll();
        int Create(string title);
        int Create();
        bool Delete(int id);
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

        public int Create(string? title)
        {
            var buyProcedure = new BuyProcedure()
            {
                Title = title
            };
            dbContext.BuyProcedures.Add(buyProcedure);
            dbContext.SaveChanges();
            return buyProcedure.Id;
        }

        public int Create()
        {
            return Create(title: null);
        }

        public bool Delete(int id)
        {
            var buyProcedure = dbContext.BuyProcedures.SingleOrDefault(x => x.Id == id);
            if (buyProcedure == null)
            {
                return false;
            }
            dbContext.BuyProcedures.Remove(buyProcedure);
            dbContext.SaveChanges();
            return true;
        }
    }
}
