﻿using System;
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
using Microsoft.Maps.MapControl.WPF;

namespace DEBUG_FrontEnd
{
    public partial class Map : Window
    {

        public Map()
        {
            InitializeComponent();
            myMap.CredentialsProvider = new Microsoft.Maps.MapControl.WPF.ApplicationIdCredentialsProvider(Backend.Backend.KeyRequest());
            myMap.Focus();

            for (int i = 0; i < (App.input.UFOData.Count)/20; i++)
            {
                Location loc = new Location();
                Pushpin pin = new Pushpin();
                loc.Latitude = App.input.UFOData[i].latitude;
                loc.Longitude = App.input.UFOData[i].longitude;
                pin.Location = loc;

                myMap.Children.Add(pin);
            }
        }
    }
}

