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
    public partial class bolumekle : Form
    {
        public bolumekle()
        {
            InitializeComponent();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(bolumekletextbox.Text))
            {
                MessageBox.Show("Bölüm ismi girin !");
            }
            else if (kryptonRadioButton1.Checked!=true && kryptonRadioButton2.Checked!=true)
            {
                MessageBox.Show("Eğitim türünü seçin !");
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
                        OleDbConnection con = new OleDbConnection();
                        string query;
                        con = Connection.GetConnection();
                        con.Open();
                        bool egitimturu;
                        if (kryptonRadioButton1.Checked)
                        {
                            egitimturu = false;
                        }
                        else
                        {
                            egitimturu = true;
                        }
                        query = "insert into Bölüm(bolum_adi, bolum_egitimturu) values('"+bolumekletextbox.Text+"', "+egitimturu.ToString()+")";
                        OleDbCommand cmd = new OleDbCommand(query, con);
                        cmd.ExecuteNonQuery();

                        con.Close();



                        MessageBox.Show("Bölüm başarılı bir şekilde eklendi !");

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
    }
}
