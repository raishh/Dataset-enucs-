using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Maps.MapControl.WPF;

namespace DataLayer
{
    abstract public class Point
    {
        public double latitude;
        public double longitude;

        public Point(double latitude, double longitude)
        {
            this.latitude = latitude;
            this.longitude = longitude;
        }
    }
}
