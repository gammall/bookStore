using System.ComponentModel.DataAnnotations;

namespace BookStore1.Entities;

public class BookAuthorEntity
{
    [Key]
    public int Id { get; set; }

    public int BookId { get; set; }
    public virtual BookEntity Book { get; set; }

    public int AuthorId { get; set; }
    public virtual AuthorEntity Author { get; set; }
}