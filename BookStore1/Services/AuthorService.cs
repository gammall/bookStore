using BookStore1.Dto;
using BookStore1.Entities;
using BookStore1.Repositories;
using System.Diagnostics;
using System.Linq.Expressions;

namespace BookStore1.Services;

public class AuthorService(AuthorRepository authorRepository)
{
    private readonly AuthorRepository _authorRepository = authorRepository;



    public bool CreateAuthor(Author author)
    {
        if (!_authorRepository.Exists(x => x.AuthorName == author.AuthorName))
        {
                var authorEntity = new AuthorEntity
                {
                    AuthorName = author.AuthorName
                };
                var result = _authorRepository.Create(authorEntity);
            if (result != null)

                return true;
        }
        return false;
    }

    public IEnumerable<Author> GetAllAuthors()
    {
        var products = new List<Author>();
        var result = _authorRepository.GetAll();

        try
        {
            foreach (var author in result)
                products.Add(new Author
                {
                    Id = author.Id.ToString(),
                    AuthorName = author.AuthorName
                });
        }
        catch { }
        return products;
    }

    public AuthorEntity GetOneAuthor(Expression<Func<AuthorEntity, bool>> predicate)
    {
        try
        {
            return _authorRepository.GetOne(predicate);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }

    public void UpdateAuthorName(int authorId, string newAuthorName)
    {
        try
        {
            var existingAuthor = _authorRepository.GetOne(author => author.Id == authorId);

            if (existingAuthor != null)
            {
                existingAuthor.AuthorName = newAuthorName;
                _authorRepository.Update(existingAuthor);
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

    public void DeleteAuthor(AuthorEntity author)
    {
        try
        {
            var existingAuthor = _authorRepository.GetOne(c => c.Id == author.Id);

            if (existingAuthor != null)
            {
                _authorRepository.Delete(existingAuthor);
            }
            else
            {
                Console.WriteLine("Could not delete customer");
            }
        }
        catch { }
    }
}
