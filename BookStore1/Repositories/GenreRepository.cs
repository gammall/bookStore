using BookStore1.Contexts;
using BookStore1.Entities;

namespace BookStore1.Repositories;

public class GenreRepository(DataContext context) : Repo<GenreEntity>(context)
{
    private readonly DataContext _context = context;

}