using BookStore1.Contexts;
using BookStore1.Entities;
using System.Diagnostics;

namespace BookStore1.Repositories;

public class AuthorRepository(DataContext context) : Repo<AuthorEntity>(context)
{
    private readonly DataContext _context = context;

    public override AuthorEntity Update(AuthorEntity entity)
    {
        try
        {
            var entityToUpdate = _context.Authors.Find(entity.Id);
            if (entityToUpdate != null)
            {
                entityToUpdate.AuthorName = entity.AuthorName;

                _context.Authors.Update(entityToUpdate);
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

    public override AuthorEntity Delete(AuthorEntity tentity)
    {
        try
        {
            var entity = _context.Authors

            .FirstOrDefault(x => x.Id == tentity.Id);
            if (entity != null)
            {
                _context.Authors
                .Remove(entity);
                _context.SaveChanges();

                return entity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null;
    }
}