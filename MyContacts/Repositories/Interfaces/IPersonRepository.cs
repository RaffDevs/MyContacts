using MyContacts.Entities;

namespace MyContacts.Repositories.Interfaces;

public interface IPersonRepository
{
    Task<Person?> GetById(int id);
    Task<List<Person>> GetAll();
    Task<Person> Create(Person data);
    Task Update(Person data);
    Task Delete(Person data);
}