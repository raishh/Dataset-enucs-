using System;
using System.IO;
using DataLayer;
using Microsoft.Maps.MapControl.WPF;
using System.Collections.Generic;
using System.Globalization;

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

        public static int[] FindDateUFO(List<UFO> list, string day, string month, string year)
        {
            List<DateTime> dt = new List<DateTime>();
            DateTime dateDt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));

            foreach (var e in list)
                dt.Add(e.date_spotted);

            int midIndex = dt.BinarySearch(dateDt);
            bool rollBack = true;
            bool rollForward = true;
            int si = midIndex - 1;
            int ei = midIndex + 1;
            int max = dt.Count - 1;

            if (midIndex == 0)
            {
                rollBack = false;
                si = midIndex;
            }
            if (midIndex == max)
            {
                rollForward = false;
                ei = midIndex;
            }

            while (rollBack)
            {
                if (si < 0)
                    rollBack = false;
                else if (dt[si] != dt[midIndex])
                    rollBack = false;
                else
                {
                    midIndex = si;
                    si--;
                }
            }

            while (rollForward)
            {
                if (ei > max)
                    rollForward = false;
                else if (dt[ei] != dt[midIndex])
                    rollForward = false;
                else
                {
                    midIndex = ei;
                    ei++;
                }
            }

            int[] returnVals = { si, ei };
            return returnVals;
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
