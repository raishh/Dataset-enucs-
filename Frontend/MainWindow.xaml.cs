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
using Backend;
using DataLayer;
using Microsoft.Maps.MapControl.WPF;
using System.IO;


namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        public static List<UFO> data;

        public MainWindow()
        {
            InitializeComponent();
            myMap.CredentialsProvider = new Microsoft.Maps.MapControl.WPF.ApplicationIdCredentialsProvider(Backend.BackendStuff.KeyRequest());
            myMap.Focus();

            App.ufo_path = Directory.GetCurrentDirectory() + @"/scrubbed.csv";
            try { data = BackendStuff.IntializeUFO(App.ufo_path); }
            catch
            {
                FilePathWin verifyWindow = new FilePathWin();
                verifyWindow.Show();
            } 
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {

            //debugging
            int[] i = BackendStuff.FindDateUFO(data, "10", "10", "1994");
            
            if (i[0] != i[1])
            {
                for (int x = i[0]; x <= i[1]; x++)
                {
                    Location loc = new Location();
                    Pushpin pin = new Pushpin();
                    loc.Latitude = data[x].latitude;
                    loc.Longitude = data[x].longitude;
                    pin.Location = loc;
                    myMap.Children.Add(pin);
                }
            }
        }

        //Adds years to ComboBox list
        private void cboxYear_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1906; i <= 2014; i++)
            {
                cboxYear.Items.Add(i);
            }
            cboxYear.Items.Add("All");
            
        }
        //Adds months to ComboBox list
        private void cboxMonth_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 12; i++)
            {
                cboxMonth.Items.Add(i);
            }
            cboxMonth.Items.Add("All");
            
        }
        
        //Adds default days to ComboBox list
        private void cboxDay_Loaded(object sender, RoutedEventArgs e)
        {
            
            for (int i = 1; i <= 31; i++)
            {
                cboxDay.Items.Add(i);
            }
            cboxDay.Items.Add("All");
            

        }

        //Adds hours to ComboBox list
        private void cboxHour_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 24; i++)
            {
                cboxHour.Items.Add(i);
            }
            cboxHour.Items.Add("All");
            
        }
                
        //Partly implemented
        private void cboxShape_Loaded(object sender, RoutedEventArgs e)
        {
            List<string> shapes = BackendStuff.Shapes();
            foreach (string shape in shapes)
            {
                cboxShape.Items.Add(shape);
            }
            cboxShape.Items.Add("All");
        }

        //Change number of days for each month        
        private void cboxYear_DropDownClosed(object sender, EventArgs e)
        {
            dayChange(cboxMonth.Text, cboxYear.Text);
        }

        //Change number of days for each month        
        private void cboxMonth_DropDownClosed(object sender, EventArgs e)
        {
            dayChange(cboxMonth.Text, cboxYear.Text);
        }
        
        private void cboxDay_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void cboxHour_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void cboxShape_DropDownClosed(object sender, EventArgs e)
        {

        }

        //Delete all items from Day ComboBox and populate it from 1 to temp
        //Where temp depends on month and year
        private void dayChange(string month, string year)
        {
            cboxDay.Items.Clear();
            int temp = 0;

            if (month == "1" || month == "3" || month == "5" || month == "7" || month == "8" || month == "10" || month == "12")
                temp = 31;
            else if (month == "4" || month == "6" || month == "9" || month == "11")
                temp = 30;
            else if (month == "2" && (String.IsNullOrEmpty(year) || Convert.ToInt32(year) % 4 != 0))
                temp = 28;
            else
                temp = 29;

            for (int i = 1; i <= temp; i++)
                cboxDay.Items.Add(i);

            cboxDay.Items.Add("All");
        }

        private void cboxShape_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cboxShape_ContextMenuClosing(object sender, ContextMenuEventArgs e)
        {
        }
    }
}
