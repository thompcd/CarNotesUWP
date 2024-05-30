using System;

using CarNotes.Core.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CarNotes.Views
{
    public sealed partial class VehicleNotesDetailControl : UserControl
    {
        public SampleOrder ListMenuItem
        {
            get { return GetValue(ListMenuItemProperty) as SampleOrder; }
            set { SetValue(ListMenuItemProperty, value); }
        }

        public static readonly DependencyProperty ListMenuItemProperty = DependencyProperty.Register("ListMenuItem", typeof(SampleOrder), typeof(VehicleNotesDetailControl), new PropertyMetadata(null, OnListMenuItemPropertyChanged));

        public VehicleNotesDetailControl()
        {
            InitializeComponent();
        }

        private static void OnListMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as VehicleNotesDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
