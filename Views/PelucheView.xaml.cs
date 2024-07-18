using Microsoft.Maui.Controls;
using PlushToyStore.Models;
using PlushToyStore.ViewModels;

namespace PlushToyStore.Views
{
    public partial class PelucheView : ContentPage
    {
        private PelucheViewModel _viewModel;

        public PelucheView()
        {
            InitializeComponent();
            BindingContext = _viewModel = new PelucheViewModel();
        }

        private void OnPelucheSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                _viewModel.SelectedPeluche = e.SelectedItem as Peluche;
                NombrePEntry.Text = _viewModel.SelectedPeluche.NombreP;
                TamanoPEntry.Text = _viewModel.SelectedPeluche.TamanoP;
                DescripcionPEntry.Text = _viewModel.SelectedPeluche.DescripcionP;
                PrecioEntry.Text = _viewModel.SelectedPeluche.Precio.ToString();
            }
        }

        private async void OnAddPelucheClicked(object sender, EventArgs e)
        {
            var newPeluche = new Peluche
            {
                NombreP = NombrePEntry.Text,
                TamanoP = TamanoPEntry.Text,
                DescripcionP = DescripcionPEntry.Text,
                Precio = decimal.Parse(PrecioEntry.Text)
            };

            await _viewModel.AddPeluche(newPeluche);

            // Clear the fields after adding
            NombrePEntry.Text = string.Empty;
            TamanoPEntry.Text = string.Empty;
            DescripcionPEntry.Text = string.Empty;
            PrecioEntry.Text = string.Empty;
        }

        private async void OnUpdatePelucheClicked(object sender, EventArgs e)
        {
            if (_viewModel.SelectedPeluche != null)
            {
                _viewModel.SelectedPeluche.NombreP = NombrePEntry.Text;
                _viewModel.SelectedPeluche.TamanoP = TamanoPEntry.Text;
                _viewModel.SelectedPeluche.DescripcionP = DescripcionPEntry.Text;
                _viewModel.SelectedPeluche.Precio = decimal.Parse(PrecioEntry.Text);

                await _viewModel.UpdatePeluche(_viewModel.SelectedPeluche);
            }
        }

        private async void OnDeletePelucheClicked(object sender, EventArgs e)
        {
            if (_viewModel.SelectedPeluche != null)
            {
                await _viewModel.DeletePeluche(_viewModel.SelectedPeluche);
            }
        }
    }
}

