// App.cs
using Microsoft.Maui.Controls;

namespace PlushToyStore
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}

