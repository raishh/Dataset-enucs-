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
using System.Windows.Shapes;
using Backend;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for FilePathWin.xaml
    /// </summary>
    public partial class FilePathWin : Window
    {
        public FilePathWin()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            App.ufo_path = txtBx.Text;
            try { MainWindow.data = BackendStuff.IntializeUFO(App.ufo_path); }
            catch
            {
                MessageBox.Show("Invalid path");
                return;
            }
            
            Close();
        }
    }
}
