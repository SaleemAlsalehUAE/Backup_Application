using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace BackUp
{
   public  class Connection
    {
        public OleDbConnection msAccessCn;
        public void startconnection() {
           // msAccessCn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=MondoDB.mdb;Jet OLEDB:Database password=SLCMONDO");
            string x = Application.ExecutablePath.Replace(Application.ProductName+".exe","");
            string p = x.Replace(Application.ProductName + ".EXE", "");
            msAccessCn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+p+"db.accdb;Jet OLEDB:Database password=SLCMONDO");
        try
        {
            msAccessCn.Open();
            
        }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }


        }

        public void endconnection() {
            try 
            {
                if (msAccessCn.State == ConnectionState.Open)
                {
                    msAccessCn.Close();
                    
                }
                
               
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
            
        }
       //execute update , insert ,delete 
       public int Execup(string query) {
           OleDbCommand cmd = new OleDbCommand();
           cmd.Connection = msAccessCn;
           cmd.CommandText = query;
           try 
           {
          return cmd.ExecuteNonQuery();
           }
           catch(Exception ex){
               MessageBox.Show(ex.Message);
           }
           return 0;
       }
       //execute select
       public OleDbDataReader execselect(string query) {
           OleDbCommand cmd = new OleDbCommand();
           cmd.Connection = msAccessCn;
           cmd.CommandText = query;
           try 
           {
               OleDbDataReader dr = cmd.ExecuteReader();
               return dr;
           }
           catch(Exception ex){
               MessageBox.Show(ex.Message);
           }
           return null;
       }

    }
}
