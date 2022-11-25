using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı
{
    public partial class sinifekle : Form
    {
        public sinifekle()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(dersliktextbox.Text))
            {
                MessageBox.Show("Derslik ismi girin !");
            }
            else if (sinifradiobutton.Checked != true && labradiobutton.Checked != true)
            {
                MessageBox.Show("Derslik türü seçin ! ");
            }
            else
            {
                if (Connection.DBPath == null)
                {
                    MessageBox.Show("Veri eklemek için öncelikle veritabanı oluştur butonundan veritabanı oluşturmanız veya veritabanı seçmeniz gerekmektedir.");
                }
                else
                {
                    try
                    {
                        string derslikboszaman = "";
                        if (Connection.dersliklerform.kryptonCheckBox1.Checked)
                        {
                            derslikboszaman = "00,01,02,03,04,05,10,11,12,13,14,15,20,21,22,23,24,25,30,31,32,33,34,35,40,41,42,43,44,45,50,51,52,53,54,55,60,61,62,63,64,65,70,71,72,73,74,75,80,81,82,83,84,85,90,91,92,93,94,95,100,101,102,103,104,105,110,111,112,113,114,115,120,121,122,123,124,125,130,131,132,133,134,135,140,141,142,143,144,145";
                        }
                        else
                        {
                            derslikboszaman = "";
                        }
                        OleDbConnection con = new OleDbConnection();
                        string query;
                        con = Connection.GetConnection();
                        con.Open();
                        bool derslikturu;
                        if (sinifradiobutton.Checked)
                        {
                            derslikturu = false;
                        }
                        else
                        {
                            derslikturu = true;
                        }
                        query = "insert into Derslik(derslik_ismi, derslik_türü, derslik_boszaman) values('" + dersliktextbox.Text + "', " + derslikturu.ToString() + ", '"+derslikboszaman+"')";
                        OleDbCommand cmd = new OleDbCommand(query, con);
                        cmd.ExecuteNonQuery();

                        con.Close();
                        


                        MessageBox.Show("Derslik başarılı bir şekilde eklendi !");
                        Connection.VerileriTazele();
                        
                        this.Close();
                        

                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                    }
                    
                }
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
