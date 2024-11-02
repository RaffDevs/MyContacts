using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MyContacts.Entities;
using MyContacts.Repositories.Interfaces;

namespace MyContacts.Pages;

public class ContactsViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private readonly IPersonRepository _repository;

    #region properties
    private ObservableCollection<Person> _persons = new ObservableCollection<Person>();
    public ObservableCollection<Person> Persons
    {
        get => _persons;
        set
        {
            _persons = value;
            OnPropertyChanged(nameof(Contacts));
        }
    }

    private Person _newPerson = new Person();
    public Person NewPerson
    {
        get => _newPerson;
        set
        {
            _newPerson = value;
            OnPropertyChanged(nameof(NewPerson));
        }
    }

    private bool _isLoading;

    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged(nameof(IsLoading));
            
        }
    }
    #endregion

    #region commands
    public ICommand LoadContacts { get; private set; }
    public ICommand AddNewContact { get; private set; }
    #endregion
    

    public ContactsViewModel(IPersonRepository repository)
    {
        _repository = repository;
        LoadContacts = new Command(async() => await GetAllContacts(), CanExecuteCommand);
        AddNewContact = new Command<Person>(async (data) => await AddContact(data), CanExecuteCommand);

    }

    #region methods
    private async Task GetAllContacts()
    {
        _isLoading = true;
        var data = await _repository.GetAll();
        _persons.Clear();
        foreach (var person in data)
        {
            Persons.Add(person);
        }
        _isLoading = false;
    }

    private async Task AddContact(Person data)
    {
        _isLoading = true;
        var person = await _repository.Create(data);
        Persons.Add(person);
        _isLoading = false;
        NewPerson = new Person();
    }

    
    private bool CanExecuteCommand()
    {
        return !_isLoading;
    }
    private bool CanExecuteCommand(object? param = null)
    {
        return !_isLoading;
    }
    
    #endregion
    

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}