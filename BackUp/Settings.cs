using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.Win32;

namespace BackUp
{
    public partial class Settings : Form
    {
        OleDbDataReader oldr;
        bool edit = false;
        public Settings()
        {
            InitializeComponent();
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

        private void Settings_Load(object sender, EventArgs e)
        {
            fillprev();
        }

        private void fillprev()
        {
            string q = "select * from Settings ";
           // string q = "select * from Paths where id = " + id;

            oldr = Form1.mycon.execselect(q);
            //int i = 0;
            if (oldr.HasRows)
            {
                edit = true;
                oldr.Read();
                if (!oldr.IsDBNull(1))
                {
                    dateTimePicker1.Value = oldr.GetDateTime(1);
                }
                if (!oldr.IsDBNull(2))
                {
                    checkBox1.Checked = oldr.GetBoolean(2);
                }

            } oldr.Close();

            RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            try
            {
                string reg = (string)Registry.GetValue(rk.Name, "BackUp.exe", false);
                checkBox2.Checked = true;
            }catch(Exception e){
                checkBox2.Checked = false;
            }
 

        }

        private void button20_Click(object sender, EventArgs e)
        {
            save();
        }

        private void save()
        {
            DateTime hm = dateTimePicker1.Value;
            bool shdon = checkBox1.Checked;
           if(edit){

               string q = "update Settings set Buptime='" + hm + "' ,Shutdown= " + shdon ;
               if (Form1.mycon.Execup(q) == 0)
               {
                   MessageBox.Show("Edit Failed");
               }
               else { this.Dispose(); }

           }else{
               string q = "insert into Settings(Buptime,Shutdown) values('"+hm+"',"+shdon+")";
               if (Form1.mycon.Execup(q) == 0)
               {
                   MessageBox.Show("save Failed");
               }
               else { this.Dispose(); }
           }
           RegistryKey rk = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
           if (checkBox2.Checked)
           {

               rk.SetValue("BackUp.exe", Application.ExecutablePath.ToString());
           }
           else
           { rk.DeleteValue("BackUp.exe", false); }          
            
        }

    }
}
