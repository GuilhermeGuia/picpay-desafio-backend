using RecipeFood.Domain.Entities;

namespace DesafioPicPay.Domain.Entities;

public class Transfer
{
    public Guid Id { get; set; }
    public long SenderId { get; set; }
    public long ReciverId { get; set; }
    public double TransferAmount { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

    public Transfer(long senderId, long reciverId, double transferAmount)
    {
        SenderId = senderId;
        ReciverId = reciverId;
        TransferAmount = TransferAmount;
        Active = true;
    }
}
