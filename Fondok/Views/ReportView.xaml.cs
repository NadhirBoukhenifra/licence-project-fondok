using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;
using Fondok.Context;

namespace Fondok.Views
{
    /// <summary>
    /// Interaction logic for ReportsView.xaml
    /// </summary>
    public partial class ReportView : UserControl
    {
        public ReportView()
        {
            InitializeComponent();

            LineSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Series 1",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
                },
                new LineSeries
                {
                    Title = "Series 2",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
                    PointGeometry = null
                },
                new LineSeries
                {
                    Title = "Series 3",
                    Values = new ChartValues<double> { 4,2,7,2,7 },
                    PointGeometry = DefaultGeometries.Square,
                    PointGeometrySize = 15
                }
            };

            LineLabels = new[] { "Jan", "Feb", "Mar", "Apr", "May" };
            LineYFormatter = value => value.ToString("C");

            //modifying the series collection will animate and update the chart
            LineSeriesCollection.Add(new LineSeries
            {
                Title = "Series 4",
                Values = new ChartValues<double> { 5, 3, 2, 4 },
                LineSmoothness = 0, //0: straight lines, 1: really smooth lines
                PointGeometry = Geometry.Parse("m 25 70.36218 20 -28 -20 22 -8 -6 z"),
                PointGeometrySize = 50,
                PointForeground = Brushes.Gray
            });

            //modifying any series values will also animate and update the chart
            LineSeriesCollection[3].Values.Add(5d);

            DataContext = this;










       
            
            PiePointLabel = chartPoint =>
    string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);

            //DataContext = this;
            //var context = new DatabaseContext();

            ////var RoomsReserved = (from s in context.Employees select s.EmployeeUserName).ToArray().Count();



            //RoomsStatsCircle.Series = new SeriesCollection
            //{
            //    new PieSeries
            //    {
            //        Title = "Reserved",
            //        Values = new ChartValues<double> {(from s in context.Rooms where(s.RoomStatus == "Reserved") select s.RoomID).ToArray().Count()},
            //        DataLabels = true,
            //        LabelPoint = PiePointLabel
            //    },
            //    new PieSeries
            //    {
            //        Title = "NOT Reserved",
            //        Values = new ChartValues<double> {(from s in context.Rooms where(s.RoomStatus == "Not Reserved") select s.RoomID).ToArray().Count()},
            //        DataLabels = true,
            //        LabelPoint = PiePointLabel
            //    },
            //    new PieSeries
            //    {
            //        Title = "OUT Service",
            //        Values = new ChartValues<double> {(from s in context.Rooms where(s.RoomStatus == "Out Service") select s.RoomID).ToArray().Count()},
            //        DataLabels = true,
            //        LabelPoint = PiePointLabel
            //    }
            //};






            CartesianSeriesCollection = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 }
                }
            };

            //adding series will update and animate the chart automatically
            CartesianSeriesCollection.Add(new ColumnSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 56, 42 }
            });

            //also adding values updates and animates the chart automatically
            CartesianSeriesCollection[1].Values.Add(48d);

            CartesianLabels = new[] { "Maria", "Susan", "Charles", "Frida" };
            CartesianFormatter = value => value.ToString("N");

            DataContext = this;



        }

        public SeriesCollection LineSeriesCollection { get; set; }
        public string[] LineLabels { get; set; }
        public Func<double, string> LineYFormatter { get; set; }
        



        public Func<ChartPoint, string> PiePointLabel { get; set; }
        public Func<ChartPoint, int> AllReservedRooms { get; set; }
        private void PieChart_OnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }








        public SeriesCollection CartesianSeriesCollection { get; set; }
        public string[] CartesianLabels { get; set; }
        public Func<double, string> CartesianFormatter { get; set; }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var context = new DatabaseContext();

            //var RoomsReserved = (from s in context.Employees select s.EmployeeUserName).ToArray().Count();



            RoomsStatsCircle.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Reserved",
                    Values = new ChartValues<double> {(from s in context.Rooms where(s.RoomStatus == "Reserved") select s.RoomID).ToArray().Count()},
                    DataLabels = true,
                    LabelPoint = PiePointLabel
                },
                new PieSeries
                {
                    Title = "NOT Reserved",
                    Values = new ChartValues<double> {(from s in context.Rooms where(s.RoomStatus == "Not Reserved") select s.RoomID).ToArray().Count()},
                    DataLabels = true,
                    LabelPoint = PiePointLabel
                },
                new PieSeries
                {
                    Title = "OUT Service",
                    Values = new ChartValues<double> {(from s in context.Rooms where(s.RoomStatus == "Out Service") select s.RoomID).ToArray().Count()},
                    DataLabels = true,
                    LabelPoint = PiePointLabel
                }
            };

        }
    }
}
