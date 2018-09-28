using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DataLayer
{
    abstract public class Loader
    {
        protected List<string> raw_data = new List<string>();
        protected List<string[]> processed_data = new List<string[]>();

        public Loader(string file_path)
        {
            var csv_reader = new StreamReader(File.OpenRead(file_path));

            if (csv_reader == null)
                throw new ArgumentNullException("File Path");

            csv_reader.ReadLine();
            while (!csv_reader.EndOfStream)
            {
                string curr = csv_reader.ReadLine();
                raw_data.Add(curr);
            }

            foreach (var e in raw_data)
                processed_data.Add(e.Split(','));

        }

    }
}
