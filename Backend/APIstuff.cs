using System;
using Google.Maps;
using System.IO;

namespace Backend
{
    public class APIstuff
    {
        public static void UFORequest()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"/KEY.txt";
            string key = System.IO.File.ReadAllText(path);
        }
    }
}
