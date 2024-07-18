using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlushToyStore.Models;
using PlushToyStore.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PlushToyStore.ViewModels
{
    public partial class PelucheViewModel : ObservableObject
    {
        private readonly PelucheService _pelucheService;

        public ObservableCollection<Peluche> Peluches { get; } = new ObservableCollection<Peluche>();

        [ObservableProperty]
        private Peluche selectedPeluche;

        public PelucheViewModel()
        {
            // Constructor sin parámetros requerido por el error
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "PlushToyStore.db3");
            _pelucheService = new PelucheService(dbPath);
            LoadPeluches();
        }

        public PelucheViewModel(PelucheService pelucheService)
        {
            _pelucheService = pelucheService;
            LoadPeluches();
        }

        public async void LoadPeluches()
        {
            var peluches = await _pelucheService.GetPeluchesAsync();
            Peluches.Clear();
            foreach (var peluche in peluches)
            {
                Peluches.Add(peluche);
            }
        }

        [RelayCommand]
        public async Task AddPeluche(Peluche peluche)
        {
            if (peluche != null)
            {
                var result = await _pelucheService.AddPelucheAsync(peluche);
                if (result > 0)
                {
                    Peluches.Add(peluche);
                }
                else
                {
                    Console.WriteLine("Failed to add peluche.");
                }
            }
        }

        [RelayCommand]
        public async Task UpdatePeluche(Peluche peluche)
        {
            if (peluche != null)
            {
                var result = await _pelucheService.UpdatePelucheAsync(peluche);
                if (result > 0)
                {
                    var index = Peluches.IndexOf(peluche);
                    if (index != -1)
                    {
                        Peluches[index] = peluche;
                    }
                }
                else
                {
                    Console.WriteLine("Failed to update peluche.");
                }
            }
        }

        [RelayCommand]
        public async Task DeletePeluche(Peluche peluche)
        {
            if (peluche != null)
            {
                var result = await _pelucheService.DeletePelucheAsync(peluche);
                if (result > 0)
                {
                    Peluches.Remove(peluche);
                }
                else
                {
                    Console.WriteLine("Failed to delete peluche.");
                }
            }
        }
    }
}

