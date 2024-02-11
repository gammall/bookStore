using BookStore1.Dto;
using BookStore1.Services;

namespace BookStore1;

internal class ConsoleUI_Author
{
    private readonly AuthorService _authorService;

    public ConsoleUI_Author(AuthorService authorService)
    {
        _authorService = authorService;
    }

    public void userUI_Author()
    {
        while (true)
        {
            Console.WriteLine("----- MENU -----");
            Console.WriteLine("1. Add a new author");
            Console.WriteLine("2. Show all existing authors");
            Console.WriteLine("3. Search for an author");
            Console.WriteLine("4. Update an author");
            Console.WriteLine("5. Delete an author");
            Console.WriteLine("6. Return");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateBook_UI();
                    break;
                case "2":
                    GetAllAuthors_UI();
                    break;
                case "3":
                    GetOneAuthor_UI();
                    break;
                case "4":
                    UpdateAuthorName_UI();
                    break;
                case "5":
                    DeleteAuthor_UI();
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

    public void CreateBook_UI()
    {
        Console.Clear();
        Console.WriteLine("----- ADD AN AUTHOR -----");

        Console.WriteLine("Author Name: ");
        var authorName = Console.ReadLine()!;

        var _author = new Author()
        {
            AuthorName = authorName,
        };
        var random = _authorService.CreateAuthor(_author);
    }

    public void GetAllAuthors_UI()
    {
        Console.Clear();

        var existingAuthors = _authorService.GetAllAuthors();

        if (existingAuthors != null)
        {
            Console.WriteLine("----- Existing Books -----");
            foreach (var author in existingAuthors)
            {
                Console.WriteLine($"{author.Id}. {author.AuthorName}");
            }
        }
        else
        {
            Console.WriteLine("No existing customers found.");
        }
    }

    public void GetOneAuthor_UI()
    {
        Console.Clear();
        Console.WriteLine("Search for an author");

        var authorName = Console.ReadLine();

        var foundAuthor = _authorService.GetOneAuthor(x => x.AuthorName == authorName);

        if (foundAuthor != null)
        {
            Console.WriteLine($"{foundAuthor.Id}. {foundAuthor.AuthorName}");
        }
        else
        {
            Console.WriteLine("Customer not found.");
        }
    }

    public void UpdateAuthorName_UI()
    {
        Console.Clear();
        Console.WriteLine("Enter author ID");

        var authors = _authorService.GetAllAuthors();
        foreach (var author in authors)
        {
            Console.WriteLine($"ID: {author.Id}, Name: {author.AuthorName}");
        }

        var authorIdInput = Console.ReadLine();


        if (int.TryParse(authorIdInput, out int authorId))
        {
            var foundAuthor = _authorService.GetOneAuthor(x => x.Id == authorId);
            if (foundAuthor != null)
            {
                while (true)
                {
                    Console.WriteLine($"1. Update this author ----> {foundAuthor.AuthorName}");
                    Console.WriteLine("2. Go back");
                    var option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            Console.WriteLine("Enter the new author name:");
                            var newAuthorName = Console.ReadLine();
                            _authorService.UpdateAuthorName(authorId, newAuthorName);
                            Console.WriteLine("Author updated successfully!");
                            break;
                        case "2":
                            return;
                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Author not found");
            }
        }
        else
        {
            Console.WriteLine("Invalid author ID format");
        }
    }

    public void DeleteAuthor_UI()
    {
        Console.Clear();
        Console.WriteLine("Search for a author name");
        var authors = _authorService.GetAllAuthors();
        foreach (var author in authors)
        {
            Console.WriteLine($"ID: {author.Id}, Name: {author.AuthorName}");
        }

        var authorId = Console.ReadLine();

        if (int.TryParse(authorId, out int _authorId))
        {
            var foundAuthor = _authorService.GetOneAuthor(x => x.Id == _authorId);
            if (foundAuthor != null)
            {
                while (true)
                {
                    Console.WriteLine($"1. Delete this author ----> {foundAuthor.AuthorName}");
                    Console.WriteLine("2. Go back");
                    var option = Console.ReadLine();
                    switch (option)
                    {
                        case "1":
                            _authorService.DeleteAuthor(foundAuthor);
                            Console.WriteLine("Customer deleted successfully");
                            return;
                        case "2":
                            return;
                        default:
                            Console.WriteLine("Invalid option");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Customer not found");
            }
        }
    }
}
