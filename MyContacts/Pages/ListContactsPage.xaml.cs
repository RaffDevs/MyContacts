using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyContacts.Pages;

public partial class ListContactsPage : ContentPage
{
    private readonly ContactsViewModel _viewModel;
    
    public ListContactsPage(ContactsViewModel viewmodel)
    {
        _viewModel = viewmodel;
        InitializeComponent();
        BindingContext = _viewModel;
        
        viewmodel.LoadContacts.Execute(null);
    }
}