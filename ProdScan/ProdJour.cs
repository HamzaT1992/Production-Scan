using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Threading.Tasks;
using System.Linq;
using System.Configuration;
using System.IO;
using iTextSharp.text.pdf;

namespace ProdScan
{
    public partial class ProdJour : Telerik.WinControls.UI.RadForm
    {
        string chemin = ConfigurationManager.AppSettings["url"];
        public ProdJour()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            radDateTimePicker1.Value = DateTime.Today;
            radWaitingBar1.Visible = true;
            radWaitingBar1.StartWaiting();
            radGridView1.DataSource = await Task.Run(() => dataLoad(radDateTimePicker1.Value));
            radWaitingBar1.StopWaiting();
            radWaitingBar1.Visible = false;
        }

        private async void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            radWaitingBar1.Visible = true;
            radWaitingBar1.StartWaiting();
            radGridView1.DataSource = await Task.Run(() => dataLoad(radDateTimePicker1.Value));
            radWaitingBar1.StopWaiting();
            radWaitingBar1.Visible = false;
        }

        private List<UserProd> dataLoad(DateTime dt)
        {

            var usersDirectory = Directory.GetDirectories(chemin);
            List<UserProd> users = new List<UserProd>();
            foreach (var ud in usersDirectory)
            {

                var dn = new DirectoryInfo(ud).Name;
                if (!dn.Contains(' '))
                    continue;
                var dparts = dn.Split(' ');
                var un = dparts[1];
                var userProd = new UserProd()
                {
                    Name = un,
                    BANQUE = getPPCount(ud, "BANQUE"),
                    Client = getPPCount(ud, "Client"),
                    FOURNISSEUR = getPPCount(ud, "FOURNISSEUR"),
                    SCAN = getPPCount(ud, "SCAN"),

                };
                userProd.calculTotal();



                users.Add(userProd);
            }
            return users;

        }
        private int getPPCount(string ud, string projet)
        {
            int prcount = 0;
            try
            {
                prcount = Directory.GetFiles(Path.Combine(ud, projet), "*.pdf", SearchOption.AllDirectories)
                                    .Select(f => new FileInfo(f))
                                    .Where(f => f.LastWriteTime.Date == radDateTimePicker1.Value)
                                    .Sum(f => new PdfReader(f.FullName).NumberOfPages);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return prcount;
        }


        //private int countTotal()
        //{
        //    return Directory.GetFiles(chemin, "*.pdf", SearchOption.AllDirectories)
        //                            .Select(f => new FileInfo(f))
        //                            .Where(f => f.LastWriteTime.Date == dateTimePicker1.Value)
        //                            .Sum(f => new PdfReader(f.FullName).NumberOfPages);
        //}
    }
}

