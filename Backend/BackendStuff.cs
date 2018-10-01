using System;
using System.IO;
using DataLayer;
using Microsoft.Maps.MapControl.WPF;
using System.Collections.Generic;

namespace Backend
{
    //Class for API interaction
    public class BackendStuff
    {
        private static UFOLoader u;

        //static method for a map api request, specfically for a UFO sighting list
        public static string KeyRequest()
        {
            string path = Directory.GetCurrentDirectory()+@"/KEY.txt";
            return File.ReadAllText(path);
        }

        public static List<UFO> IntializeUFO(string f)
        {
            u = new UFOLoader(f);
            return u.UFOData;
        }

        public static List<string> Shapes()
        {
            List<string> shapes = new List<string>();
            foreach (var item in u.UFOData)
            {
                if (!shapes.Contains(item.shape))
                    shapes.Add(item.shape);
            }

            return shapes;
        }


    }
}
