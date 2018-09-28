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
using DataLayer;
using Backend;

namespace DEBUG_FrontEnd
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

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            App.input = new UFOLoader(txtDebug.Text);
            foreach (var entry in App.input.UFOData)
                lstDebug.Items.Add(entry.ToString());

            btnMap.Visibility = Visibility.Visible;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnMap_Click(object sender, RoutedEventArgs e)
        {
            Map win = new Map();
            win.Show();
        }
    }
}
