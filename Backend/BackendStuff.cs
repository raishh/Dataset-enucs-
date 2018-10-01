using System;
using System.IO;
using DataLayer;
using Microsoft.Maps.MapControl.WPF;
using System.Collections.Generic;

namespace Backend
{
    //Class for API interaction
    public static class BackendStuff
    {

        //static method for a map api request, specfically for a UFO sighting list
        public static string KeyRequest()
        {
            string path = Directory.GetCurrentDirectory()+@"/KEY.txt";
            return File.ReadAllText(path);
        }

        public static List<string> Shapes(List<UFO> dataCopy)
        {
            List<string> shapes = new List<string>();
            foreach (var item in dataCopy)
            {
                if (!shapes.Contains(item.shape))
                    shapes.Add(item.shape);
            }

            return shapes;
        }


    }
}
