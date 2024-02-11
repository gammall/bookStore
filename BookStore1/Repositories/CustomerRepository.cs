using BookStore1.Contexts;
using BookStore1.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using static Dapper.SqlMapper;

namespace BookStore1.Repositories;

public class CustomerRepository(DataContext context) : Repo<CustomerEntity>(context)
{
    private readonly DataContext _context = context;

    public override CustomerEntity GetOne(Expression<Func<CustomerEntity, bool>> expression)
    {
        try
        {
            var customer = _context.Customers
            .FirstOrDefault(expression);
            return customer;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    public override CustomerEntity Update(CustomerEntity entity)
    {
        try
        {
            var entityToUpdate = _context.Customers.Find(entity.CustomerEmail);
            if (entityToUpdate != null)
            {
                entityToUpdate.CustomerName = entity.CustomerName;
                entityToUpdate.CustomerEmail = entity.CustomerEmail;

                _context.Customers.Update(entityToUpdate);
                _context.SaveChanges();
                return entityToUpdate;
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("ERROR :: " + ex.Message);
        }
        return null;
    }

    public override CustomerEntity Delete(CustomerEntity tentity)
    {
        try
        {
            var entity = _context.Customers
            
            .FirstOrDefault(x => x.CustomerEmail == tentity.CustomerEmail);
            if (entity != null)
            {
                _context.Customers
                .Remove(entity);
                _context.SaveChanges();

                return entity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null;
    }
}
