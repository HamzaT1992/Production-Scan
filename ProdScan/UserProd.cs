using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdScan
{
    class UserProd
    {
        public string Name { get; set; }
        public int BANQUE { get; set; }
        public int Client { get; set; }
        public int FOURNISSEUR { get; set; }
        public int SCAN { get; set; }
        public int Total { get; set; }

        public UserProd()
        {
            
        }
        public void calculTotal()
        {
            Total = BANQUE + Client + FOURNISSEUR + SCAN;
        }
    }
}
