using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı
{
    public partial class dersduzenle : Form
    {
        public dersduzenle()
        {
            InitializeComponent();
        }
        public int id = 0;
        private void silbutton_Click(object sender, EventArgs e)
        {
            ogretmencombobox.SelectedIndex = -1;
            silbutton.Enabled = false;
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(dersismitextbox.Text))
            {
                MessageBox.Show("Ders ismi girin !");
            }
            else if (String.IsNullOrEmpty(teoriktextbox.Text))
            {
                MessageBox.Show("Teorik ders sayısını girin !");
            }
            else if (String.IsNullOrEmpty(uygulamatextbox.Text))
            {
                MessageBox.Show("Uygulama ders sayısını girin !");
            }
            else if (ogretmencombobox.SelectedIndex == -1)
            {
                MessageBox.Show("Öğretmen seçin !");
            }
            else if (string.IsNullOrEmpty(numaratextbox.Text))
            {
                MessageBox.Show("Numara girin !");
            }
            else
            {
                if (Connection.DBPath == null)
                {
                    //burada ders ismine göre veri girilecek(veritabanı olmadan!)

                }
                else
                {
                    string duplicate = "The changes you requested to the table were not successful because they would create duplicate values in the index, primary key, or relationship. Change the data in the field or fields that contain duplicate data, remove the index, or redefine the index to permit duplicate entries and try again.";
                    try
                    {
                        OleDbConnection con = new OleDbConnection();
                        string query;
                        con = Connection.GetConnection();
                        con.Open();

                        query = "UPDATE Ders SET Ders.ders_ismi = '"+dersismitextbox.Text+"', Ders.ders_teorik = "+Convert.ToInt32(teoriktextbox.Text)+", Ders.ders_uygulama ="+Convert.ToInt32(uygulamatextbox.Text)+", Ders.ders_no = '"+numaratextbox.Text+"', Ders.ogr_id ="+ogretmencombobox.SelectedValue+" WHERE (((Ders.ders_id)="+id+"));";
                        OleDbCommand cmd = new OleDbCommand(query, con);
                        cmd.ExecuteNonQuery();

                        con.Close();

                        
                        MessageBox.Show("Ders başarılı bir şekilde güncellendi !");
                        Connection.bolumlerform.derslistbox.SelectedIndex = -1;
                        Connection.bolumlerform.derslistbox.SelectedIndex = -1;
                        Connection.VerileriTazele();
                        this.Close();

                    }
                    catch (OleDbException ex)
                    {
                        if (ex.Message == duplicate)
                        {
                            MessageBox.Show("Numara değeri başka ders ile çakışıyor !");
                        }
                        else
                        {
                            MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                        }
                    }

                }
            }
        }

        private void ogretmencombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            silbutton.Enabled = true;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numaratextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
