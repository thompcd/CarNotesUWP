using System;

using CarNotes.ViewModels;

using Windows.UI.Xaml.Controls;

namespace CarNotes.Views
{
    public sealed partial class LogInPage : Page
    {
        public LogInViewModel ViewModel { get; } = new LogInViewModel();

        public LogInPage()
        {
            InitializeComponent();
        }
    }
}
