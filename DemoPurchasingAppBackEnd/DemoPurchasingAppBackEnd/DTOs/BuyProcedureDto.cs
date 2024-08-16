using DemoPurchasingAppBackEnd.Entities;

namespace DemoPurchasingAppBackEnd.DTOs
{
    public record struct BuyProcedureDto(int ID, string? Title, double Price, CostEnumerationType CostEnumerationType);
}
