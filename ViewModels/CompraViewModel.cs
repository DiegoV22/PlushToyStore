using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PlushToyStore.Models;
using PlushToyStore.Services;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PlushToyStore.ViewModels
{
    public partial class CompraViewModel : ObservableObject
    {
        private readonly CompraService _compraService;

        public ObservableCollection<Compra> Compras { get; } = new ObservableCollection<Compra>();

        [ObservableProperty]
        private Compra _selectedCompra;

        public CompraViewModel()
        {
            // Este constructor es necesario para que XAML pueda instanciar el ViewModel
        }

        public CompraViewModel(CompraService compraService)
        {
            _compraService = compraService;
            LoadCompras();
        }

        public async void LoadCompras()
        {
            var compras = await _compraService.GetComprasAsync();
            Compras.Clear();
            foreach (var compra in compras)
            {
                Compras.Add(compra);
            }
        }

        [RelayCommand]
        public async Task AddCompra(Compra compra)
        {
            await _compraService.AddCompraAsync(compra);
            Compras.Add(compra);
        }

        [RelayCommand]
        public async Task UpdateCompra(Compra compra)
        {
            await _compraService.UpdateCompraAsync(compra);
            var index = Compras.IndexOf(compra);
            if (index != -1)
            {
                Compras[index] = compra;
            }
        }

        [RelayCommand]
        public async Task DeleteCompra(Compra compra)
        {
            await _compraService.DeleteCompraAsync(compra);
            Compras.Remove(compra);
        }
    }
}
