using BookStore1.Contexts;
using BookStore1.Entities;

namespace BookStore1.Repositories;

public class BookAuthorRepository(DataContext context) : Repo<BookAuthorEntity>(context)
{
    private readonly DataContext _context = context;

}
