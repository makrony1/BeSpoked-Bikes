using System.ComponentModel.DataAnnotations;

namespace BSB.Models.Entity;

public class EntityBase
{
    [Key]
    public string Id { get; set; }
    public bool IsDeleted { get; set; }

    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    public EntityBase()
    {
        Id = Guid.NewGuid().ToString();
        CreatedAt = DateTimeOffset.Now;
    }
}
