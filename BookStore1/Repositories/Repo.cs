using BookStore1.Contexts;
using System.Diagnostics;
using System.Linq.Expressions;

namespace BookStore1.Repositories;

public abstract class Repo<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    protected Repo(DataContext context)
    {
        _context = context;
    }


    // ----------------------------------------------------------CREATE----------------------------------------------------------

    public virtual TEntity Create(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    // ----------------------------------------------------------GET----------------------------------------------------------
    public virtual IEnumerable<TEntity> GetAll()
    {
        try
        {
            return _context.Set<TEntity>().ToList();
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }


    public virtual TEntity GetOne(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            return _context.Set<TEntity>().FirstOrDefault(expression);
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }

    // ----------------------------------------------------------UPDATE----------------------------------------------------------

    public virtual TEntity Update(TEntity entity)
    {
        try
        {
            var entityToUpdate = _context.Set<TEntity>().Find(entity);
            if (entityToUpdate != null)
            {
                entityToUpdate = entity;
                _context.Set<TEntity>().Update(entityToUpdate);
                _context.SaveChanges();
                return entityToUpdate;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null!;
    }


    // ----------------------------------------------------------DELETE----------------------------------------------------------

    public virtual TEntity Delete(TEntity tentity)
    {
        try
        {
            var entity = _context.Set<TEntity>().FirstOrDefault(tentity);
            if (entity != null)
            {
                _context.Set<TEntity>().Remove(entity);
                _context.SaveChanges();

                return entity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return null;
    }


    public virtual bool Exists(Expression<Func<TEntity, bool>> predicate)
    {
        try
        {
           return _context.Set<TEntity>().Any(predicate);
        }
        catch (Exception ex) { Debug.WriteLine("ERROR :: " + ex.Message); }
        return false;
    }
}