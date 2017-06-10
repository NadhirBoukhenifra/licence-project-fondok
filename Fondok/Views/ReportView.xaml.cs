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

            PiePointLabel = chartPoint => string.Format("{0} ({1:P})", chartPoint.Y, chartPoint.Participation);














            IncomesSeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Reservations Incomes",
                    Values = new ChartValues<double> { 4, 6,0,0 }
                },
                new LineSeries
                {
                    Title = "Forms Incomes",
                    Values = new ChartValues<double> { 6, 7,0,0 }
                }
            };

            IncomesLabels = new[] { "Week 01", "Week 02", "Week 03", "Week 04" };
            IncomesValues = new[] { 100, 200, 300, 400 };
            IncomesYFormatter = value => value.ToString("DZD #; 0");

            //modifying the series collection will animate and update the chart
            //IncomesSeriesCollection.Add(new LineSeries
            //{
            //    Values = new ChartValues<double> { 5, 3, 2, 4 },
            //    LineSmoothness = 0 //straight lines, 1 really smooth lines
            //});

            //modifying any series values will also animate and update the chart
            //IncomesSeriesCollection[2].Values.Add(5d);







            DataContext = this;

        }

        public Func<ChartPoint, string> PiePointLabel { get; set; }
        public Func<ChartPoint, int> AllReservedRooms { get; set; }
        private void PieChartOnDataClick(object sender, ChartPoint chartpoint)
        {
            var chart = (LiveCharts.Wpf.PieChart)chartpoint.ChartView;

            //clear selected slice.
            foreach (PieSeries series in chart.Series)
                series.PushOut = 0;

            var selectedSeries = (PieSeries)chartpoint.SeriesView;
            selectedSeries.PushOut = 8;
        }











        public SeriesCollection IncomesSeriesCollection { get; set; }
        public string[] IncomesLabels { get; set; }
        public int[] IncomesValues { get; set; }
        public Func<double, string> IncomesYFormatter { get; set; }




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



            TotalRooms.Text = "Total Rooms: " + (from s in context.Rooms select s.RoomID).ToArray().Count().ToString();
            TotalClients.Text = "Total Clients: " + (from s in context.Clients select s.ClientID).ToArray().Count().ToString();
            TotalEmployees.Text = "Total Employees: " + (from s in context.Employees select s.EmployeeID).ToArray().Count().ToString();

        }
    }
}
