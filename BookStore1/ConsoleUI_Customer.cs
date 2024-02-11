using BookStore1.Dto;
using BookStore1.Entities;
using BookStore1.Services;

namespace BookStore1;

internal class ConsoleUI_Customer
{
    private readonly CustomerService _customerService;

    public ConsoleUI_Customer(CustomerService customerService)
    {
        _customerService = customerService;
    }

    public void userUI_Customer()
    {
        while (true) 
        {
            Console.WriteLine("----- MENU -----");
            Console.WriteLine("1. Create a new customer");
            Console.WriteLine("2. Show all existing customers");
            Console.WriteLine("3. Search for a customer ");
            Console.WriteLine("4. Update a customer");
            Console.WriteLine("5. Delete a customer");
            Console.WriteLine("6. Return");
            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateCustomer_UI();
                    break;
                case "2":
                    GetAllCustomers_UI();
                    break;
                case "3":
                    GetOneCustomer_UI();
                    break;
                case "4":
                    UpdateCustomer_UI();
                    break; 
                case "5":
                    DeleteCustomer_UI();
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

    public void CreateCustomer_UI()
    {
        Console.Clear();
        Console.WriteLine("----- CREATE CUSTOMER -----");

        Console.WriteLine("Customer Name: ");
        var customerName = Console.ReadLine()!;

        Console.WriteLine("Customer Email: ");
        var customerEmail = Console.ReadLine()!;


        var _customer = new Customer()
        {
            CustomerEmail = customerEmail,
            CustomerName = customerName
        };

        var random = _customerService.CreateCustomer(_customer);
    }

    public void GetAllCustomers_UI()
    {
        Console.Clear();

        var existingCustomers = _customerService.GetAllCustomers();

        if (existingCustomers != null)
        {
            Console.WriteLine("----- Existing Customers -----");
            foreach (var customer in existingCustomers)
            {
                Console.WriteLine($"Name: {customer.CustomerName}, Email: {customer.CustomerEmail}");
            }
        }
        else
        {
            Console.WriteLine("No existing customers found.");
        }
    }

    public void GetOneCustomer_UI()
    {
        Console.Clear();
        Console.WriteLine("Search for a customer-email");

        var customerEmail = Console.ReadLine();

        var foundCustomer = _customerService.GetOneCustomer(x => x.CustomerEmail == customerEmail);

        if (foundCustomer != null)
        {
            Console.WriteLine($"Name: {foundCustomer.CustomerName}, Email: {foundCustomer.CustomerEmail}");
        }
        else
        {
            Console.WriteLine("Customer not found.");
        }
    }

    public void UpdateCustomer_UI()
    {
        Console.Clear();
        Console.WriteLine("Search for a customer-email");

        var customerEmail = Console.ReadLine();

        var foundCustomer = _customerService.GetOneCustomer(x => x.CustomerEmail == customerEmail);
        if (foundCustomer != null)
        {
            while (true)
            {
                Console.WriteLine($"1. Update this contact ----> {foundCustomer.CustomerName} (Email) {foundCustomer.CustomerEmail}");
                Console.WriteLine("2. Go back");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Console.WriteLine("Enter the new name:");
                        var newName = Console.ReadLine();
                        foundCustomer.CustomerName = newName;
                        _customerService.UpdateCustomerName(foundCustomer.CustomerEmail, newName);
                        Console.WriteLine("Customer updated successfully!");
                        Console.WriteLine($"Updated Customer: (Name) {foundCustomer.CustomerName}, (Email) {foundCustomer.CustomerEmail}");
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


    public void DeleteCustomer_UI()
    {
        Console.Clear();
        Console.WriteLine("Search for a customer-email");

        var customerEmail = Console.ReadLine();

        var foundCustomer = _customerService.GetOneCustomer(x => x.CustomerEmail == customerEmail);
        if (foundCustomer != null)
        {
            while (true)
            {
                Console.WriteLine($"1. Delete this contact ----> {foundCustomer.CustomerName} (Email) {foundCustomer.CustomerEmail}");
                Console.WriteLine("2. Go back");
                var option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        _customerService.DeleteCustomer(foundCustomer);
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
