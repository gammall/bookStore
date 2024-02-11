using System.ComponentModel.DataAnnotations;

namespace BookStore1.Entities;

public class GenreEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string GenreName { get; set; } = null!;

    public virtual ICollection<BookEntity> Books { get; set; } = new List<BookEntity>();
}