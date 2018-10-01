using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DataLayer
{
    //UFO class for storing detail per each sighting
    public class UFO : Point
    {
        public string date_spotted;
        public string shape;
        public string duration;
        public string comment;

        public UFO(string date_spotted, string shape, string duration, string comment, double latitude, double longitude) : base (latitude, longitude)
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
            //if the sighting has a valid location then push it onto a list of UFO Sightings
            foreach (string[] e in processed_data)
            {
                if (e[9] == "0" || !e[0].Contains("/")) continue;
                try { UFOData.Add(new UFO(e[0], e[4], e[5], e[7], Double.Parse(e[9]), Double.Parse(e[10]))); } catch { }
            }

            string[] tempArr;
            string swap;

            foreach (UFO item in UFOData)
            {
                tempArr = item.date_spotted.Split('/', ' ');

                swap = tempArr[0];
                tempArr[0] = tempArr[2];
                tempArr[2] = swap;

                swap = tempArr[1];
                tempArr[1] = tempArr[2];
                tempArr[2] = swap;

                if (tempArr[2].StartsWith("0"))
                    tempArr[2] = Convert.ToString(Convert.ToInt32(tempArr[2]));
                if (tempArr[1].StartsWith("0"))
                    tempArr[1] = Convert.ToString(Convert.ToInt32(tempArr[1]));

                item.date_spotted = tempArr[0] + "/" + tempArr[1] + "/" + tempArr[2] + " " + tempArr[3];

                if (item.shape.Equals(""))
                    item.shape = "unknown";
            }
             UFOData.Sort((x, y) => x.date_spotted.CompareTo(y.date_spotted));
        }
    }
}
