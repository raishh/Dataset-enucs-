using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DataLayer
{
    public class UFO
    {
        public string date_spotted;
        public string shape;
        public string duration;
        public double latitude;
        public double longitutde;

        public UFO(string date_spotted, string shape, string duration, double latitude, double longitutde)
        {
            this.date_spotted = date_spotted;
            this.shape = shape;
            this.duration = duration;
            this.latitude = latitude;
            this.longitutde = longitutde;
        }
    }

    public class UFOLoader : Loader
    {
        public List<UFO> ufo_data { get; } = new List<UFO>();

        public UFOLoader(string file_path) : base(file_path)
        {
            foreach (var e in processed_data)
            {
                if (e[9] == "0") continue;
                ufo_data.Add(new UFO(e[0], e[4], e[5], Double.Parse(e[9]), Double.Parse(e[10])));
            }
        }

    }
}
