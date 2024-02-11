namespace BookStore1.Dto;

public class Book
{
    public int Id { get; set; } 
    public string Title { get; set; }
    public decimal Price { get; set; }
    public Author? Author { get; set; }
}