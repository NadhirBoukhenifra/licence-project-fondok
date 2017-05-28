using Fondok.Models;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;

namespace Fondok.ViewModels
{
    //public class RoomsViewModel : BindableBase, IConfirmNavigationRequest
    public class RoomsViewModel : BindableBase
    {
        
            //SQLiteDatabase DB = new SQLiteDatabase();

            //DataTable Rooms;

            //String Query = "select * from ROOMS";

            //Rooms = DB.GetDataTable(Query);


        //RoomsGrid.DataContext = Rooms;
    

        //public ObservableCollection<Lecturer> Lecturers;

        public RoomsViewModel()
        {
            SQLiteDatabase DB = new SQLiteDatabase();

            DataTable RoomsSource;

            String Query = "select * from ROOMS";

            RoomsSource = DB.GetDataTable(Query);


            
        }

       

        //public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        //{
        //    bool result = true;

        //    if (MessageBox.Show("Do you to navigate?", "Navigate?", MessageBoxButton.YesNo) == MessageBoxResult.No)
        //        result = false;

        //    continuationCallback(result);
        //}

        //public bool IsNavigationTarget(NavigationContext navigationContext)
        //{
        //    return true;
        //}

        //public void OnNavigatedFrom(NavigationContext navigationContext)
        //{

        //}

        //public void OnNavigatedTo(NavigationContext navigationContext)
        //{

        //}
    }
}
