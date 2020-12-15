using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Alkalmazas
{
    public class CsvWriter
    {
        private string path;

        public CsvWriter(string path)
        {
            if (path is null)
            {
                throw new ArgumentNullException();
            }
            this.path = path;
        }
        
        public void WriteRow(string row)
        {
            File.AppendAllText(path, row); 
        }
    }
}
