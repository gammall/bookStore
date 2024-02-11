using BookStore1.Dto;
using BookStore1.Services;

namespace BookStore1;

internal class ConsoleUI_Book
{
    private readonly BookService _bookservices;

    public ConsoleUI_Book(BookService bookservices)
    {
        _bookservices = bookservices;
    }

    public void userUI_Book()
    {
        while (true)
        {
            Console.WriteLine("----- MENU -----");
            Console.WriteLine("1. Add a new book");
            Console.WriteLine("2. Show all existing books");
            Console.WriteLine("3. Search for a book ");
            Console.WriteLine("4. Update a customer");
            Console.WriteLine("5. Delete a book");
            Console.WriteLine("6. Exit");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateBook_UI();
                    break;
                case "2":
                    GetAllBooks_UI();
                    break;
                case "3":
                    GetOneBook_UI();
                    break;
                case "4":
                    UpdateBookPrice_UI();
                    break;
                case "5":
                    DeleteBook_UI();
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
        Console.WriteLine("----- ADD A BOOK -----");

        Console.WriteLine("Book Title: ");
        var Title = Console.ReadLine()!;

        Console.WriteLine("Book Price: ");
        var priceString = Console.ReadLine()!;

        Console.WriteLine("Author: ");
        var Author = Console.ReadLine()!;

        Console.WriteLine("Genre: ");
        var Genre  = Console.ReadLine()!;

        decimal Price;
        if (!decimal.TryParse(priceString, out Price))
        {
            Console.WriteLine("Invalid price format. Please enter a valid decimal value for the price.");
            return;
        }

        var _book = new BookRegDto()
        {
            Title = Title,
            Price = Price,
            Author = Author,
            Genre = Genre
        };
        var random = _bookservices.CreateBook(_book);
    }


    public void GetAllBooks_UI()
    {
        Console.Clear();

        var existingBooks = _bookservices.GetAllBooks();

        if (existingBooks != null)
        {
            Console.WriteLine("----- Existing Books -----");
            foreach (var book in existingBooks)
            {
                Console.WriteLine($"Title: {book.Title}, Price: ${book.Price}");
            }
        }
        else
        {
            Console.WriteLine("No existing books found.");
        }
    }


    public void GetOneBook_UI()
    {
        Console.Clear();
        Console.WriteLine("Search for a book title");

        var bookTitle = Console.ReadLine();

        var foundBook = _bookservices.GetOneBook(x => x.Title == bookTitle);

        if (foundBook != null)
        {
            Console.WriteLine($"Title: {foundBook.Title}, Price: ${foundBook.Price}");
        }
        else
        {
            Console.WriteLine("Customer not found.");
        }
    }


    public void UpdateBookPrice_UI()
    {
        Console.Clear();
        Console.WriteLine("Search for a book title");

        var bookTitle = Console.ReadLine();

        var foundBook = _bookservices.GetOneBook(x => x.Title == bookTitle);
        if (foundBook != null)
        {
            while (true)
            {
                Console.WriteLine($"1. Update this contact ----> {foundBook.Title}, Price: ${foundBook.Price}");
                Console.WriteLine("2. Go back");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter the new Price:");
                        var newPriceInput = Console.ReadLine();
                        if (decimal.TryParse(newPriceInput, out decimal newPrice))
                        {
                            foundBook.Price = newPrice;
                            _bookservices.UpdateBookPrice(foundBook.Title, newPrice.ToString());
                            Console.WriteLine("Book updated successfully!");
                            Console.WriteLine($"Updated Book: (Title) {foundBook.Title}, (Price) {foundBook.Price}");
                        }
                        break;
                    case "2":
                        return;
                    default:
                        Console.WriteLine("invalid option");
                        break;
                }
            }
        }
        else { Console.WriteLine("Customer not found"); }
    }

    public void DeleteBook_UI()
    {
        Console.Clear();
        Console.WriteLine("Search for a book title");

        var bookTitle = Console.ReadLine();

        var foundBook = _bookservices.GetOneBook(x => x.Title == bookTitle);
        if (foundBook != null)
        {
            while (true)
            {
                Console.WriteLine($"1. Delete this contact ----> {foundBook.Title}, Price: ${foundBook.Price}");
                Console.WriteLine("2. Go back");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        _bookservices.DeleteBook(foundBook);
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
