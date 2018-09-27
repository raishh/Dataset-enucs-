using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DataLayer
{
    abstract class Loader
    {
        private List<string> _raw_data { get { return _raw_data; } }

        public Loader(string file_path)
        {
            var csv_reader = new StreamReader(File.OpenRead(file_path));

            if (csv_reader == null)
                throw new ArgumentNullException("File Path");

            while (!csv_reader.EndOfStream)
            {
                string curr = csv_reader.ReadLine();
                _raw_data.Add(curr);
            }
        }
    }
}
