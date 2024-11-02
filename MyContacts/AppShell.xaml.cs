using MyContacts.Pages;

namespace MyContacts;

public partial class AppShell : Shell
{
    public AppShell()
    {
        Routing.RegisterRoute("home", typeof(HomePage));
        Routing.RegisterRoute("newcontact", typeof(NewContactPage));
        Routing.RegisterRoute("listcontacts", typeof(ListContactsPage));
        InitializeComponent();
    }
}