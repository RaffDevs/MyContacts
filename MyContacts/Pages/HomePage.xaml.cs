namespace MyContacts.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    
    private async void OnShowContactsButtonClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("listcontacts");
    }

    private async void OnAddNewContactButtonClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("newcontact");
    }
}