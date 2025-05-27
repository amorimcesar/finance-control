using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceControl.Domain.Entities;

public class EntityBase
{
    public long Id { get; set; }
    public bool Active { get; set; } = true;
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
}