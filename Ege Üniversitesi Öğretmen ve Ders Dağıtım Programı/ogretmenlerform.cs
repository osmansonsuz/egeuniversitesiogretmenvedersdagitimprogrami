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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı
{
    public partial class ogretmenlerform : Form
    {
        public ogretmenlerform()
        {
            InitializeComponent();
        }

        private void kryptonDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            kryptonDataGridView1.SelectAll();
        }

        private void kryptonButton5_Click(object sender, EventArgs e)
        {
            kryptonDataGridView1.ClearSelection();
        }

        private void ogretmenlerform_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 16; i++)
            {
                kryptonDataGridView1.Rows.Add();

            }
            kryptonDataGridView1.ClearSelection();
            for (int i = 0; i < this.kryptonDataGridView1.Rows.Count; i++)
            {
                this.kryptonDataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void ogretmenlerform_Resize(object sender, EventArgs e)
        {
            
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            ogretmenekle ogretmenekle = new ogretmenekle();
            ogretmenekle.ShowDialog();
            

        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            if (Connection.ogretmenlerform.ogretmencombobox.SelectedIndex == -1)
            {
                MessageBox.Show("Herhangi bir öğretmen seçili değil !");
            }
            else
            {
                DialogResult result = MessageBox.Show("Öğretmeni silmek istediğinizden emin misiniz ?", "Öğretmeni sil", MessageBoxButtons.OKCancel);
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
                            int ogretmen = Convert.ToInt32(Connection.ogretmenlerform.ogretmencombobox.SelectedValue);
                            query = "DELETE FROM Öğretmen WHERE ogr_id=("+ogretmen+")";
                            OleDbCommand cmd = new OleDbCommand(query, con);
                            cmd.ExecuteNonQuery();

                            con.Close();

                            Connection.VerileriTazele();

                            if (ogretmencombobox.Items.Count == 0)
                            {
                                kryptonTextBox3.Enabled = false;
                                kryptonTextBox3.Text = "";
                                kryptonDataGridView1.Enabled = false;
                                for (int i = 0; i < kryptonDataGridView1.Rows.Count; i++)
                                {
                                    for (int j = 0; j < kryptonDataGridView1.Columns.Count; j++)
                                    {
                                        kryptonDataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                                    }
                                }

                            }
                            kryptonTextBox1.Text = "";
                            kryptonTextBox2.Text = "";
                            kryptonTextBox3.Text = "";

                            MessageBox.Show("Öğretmen başarılı bir şekilde silindi !");

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
            
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
        {

        }

        private void kryptonButton4_Click_1(object sender, EventArgs e)
        {
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#b7dbff");
            if (ogretmencombobox.SelectedItem == null)
            {
                kryptonDataGridView1.ClearSelection();
                MessageBox.Show("Tabloya veri girebilmek için öğretmen seçin!");
            }
            else
            {
                for (int i = 0; i < kryptonDataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < kryptonDataGridView1.ColumnCount; j++)
                    {
                        kryptonDataGridView1.Rows[i].Cells[j].Style.BackColor = col;
                    }
                }
                try
                {
                    int uygunsaat = 0;
                    var indexler = new System.Text.StringBuilder();
                    for (int i = 0; i < kryptonDataGridView1.RowCount; i++)
                    {
                        for (int j = 0; j < kryptonDataGridView1.ColumnCount; j++)
                        {
                            if (kryptonDataGridView1.Rows[i].Cells[j].Style.BackColor == col)
                            {
                                if (indexler.Length == 0)
                                {
                                    indexler.Append(i.ToString() + j.ToString());
                                    uygunsaat += 1;
                                }
                                else
                                {
                                    indexler.Append("," + i.ToString() + j.ToString());
                                    uygunsaat += 1;
                                }
                            }
                        }
                    }

                    OleDbConnection con = new OleDbConnection();
                    string query;
                    con = Connection.GetConnection();
                    con.Open();

                    query = "UPDATE Öğretmen SET Öğretmen.ogr_boszaman ='" + indexler + "' WHERE Öğretmen.ogr_id =" + ogretmencombobox.SelectedValue.ToString() + "";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    kryptonTextBox2.Text = uygunsaat.ToString();

                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                }
            }
        }

        private void kryptonButton5_Click_1(object sender, EventArgs e)
        {
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#b7dbff");
            if (ogretmencombobox.SelectedItem == null)
            {
                kryptonDataGridView1.ClearSelection();
                MessageBox.Show("Tablodan veri silebilmek için öğretmen seçin!");
            }
            else
            {
                for (int i = 0; i < kryptonDataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < kryptonDataGridView1.Columns.Count; j++)
                    {
                        kryptonDataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                }

                try
                {
                    int uygunsaat = 0;
                    var indexler = new System.Text.StringBuilder();
                    for (int i = 0; i < kryptonDataGridView1.RowCount; i++)
                    {
                        for (int j = 0; j < kryptonDataGridView1.ColumnCount; j++)
                        {
                            if (kryptonDataGridView1.Rows[i].Cells[j].Style.BackColor == col)
                            {
                                if (indexler.Length == 0)
                                {
                                    indexler.Append(i.ToString() + j.ToString());
                                    uygunsaat += 1;
                                }
                                else
                                {
                                    indexler.Append("," + i.ToString() + j.ToString());
                                    uygunsaat += 1;
                                }
                            }
                        }
                    }

                    OleDbConnection con = new OleDbConnection();
                    string query;
                    con = Connection.GetConnection();
                    con.Open();

                    query = "UPDATE Öğretmen SET Öğretmen.ogr_boszaman ='" + indexler + "' WHERE Öğretmen.ogr_id =" + ogretmencombobox.SelectedValue.ToString() + "";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    kryptonTextBox2.Text = uygunsaat.ToString();

                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                }
            }
            
        }

        private void kryptonDataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#b7dbff");
            if (ogretmencombobox.SelectedItem == null)
            {
                kryptonDataGridView1.ClearSelection();
                MessageBox.Show("Tabloya veri girebilmek için öğretmen seçin!");
            }
            else
            {
                
                if (kryptonDataGridView1.Rows[kryptonDataGridView1.CurrentCell.RowIndex].Cells[kryptonDataGridView1.CurrentCell.ColumnIndex].Style.BackColor == col)
                {
                    kryptonDataGridView1.Rows[kryptonDataGridView1.CurrentCell.RowIndex].Cells[kryptonDataGridView1.CurrentCell.ColumnIndex].Style.BackColor = Color.White;
                }
                else
                {
                    kryptonDataGridView1.Rows[kryptonDataGridView1.CurrentCell.RowIndex].Cells[kryptonDataGridView1.CurrentCell.ColumnIndex].Style.BackColor = col;
                }
                kryptonDataGridView1.ClearSelection();
            }
            

            if (Connection.DBPath == null)
            {
                //burada ders ismine göre veri girilecek(veritabanı olmadan!)

            }
            else
            {
                try
                {
                    int uygunsaat = 0;
                    var indexler = new System.Text.StringBuilder();
                    for (int i = 0; i < kryptonDataGridView1.RowCount; i++)
                    {
                        for (int j = 0; j < kryptonDataGridView1.ColumnCount; j++)
                        {
                            if (kryptonDataGridView1.Rows[i].Cells[j].Style.BackColor == col)
                            {
                                if (indexler.Length == 0)
                                {
                                    indexler.Append(i.ToString() + j.ToString());
                                    uygunsaat += 1;
                                }
                                else
                                {
                                    indexler.Append("," + i.ToString() + j.ToString());
                                    uygunsaat += 1;
                                }
                            }
                        }
                    }

                    OleDbConnection con = new OleDbConnection();
                    string query;
                    con = Connection.GetConnection();
                    con.Open();

                    query = "UPDATE Öğretmen SET Öğretmen.ogr_boszaman ='" + indexler + "' WHERE Öğretmen.ogr_id =" + ogretmencombobox.SelectedValue.ToString() + "";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    kryptonTextBox2.Text = uygunsaat.ToString();

                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                }

            }
        }

        private void ogretmencombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            kryptonListBox1.Items.Clear();
            if (ogretmencombobox.Items.Count != 0)
            {
                kryptonDataGridView1.Enabled = true;
                kryptonTextBox3.Enabled = true;
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

                        query = "SELECT Öğretmen.ogr_boszaman,Öğretmen.ogr_ekbilgi FROM Öğretmen WHERE (((Öğretmen.ogr_id)="+ogretmencombobox.SelectedValue+"))";
                        OleDbCommand command = new OleDbCommand(query, con);
                        OleDbDataReader DR1 = command.ExecuteReader();
                        string ogrboszamanvirgullu = "";
                        string ekbilgi = "";
                        if (DR1.Read())
                        {
                            ogrboszamanvirgullu = DR1.GetValue(0).ToString();
                            ekbilgi = DR1.GetValue(1).ToString();
                        }
                        kryptonTextBox3.Text = ekbilgi;
                        List<string> ogrboszaman = new List<string>();

                        string indexes = "";
                        foreach (char item in ogrboszamanvirgullu)
                        {
                            if (item == ',')
                            {
                                ogrboszaman.Add(indexes);
                                indexes = "";
                                
                            }
                            else
                            {
                                indexes = indexes + item;
                            }
                        }
                        if (indexes.Length != 0 || ogrboszaman.Count != 0)
                        {
                            ogrboszaman.Add(indexes);
                        }

                        List<int> rowindex = new List<int>();
                        List<int> colindex = new List<int>();

                        if (ogrboszaman.Count != 0)
                        {
                            for (int i = 0; i < ogrboszaman.Count; i++)
                            {
                                int indexsayi = 0;
                                indexsayi = ogrboszaman[i].Length;
                                if (indexsayi == 3)
                                {
                                    colindex.Add(Convert.ToInt32(ogrboszaman[i].Substring(2)));
                                    rowindex.Add(Convert.ToInt32(ogrboszaman[i].Substring(0, 2)));
                                }
                                else
                                {
                                    colindex.Add(Convert.ToInt32(ogrboszaman[i].Substring(1)));
                                    rowindex.Add(Convert.ToInt32(ogrboszaman[i].Substring(0, 1)));
                                }

                            }
                        }
                        else
                        {

                        }
                        //datagrid temizlendi
                        for (int i = 0; i < Connection.ogretmenlerform.kryptonDataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < Connection.ogretmenlerform.kryptonDataGridView1.Columns.Count; j++)
                            {
                                Connection.ogretmenlerform.kryptonDataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                            }
                        }



                        if (colindex.Count != 0)
                        {
                            for (int i = 0; i < colindex.Count; i++)
                            {
                                System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#b7dbff");
                                if (kryptonDataGridView1.Rows[rowindex[i]].Cells[colindex[i]].Style.BackColor == col)
                                {
                                    kryptonDataGridView1.Rows[rowindex[i]].Cells[colindex[i]].Style.BackColor = Color.White;
                                }
                                else
                                {
                                    kryptonDataGridView1.Rows[rowindex[i]].Cells[colindex[i]].Style.BackColor = col;
                                }
                                kryptonDataGridView1.ClearSelection();
                            }
                        }
                        else
                        {
                            for (int i = 0; i < kryptonDataGridView1.Rows.Count; i++)
                            {
                                for (int j = 0; j < kryptonDataGridView1.Columns.Count; j++)
                                {
                                    kryptonDataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                                }
                            }
                        }

                        query = "SELECT Ders.ders_id FROM Ders INNER JOIN (Bölüm INNER JOIN Bölüm_ders ON Bölüm.bolum_id = Bölüm_ders.bolum_id) ON Ders.ders_id = Bölüm_ders.ders_id WHERE (((Ders.ogr_id)="+ogretmencombobox.SelectedValue.ToString()+"))";
                        OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "Dersid");

                        string dersismi = "";
                        int teorik = 0;
                        int uygulama = 0;
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            string dersid;
                            dersid = ds.Tables[0].Rows[i]["ders_id"].ToString();
                            int bolumid = 0;
                            string bolumadi = "";

                            query = "SELECT Bölüm_ders.bolum_id FROM Bölüm_ders WHERE (((Bölüm_ders.ders_id)="+dersid.ToString()+"))";
                            command = new OleDbCommand(query, con);
                            DR1 = command.ExecuteReader();


                            if (DR1.Read())
                            {
                                bolumid = DR1.GetInt32(0);
                            }

                            query = "SELECT Bölüm.bolum_adi FROM Bölüm WHERE (((Bölüm.bolum_id)="+bolumid.ToString()+"))";
                            command = new OleDbCommand(query, con);
                            DR1 = command.ExecuteReader();

                            if (DR1.Read())
                            {
                                bolumadi = DR1.GetValue(0).ToString();
                            }


                            query = "SELECT Ders.ders_ismi, Ders.ders_teorik, Ders.ders_uygulama FROM Ders WHERE (((Ders.ders_id)="+dersid.ToString()+"))";

                            command = new OleDbCommand(query, con);
                            DR1 = command.ExecuteReader();


                            if (DR1.Read())
                            {
                                dersismi = DR1.GetValue(0).ToString();
                                teorik += DR1.GetInt32(1);
                                uygulama += DR1.GetInt32(2);
                            }


                            kryptonListBox1.Items.Add(bolumadi+" : "+dersismi);


                        }
                        kryptonTextBox2.Text = rowindex.Count.ToString();
                        kryptonTextBox1.Text = (teorik+uygulama).ToString();

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
                kryptonTextBox3.Enabled = false;
                kryptonTextBox3.Text = "";
                kryptonDataGridView1.Enabled = false;
                for (int i = 0; i < kryptonDataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < kryptonDataGridView1.Columns.Count; j++)
                    {
                        kryptonDataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                }
                kryptonTextBox2.Text = "";
                kryptonTextBox1.Text = "";
                kryptonListBox1.Items.Clear();
            }
        }

        private void kryptonTextBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection con = new OleDbConnection();
                string query;
                con = Connection.GetConnection();
                con.Open();

                query = "UPDATE Öğretmen SET Öğretmen.ogr_ekbilgi = '" + kryptonTextBox3.Text + "' WHERE(((Öğretmen.ogr_id) = " + ogretmencombobox.SelectedValue.ToString() + "))";
                OleDbCommand cmd = new OleDbCommand(query, con);
                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
            }
        }


    }
}
