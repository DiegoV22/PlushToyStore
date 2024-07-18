using Microsoft.Maui.Controls;
using PlushToyStore.Models;
using PlushToyStore.ViewModels;
using PlushToyStore.Services;

namespace PlushToyStore.Views
{
    public partial class UserView : ContentPage
    {
        private UserViewModel _viewModel;

        public UserView()
        {
            InitializeComponent();

            var userService = MauiProgram.Current.Services.GetService<UserService>();
            _viewModel = new UserViewModel(userService);
            BindingContext = _viewModel;
        }

        private void OnUserSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                _viewModel.SelectedUser = e.SelectedItem as User;
                NombreEntry.Text = _viewModel.SelectedUser.Nombre;
                CedulaEntry.Text = _viewModel.SelectedUser.Cedula;
                CorreoElectronicoEntry.Text = _viewModel.SelectedUser.CorreoElectronico;
                FechaNacimientoDatePicker.Date = _viewModel.SelectedUser.FechaNacimiento;
            }
        }

        private async void OnAddUserClicked(object sender, EventArgs e)
        {
            var newUser = new User
            {
                Nombre = NombreEntry.Text,
                Cedula = CedulaEntry.Text,
                CorreoElectronico = CorreoElectronicoEntry.Text,
                FechaNacimiento = FechaNacimientoDatePicker.Date
            };

            await _viewModel.AddUser(newUser);

            // Clear the fields after adding
            NombreEntry.Text = string.Empty;
            CedulaEntry.Text = string.Empty;
            CorreoElectronicoEntry.Text = string.Empty;
            FechaNacimientoDatePicker.Date = DateTime.Now;
        }

        private async void OnUpdateUserClicked(object sender, EventArgs e)
        {
            if (_viewModel.SelectedUser != null)
            {
                _viewModel.SelectedUser.Nombre = NombreEntry.Text;
                _viewModel.SelectedUser.Cedula = CedulaEntry.Text;
                _viewModel.SelectedUser.CorreoElectronico = CorreoElectronicoEntry.Text;
                _viewModel.SelectedUser.FechaNacimiento = FechaNacimientoDatePicker.Date;
                await _viewModel.UpdateUser(_viewModel.SelectedUser);
            }
        }

        private async void OnDeleteUserClicked(object sender, EventArgs e)
        {
            if (_viewModel.SelectedUser != null)
            {
                await _viewModel.DeleteUser(_viewModel.SelectedUser);
            }
        }
    }
}

