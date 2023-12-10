using CSharpTest.Net;
using DemoPurchasingAppBackEnd.Database;
using DemoPurchasingAppBackEnd.Entities;

namespace DemoPurchasingAppBackEnd.Services
{
    public interface IBuyProcedureService
    {
        IEnumerable<BuyProcedure> GetAll();
        void Create(string title);
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

        public void Create(string title)
        {
            if (dbContext.BuyProcedures.Any(x => x.Title == title))
                throw new DuplicateKeyException();

            dbContext.BuyProcedures.Add(new BuyProcedure()
            {
                Title = title
            });
            dbContext.SaveChanges();
        }

    }
}
