using Microsoft.Extensions.DependencyInjection;
using PlushToyStore.Services;
using PlushToyStore.ViewModels;
using PlushToyStore.Views;
using System.IO;

namespace PlushToyStore
{
    public static class MauiProgram
    {
        private static MauiApp? _mauiAppInstance;

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "PlushToyStore.db3");
            builder.Services.AddSingleton<UserService>(s => ActivatorUtilities.CreateInstance<UserService>(s, dbPath));
            builder.Services.AddSingleton<PelucheService>(s => ActivatorUtilities.CreateInstance<PelucheService>(s, dbPath));
            builder.Services.AddSingleton<CompraService>(s => ActivatorUtilities.CreateInstance<CompraService>(s, dbPath));

            builder.Services.AddTransient<UserViewModel>();
            builder.Services.AddTransient<UserView>();
            builder.Services.AddTransient<PelucheViewModel>();
            builder.Services.AddTransient<PelucheView>();
            builder.Services.AddTransient<CompraViewModel>();
            builder.Services.AddTransient<CompraView>();

            _mauiAppInstance = builder.Build();

            return _mauiAppInstance;
        }

        public static MauiApp Current => _mauiAppInstance ?? throw new InvalidOperationException("MauiApp is not yet initialized. Call CreateMauiApp first.");
    }
}

