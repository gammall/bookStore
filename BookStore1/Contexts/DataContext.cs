using BookStore1.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore1.Contexts;

public partial class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public virtual DbSet<AuthorEntity> Authors { get; set; }
    public virtual DbSet<BookAuthorEntity> BookAuthors { get; set; }
    public virtual DbSet<BookEntity> Books { get; set; }
    public virtual DbSet<OrderEntity> Orders { get; set; }
    public virtual DbSet<BookOrderEntity> BookOrders { get; set; }
    public virtual DbSet<CustomerEntity> Customers { get; set; }
    public virtual DbSet<GenreEntity> Genres { get; set; }
}
