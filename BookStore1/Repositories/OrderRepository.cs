using BookStore1.Contexts;
using BookStore1.Entities;

namespace BookStore1.Repositories;

public class OrderRepository(DataContext context) : Repo<OrderEntity>(context)
{
    private readonly DataContext _context = context;

}
