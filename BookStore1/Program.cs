using BookStore1;
using BookStore1.Contexts;
using BookStore1.Repositories;
using BookStore1.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{
    services.AddDbContext<DataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\PROGRAMMERING\C#\BookStore1\BookStore1\Data\localhost.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));


    services.AddScoped<AuthorRepository>();
    services.AddScoped<BookAuthorRepository>();
    services.AddScoped<BookOrderRepository>();
    services.AddScoped<BookRepository>();
    services.AddScoped<CustomerRepository>();
    services.AddScoped<GenreRepository>();
    services.AddScoped<OrderRepository>();

    services.AddScoped<CustomerService>();
    services.AddScoped<BookService>();
    services.AddScoped<GenreService>();
    services.AddScoped<AuthorService>();
    services.AddScoped<OrderService>();

    services.AddSingleton<ConsoleUI>();
    services.AddSingleton<ConsoleUI_Customer>();
    services.AddSingleton<ConsoleUI_Book>();
    services.AddSingleton<ConsoleUI_Genre>();
    services.AddSingleton<ConsoleUI_Author>();
    services.AddSingleton<ConsoleUI_Order>();


}).Build();


var consoleUI = builder.Services.GetRequiredService<ConsoleUI>();
consoleUI.UserUI();
