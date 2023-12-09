using System.ComponentModel.DataAnnotations;

namespace DemoPurchasingAppBackEnd.Entities
{
    public class BuyProcedure
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get ; set; }
        public double MaxPrice { get; set; }
    }
}
