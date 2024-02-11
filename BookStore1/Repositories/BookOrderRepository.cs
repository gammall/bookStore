using BookStore1.Contexts;
using BookStore1.Entities;

namespace BookStore1.Repositories;

public class BookOrderRepository(DataContext context) : Repo<BookOrderEntity>(context)
{
    private readonly DataContext _context = context;

}
