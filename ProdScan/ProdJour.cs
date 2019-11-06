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
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace ProdScan
{
    public partial class ProdJour : Telerik.WinControls.UI.RadForm
    {
        List<DocInfos> AllPdfs = new List<DocInfos>();
        List<string> Allusers = new List<string>();
        string chemin = ConfigurationManager.AppSettings["url"];
        bool loading = false;
        public ProdJour()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            loading = true;
            radDateTimePicker1.Enabled = false;
            radWaitingBar1.Visible = true;
            button1.Enabled = false;
            radWaitingBar1.StartWaiting();

            var userDirs = Directory.GetDirectories(chemin)
                                    .Where(d => d.Contains("POSTE_"))
                                    .ToArray();
            await Task.Run(() =>
            {
                int count = 0;
                foreach (var udir in userDirs)
                {
                    var projectDirs = Directory.GetDirectories(udir);
                    var uparts = new DirectoryInfo(udir).Name.Split(' ');
                    var uName = uparts.Length == 2 ? uparts[1] : uparts[1]+" "+uparts[2];

                    Allusers.Add(uName);

                    foreach (var pdir in projectDirs)
                    {
                        
                        var projName = new DirectoryInfo(pdir).Name;
                        if (projName == "SCAN")
                            continue;

                        AllPdfs.AddRange(Directory.GetFiles(pdir, "*.pdf", SearchOption.AllDirectories)
                                            .Select(f => new DocInfos()
                                            {
                                                UserName = uName,
                                                Project = projName,
                                                File = new FileInfo(f),
                                                Pages = getpdfPages(f)
                                            })
                                            .ToList());
                        Console.WriteLine(++count);
                    }
                }
            });

            radWaitingBar1.StopWaiting();
            radWaitingBar1.Visible = false;
            button1.Enabled = true;

            loading = false;
            radDateTimePicker1.Value = DateTime.Today;
            radDateTimePicker1.Enabled = true;
            
            
            
        }

        private async void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (loading)
            {
                return;
            }
            radWaitingBar1.Visible = true;
            radWaitingBar1.StartWaiting();
            radGridView1.DataSource = await Task.Run(() => dataLoad());
            radWaitingBar1.StopWaiting();
            radWaitingBar1.Visible = false;
        }

        private List<UserProd> dataLoad()
        {
            var users = new List<UserProd>();
            foreach (var un in Allusers)
            {

                var userProd = new UserProd()
                {
                    Name = un,
                    BANQUE = getPPCount(un, "BANQUE"),
                    Client = getPPCount(un, "Client"),
                    FOURNISSEUR = getPPCount(un, "FOURNISSEUR"),
                    SCAN = getPPCount(un, "SCAN"),
                    CAISSE = getPPCount(un, "CAISSE")

                };
                 userProd.calculTotal();



                users.Add(userProd);
            }
            return users;

        }
        private string getPPCount(string un, string projet)
        {
            var docWithPages = "";
            try
            {
                //var pdfs = Directory.GetFiles(Path.Combine(ud, projet), "*.pdf", SearchOption.AllDirectories)
                //                    .Select(f => new FileInfo(f))
                //                    .Where(f => f.LastWriteTime.Date == radDateTimePicker1.Value.Date);
                //.Where(f => f.LastWriteTime.Date == radDateTimePicker1.Value);
                var updfs = AllPdfs
                    .Where(p => p.UserName == un && p.Project == projet && p.File.LastWriteTime.Date == radDateTimePicker1.Value.Date).ToList();
                var pages =updfs.Sum(p => p.Pages);
                docWithPages = $"{updfs.Count()} ; {pages}";
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
                FileName = "FinaTech Prod "+ radDateTimePicker1.Value.ToString("dd-MM-yyyy"),
            };
            if(dossExport.ShowDialog() == DialogResult.OK)
            {
                var doss = dossExport.FileName;

                var spreadExport = new GridViewSpreadExport(radGridView1);
                var exportRender = new SpreadExportRenderer();
                spreadExport.RunExport(doss, exportRender);
            }
        }

        private void ProdJour_SizeChanged(object sender, EventArgs e)
        {
            radDateTimePicker1.Top = (radPanel1.ClientSize.Height - radDateTimePicker1.Height) / 2;
            radDateTimePicker1.Left = (radPanel1.ClientSize.Width - radDateTimePicker1.Width) / 2;
        }

        private int getpdfPages(string pdf)
        {
            int nump = 0;
            if (!File.Exists(pdf))
            {
                pdf = pdf.Replace(".pdf", "OK.pdf");
            }
            if (!File.Exists(pdf))
            {
                return 0;
            }
            try
            {
                pdf = "\""+pdf+"\"";
                var process = new Process
                {
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = @".\PDFtk\bin\pdftk.exe",
                        Arguments = $"{pdf} dump_data",
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        CreateNoWindow = true
                    }
                };

                process.Start();

                string strOutput = process.StandardOutput.ReadToEnd();

                process.Close();

                nump = int.Parse(Regex.Match(strOutput, @"NumberOfPages: (\d+)").Groups[1].Value);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return nump;
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

