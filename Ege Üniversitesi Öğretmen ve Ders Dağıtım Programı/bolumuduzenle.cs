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
    public partial class bolumuduzenle : Form
    {
        public int id = 0;
        public bolumuduzenle()
        {
            InitializeComponent();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bolumtextbox.Text))
            {
                MessageBox.Show("Bölüm ismi girin !");
            }
            else if (orgunegitimradio.Checked != true && ikinciogretimradio.Checked != true)
            {
                MessageBox.Show("Eğitim türünü seçin !");
            }
            else
            {

                if (Connection.DBPath == null)
                {
                    //burada bölüm ismine göre veri girilecek(veritabanı olmadan!)

                }
                else
                {
                    try
                    {
                        OleDbConnection con = new OleDbConnection();
                        string query;
                        con = Connection.GetConnection();
                        con.Open();
                        bool egitimturu;
                        if (orgunegitimradio.Checked)
                        {
                            egitimturu = false;  
                        }
                        else
                        {
                            egitimturu = true;
                        }

                        query = "UPDATE Bölüm SET Bölüm.bolum_adi = '"+bolumtextbox.Text+"', Bölüm.bolum_egitimturu = "+egitimturu.ToString()+"  WHERE(((Bölüm.bolum_id) = "+id+"))";
                        OleDbCommand cmd = new OleDbCommand(query, con);
                        cmd.ExecuteNonQuery();

                        con.Close();

                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                    }

                }


                Connection.VerileriTazele();
                MessageBox.Show("Bölüm düzenleme başarılı!");

                this.Close();
            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bolumuduzenle_Load(object sender, EventArgs e)
        {

        }
    }
}
