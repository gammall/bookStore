using BookStore1.Dto;
using BookStore1.Entities;
using BookStore1.Services;

namespace BookStore1;

internal class ConsoleUI_Genre
{
    private readonly GenreService _genreService;

    public ConsoleUI_Genre(GenreService genreService)
    {
        _genreService = genreService;
    }

    public void userUI_Genre()
    {
        while (true)
        {
            Console.WriteLine("----- MENU -----");
            Console.WriteLine("1. Create a new genre");
            Console.WriteLine("2. Search for a genre");
            Console.WriteLine("3. .................");
            Console.WriteLine("4. .................");
            Console.WriteLine("5. .................");
            Console.WriteLine("6. Return");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateGenre_UI();
                    break;
                case "2":
                    GetOneGenre_UI();
                    break;
                case "3":

                    break;
                case "4":

                    break;
                case "5":

                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();

        }
    }

    public void CreateGenre_UI()
    {
        Console.Clear();
        Console.WriteLine("----- CREATE GENRE -----");

        Console.WriteLine("Genre name: ");
        var genreName = Console.ReadLine()!;


        var _genre = new Genre()
        {
            GenreName = genreName
        };

        var random = _genreService.CreateGenre(_genre.GenreName);
    }

    public void GetOneGenre_UI()
    {
        Console.Clear();
        Console.WriteLine("Search for a genre");

        var genre = Console.ReadLine();

        var foundGenre = _genreService.GetOneGenre(x => x.GenreName == genre);

        if (foundGenre != null)
        {
            Console.WriteLine($"Genre name: {foundGenre.GenreName}");
        }
        else
        {
            Console.WriteLine("Genre not found.");
        }
    }
}
