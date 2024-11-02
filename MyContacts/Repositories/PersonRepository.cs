using Microsoft.EntityFrameworkCore;
using MyContacts.Database;
using MyContacts.Repositories.Interfaces;
using MyContacts.Entities;

namespace MyContacts.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly MyContactsDbContext _context;

    public PersonRepository(MyContactsDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }


    public async Task<Person?> GetById(int id)
    {
        return await _context.Persons.FindAsync(id);
    }

    public async Task<List<Person>> GetAll()
    {
        return await _context.Persons.ToListAsync();
    }

    public async Task<Person> Create(Person data)
    {
        var person = _context.Persons.Add(data);
        await _context.SaveChangesAsync();

        return person.Entity;
    }

    public async Task Update(Person data)
    {
        _context.Persons.Update(data);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Person data)
    {
        _context.Persons.Remove(data);
        await _context.SaveChangesAsync();
    }
}