using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace BackUp
{
    public partial class Form1 : Form
    {
        OleDbDataReader oldr;
        public static bool timedbupcanceled=false;
        public static Connection mycon = new Connection();
        bool exit = false;
        static bool timed = false;
        public Form1()
        {
            InitializeComponent();
        }


        //protected override bool ProcessDialogKey(Keys keyData)
        //{
        //    if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
        //    {
        //        this.Close();
        //        return true;
        //    }
        //    return base.ProcessDialogKey(keyData);
        //}

        private void Form1_Load(object sender, EventArgs e)
        {


            mycon.startconnection();
            fillvalues();
            timer1.Start();
        }

        //private void test()
        //{
        //    //string fn = "xxxxxxxxxxxxxddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd.txt";
        //    //try
        //    //{
        //    //    File.Copy(fn, "Bassam" + "\\"+fn, true);
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    MessageBox.Show(ex.Message);
        //    //    // e.Cancel = true;
        //    //}
        //}

        private void listView11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView11.SelectedItems.Count > 0)
            {
               textBox27.Text = listView11.SelectedItems[0].SubItems[1].Text;

                textBox1.Text = listView11.SelectedItems[0].SubItems[2].Text;
                textBox2.Text = listView11.SelectedItems[0].SubItems[3].Text;
  
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add();
        }

        private void add()
        {
            addbup adbupfrm = new addbup();
            adbupfrm.ShowDialog();
            fillvalues();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delet();
            
        }

        private void delet()
        {
            if (listView11.Items.Count > 0)
            {
                if (listView11.SelectedItems.Count > 0)
                {
                    int eid = int.Parse(listView11.SelectedItems[0].SubItems[0].Text);
                    if (MessageBox.Show("Are you sure you want to delete selected Path ", "Delete BackUp Path", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                    {
                        string q = "delete from Paths where id= " + eid;
                        if (Form1.mycon.Execup(q) == 0)
                        {
                            MessageBox.Show("Delete Failed");
                        }
                        else
                        {
                            MessageBox.Show("Path Deleted");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Select Path from the List");
                }
            }

            fillvalues();
        }

        private void fillvalues()
        {
            listView11.Items.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox27.Text = "";
            string q = "select * from Paths";

            

            oldr = Form1.mycon.execselect(q);
            //int i = 0;
            if (oldr.HasRows)
            {

                while (oldr.Read())
                {
                    //q1 = "SELECT Students.id AS Students_id, Students.Fname, Students.Fthrname, Students.Mothnm, Students.Ssex, Students.Pbirth, Students.Sbirth, Students.Recdate, DateDiff('m',[Recdate],Now()) AS Smnths, Students.Joindt, Students.address, Students.FthrWrk, Students.FthrMob, Students.Mothwrk, Students.Mothmob, Students.Fathmail, Students.Fthrwrkphn, Students.FthrNatnm, Students.Mothmail, Students.Mothwrkphn, Students.Notes, Stdyears.id AS Stdyears_id, Stdyears.Styear, Stdyears.Ystlm, Stdyears.Ystlmnum FROM Students INNER JOIN Stdyears ON Students.[id] = Stdyears.[Sid]  where ";
                    ListViewItem LItem = new ListViewItem();
                    LItem.Text = oldr.GetInt32(0).ToString();


                    if (!oldr.IsDBNull(1))
                    {
                        LItem.SubItems.Add(oldr.GetString(1));
                    }
                    else { LItem.SubItems.Add("empty"); }

                    if (!oldr.IsDBNull(2))
                    {
                        LItem.SubItems.Add(oldr.GetString(2));
                    }
                    else { LItem.SubItems.Add("empty"); }

                    if (!oldr.IsDBNull(3))
                    {
                        LItem.SubItems.Add(oldr.GetString(3));
                    }
                    else { LItem.SubItems.Add("empty"); }

                    listView11.Items.Add(LItem);
                }
            } oldr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void edit()
        {

            if (listView11.Items.Count > 0)
            {
                if (listView11.SelectedItems.Count > 0)
                {
                    int id = int.Parse(listView11.SelectedItems[0].SubItems[0].Text);
                    addbup adfrm = new addbup(id);
                    adfrm.ShowDialog();
                    fillvalues();
                }
                else
                {
                    MessageBox.Show("Please select Path from The List");
                }
            }
        
        }

        private void listView11_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            edit();
        }

        private void إضافةمسارنسخاحتياطيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add();
        }

        private void تعديلمسارنسخاحتياطيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void حذفمسارالنسخالاحتياطيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delet();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Set();
        }

        private void Set()
        {
            Settings setfrm = new Settings();
            setfrm.ShowDialog();
            timedbupcanceled = false;
        }

        private void تحديدوقتالنسخالاحتياطيToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Set();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (listView11.Items.Count > 0)
            {
                int h = DateTime.Now.Hour;
                int m = DateTime.Now.Minute;

                string q = "SELECT  * from Settings  WHERE    Hour([Buptime])=" + h + " And Minute([Buptime])= " + m;
                //OR  (DatePart('yyyy',[Tdate])=" + yr + " AND  DatePart('m',[Tdate])=" + mnth + " AND DatePart('d',[Tdate])=" + dy + "   AND TimeValue([Ttime])>=Time())  
                oldr = Form1.mycon.execselect(q);
                //int i = 0;
                if (oldr.HasRows)
                {
                    if (!Bupprocess.started && !timedbupcanceled)
                    {
                        timed = true;
                        beginbcup();
                    }



                } oldr.Close();
            }
        }
        public static void canceled() {
            if (timed)
            {
                timedbupcanceled = true;
            }
            else { timedbupcanceled = false; }
        }
        private void beginbcup()
        {


                timer1.Stop();
                Bupprocess bupprccfrm = new Bupprocess(listView11.Items);
                bupprccfrm.ShowDialog();
                bupprccfrm.Dispose();
               // MessageBox.Show("sdf");
                timer1.Start();

        
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listView11.Items.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to start Backup Now? ", "start BackUp", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (!Bupprocess.started)
                    {
                        timed = false;
                        beginbcup();
                    }
                }
            }
            else {
                MessageBox.Show("there is no Path to BackUp please add one Path At least and try again ", "No Backup Paths", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void خروجToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            mycon.endconnection();
            Application.Exit();
        }

        private void خروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exit = true;
            timer1.Stop();
            
            mycon.endconnection();
            Application.Exit();
        }



        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
               // this.WindowState = FormWindowState.Normal;
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
            else 
             {
                this.Hide();
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void backUpLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Log logfrm = new Log();
            logfrm.ShowDialog();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Log logfrm = new Log();
            logfrm.ShowDialog();
        }

        private void حـــولالتطبيقToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 abfrm = new AboutBox1();
            abfrm.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exit)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }

        }



    }
}
