using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdScan
{
    [Serializable()]
    class DocInfos : IComparable<DocInfos>
    {
        public string UserName { get; set; }
        public string Project {get; set;}
        public FileInfo File {get; set;}
        public int Pages {get; set;}
        public DocInfos()
        {

        }

        public int CompareTo(DocInfos obj)
        {
            if (File.FullName == obj.File.FullName && File.Length == obj.File.Length)
            {
                return 1;
            }
            return 0;
        }

    }
}
