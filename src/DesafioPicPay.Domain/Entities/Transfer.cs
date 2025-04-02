using RecipeFood.Domain.Entities;

namespace DesafioPicPay.Domain.Entities;

public class Transfer
{
    public Guid Id { get; set; }
    public long PayerId { get; set; }
    public long Payee { get; set; }
    public double TransferAmount { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}
