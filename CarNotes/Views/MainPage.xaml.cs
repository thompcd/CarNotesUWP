using System;

using CarNotes.ViewModels;

using Windows.UI.Xaml.Controls;

namespace CarNotes.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
