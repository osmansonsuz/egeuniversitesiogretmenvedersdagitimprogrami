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
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı
{
    public partial class dersekle : Form
    {
        public int bolumid;
        public dersekle()
        {
            InitializeComponent();
        }

        private void silbutton_Click(object sender, EventArgs e)
        {
            ogretmencombobox.SelectedIndex = -1;
            ogretmencombobox.SelectedIndex = -1;
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
                    //bool varmi = false;
                    //foreach (string item in Connection.bolumlerform.bolumlerlistbox.Items)
                    //{
                    //    if (item == bolumekletextbox.Text)
                    //    {
                    //        MessageBox.Show("Aynı isimde 2 bölüm olamaz !");
                    //        varmi = true;
                    //        break;
                    //    }
                    //}
                    //if (varmi == false)
                    //{
                    //    Connection.ogretmenlerform.ogretmencombobox.Items.Add(bolumekletextbox.Text);
                    //    MessageBox.Show("Öğretmen başarılı bir şekilde eklendi !");
                    //    this.Close();
                    //}

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

                        query = "insert into Ders(ders_ismi, ders_teorik, ders_uygulama, ogr_id, ders_no) values('" + dersismitextbox.Text + "', " + Convert.ToInt32(teoriktextbox.Text) + ", " + Convert.ToInt32(uygulamatextbox.Text) + ", " + ogretmencombobox.SelectedValue.ToString() + ", '" + numaratextbox.Text.ToString() + "')";
                        OleDbCommand cmd = new OleDbCommand(query, con);
                        cmd.ExecuteNonQuery();
                        int dersid = 0;
                        query = "SELECT MAX(Ders_id) as id FROM Ders";
                        OleDbCommand command = new OleDbCommand(query, con);
                        OleDbDataReader DR1 = command.ExecuteReader();
                        if (DR1.Read())
                        {
                            dersid = DR1.GetInt32(0);
                        }



                        query = "insert into Bölüm_ders(bolum_id,ders_id) values(" + bolumid.ToString() + "," + dersid.ToString() + ")";
                        cmd = new OleDbCommand(query, con);
                        cmd.ExecuteNonQuery();


                        con.Close();

                        Connection.tabloform.seciliderslabel.Text = Connection.tabloform.bolumlerlistbox.GetItemText(Connection.tabloform.bolumlerlistbox.SelectedItem);
                        Connection.tabloform.kryptonDataGridView1.Enabled = true;
                        if (Connection.tabloform.bolumlerlistbox.SelectedIndex != -1)
                        {


                            if (Connection.DBPath == null)
                            {
                                //burada bölüm ismine göre veri çekilecek(veritabanı olmadan!)

                            }
                            else
                            {
                                try
                                {
                                    con = Connection.GetConnection();
                                    con.Open();

                                    query = "SELECT Ders.ders_id, Ders.ders_ismi FROM Ders INNER JOIN Bölüm_ders ON Ders.ders_id = Bölüm_ders.ders_id WHERE(((Bölüm_ders.bolum_id) =" + Connection.tabloform.bolumlerlistbox.SelectedValue.ToString() + "))";

                                    OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                                    DataSet ds = new DataSet();
                                    da.Fill(ds, "Ders");
                                    Connection.tabloform.derslerlistbox.DisplayMember = "ders_ismi";
                                    Connection.tabloform.derslerlistbox.ValueMember = "ders_id";
                                    Connection.tabloform.derslerlistbox.DataSource = ds.Tables["Ders"];



                                    con.Close();
                                    Connection.tabloform.dersismilabel.Text = Connection.tabloform.derslerlistbox.GetItemText(Connection.tabloform.derslerlistbox.SelectedItem);
                                }
                                catch (OleDbException ex)
                                {
                                    MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                                }
                            }
                        }



                        
                        MessageBox.Show("Ders başarılı bir şekilde eklendi !");
                        Connection.VerileriTazele();
                        dersismitextbox.Text = "";
                        teoriktextbox.Text = "0";
                        uygulamatextbox.Text = "0";
                        ogretmencombobox.SelectedIndex = -1;
                        numaratextbox.Text = "";
                        Connection.bolumlerform.bolumlerlistbox.SelectedIndex =-1;
                        Connection.bolumlerform.bolumismitextbox.Text = "";
                        Connection.bolumlerform.orgunradiobutton.Checked = false;
                        Connection.bolumlerform.ikinciradiobutton.Checked = false;
                        Connection.bolumlerform.derslistbox.DataSource = null;
                        Connection.bolumlerform.derslistbox.Enabled= false;


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
            if (ogretmencombobox.SelectedIndex != -1)
            {
                silbutton.Enabled = true;
            }
            else
            {
                silbutton.Enabled = false;
            }
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

        private void dersekle_Load(object sender, EventArgs e)
        {
            ogretmencombobox.SelectedIndex = -1;
        }

        private void teoriktextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void uygulamatextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
