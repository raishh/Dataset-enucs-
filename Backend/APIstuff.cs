using System;
using System.IO;
using DataLayer;
using Microsoft.Maps.MapControl.WPF;
using System.Collections.Generic;


namespace Backend
{
    //Class for API interaction
    public class APIstuff
    {
        //static method for a map api request, specfically for a UFO sighting list
        public static string KeyRequest()
        {
            string path = Directory.GetCurrentDirectory()+@"/KEY.txt";
            return File.ReadAllText(path);
        }
    }
}
