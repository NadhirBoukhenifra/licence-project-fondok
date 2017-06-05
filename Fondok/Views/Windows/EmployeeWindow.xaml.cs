using Fondok.Context;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace Fondok.Views.Windows
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        public EmployeeWindow()
        {
            InitializeComponent();
            //var context = new DatabaseContext();

            //var EmployeeJobList = (from s in context.Employees select s.EmployeeUserName).ToArray();
            string[] EmployeeJobList = new string[] { "Admin", "Receptionist"};

            EmployeeJobField.ItemsSource = EmployeeJobList;
            //EmployeeDateOfBirthField.SelectedDate = DateTime.ParseExact("MM/dd/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            //EmployeeDateOfBirthField.SelectedDate = DateTime.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
            //EmployeeDateOfBirthField.SelectedDate.Value(DateTime.Now.ToShortDateString());
            //EmployeeDateOfBirthField.SelectedDate = DateTime.Now;
            //EmployeeDateOfBirthField.Text = DateTime.Now.ToString();

            //EmployeeDateOfBirthField.SelectedDate = DateTime.Now;

            //EmployeeDateOfBirthField.DisplayDate = DateTime.Now;
            //EmployeeDateOfBirthField.Text = DateTime.Now.ToString();


            if (EmployeeDateOfBirthField.SelectedDate == null)
            {

                MessageBox.Show("Null" + EmployeeDateOfBirthField.SelectedDate.ToString());

            }
            else
            {
                MessageBox.Show("NOT" + EmployeeDateOfBirthField.SelectedDate.ToString());

            }
        }

        private void AddEmployeeClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;

        }

        public void TextBoxPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            EmployeeDateOfBirthField.IsDropDownOpen = true;
        }

        private void TextBoxPreviewTouchDown(object sender, TouchEventArgs e)
        {
            EmployeeDateOfBirthField.IsDropDownOpen = true;
        }

        private void DatePickerSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            EmployeeDateOfBirthField.IsDropDownOpen = false;

            //EmployeeDateOfBirthField.SelectedDate.Value.ToString("MM-dd-yyyy", System.Globalization.CultureInfo.InvariantCulture);


            //if (EmployeeDateOfBirthField.SelectedDate.HasValue)
            //{
            //    MessageBox.Show(EmployeeDateOfBirthField.SelectedDate.Value.ToString());
            //}

            //String MyString;
            //MyString = EmployeeDateOfBirthField.SelectedDate.Value.ToString("MM/dd/yyyy");

            //DateTime MyDateTime;
            //MyDateTime = new DateTime();

            //MyDateTime = DateTime.ParseExact(MyString, "MM/dd/yyyy",
            //                                 null);
            //EmployeeDateOfBirthField.SelectedDate = MyDateTime;

            //EmployeeDateOfBirthField.SelectedDate = Convert.ToDateTime(EmployeeDateOfBirthField.SelectedDate.Value.Year.ToString());

            //MessageBox.Show("Hello nb" + Convert.ToDateTime(EmployeeDateOfBirthField.SelectedDate.Value.Year.ToString("yyyy")));
            //MessageBox.Show("Hello nb" + EmployeeDateOfBirthField.DisplayDate.Day
            //    + EmployeeDateOfBirthField.DisplayDate.Month + EmployeeDateOfBirthField.DisplayDate.Year
            //    );

            //string s = EmployeeDateOfBirthField.SelectedDate.Value.Year.ToString()+"/" + EmployeeDateOfBirthField.SelectedDate.Value.Month.ToString()+"/" + EmployeeDateOfBirthField.SelectedDate.Value.Day.ToString();

            //MessageBox.Show("Hello before" + s

            //   );
            //System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-gb");

            //EmployeeDateOfBirthField.SelectedDate = DateTime.Parse(s, cultureinfo);
            //MessageBox.Show("Hello after" + EmployeeDateOfBirthField.SelectedDate.Value.ToString()

            //   );
            //string nb = EmployeeDateOfBirthField.SelectedDate.Value - DateTime.Parse(s, cultureinfo);

            //DateTime.Parse("13/12/2014", new CultureInfo("en-GB")); // Works fine.
            //string myDateTimeValue = "2/16/1992 12:15:12";
            //IFormatProvider culture = new CultureInfo("fr-FR", true);

            //MessageBox.Show(DateTime.ParseExact(myDateTimeValue, "MM/dd/yyyy", culture, DateTimeStyles.AdjustToUniversal).ToString());

            

        }

    }

}
