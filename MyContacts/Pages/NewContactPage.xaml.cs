using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyContacts.Entities;
using MyContacts.Repositories.Interfaces;

namespace MyContacts.Pages;

public partial class NewContactPage : ContentPage
{
    private readonly ContactsViewModel _viewModel;

    public NewContactPage(ContactsViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;

        BindingContext = viewModel;
    }

    private void OnEntryCompleted(object? sender, EventArgs e)
    {
        if (sender == EntryContactName)
        {
            EntryPhoneNumber.Focus();
        }

        if (sender == EntryPhoneNumber)
        {
            EntryPhoneNumber.Unfocus();
        }
    }
}