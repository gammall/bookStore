using System.ComponentModel.DataAnnotations;

namespace BookStore1.Entities;

public class CustomerEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string CustomerName { get; set; } = null!;

    [StringLength(100)]
    public string CustomerEmail { get; set; } = null!;

    public virtual ICollection<OrderEntity> Orders { get; set; } = null!;
}