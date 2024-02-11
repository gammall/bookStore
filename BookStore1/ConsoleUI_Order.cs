using BookStore1.Dto;
using BookStore1.Entities;
using BookStore1.Repositories;
using BookStore1.Services;
using BookStore1.Repositories;
using System.Linq.Expressions;

namespace BookStore1;

internal class ConsoleUI_Order
{

    private readonly OrderService _orderService;
    private readonly CustomerService _customerService;
    private readonly CustomerRepository _customerRepository;
    private readonly BookRepository _bookRepository;
    private readonly BookService _bookService;

    public ConsoleUI_Order(OrderService orderService, CustomerService customerService, CustomerRepository customerRepository, BookRepository bookRepository, BookService bookService)
    {
        _orderService = orderService;
        _customerService = customerService;
        _customerRepository = customerRepository;
        _bookRepository = bookRepository;
        _bookService = bookService;
    }


    public void userUI_Order()
    {
        while (true)
        {
            Console.WriteLine("----- MENU -----");
            Console.WriteLine("1. Create a new order");
            Console.WriteLine("2. Return");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateOrder_UI();
                    break;
                case "2":
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






    public void CreateOrder_UI()
    {
        Console.Clear();
        Console.WriteLine("----- CREATE ORDER -----");

        Console.WriteLine("Enter customer email: ");
        var customerEmail = Console.ReadLine();

        var foundCustomer = _customerService.GetOneCustomer(x => x.CustomerEmail == customerEmail);

        if (foundCustomer != null)
        {
            var existingBooks = _bookService.GetAllBooks();

            if (existingBooks != null)
            {
                Console.WriteLine($"Welcome {foundCustomer.CustomerName}, select bookId to add book to order list:");
                foreach (var book in existingBooks)
                {
                    Console.WriteLine($"BookId: {book.Id}, Title: {book.Title}, Price: ${book.Price}");
                }
            }
            var orderList = new List<Book>();
            decimal totalPrice = 0;
            Console.WriteLine("Enter bookId to add to order list then press enter to add another book (enter twice to see total price):");
            string option;
            while ((option = Console.ReadLine()) != "")
            {
                if (int.TryParse(option, out int bookId))
                {
                    var selectedBook = existingBooks.FirstOrDefault(book => book.Id == bookId);
                    if (selectedBook != null)
                    {
                        orderList.Add(selectedBook);
                        totalPrice += selectedBook.Price;
                    }
                    else
                    {
                        Console.WriteLine("Invalid bookId, please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input, please enter a valid bookId or press Enter to finish.");
                }
            }

            Console.WriteLine("Order Summary:");
            foreach (var book in orderList)
            {
                Console.WriteLine($"Title: {book.Title}, Price: ${book.Price}");
            }
            Console.WriteLine($"Total Price: ${totalPrice}");
        }

        else
        {
            Console.WriteLine("Customer not found, you need to be a customer to make an order");
        }
    }
}
