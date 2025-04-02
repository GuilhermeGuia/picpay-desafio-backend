using RecipeFood.Domain.Entities;

namespace DesafioPicPay.Domain.Entities;

public class Account : EntityBase
{
    public double Balance { get; set; }
    public long OwnerId { get; set; }
    public User Owner { get; set; }
    public void Debit(long value)
    {
        Balance -= value;
    }
    public void Credit(long value)
    {
        Balance += value;
    }
}
