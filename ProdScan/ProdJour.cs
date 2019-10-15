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
using Telerik.WinControls.Export;

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
            button1.Enabled = false;
            radWaitingBar1.StartWaiting();
            radGridView1.DataSource = await Task.Run(() => dataLoad(radDateTimePicker1.Value));
            radWaitingBar1.StopWaiting();
            radWaitingBar1.Visible = false;
            button1.Enabled = true;
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
        private string getPPCount(string ud, string projet)
        {
            var docWithPages = "";
            try
            {
                var pdfs = Directory.GetFiles(Path.Combine(ud, projet), "*.pdf", SearchOption.AllDirectories)
                                    .Select(f => new FileInfo(f))
                                    .Where(f => f.LastWriteTime.Date == radDateTimePicker1.Value);
                var pages =pdfs.Sum(f => new PdfReader(f.FullName).NumberOfPages);
                docWithPages = $"{pdfs.Count()} ; {pages}";
                if (pages == 0)
                    docWithPages = "0";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return docWithPages;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dossExport = new SaveFileDialog() {
                Filter = "Excel | *.xlsx",
                FileName = "FinaTech Prod "+DateTime.Now.ToString("dd -MM-yyyy_hh-mm"),
            };
            if(dossExport.ShowDialog() == DialogResult.OK)
            {
                var doss = dossExport.FileName;

                var spreadExport = new GridViewSpreadExport(radGridView1);
                var exportRender = new SpreadExportRenderer();
                spreadExport.RunExport(doss, exportRender);
            }
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

