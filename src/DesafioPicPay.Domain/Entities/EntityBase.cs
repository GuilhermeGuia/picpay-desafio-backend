namespace RecipeFood.Domain.Entities;
abstract public class EntityBase
{
    public long Id { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}