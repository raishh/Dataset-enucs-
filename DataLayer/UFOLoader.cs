using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Globalization;

namespace DataLayer
{
    //UFO class for storing detail per each sighting
    public class UFO : Point
    {
        public DateTime date_spotted;
        public string shape;
        public string duration;
        public string comment;

        public UFO(DateTime date_spotted, string shape, string duration, string comment, double latitude, double longitude) : base (latitude, longitude)
        {
            this.date_spotted = date_spotted;
            this.shape = shape;
            this.duration = duration;
            this.comment = comment;
        }

        public override string ToString()
        {
            return $"{date_spotted}, {shape}, {duration}, {Math.Round(latitude)}, {Math.Round(longitude)}";
        }

    }

    //Child Class of Loader, UFOLoader, specifically for loading UFO csv
    public class UFOLoader : Loader
    {
        public List<UFO> UFOData { get; } = new List<UFO>();

        public UFOLoader(string file_path) : base(file_path)
        {
            CultureInfo culture = new CultureInfo("en-US");
            //if the sighting has a valid location then push it onto a list of UFO Sightings
            foreach (string[] e in processed_data)
            {
                if (e[9] == "0" || !e[0].Contains("/")) continue;
                if (e[4].Equals("")) e[4] = "unknown";

                try { UFOData.Add(new UFO(DateTime.Parse(e[0], culture), e[4], e[5], e[7], Double.Parse(e[9]), Double.Parse(e[10]))); } catch { }
            }

             UFOData.Sort((x, y) => DateTime.Compare(x.date_spotted, y.date_spotted));
        }
    }
}
