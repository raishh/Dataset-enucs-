using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DataLayer
{
    //Abstract class for loading different datasets
    abstract public class Loader
    {
        protected List<string> raw_data = new List<string>();
        protected List<string[]> processed_data = new List<string[]>();

        //Constructor taking in file_path
        public Loader(string file_path)
        {
            var csv_reader = new StreamReader(File.OpenRead(file_path));

            if (csv_reader == null)
                throw new ArgumentNullException("File Path");

            //reads csv file and collects raw data
            csv_reader.ReadLine();
            while (!csv_reader.EndOfStream)
            {
                string curr = csv_reader.ReadLine();
                raw_data.Add(curr);
            }

            //splits the csv by its commas
            foreach (var e in raw_data)
                processed_data.Add(e.Split(','));

        }

    }
}
