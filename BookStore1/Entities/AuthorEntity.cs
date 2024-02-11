using System.ComponentModel.DataAnnotations;

namespace BookStore1.Entities;

public class AuthorEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string AuthorName { get; set; } = null!;

    public virtual ICollection<BookAuthorEntity> BookAuthors { get; set; }
}