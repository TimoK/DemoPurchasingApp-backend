using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoPurchasingAppBackEnd.Entities
{
    public class BuyProcedure
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Title { get ; set; }
        public double MaxPrice { get; set; }
    }
}
