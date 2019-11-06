using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdScan
{
    
    class DocInfos
    {
        public string UserName { get; set; }
        public string Project {get; set;}
        public FileInfo File {get; set;}
        public int Pages {get; set;}
        public DocInfos()
        {

        }
    }
}
