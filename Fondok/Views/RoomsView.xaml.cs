using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using MaterialDesignThemes.Wpf;
using Fondok.ViewModels;

namespace Fondok.Views
{
    /// <summary>
    /// Interaction logic for ViewA
    /// </summary>
    public partial class RoomsView : UserControl
    {
        public RoomsView()
        {
            InitializeComponent();


            DataContext = new RoomsViewModel();


        }
        //private void EditRoomClick(object sender, RoutedEventArgs e)
        //{
            

        //    SQLiteDatabase DB = new SQLiteDatabase();

        //    DataTable Rooms;

        //    String RoomsQuery = "select * from ROOMS";

        //    Rooms = DB.GetDataTable(RoomsQuery);

            
        //    string _RoomID = "select RoomID from Rooms where RoomID='"+ RoomsGrid.SelectedItem+"'";
            
            



        //    RoomsGrid.Items.Refresh();

        //}

        private void AddRoomClick(object sender, RoutedEventArgs e)
        {
            _Add_Room _Add_Room = new _Add_Room();

            _Add_Room.ShowDialog();
            




        }

       
    }
}
