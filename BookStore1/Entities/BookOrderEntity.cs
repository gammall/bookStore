using System.ComponentModel.DataAnnotations;

namespace BookStore1.Entities;

public class BookOrderEntity
{
    [Key]
    public int Id { get; set; }

    public int BookId { get; set; }
    public virtual BookEntity Book { get; set; }

    public int OrderId { get; set; }
    public virtual OrderEntity Order { get; set; }
}