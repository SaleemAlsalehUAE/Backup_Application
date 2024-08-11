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
    public partial class Log : Form
    {

        OleDbDataReader oldr;
        public Log()
        {
            InitializeComponent();
        }

        private void Log_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Value = DateTime.Now;
        }

        private void fillvalues()
        {

            listView11.Items.Clear();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            int yr=dateTimePicker1.Value.Year;
            string q = "select * from Log where DatePart('yyyy',[Ldts])=" + yr + " ORDER by id DESC" ;



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
                        LItem.SubItems.Add(oldr.GetDateTime(1).ToString());
                    }
                    else { LItem.SubItems.Add("empty"); }

                    if (!oldr.IsDBNull(2))
                    {
                        LItem.SubItems.Add(oldr.GetDateTime(2).ToString());
                    }
                    else { LItem.SubItems.Add("empty"); }

                    if (!oldr.IsDBNull(3))
                    {
                        switch( oldr.GetString(3)){

                            case "finished":
                                LItem.SubItems.Add("Success");
                                break;

                            case "canceled":
                                LItem.SubItems.Add("Canceled");
                                break;

                            default:
                                LItem.SubItems.Add("Failed");
                                break;


                        }
                    }
                    else { LItem.SubItems.Add("empty"); }

                    listView11.Items.Add(LItem);
                }
            } oldr.Close();

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            fillvalues();
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

        private void listView11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView11.SelectedItems.Count > 0)
            {
                textBox1.Text = listView11.SelectedItems[0].SubItems[1].Text;

                textBox2.Text = listView11.SelectedItems[0].SubItems[2].Text;
                textBox3.Text = listView11.SelectedItems[0].SubItems[3].Text;

            }
        }
    }
}
