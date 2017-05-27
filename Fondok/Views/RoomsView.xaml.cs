using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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
            SQLiteDatabase DB = new SQLiteDatabase();

            DataTable Rooms;

            String Query = "select * from ROOMS";

            Rooms = DB.GetDataTable(Query);

            RoomsGrid.DataContext = Rooms;


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    object item = MyDataGrid.SelectedItem;
            //    gridDataContext datacontext = new gridDataContext();

            //    int m = int.Parse((MyDataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text);

            //    registration Registration = datacontext.registrations.Where(A => A.RegId == m).Single();
            //    Registration.Name = (MyDataGrid.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
            //    Registration.FName = (MyDataGrid.SelectedCells[2].Column.GetCellContent(item) as TextBlock).Text;
            //    datacontext.SubmitChanges();
            //    MessageBox.Show("Row Updated Successfully");
            //    LoadCustomerDetail();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    return;
            //}

            SQLiteDatabase DB = new SQLiteDatabase();

            DataTable Rooms;

            String RoomsQuery = "select * from ROOMS";

            Rooms = DB.GetDataTable(RoomsQuery);

            object _SelectedItem = RoomsGrid.SelectedItem;
            
            string _RoomID = "select RoomID from Rooms where RoomID='"+ RoomsGrid.SelectedItem+"'";
            string _RoomType = "select RoomType from Rooms where RoomType='' ";
            //string Pass = "select PASSWORD from USERS where PASSWORD='" + this.userPasswordBox.Password + "' ";

            string _RID = DB.ExecuteScalar(_RoomID);
            string _RType = DB.ExecuteScalar(_RoomType);

            List<string> RoomRow = new List<string>();
            List<string> RoomCol = new List<string>();

            foreach (DataRow rRow in Rooms.Rows)
            {
                RoomRow.Add(rRow.ToString());
                foreach (DataColumn rCol in Rooms.Columns)
                {
                    //MessageBox.Show(Rooms.Columns.Count.ToString() + dtRow[dc].ToString());
                RoomRow.Add(rCol.ToString());

                }

            }

            MessageBox.Show(Rooms.Columns.Count.ToString() + RoomRow[1] );


            RoomsGrid.Items.Refresh();

        }
    }
}
