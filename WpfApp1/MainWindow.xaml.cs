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


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Wb_Initialized(object sender, EventArgs e)
        {
            Wb.Navigate("https://www.google.co.in/maps");
        }
        //Not implemented yet
        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            
           
        }
        //Adds days to ComboBox list
        private void cboxDay_Loaded(object sender, RoutedEventArgs e)
        {
            for(int i = 1; i <= 31; i++)
            {
                cboxDay.Items.Add(i);
            }
                       
        }
        //Adds hours to ComboBox list
        private void cboxHour_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 24; i++)
            {
                cboxHour.Items.Add(i);
            }
        }
        //Adds months to ComboBox list
        private void cboxMonth_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1; i <= 12; i++)
            {
                cboxMonth.Items.Add(i);
            }
        }
        //Adds years to ComboBox list
        private void cboxYear_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 1906; i <= 2013; i++)
            {
                cboxYear.Items.Add(i);
            }
        }
        //Not implemented yet
        private void cboxShape_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
