using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore1.Entities;

public class OrderEntity
{
    [Key]
    public int Id { get; set; }

    public int Quantity { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalPrice { get; set; }

    public virtual ICollection<BookOrderEntity> BookOrders { get; set; }

    public int CustomerId { get; set; }
    public virtual GenreEntity Customer { get; set; }
}