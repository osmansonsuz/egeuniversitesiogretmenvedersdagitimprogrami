using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using ComponentFactory.Krypton.Toolkit;
using System.Collections;
using ADOX;

namespace Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı
{
    public partial class Mainform : Form
    {
        public string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
        public string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();



        public OleDbConnection con = new OleDbConnection();
        public string DBPath;
        

        public Mainform()
        {
            InitializeComponent();


    }



        ogretmenlerform ogretmenlerform = Connection.ogretmenlerform;
        bolumlerform bolumlerform = Connection.bolumlerform;
        dersliklerform dersliklerform = Connection.dersliklerform;
        ayarlarform ayarlarform = Connection.ayarlarform;
        tabloform tabloform = Connection.tabloform;
        otomatikyerlestir otomatikyerlestir = Connection.otomatikyerlestir;
        tamamlanmakontrol tamamlanmakontrol = Connection.tamamlanmakontrol;
        rapor rapor = Connection.rapor;

        private void Form1_Load(object sender, EventArgs e)
        {
            //%7.60 1920 için   %4.91 1080 için --- buton width height 146 53
            //%0.63 1920 ve 1080 için buton location


            headerpanel.Width = Convert.ToInt32(screenWidth);
            mdipanel.Width = Convert.ToInt32(screenWidth);

            double buttonwidth = Convert.ToDouble(headerpanel.Width) * 8.60 / 100;
            double buttonheight = Convert.ToDouble(screenHeight) * 4.91 / 100;
            int aralik = Convert.ToInt32(Convert.ToDouble(headerpanel.Width) * 0.005);
            double panelwidtharalik = (mdipanel.Width - 1048) / 2;
            double panelheightaralik = (mdipanel.Height - 589) / 2;

            ogretmenlerbutton.Width = Convert.ToInt32(buttonwidth);
            ogretmenlerbutton.Height = Convert.ToInt32(buttonheight);
            ogretmenlerbutton.Location = new Point(aralik, 12);


            bolumlerbutton.Width = Convert.ToInt32(buttonwidth);
            bolumlerbutton.Height = Convert.ToInt32(buttonheight);
            bolumlerbutton.Location = new Point(ogretmenlerbutton.Width+ogretmenlerbutton.Location.X+Convert.ToInt32(Convert.ToDouble(headerpanel.Width) * 0.005), 12);

            dersliklerbutton.Width = Convert.ToInt32(buttonwidth);
            dersliklerbutton.Height = Convert.ToInt32(buttonheight);
            dersliklerbutton.Location = new Point(bolumlerbutton.Location.X+bolumlerbutton.Width+aralik, 12);

            ayarlarbutton.Width = Convert.ToInt32(buttonwidth);
            ayarlarbutton.Height = Convert.ToInt32(buttonheight);
            ayarlarbutton.Location = new Point(dersliklerbutton.Location.X + dersliklerbutton.Width + aralik, 12);

            tablobutton.Width = Convert.ToInt32(buttonwidth);
            tablobutton.Height = Convert.ToInt32(buttonheight);
            tablobutton.Location = new Point(ayarlarbutton.Location.X + ayarlarbutton.Width + aralik, 12);

            quitbutton.Width = Convert.ToInt32(buttonwidth);
            quitbutton.Height = Convert.ToInt32(buttonheight);
            quitbutton.Location = new Point(Convert.ToInt32(screenWidth) - aralik - quitbutton.Width, 12);

            readfromfilebutton.Width = Convert.ToInt32(buttonwidth);
            readfromfilebutton.Height = Convert.ToInt32(buttonheight);
            readfromfilebutton.Location = new Point(quitbutton.Location.X - aralik - readfromfilebutton.Width- Convert.ToInt32(Convert.ToDouble(headerpanel.Width) * 0.15), 12);

            savetofilebutton.Width = Convert.ToInt32(buttonwidth);
            savetofilebutton.Height = Convert.ToInt32(buttonheight);
            savetofilebutton.Location = new Point(readfromfilebutton.Location.X - aralik - savetofilebutton.Width, 12);

            //1057 width sağdan ve soldan 12 px boşluk
            //640 height üstten alttan 12px boşluk
            //%1.14 width/2=0.57
            //%1.88 height/2=0.94
            //Height 973 e göre alınacak
            //1904 973
            //panel 1055 width 640 height
            FormGetir(Connection.ogretmenlerform);
            FormGizle(Connection.ogretmenlerform);
            FormGetir(Connection.bolumlerform);
            FormGizle(Connection.bolumlerform);
            FormGetir(Connection.dersliklerform);
            FormGizle(Connection.dersliklerform);
            FormGetir(Connection.tabloform);
            FormGizle(Connection.tabloform);
            FormGetir(Connection.ayarlarform);
            this.Text = "Öğretmen ve Ders Dağıtım Programı 1.3 Ayarlar";
            ayarlarbutton.Enabled = false;
            

            ogretmenlerform.Width = mdipanel.Width;
            ogretmenlerform.Height = mdipanel.Height;
            bolumlerform.Width = mdipanel.Width;
            bolumlerform.Height = mdipanel.Height;
            dersliklerform.Width = mdipanel.Width;
            dersliklerform.Height = mdipanel.Height;
            ayarlarform.Width = mdipanel.Width;
            ayarlarform.Height = mdipanel.Height;
            tabloform.Width = mdipanel.Width;
            tabloform.Height = mdipanel.Height;

            ogretmenlerform.ogretmenlerformpanel.Location = new Point(Convert.ToInt32(panelwidtharalik), Convert.ToInt32(panelheightaralik));
            bolumlerform.bolumlerformpanel.Location = new Point(Convert.ToInt32(panelwidtharalik), Convert.ToInt32(panelheightaralik));
            dersliklerform.dersliklerformpanel.Location = new Point(Convert.ToInt32(panelwidtharalik), Convert.ToInt32(panelheightaralik));
            ayarlarform.ayarlarformpanel.Location = new Point(Convert.ToInt32(panelwidtharalik), Convert.ToInt32(panelheightaralik));
            tabloform.tabloformpanel.Location = new Point(Convert.ToInt32(panelwidtharalik), Convert.ToInt32(panelheightaralik));

        }

        private void Mainform_Resize(object sender, EventArgs e)
        {

            double buttonwidth = Convert.ToDouble(headerpanel.Width) * 8.60 / 100;
            double buttonheight = Convert.ToDouble(screenHeight) * 4.91 / 100;
            int aralik = Convert.ToInt32(Convert.ToDouble(headerpanel.Width) * 0.005);
            double panelwidtharalik = (mdipanel.Width-1048)/2;
            double panelheightaralik = (mdipanel.Height-589)/2;


            ogretmenlerbutton.Width = Convert.ToInt32(buttonwidth);
            ogretmenlerbutton.Height = Convert.ToInt32(buttonheight);
            ogretmenlerbutton.Location = new Point(aralik, 12);


            bolumlerbutton.Width = Convert.ToInt32(buttonwidth);
            bolumlerbutton.Height = Convert.ToInt32(buttonheight);
            bolumlerbutton.Location = new Point(ogretmenlerbutton.Width + ogretmenlerbutton.Location.X + Convert.ToInt32(Convert.ToDouble(headerpanel.Width) * 0.005), 12);

            dersliklerbutton.Width = Convert.ToInt32(buttonwidth);
            dersliklerbutton.Height = Convert.ToInt32(buttonheight);
            dersliklerbutton.Location = new Point(bolumlerbutton.Location.X + bolumlerbutton.Width + aralik, 12);

            ayarlarbutton.Width = Convert.ToInt32(buttonwidth);
            ayarlarbutton.Height = Convert.ToInt32(buttonheight);
            ayarlarbutton.Location = new Point(dersliklerbutton.Location.X + dersliklerbutton.Width + aralik, 12);

            tablobutton.Width = Convert.ToInt32(buttonwidth);
            tablobutton.Height = Convert.ToInt32(buttonheight);
            tablobutton.Location = new Point(ayarlarbutton.Location.X + ayarlarbutton.Width + aralik, 12);

            quitbutton.Width = Convert.ToInt32(buttonwidth);
            quitbutton.Height = Convert.ToInt32(buttonheight);
            quitbutton.Location = new Point(Convert.ToInt32(headerpanel.Width) - aralik - quitbutton.Width, 12);

            readfromfilebutton.Width = Convert.ToInt32(buttonwidth);
            readfromfilebutton.Height = Convert.ToInt32(buttonheight);
            readfromfilebutton.Location = new Point(quitbutton.Location.X - aralik - readfromfilebutton.Width - Convert.ToInt32(Convert.ToDouble(headerpanel.Width) * 0.15), 12);

            savetofilebutton.Width = Convert.ToInt32(buttonwidth);
            savetofilebutton.Height = Convert.ToInt32(buttonheight);
            savetofilebutton.Location = new Point(readfromfilebutton.Location.X - aralik - savetofilebutton.Width, 12);


            //1057 width sağdan ve soldan 12 px boşluk
            //640 height üstten alttan 12px boşluk
            //%1.14 width/2=0.57
            //%1.88 height/2=0.94
            //Height 973 e göre alınacak
            //1904 973
            //panel 1055 width 640 height
            //1070 736

            ogretmenlerform.Width = mdipanel.Width;
            ogretmenlerform.Height = mdipanel.Height;
            bolumlerform.Width = mdipanel.Width;
            bolumlerform.Height = mdipanel.Height;
            dersliklerform.Width = mdipanel.Width;
            dersliklerform.Height = mdipanel.Height;
            ayarlarform.Width = mdipanel.Width;
            ayarlarform.Height = mdipanel.Height;
            tabloform.Width = mdipanel.Width;
            tabloform.Height = mdipanel.Height;

            ogretmenlerform.ogretmenlerformpanel.Location = new Point(Convert.ToInt32(panelwidtharalik), Convert.ToInt32(panelheightaralik));
            bolumlerform.bolumlerformpanel.Location = new Point(Convert.ToInt32(panelwidtharalik), Convert.ToInt32(panelheightaralik));
            dersliklerform.dersliklerformpanel.Location = new Point(Convert.ToInt32(panelwidtharalik), Convert.ToInt32(panelheightaralik));
            ayarlarform.ayarlarformpanel.Location = new Point(Convert.ToInt32(panelwidtharalik), Convert.ToInt32(panelheightaralik));
            tabloform.tabloformpanel.Location = new Point(Convert.ToInt32(panelwidtharalik), Convert.ToInt32(panelheightaralik));


        }

        Form lastknownform;
        private void FormGetir(Form frm)
        {
            mdipanel.Controls.Clear();
            frm.MdiParent = this;
            frm.FormBorderStyle = FormBorderStyle.None;
            mdipanel.Controls.Add(frm);
            lastknownform = frm;
            frm.Show();

        }
        private void FormGizle(Form frm)
        {
            frm.Hide();
        }
        private void ogretmenlerbutton_Click(object sender, EventArgs e)
        {
            FormGizle(lastknownform);
            FormGetir(ogretmenlerform);
            this.Text = "Öğretmen ve Ders Dağıtım Programı 1.3 Öğretmenler";
            ogretmenlerbutton.Enabled = false;
            bolumlerbutton.Enabled = true;
            dersliklerbutton.Enabled = true;
            ayarlarbutton.Enabled = true;
            tablobutton.Enabled = true;
            if (Connection.DBPath == null)
            {

            }
            else
            {
                Connection.VerileriTazele();
            }
        }

        private void bolumlerbutton_Click(object sender, EventArgs e)
        {
            FormGizle(lastknownform);
            FormGetir(bolumlerform);
            this.Text = "Öğretmen ve Ders Dağıtım Programı 1.3 Bölümler";
            ogretmenlerbutton.Enabled = true;
            bolumlerbutton.Enabled = false;
            dersliklerbutton.Enabled = true;
            ayarlarbutton.Enabled = true;
            tablobutton.Enabled = true;
            if (Connection.DBPath == null)
            {

            }
            else
            {
                Connection.VerileriTazele();
            }
        }

        private void dersliklerbutton_Click(object sender, EventArgs e)
        {
            FormGizle(lastknownform);
            FormGetir(dersliklerform);
            this.Text = "Öğretmen ve Ders Dağıtım Programı 1.3 Derslikler";
            ogretmenlerbutton.Enabled = true;
            bolumlerbutton.Enabled = true;
            dersliklerbutton.Enabled = false;
            ayarlarbutton.Enabled = true;
            tablobutton.Enabled = true;
            if (Connection.DBPath == null)
            {

            }
            else
            {
                Connection.VerileriTazele();
            }
        }

        private void ayarlarbutton_Click(object sender, EventArgs e)
        {
            FormGizle(lastknownform);
            FormGetir(ayarlarform);
            this.Text = "Öğretmen ve Ders Dağıtım Programı 1.3 Ayarlar";
            ogretmenlerbutton.Enabled = true;
            bolumlerbutton.Enabled = true;
            dersliklerbutton.Enabled = true;
            ayarlarbutton.Enabled = false;
            tablobutton.Enabled = true;
            if (Connection.DBPath == null)
            {

            }
            else
            {
                Connection.VerileriTazele();
            }
        }

        private void tablobutton_Click(object sender, EventArgs e)
        {
            FormGizle(lastknownform);
            FormGetir(tabloform);
            this.Text = "Öğretmen ve Ders Dağıtım Programı 1.3 Tablo";
            ogretmenlerbutton.Enabled = true;
            bolumlerbutton.Enabled = true;
            dersliklerbutton.Enabled = true;
            ayarlarbutton.Enabled = true;
            tablobutton.Enabled = false;
            if (Connection.DBPath == null)
            {

            }
            else
            {
                Connection.VerileriTazele();
            }

        }

        private void quitbutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void readfromfilebutton_Click(object sender, EventArgs e)
        {
            string sFileName;
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                sFileName = openFileDialog1.FileName;
                try
                {
                    DBPath = sFileName;
                    Connection.SetdbPath(DBPath);
                    con = Connection.GetConnection();
                    Connection.VerileriTazele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }


        private void savetofilebutton_Click(object sender, EventArgs e)
        {
            


            SaveFileDialog save = new SaveFileDialog();
            save.OverwritePrompt = false;
            save.Title = "Access Database Dosyaları";
            save.DefaultExt = "accdb";
            save.Filter = "Access Veritabanı (*.accdb)|*.accdb|Tüm Dosyalar(*.*)|*.*";



            if (save.ShowDialog() == DialogResult.OK)
            {

                ADOX.Catalog cat = new ADOX.Catalog();

                cat.Create("Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source="+save.FileName+";");
                
                cat = null;


                DBPath = save.FileName;
                try
                {
                    DBPath = save.FileName;
                    Connection.SetdbPath(DBPath);
                    con = Connection.GetConnection();
                    string query;
                    con.Open();

                    query = "CREATE TABLE Ayarlar (Kimlik AutoIncrement PRIMARY KEY,derssaatleri LONGTEXT,gunduzegitimi LONGTEXT,geceegitimi LONGTEXT)";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();
                    query = "INSERT INTO Ayarlar ( derssaatleri,gunduzegitimi,geceegitimi )\r\nVALUES ('08:30,09:15,09:30,10:15,10:30,11:15,11:30,12:15,13:00,13:45,14:00,14:45,15:00,15:45,16:00,16:45,17:00,17:45,18:00,18:45,19:00,19:45,20:00,20:45,21:00,21:45,22:00,22:45,23:00,23:45','00,01,02,03,04,10,11,12,13,14,20,21,22,23,24,30,31,32,33,34,40,41,42,43,44,50,51,52,53,54,60,61,62,63,64,70,71,72,73,74','80,81,82,83,84,90,91,92,93,94,100,101,102,103,104,110,111,112,113,114,120,121,122,123,124,130,131,132,133,134,140,141,142,143,144')";
                    cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();
                    query = "CREATE TABLE Bölüm (bolum_id AutoIncrement,bolum_adi text,bolum_egitimturu YESNO, PRIMARY KEY(bolum_id,bolum_adi))";
                    cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();
                    query = "CREATE TABLE Bölüm_ders (bolum_dersid AutoIncrement,bolum_id int,ders_id int, PRIMARY KEY(bolum_dersid))";
                    cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();
                    query = "CREATE TABLE Ders (ders_id AutoIncrement,ders_ismi text,ders_teorik int,ders_uygulama int,ders_no text,ogr_id int, PRIMARY KEY(ders_id,ders_no))";
                    cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();
                    query = "CREATE TABLE Derslik (derslik_id AutoIncrement,derslik_ismi text,derslik_türü yesno,derslik_boszaman longtext, PRIMARY KEY(derslik_id,derslik_ismi))";
                    cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();
                    query = "CREATE TABLE Öğretmen (ogr_id AutoIncrement,ogr_adsoyad text,ogr_boszaman longtext,ogr_ekbilgi longtext, PRIMARY KEY(ogr_id,ogr_adsoyad))";
                    cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    MessageBox.Show("Veritabanı başarılı bir şekilde oluşturuldu.");

                    Connection.VerileriTazele();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}
