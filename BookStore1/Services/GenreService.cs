using BookStore1.Dto;
using BookStore1.Entities;
using BookStore1.Repositories;
using System.Linq.Expressions;

namespace BookStore1.Services;

public class GenreService(GenreRepository genreRepository)
{
    private readonly GenreRepository _genreRepository = genreRepository;

    public GenreEntity CreateGenre(string genreName)
    {
        var genreEntity = _genreRepository.Create(new GenreEntity { GenreName = genreName });
        if (genreEntity != null)
        {
            return genreEntity;
        }
        return null!;
    }

    public GenreEntity GetOneGenre(Expression<Func<GenreEntity, bool>> predicate)
    {
        try
        {
            return _genreRepository.GetOne(predicate);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            throw;
        }
    }

}
