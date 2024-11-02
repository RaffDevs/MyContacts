using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyContacts.Database;
using MyContacts.Pages;
using MyContacts.Repositories;
using MyContacts.Repositories.Interfaces;

namespace MyContacts;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "mycontacts.db3");

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddTransient<IPersonRepository, PersonRepository>();
        builder.Services.AddDbContext<MyContactsDbContext>(options =>
        {
            options.UseSqlite($"Filename={dbPath}");
        });

        builder.Services.AddSingleton<ContactsViewModel>();
        builder.Services.AddSingleton<HomePage>();
        builder.Services.AddSingleton<NewContactPage>();
        builder.Services.AddSingleton<ListContactsPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}