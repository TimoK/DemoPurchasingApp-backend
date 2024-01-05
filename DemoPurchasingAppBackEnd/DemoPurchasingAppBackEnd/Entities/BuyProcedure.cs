using System.ComponentModel.DataAnnotations.Schema;

namespace DemoPurchasingAppBackEnd.Entities
{
    public class BuyProcedure
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get ; set; }
        public double Price { get; set; }
        public CostEnumerationType CostEnumerationType { get; set; }
    }

    public enum CostEnumerationType { NotDefined = 0, Yearly = 1, Quarterly = 2, OneTime = 3 }
}
