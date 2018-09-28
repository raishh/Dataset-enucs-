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

namespace DEBUG_FrontEnd
{
    public partial class Map : Window
    {

        public Map()
        {
            InitializeComponent();
            myMap.CredentialsProvider = new Microsoft.Maps.MapControl.WPF.ApplicationIdCredentialsProvider(APIstuff.KeyRequest());
        }
    }
}
