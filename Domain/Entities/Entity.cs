namespace Domain.Entities;

public class Entity
{
    public virtual Guid Id { get; set; } = Guid.NewGuid();
}