using Microsoft.EntityFrameworkCore;
using MyContacts.Entities;

namespace MyContacts.Database;

public class MyContactsDbContext : DbContext
{
    public DbSet<Person> Persons { get; set; }
    
    public MyContactsDbContext(DbContextOptions<MyContactsDbContext> options) : base(options)
    {
        SQLitePCL.Batteries_V2.Init();
        this.Database.EnsureCreated();
    }
}