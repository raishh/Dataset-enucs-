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

        static int BinarySearchDate(List<DateTime> dt, int l, int r, DateTime x)
        {
            if (r >= l)
            {
                int mid = l + (r - l) / 2;
                
                if (dt[mid].Date == x.Date)
                    return mid;

                if (dt[mid].Date > x.Date)
                    return BinarySearchDate(dt, l, mid - 1, x);
                
                return BinarySearchDate(dt, mid + 1, r, x);
            }
            //returns this if not found
            return -1;
        }

        //TO-DO: Allow for ambiguous data (All)
        public static int[] FindDateUFO(List<UFO> list, string day, string month, string year, bool allFlag)
        {
            List<DateTime> dt = new List<DateTime>();
            DateTime dateDt;

            if (!allFlag)
            {
                foreach (var e in list)
                    dt.Add(e.date_spotted);
                dateDt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
            }
            else
            {
                foreach (var e in list)
                    dt.Add(new DateTime(e.date_spotted.Year, e.date_spotted.Month, 1));
                dateDt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1);
            }
            

            int max = dt.Count - 1;
            int midIndex = BinarySearchDate(dt, 0, max, dateDt);

            if (midIndex == -1)
                throw new ArgumentException("Not found");

            bool rollBack = true;
            bool rollForward = true;
            int si = midIndex - 1;
            int ei = midIndex + 1;

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
                else if (dt[si].Date != dt[midIndex].Date)
                {
                    rollBack = false;
                    si++;
                }
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
                else if (dt[ei].Date != dt[midIndex].Date)
                {
                    rollForward = false;
                    ei--;
                }
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
