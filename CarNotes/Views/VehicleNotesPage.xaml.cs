using System;

using CarNotes.ViewModels;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CarNotes.Views
{
    public sealed partial class VehicleNotesPage : Page
    {
        public VehicleNotesViewModel ViewModel { get; } = new VehicleNotesViewModel();

        public VehicleNotesPage()
        {
            InitializeComponent();
            Loaded += VehicleNotesPage_Loaded;
        }

        private async void VehicleNotesPage_Loaded(object sender, RoutedEventArgs e)
        {
            await ViewModel.LoadDataAsync(ListDetailsViewControl.ViewState);
        }
    }
}
