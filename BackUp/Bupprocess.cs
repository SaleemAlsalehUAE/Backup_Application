using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Microsoft.VisualBasic.FileIO;
using MYCPF;
using System.IO;
using System.Data.OleDb;
using System.Diagnostics;
using System.Threading;
namespace BackUp
{
    public partial class Bupprocess : Form, ICopyFilesDiag
    {
       
        public System.ComponentModel.ISynchronizeInvoke SynchronizationObject { get; set; }
        //List<String> TempFiles;
        string dEST = "";
        int bupid;
        int c = -1;
        int finishingcounter = 0;
        int sourccount = 0;
        bool callcopy = false;
        OleDbDataReader oldr;
        public static bool started=false;
        bool finished=false,canceled=false;
        ListView.ListViewItemCollection items;
        int cdn = 10;
        // WebClient webClient = new WebClient();
       
        public Bupprocess()
        {
            InitializeComponent();
        }

        //protected override bool ProcessDialogKey(Keys keyData)
        //{
        //    if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
        //    {
        //        RaiseCancel();
        //        this.Close();
        //        return true;
        //    }
        //    return base.ProcessDialogKey(keyData);
        //}
        public void update(Int32 totalFiles, Int32 copiedFiles, Int64 totalBytes, Int64 copiedBytes, String currentFilename)
        {
            progressBar1.Maximum = totalFiles;
            progressBar1.Value = copiedFiles;
            progressBar2.Maximum = 100;
            if (totalBytes != 0)
            {
                progressBar2.Value = Convert.ToInt32((100f / (totalBytes / 1024f)) * (copiedBytes / 1024f));
            }

            label2.Text = "Total files (" + copiedFiles + "/" + totalFiles + ")";
            label3.Text = currentFilename;

        }

        public void bupcompleted() {
            finishingcounter++;
            if (finishingcounter == sourccount)
            {
                finished = true;
                callcopy = false;
            }
            else { callcopy = true; }
        
        }
        public void bupcanceled()
        {
            canceled = true;
        }
        private void RaiseCancel()
        {
            if (EN_cancelCopy != null)
            {
                EN_cancelCopy();
            }
        }
        public event CopyFiles.DEL_cancelCopy EN_cancelCopy;
        public Bupprocess(ListView.ListViewItemCollection items)
        {
            InitializeComponent();
            this.items = items;
            sourccount = items.Count;
        }

        private void Bupprocess_Load(object sender, EventArgs e)
        {
            //progressBar1.Show();
            //progressBar2.Show();
            //label2.Show();
            //label3.Show();
            countdown();
            
            
        }

        private void countdown()
        {
            timer1.Start();
        }

        private void begin()
        {
          
            timer2.Start();
            progressBar1.Show();
            progressBar2.Show();
            label2.Show();
            label3.Show();
            label4.Hide();
            label5.Show();
            label6.Show();
            label7.Show();
            label8.Show();
            label1.Text = "BackUp in Progress";
           // CopyFileWithProgress("Test.mkv", "D:\\");
            setbuplog();
            started = true;
            copy();

           
           
        }

        private void copy()
        {
      
           // sourccount = items.Count;
            c++;
            if (c < items.Count)
            {
                string source = items[c].SubItems[1].Text;
                dEST = items[c].SubItems[2].Text;
                label7.Text = source;
                label8.Text = dEST;
                if (targetroot(dEST))
                {
                    DirectoryInfo d = new DirectoryInfo(source);
                    if (d.Parent == null)
                    {

                        // MessageBox.Show("Drive");
                        dEST = dEST + "\\" + source.Replace(":", "");
                        label7.Text = source;
                        label8.Text = dEST;
                        //string[] ds = Directory.GetDirectories(source);
                        //ds = removeunwanteddir(ds);
                        //string[] fls = Directory.GetFiles(source);
                        //for (int j = 0; j < ds.Length; j++)
                        //{
                        MYCPF.CopyFiles Temp = new MYCPF.CopyFiles(source, dEST);
                        this.SynchronizationObject = this;
                        Temp.CopyAsync(this);


                        //}
                        //if (fls.Length > 0)
                        //{
                        //    List<string> T = new List<string>();
                        //    T.AddRange(fls);

                        //    MYCPF.CopyFiles Temp2 = new MYCPF.CopyFiles(T, dEST);
                        //    this.SynchronizationObject = this;
                        //    Temp2.CopyAsync(this);
                        //}

                    }
                    else
                    {
                        //List<string> T = new List<string>();
                        //string[] ds = Directory.GetDirectories(items[i].SubItems[1].Text);
                        //for (int j = 0; j < ds.Length; j++)
                        //{
                        //    T.AddRange(Directory.GetFiles(ds[j]));



                        MYCPF.CopyFiles Temp = new MYCPF.CopyFiles(source, dEST);
                        this.SynchronizationObject = this;
                        Temp.CopyAsync(this);

                    }
                }
                else
                {
                    MessageBox.Show("Please Make sure of target current operation will be skipped  " + Environment.NewLine + " not fount " + dEST + "backup Target  ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //if(i==items.Count-1){
                    // if(!CopyFiles.copying){
                    //     timer1.Stop();
                    //     timer2.Stop();
                    //     this.Dispose();
                    // }}

                }
            }
            //else {
            //    timer1.Stop();
            //    timer2.Stop();
            //    this.Dispose();
            //}
        }

        private string[] removeunwanteddir(string[] ds)
        {
             List<string> T = new List<string>();
             for (int i = 0; i < ds.Length;i++ ) {
                 if (!(ds[i].Contains("$RECYCLE.BIN") || ds[i].Contains("System Volume Information")))
                 {
                     T.Add(ds[i]);
                 }
             }
             return T.ToArray();
             }

        private bool targetroot(string dEST)
        {
            DirectoryInfo d = new DirectoryInfo(dEST);
            if(d.Root.Exists){
            return true;
            }
                return false;
        }

        private void setbuplog()
        {
            DateTime d = DateTime.Now;
            string state = "started";
            string q1 = "select  Max(Log.[id]) AS Expr1 from Log";
            
            oldr = Form1.mycon.execselect(q1);
            //int i = 0;
            if (oldr.HasRows)
            {
                oldr.Read();
                if (!oldr.IsDBNull(0))
                {
                    bupid = oldr.GetInt32(0) + 1;
                }
                else {
                    bupid = 0;
                }
            }
            else {
                bupid = 0;
            }
            oldr.Close();
            string q = "insert into Log(id,Ldts,Ldtf,Lstate) values("+bupid+",'"+d+"','"+d+"','"+state+"')";
            if (Form1.mycon.Execup(q) == 0)
            {
                MessageBox.Show("save Failed");
            }
       

        }

        //private List<string> fillFiles(string source)
        //{

            
        //    return T;

        //}

        //public delegate void IntDelegate(int Int);

        //public  event IntDelegate FileCopyProgress;
        //public  void CopyFileWithProgress(string source, string destination)
        //{
        //     webClient = new WebClient();
            
        //    webClient.DownloadProgressChanged += DownloadProgress;
        //    webClient.DownloadFileAsync(new Uri("E:\\Work\\Projects\\BackUp\\BackUp\\bin\\Debug\\Test.mkv"), "D:\\s.mkv");
        //}

        //private  void DownloadProgress(object sender, DownloadProgressChangedEventArgs e)
        //{
        //    if (FileCopyProgress != null)
        //        FileCopyProgress(e.ProgressPercentage);
        //    progressBar1.Value = e.ProgressPercentage;
        //}


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cdn == 0)
            {
               
                timer1.Stop();
                begin();
            }
            else
            {
                label1.Text = cdn.ToString();
                cdn--;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            started = false;
            if (timer1.Enabled)
            {
                Form1.canceled();
                this.Close();
            }
            else
            {
                RaiseCancel();
                Form1.canceled();
            }


        }

        private void Bupprocess_FormClosing(object sender, FormClosingEventArgs e)
        {
           // RaiseCancel();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(canceled){
                string s = "canceled";
                DateTime d = DateTime.Now;
                string q = "update Log set Lstate='"+s+"' ,Ldtf='"+d+"' where id = " + bupid;

                if (Form1.mycon.Execup(q) == 0)
                {
                    MessageBox.Show("Edit Failed");
                }


                timer2.Stop();
                progressBar1.Hide();
                progressBar2.Hide();
                label2.Hide();
                label3.Hide();
                label5.Hide();
                label6.Hide();
                label7.Hide();

                label8.Hide();
                label1.Text = "BackUp Canceled";
                button1.Hide();
                button2.Show();
            }
            else if (finished)
            {
                bupfinished();

            }else if(callcopy){
                copy();
            }
        }

        private void bupfinished()
        {
            DateTime d = DateTime.Now;
            string s = "finished";
            string q = "update Log set Lstate='" + s + "', Ldtf='" + d + "' where id = " + bupid;

            if (Form1.mycon.Execup(q) == 0)
            {
                MessageBox.Show("Edit Failed");
            }

            timer2.Stop();
            progressBar1.Hide();
            progressBar2.Hide();
            label2.Hide();
            label3.Hide();
            label8.Hide();
            label7.Hide();
            label5.Hide();
            label6.Hide();
            label1.Text = "BackUp Succeded";
            button1.Hide();
            button2.Show();
            shutdownifture();
        }

        private void shutdownifture()
        {
            string q = "select Shutdown from Settings";

              oldr = Form1.mycon.execselect(q);
            //int i = 0;
              if (oldr.HasRows)
              {
                  oldr.Read();
                  if (!oldr.IsDBNull(0))
                  {
                     if(oldr.GetBoolean(0)){
                         oldr.Close();
                         Form1.mycon.endconnection();
                         try
                         {
                             //MessageBox.Show("Shutting down");
                              Process.Start("shutdown", "-s -f -t 0");
                         }
                         catch (Exception ex)
                         {

                             MessageBox.Show(ex.Message);
                         }
                     }
                  }
              
              }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            started = false;
            this.Close();
        }


    }
}
