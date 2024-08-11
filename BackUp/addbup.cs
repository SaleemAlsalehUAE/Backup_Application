using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace BackUp
{
    public partial class addbup : Form
    {
        OleDbDataReader oldr;
        bool edit = false;
        int id;
        public addbup()
        {
            InitializeComponent();
        }

        public addbup(int id)
        {
            InitializeComponent();
            edit = true;
            this.id = id;
            fillprevv();
          
        }

        private void fillprevv()
        {
            string q = "select * from Paths where id = " + id  ;
            
            oldr = Form1.mycon.execselect(q);
            //int i = 0;
            if (oldr.HasRows)
            {
                oldr.Read();
                if (!oldr.IsDBNull(1))
                {
                    textBox27.Text = oldr.GetString(1);
                }
                if (!oldr.IsDBNull(2))
                {
                    textBox1.Text = oldr.GetString(2);
                }
                if (!oldr.IsDBNull(3))
                {
                    textBox2.Text = oldr.GetString(3);
                }
            }
        
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }
        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox27.Text.Trim().Equals("") || textBox1.Text.Trim().Equals(""))
            {
                MessageBox.Show("Please fill Required Fields");
            }
            else
            {
                Save();
            }
        }

        private void Save()
        {
            remquts();
            string cpath = textBox27.Text.Trim();
            string tarpath =textBox1.Text.Trim();
            string notes = textBox2.Text.Trim();
           if(edit){


               string q = "update  Paths  set Cpypath='" + cpath + "' ,Tarpath ='" + tarpath + "' ,Notes ='" + notes + "' where id = " + id;

               if (Form1.mycon.Execup(q) == 0)
               {
                   MessageBox.Show("Edit Failed");
               }
               else { this.Dispose(); }

           }else{
               string q = "insert into Paths(Cpypath,Tarpath,Notes) values('"+cpath+"','"+tarpath+"','"+notes+"')";

               if (Form1.mycon.Execup(q) == 0)
               {
                   MessageBox.Show("Add Failed");
               }
               else { this.Dispose(); }

           
           }
        }

        private void remquts()
        {
            textBox2.Text = textBox2.Text.Replace("     ", " ");
            textBox2.Text = textBox2.Text.Replace("    ", " ");
            textBox2.Text = textBox2.Text.Replace("   ", " ");
            textBox2.Text = textBox2.Text.Replace("  ", " ");
            textBox2.Text = textBox2.Text.Replace("'", "");
            textBox2.Text = textBox2.Text.Replace("\"", "");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox27.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
