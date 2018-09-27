using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DataLayer
{
    public class UFOLoader : Loader
    {
        private List<string> _raw_data;

        public UFOLoader(string file_path) : base(file_path) { }
    }
}
