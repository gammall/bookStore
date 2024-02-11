using BookStore1.Contexts;
using BookStore1.Dto;
using BookStore1.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using static Dapper.SqlMapper;

namespace BookStore1.Repositories;

public class BookRepository(DataContext context) : Repo<BookEntity>(context)
{
    private readonly DataContext _context = context;

    public override BookEntity GetOne(Expression<Func<BookEntity, bool>> expression)
    {
        try
        {
            var book = _context.Books
            .FirstOrDefault(expression);
            return book;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }


    public override BookEntity Delete(BookEntity tentity)
    {
        try
        {
            var entity = _context.Books

            .FirstOrDefault(x => x.Title == tentity.Title);
            if (entity != null)
            {
                _context.Books
                .Remove(entity);
                _context.SaveChanges();

                return entity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null;
    }
}
