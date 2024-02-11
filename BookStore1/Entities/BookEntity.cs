using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore1.Entities;

public class BookEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; } = null!;

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public virtual ICollection<BookAuthorEntity> BookAuthors { get; set; }
    public virtual ICollection<BookOrderEntity> BookOrders { get; set; }

    public int GenreId { get; set; }
    public virtual GenreEntity Genre { get; set; }
}
