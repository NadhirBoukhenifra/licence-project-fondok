using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using MaterialDesignThemes.Wpf;
using Fondok.ViewModels;
using System.Data.SQLite;
using Fondok.Views.Windows;
namespace Fondok.Views
{
    public partial class RoomView : UserControl
    {
        public RoomView()
        {
            InitializeComponent();
        }
       
       
        void RoomViewLoaded(object sender, RoutedEventArgs e)
        {
            RoomGrid.UpdateLayout();
            RoomGrid.Items.Refresh();

        }

    }
}