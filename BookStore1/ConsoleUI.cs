namespace BookStore1;

internal class ConsoleUI
{

    private readonly ConsoleUI_Customer _customerUI;
    private readonly ConsoleUI_Book _bookUI;
    private readonly ConsoleUI_Genre _genreUI;
    private readonly ConsoleUI_Author _authorUI;
    private readonly ConsoleUI_Order _orderUI;

    public ConsoleUI(ConsoleUI_Customer customerUI, ConsoleUI_Book bookUI, ConsoleUI_Genre genreUI, ConsoleUI_Author authorUI, ConsoleUI_Order orderUI)
    {
        _customerUI = customerUI;
        _bookUI = bookUI;
        _genreUI = genreUI;
        _authorUI = authorUI;
        _orderUI = orderUI;
    }


    public void UserUI()
    {
        while (true)
        {
            Console.WriteLine("---------- MAIN MENU ----------");
            Console.WriteLine("1. Customers");
            Console.WriteLine("2. Books");
            Console.WriteLine("3. Genres ");
            Console.WriteLine("4. Authors");
            Console.WriteLine("5. Orders");
            Console.WriteLine("6. Exit");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    _customerUI.userUI_Customer();
                    break;
                case "2":
                    _bookUI.userUI_Book();
                    break;
                case "3":
                    _genreUI.userUI_Genre();
                    break;
                case "4":
                    _authorUI.userUI_Author();
                    break;
                case "5":
                    _orderUI.userUI_Order();
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
}
