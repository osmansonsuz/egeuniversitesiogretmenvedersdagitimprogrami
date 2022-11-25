using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı
{
    public partial class ogretmenekle : Form
    {
        public ogretmenekle()
        {
            InitializeComponent();
        }
        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(ogretmenisimtextbox.Text))
            {
                MessageBox.Show("Öğretmen ismi girin !");
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
                        query = "insert into Öğretmen(ogr_adsoyad) values('" + ogretmenisimtextbox.Text + "') ";
                        OleDbCommand cmd = new OleDbCommand(query, con);
                        cmd.ExecuteNonQuery();

                        query = "select ogr_adsoyad,ogr_id from Öğretmen";
                        OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "Öğretmen");
                        Connection.ogretmenlerform.ogretmencombobox.DisplayMember = "ogr_adsoyad";
                        Connection.ogretmenlerform.ogretmencombobox.ValueMember = "ogr_id";
                        Connection.ogretmenlerform.ogretmencombobox.DataSource = ds.Tables["Öğretmen"];

                        con.Close();

                        Connection.VerileriTazele();

                        MessageBox.Show("Öğretmen başarılı bir şekilde eklendi !");
                        this.Close();

                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                    }
                }
                
            }
        }

        private void ogretmenekle_Load(object sender, EventArgs e)
        {

        }
    }
}
