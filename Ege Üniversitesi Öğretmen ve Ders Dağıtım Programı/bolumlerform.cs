using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı
{
    public partial class bolumlerform : Form
    {
        public bolumlerform()
        {
            InitializeComponent();
        }

        private void bolumlerform_Load(object sender, EventArgs e)
        {

        }


        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Connection.bolumekle.ShowDialog();
        }

        private void kryptonListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bolumlerlistbox.SelectedIndex != -1)
            {
                bolumsilbutton.Enabled = true;
                bolumuduzenlebutton.Enabled = true;
                derseklebutton.Enabled = true;
                derslistbox.Enabled = true;
                if (Connection.DBPath == null)
                {
                    //burada bölüm ismine göre veri çekilecek(veritabanı olmadan!)

                }
                else
                {
                    try
                    {
                        OleDbConnection con = new OleDbConnection();
                        string query;
                        con = Connection.GetConnection();
                        con.Open();

                        query = "SELECT Bölüm.bolum_adi as bolum_adi,Bölüm.bolum_egitimturu as bolum_egitimturu FROM Bölüm WHERE (((Bölüm.bolum_id)=" + bolumlerlistbox.SelectedValue + "))";
                        OleDbCommand command = new OleDbCommand(query, con);
                        OleDbDataReader DR1 = command.ExecuteReader();

                        if (DR1.Read())
                        {
                            bolumismitextbox.Text = DR1.GetValue(0).ToString();
                            if (DR1.GetBoolean(1) == true)
                            {
                                ikinciradiobutton.Checked = true;
                            }
                            else
                            {
                                orgunradiobutton.Checked = true;
                            }
                        }

                        query = "SELECT Ders.ders_id as ders_id, Ders.ders_ismi as ders_ismi,Ders.ders_teorik as ders_teorik,Ders.ders_uygulama as ders_uygulama FROM Ders INNER JOIN Bölüm_ders ON Ders.ders_id = Bölüm_ders.ders_id WHERE (((Bölüm_ders.bolum_id)=" + bolumlerlistbox.SelectedValue.ToString() + "))";
                        OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "Ders");
                        Connection.bolumlerform.derslistbox.DisplayMember = "ders_ismi";
                        Connection.bolumlerform.derslistbox.ValueMember = "ders_id";
                        Connection.bolumlerform.derslistbox.DataSource = ds.Tables["Ders"];


                        if (derslistbox.SelectedIndex != -1)
                        {
                            query = "SELECT Ders.ders_id, Ders.ders_ismi, Ders.ders_teorik, Ders.ders_uygulama, Ders.ders_no FROM Ders WHERE(((Ders.ders_id) =" + (derslistbox.SelectedValue) + "))";



                            command = new OleDbCommand(query, con);
                            DR1 = command.ExecuteReader();

                            if (DR1.Read())
                            {
                                dersismitextbox.Text = DR1.GetValue(1).ToString();
                                teoriktextbox.Text = DR1.GetValue(2).ToString();
                                uygulamatextbox.Text = DR1.GetValue(3).ToString();
                                numaratextbox.Text = DR1.GetValue(4).ToString();
                            }
                            query = "SELECT Öğretmen.ogr_adsoyad FROM Öğretmen INNER JOIN Ders ON Öğretmen.ogr_id = Ders.ogr_id WHERE(((Ders.ders_id) =" + (derslistbox.SelectedValue) + "))";



                            command = new OleDbCommand(query, con);
                            DR1 = command.ExecuteReader();

                            if (DR1.Read())
                            {
                                ogretmentextbox.Text = DR1.GetValue(0).ToString();
                            }
                        }
                        else
                        {
                            dersismitextbox.Text = "";
                            teoriktextbox.Text = "";
                            uygulamatextbox.Text = "";
                            ogretmentextbox.Text = "";
                            numaratextbox.Text = "";
                            derssilbutton.Enabled = false;
                            dersiduzenlebutton.Enabled = false;

                        }


                        con.Close();

                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                    }
                }
                derslistbox.SelectedIndex = -1;
            }
            else
            {
                derslistbox.DataSource = null;
                bolumsilbutton.Enabled = false;
                bolumuduzenlebutton.Enabled = false;
                derseklebutton.Enabled = false;
                derslistbox.Enabled = false;
                ikinciradiobutton.Checked = false;
                orgunradiobutton.Checked = false;
                bolumismitextbox.Text = "";
            }



        }

        private void kryptonListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dersismitextbox.Text = "";
            teoriktextbox.Text = "";
            uygulamatextbox.Text = "";
            ogretmentextbox.Text = "";
            numaratextbox.Text = "";

            if (derslistbox.SelectedIndex != -1)
            {
                derssilbutton.Enabled = true;
                dersiduzenlebutton.Enabled = true;

                if (Connection.DBPath == null)
                {
                    //burada bölüm ismine göre veri çekilecek(veritabanı olmadan!)

                }
                else
                {
                    try
                    {
                        OleDbConnection con = new OleDbConnection();
                        string query;
                        con = Connection.GetConnection();
                        con.Open();

                        query = "SELECT Ders.ders_id, Ders.ders_ismi, Ders.ders_teorik, Ders.ders_uygulama, Ders.ders_no FROM Ders WHERE(((Ders.ders_id) =" + (derslistbox.SelectedValue) + "))";


                        OleDbCommand command = new OleDbCommand(query, con);
                        OleDbDataReader DR1 = command.ExecuteReader();
                        if (DR1.Read())
                        {
                            dersismitextbox.Text = DR1.GetValue(1).ToString();
                            teoriktextbox.Text = DR1.GetValue(2).ToString();
                            uygulamatextbox.Text = DR1.GetValue(3).ToString();
                            numaratextbox.Text = DR1.GetValue(4).ToString();
                        }

                        query = "SELECT Öğretmen.ogr_adsoyad FROM Öğretmen INNER JOIN Ders ON Öğretmen.ogr_id = Ders.ogr_id WHERE(((Ders.ders_id) =" + (derslistbox.SelectedValue) + "))";



                        command = new OleDbCommand(query, con);
                        DR1 = command.ExecuteReader();

                        if (DR1.Read())
                        {
                            ogretmentextbox.Text = DR1.GetValue(0).ToString();
                        }


                        con.Close();

                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                    }
                }
            }
            else
            {
                derssilbutton.Enabled = false;
                dersiduzenlebutton.Enabled = false;

                dersismitextbox.Text = "";
                teoriktextbox.Text = "";
                uygulamatextbox.Text = "";
                ogretmentextbox.Text = "";
                numaratextbox.Text = "";
            }
        }

        private void derseklebutton_Click(object sender, EventArgs e)
        {
            Connection.dersekle.bolumid = Convert.ToInt32(bolumlerlistbox.SelectedValue);
            Connection.dersekle.ShowDialog();
        }

        private void bolumuduzenlebutton_Click(object sender, EventArgs e)
        {
            if (Connection.DBPath == null)
            {
                //burada bölüm ismine göre veri çekilecek(veritabanı olmadan!)

            }
            else
            {
                try
                {
                    OleDbConnection con = new OleDbConnection();
                    string query;
                    con = Connection.GetConnection();
                    con.Open();

                    query = "SELECT Bölüm.bolum_adi as bolum_adi,Bölüm.bolum_egitimturu as bolum_egitimturu FROM Bölüm WHERE (((Bölüm.bolum_id)=" + bolumlerlistbox.SelectedValue + "))";
                    OleDbCommand command = new OleDbCommand(query, con);
                    OleDbDataReader DR1 = command.ExecuteReader();
                    Connection.bolumuduzenle.id = Convert.ToInt32(bolumlerlistbox.SelectedValue);
                    
                    if (DR1.Read())
                    {
                        Connection.bolumuduzenle.bolumtextbox.Text = DR1.GetValue(0).ToString();
                        if (DR1.GetBoolean(1) == true)
                        {
                            Connection.bolumuduzenle.ikinciogretimradio.Checked = true;
                        }
                        else
                        {
                            Connection.bolumuduzenle.orgunegitimradio.Checked = true;
                        }
                    }
                    con.Close();

                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                }
            
            }

            Connection.bolumuduzenle.ShowDialog();
        }

        private void bolumupbutton_Click(object sender, EventArgs e)
        {
            int index = bolumlerlistbox.SelectedIndex;
            string listboxitemtext = bolumlerlistbox.SelectedItem.ToString();
            if (index > 0)
            {
                bolumlerlistbox.Items.RemoveAt(index);
                bolumlerlistbox.Items.Insert(index - 1, listboxitemtext);
                bolumlerlistbox.SetSelected(index - 1, true);

            }

        }

        private void bolumdownbutton_Click(object sender, EventArgs e)
        {
            int index = bolumlerlistbox.SelectedIndex;
            string listboxitemtext = bolumlerlistbox.SelectedItem.ToString();
            if (index<bolumlerlistbox.Items.Count-1)
            {
                bolumlerlistbox.Items.RemoveAt(index);
                bolumlerlistbox.Items.Insert(index+1, listboxitemtext);
                bolumlerlistbox.SetSelected(index + 1, true);

            }
        }

        private void bolumsilbutton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bölümü silmek istediğinizden emin misiniz ?", "Bölümü sil", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                if (Connection.DBPath == null)
                {
                    //burada bölüm ismine göre veri silinecek(veritabanı olmadan!)

                }
                else
                {
                    try
                    {
                        OleDbConnection con = new OleDbConnection();
                        string query;
                        con = Connection.GetConnection();
                        con.Open();
                        query = "DELETE Ders.*, Bölüm_ders.bolum_id FROM Ders INNER JOIN Bölüm_ders ON Ders.ders_id = Bölüm_ders.ders_id WHERE (((Bölüm_ders.bolum_id)="+bolumlerlistbox.SelectedValue.ToString()+"))";
                        OleDbCommand cmd = new OleDbCommand(query, con);
                        cmd.ExecuteNonQuery();

                        query = "DELETE Bölüm_ders.*, Bölüm_ders.bolum_id FROM Bölüm_ders WHERE (((Bölüm_ders.bolum_id)="+bolumlerlistbox.SelectedValue.ToString()+"));";
                        cmd = new OleDbCommand(query, con);
                        cmd.ExecuteNonQuery();


                        query = "DELETE FROM Bölüm WHERE bolum_id=" + bolumlerlistbox.SelectedValue;
                        cmd = new OleDbCommand(query, con);
                        cmd.ExecuteNonQuery();

                        con.Close();

                        Connection.VerileriTazele();

                        bolumlerlistbox.SelectedIndex = -1;
                        derslistbox.SelectedIndex = -1;
                        bolumsilbutton.Enabled = false;
                        bolumuduzenlebutton.Enabled = false;
                        derseklebutton.Enabled = false;
                        derslistbox.Enabled = false;
                        derssilbutton.Enabled = false;
                        dersiduzenlebutton.Enabled = false;

                        if (bolumlerlistbox.Items.Count == 0)
                        {
                            bolumismitextbox.Text = "";
                            orgunradiobutton.Checked = false;
                            ikinciradiobutton.Checked = false;

                        }

                        MessageBox.Show("Bölüm ve dersleri başarılı bir şekilde silindi !");


                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                    }
                }

                

                

            }
            else
            {

            }
        }

        private void derssilbutton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Dersi silmek istediğinizden emin misiniz ?", "Dersi sil", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                if (Connection.DBPath == null)
                {
                    //burada bölüm ismine göre veri silinecek(veritabanı olmadan!)

                }

                else
                {
                    try
                    {
                        OleDbConnection con = new OleDbConnection();
                        string query;
                        con = Connection.GetConnection();
                        con.Open();
                        query = "DELETE Bölüm_ders.*, Bölüm_ders.ders_id FROM Bölüm_ders WHERE(((Bölüm_ders.ders_id) ="+derslistbox.SelectedValue.ToString()+"))";
                        OleDbCommand cmd = new OleDbCommand(query, con);
                        cmd.ExecuteNonQuery();

                        query = "DELETE Ders.*, Ders.ders_id FROM Ders WHERE (((Ders.ders_id)="+derslistbox.SelectedValue.ToString()+"))";
                        cmd = new OleDbCommand(query, con);
                        cmd.ExecuteNonQuery();

                        con.Close();

                        Connection.VerileriTazele();

                        

                        MessageBox.Show("Ders başarılı bir şekilde silindi !");
                        derslistbox.SelectedIndex = -1;
                        derslistbox.DataSource = null;
                        derssilbutton.Enabled = false;
                        dersiduzenlebutton.Enabled = false;

                        dersismitextbox.Text = "";
                        teoriktextbox.Text = "";
                        uygulamatextbox.Text = "";
                        ogretmentextbox.Text = "";
                        numaratextbox.Text = "";

                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                    }




                    
                }



                

            }
            else
            {

            }
        }

        private void dersupbutton_Click(object sender, EventArgs e)
        {
            int index = derslistbox.SelectedIndex;
            string listboxitemtext = derslistbox.SelectedItem.ToString();
            if (index > 0)
            {
                derslistbox.Items.RemoveAt(index);
                derslistbox.Items.Insert(index - 1, listboxitemtext);
                derslistbox.SetSelected(index - 1, true);

            }
        }

        private void dersdownbutton_Click(object sender, EventArgs e)
        {
            int index = derslistbox.SelectedIndex;
            string listboxitemtext = derslistbox.SelectedItem.ToString();
            if (index < derslistbox.Items.Count - 1)
            {
                derslistbox.Items.RemoveAt(index);
                derslistbox.Items.Insert(index + 1, listboxitemtext);
                derslistbox.SetSelected(index + 1, true);

            }
        }

        private void derskopyalabutton_Click(object sender, EventArgs e)
        {

        }

        private void dersiduzenlebutton_Click(object sender, EventArgs e)
        {
            if (Connection.DBPath == null)
            {
                //burada bölüm ismine göre veri çekilecek(veritabanı olmadan!)

            }
            else
            {
                try
                {
                    OleDbConnection con = new OleDbConnection();
                    string query;
                    con = Connection.GetConnection();
                    con.Open();

                    query = "SELECT  Ders.ders_ismi as dersismi, Ders.ders_teorik as dersteorik, Ders.ders_uygulama as dersuygulama, Ders.ders_no as dersno, Ders.ogr_id as dersogretmen FROM Ders WHERE (((Ders.ders_id)="+derslistbox.SelectedValue+"))";
                    OleDbCommand command = new OleDbCommand(query, con);
                    OleDbDataReader DR1 = command.ExecuteReader();
                    Connection.dersduzenle.id = Convert.ToInt32(derslistbox.SelectedValue);
                    if (DR1.Read())
                    {
                        Connection.dersduzenle.dersismitextbox.Text = DR1.GetValue(0).ToString();
                        Connection.dersduzenle.teoriktextbox.Text = DR1.GetValue(1).ToString();
                        Connection.dersduzenle.uygulamatextbox.Text = DR1.GetValue(2).ToString();
                        Connection.dersduzenle.numaratextbox.Text = DR1.GetValue(3).ToString();
                        Connection.dersduzenle.ogretmencombobox.SelectedValue = DR1.GetValue(4).ToString(); 
                    }

                    con.Close();

                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                }

            }

            Connection.dersduzenle.ShowDialog();
        }


    }
}
