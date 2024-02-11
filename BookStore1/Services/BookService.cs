using BookStore1.Dto;
using BookStore1.Entities;
using BookStore1.Repositories;
using Microsoft.Identity.Client;
using System.Diagnostics;
using System.Linq.Expressions;

namespace BookStore1.Services;

public class BookService(BookRepository bookRepository, GenreRepository genreRepository,BookAuthorRepository bookAuthorRepository, AuthorRepository authorRepository, GenreService genreService, AuthorService authorService)
{
    private readonly BookRepository _bookRepository = bookRepository;
    private readonly GenreRepository _genreRepository = genreRepository;
    private readonly AuthorRepository _authorRepository = authorRepository;
    private readonly BookAuthorRepository _bookAuthorRepository = bookAuthorRepository;
    private readonly GenreService _genreService = genreService;
    // private readonly AuthorRepository _authorRepository = authorRepository;

    public Book CreateBook(BookRegDto bookRegDto)
    {
        try 
        {
            if (!_bookRepository.Exists(x => x.Title == bookRegDto.Title))
            {
                var genreEntity = _genreService.GetOneGenre(x => x.GenreName == bookRegDto.Genre);
                if (genreEntity == null)
                {
                    genreEntity = _genreService.CreateGenre(bookRegDto.Genre);
                } 


                var bookEntity = _bookRepository.Create(new BookEntity
                {
                    Title = bookRegDto.Title,
                    Price = bookRegDto.Price,
                    GenreId = genreEntity.Id
                });
                if (bookEntity != null)
                {
                    var authorEntity = _authorRepository.GetOne(x => x.AuthorName == bookRegDto.Author);

                    if (authorEntity == null)
                    {
                        authorEntity = _authorRepository.Create(new AuthorEntity
                        {
                            AuthorName = bookRegDto.Author
                        });
                        if (authorEntity != null)
                        {
                            var bookAuthor = _bookAuthorRepository.Create(new BookAuthorEntity
                            {
                                BookId = bookEntity.Id,
                                AuthorId = authorEntity.Id,
                            });

                            if (bookAuthor != null)
                            {
                                var book = new Book
                                {
                                    Id = bookAuthor.Id,
                                    Title = bookEntity.Title,
                                    Price = bookEntity.Price, 

                                    Author = new Author
                                    {
                                        AuthorName = authorEntity.AuthorName
                                    }
                                };
                                return book;
                            }
                        }
                    }
                }
            }
        }
        catch { }
        return null!;
    }


    public IEnumerable<Book> GetAllBooks()
    {
        var products = new List<Book>();
        var result = _bookRepository.GetAll();
        
        try
        {
            foreach (var book in result)
                products.Add(new Book
                {
                    Id = book.Id,
                    Title = book.Title,
                    Price = book.Price
                });
        }
        catch { }
        return products;
    }


    public BookEntity GetOneBook(Expression<Func<BookEntity, bool>> predicate)
    {
        try
        {
            return _bookRepository.GetOne(predicate);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }


    public void UpdateBookPrice(string Title, string newBookPrice)
    {
        try
        {
            var existingBook = _bookRepository.GetOne(book => book.Title == Title);

            if (existingBook != null)
            {
                if (decimal.TryParse(newBookPrice, out decimal parsedPrice))
                {
                    var bookToUpdate = new BookEntity { Title = Title, Price = parsedPrice };

                    _bookRepository.Update(bookToUpdate);
                }
            }
            else
            {
                Console.WriteLine("Could not update customer");
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
        }
    }

    public void DeleteBook(BookEntity book)
    {
        try
        {
            var existingBook = _bookRepository.GetOne(c => c.Title == book.Title);

            if (existingBook != null)
            {
                _bookRepository.Delete(existingBook);
            }
            else
            {
                Console.WriteLine("Could not delete book");
            }
        }
        catch { }
    }
}
