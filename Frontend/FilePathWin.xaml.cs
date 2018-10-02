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
using System.IO;
using Microsoft.Win32;

namespace WpfApp1
{
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    var csv_reader = new StreamReader(File.OpenRead(openFileDialog.FileName));

                    if (csv_reader == null)
                        throw new ArgumentNullException("File Path");
                }
                catch
                {
                    MessageBox.Show("Invalid path");
                    return;
                }

            }
            
            App.ufo_path = openFileDialog.FileName;
            App.accessed = true;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
