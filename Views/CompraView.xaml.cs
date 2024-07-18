using Microsoft.Maui.Controls;
using PlushToyStore.Models;
using PlushToyStore.ViewModels;
using PlushToyStore.Services;
using System;
using System.Linq;

namespace PlushToyStore.Views
{
    public partial class CompraView : ContentPage
    {
        private readonly CompraViewModel _viewModel;
        private readonly UserService _userService;
        private readonly PelucheService _pelucheService;

        public CompraView()
        {
            InitializeComponent();

            _userService = MauiProgram.Current.Services.GetService<UserService>();
            _pelucheService = MauiProgram.Current.Services.GetService<PelucheService>();

            _viewModel = new CompraViewModel(MauiProgram.Current.Services.GetService<CompraService>());
            BindingContext = _viewModel;

            LoadUsersAndPeluches();
        }

        private async void LoadUsersAndPeluches()
        {
            var users = await _userService.GetUsersAsync();
            UsuarioPicker.ItemsSource = users;

            var peluches = await _pelucheService.GetPeluchesAsync();
            PeluchePicker.ItemsSource = peluches;
        }

        private void OnCompraSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                _viewModel.SelectedCompra = e.SelectedItem as Compra;
                UsuarioPicker.SelectedItem = _viewModel.SelectedCompra.Usuario;
                PeluchePicker.SelectedItem = _viewModel.SelectedCompra.Peluche;
                FechaCompraDatePicker.Date = _viewModel.SelectedCompra.FechaCompra;
            }
        }

        private async void OnAddCompraClicked(object sender, EventArgs e)
        {
            var newCompra = new Compra
            {
                Usuario = UsuarioPicker.SelectedItem as User,
                Peluche = PeluchePicker.SelectedItem as Peluche,
                FechaCompra = FechaCompraDatePicker.Date
            };
            await _viewModel.AddCompra(newCompra);
        }

        private async void OnUpdateCompraClicked(object sender, EventArgs e)
        {
            if (_viewModel.SelectedCompra != null)
            {
                _viewModel.SelectedCompra.Usuario = UsuarioPicker.SelectedItem as User;
                _viewModel.SelectedCompra.Peluche = PeluchePicker.SelectedItem as Peluche;
                _viewModel.SelectedCompra.FechaCompra = FechaCompraDatePicker.Date;
                await _viewModel.UpdateCompra(_viewModel.SelectedCompra);
            }
        }

        private async void OnDeleteCompraClicked(object sender, EventArgs e)
        {
            if (_viewModel.SelectedCompra != null)
            {
                await _viewModel.DeleteCompra(_viewModel.SelectedCompra);
            }
        }
    }
}
