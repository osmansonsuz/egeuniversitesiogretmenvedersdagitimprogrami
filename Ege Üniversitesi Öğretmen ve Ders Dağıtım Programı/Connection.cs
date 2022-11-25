using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.IO;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using System.Drawing;

namespace Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı
{
    public static class Connection
    {
        private static OleDbConnection con = new OleDbConnection();
        public static string DBPath;

        public static ogretmenlerform ogretmenlerform = new ogretmenlerform();
        public static bolumlerform bolumlerform = new bolumlerform();
        public static dersliklerform dersliklerform = new dersliklerform();
        public static ayarlarform ayarlarform = new ayarlarform();
        public static tabloform tabloform = new tabloform();
        public static otomatikyerlestir otomatikyerlestir = new otomatikyerlestir();
        public static tamamlanmakontrol tamamlanmakontrol = new tamamlanmakontrol();
        public static rapor rapor = new rapor();
        public static bolumekle bolumekle = new bolumekle();
        public static bolumuduzenle bolumuduzenle = new bolumuduzenle();
        public static dersekle dersekle = new dersekle();
        public static dersduzenle dersduzenle = new dersduzenle();
        public static raporcikti raporcikti = new raporcikti();

        public static OleDbConnection GetConnection()
            {
                try
                {
                    con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + DBPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            return con; 
            }

        public static void SetdbPath(string databasepath)
        {
            DBPath = databasepath;
        }
        public static string ReturndbPath()
        {
            return DBPath;
        }

        public static void VerileriTazele()
        {
            //ogretmenlerform.ogretmencombobox.DataSource = null;
            //dersekle.ogretmencombobox.DataSource = null;
            //bolumlerform.bolumlerlistbox.DataBindings.Clear();
            //dersliklerform.dersliklistbox.DataBindings.Clear();
            //tabloform.bolumlerlistbox.DataSource = null;
            //otomatikyerlestir.bolumlerlistbox.DataSource = null;
            //dersliklerform.dersliklistbox.DataSource = null;
            //tabloform.dersliklerlistbox.DataSource = null;
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            string query = "select ogr_adsoyad,ogr_id from Öğretmen";
            OleDbDataAdapter da = new OleDbDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Öğretmen");
            ogretmenlerform.ogretmencombobox.DisplayMember = "ogr_adsoyad";
            ogretmenlerform.ogretmencombobox.ValueMember = "ogr_id";
            ogretmenlerform.ogretmencombobox.DataSource = ds.Tables["Öğretmen"];
            dersekle.ogretmencombobox.DisplayMember = "ogr_adsoyad";
            dersekle.ogretmencombobox.ValueMember = "ogr_id";
            dersekle.ogretmencombobox.DataSource = ds.Tables["Öğretmen"];
            dersduzenle.ogretmencombobox.Text = "";
            dersduzenle.ogretmencombobox.DisplayMember = "ogr_adsoyad";
            dersduzenle.ogretmencombobox.ValueMember = "ogr_id";
            dersduzenle.ogretmencombobox.DataSource = ds.Tables["Öğretmen"];
            
            rapor.ogretmenlerlistbox.DisplayMember = "ogr_adsoyad";
            rapor.ogretmenlerlistbox.ValueMember = "ogr_id";
            rapor.ogretmenlerlistbox.DataSource = ds.Tables["Öğretmen"];
            rapor.ogretmenlerlistbox.SelectedIndex = -1;
                           


            query = "select bolum_adi,bolum_id from Bölüm";
            da = new OleDbDataAdapter(query, con);
            ds = new DataSet();
            da.Fill(ds, "Bölüm");
            bolumlerform.bolumlerlistbox.DisplayMember = "bolum_adi";
            bolumlerform.bolumlerlistbox.ValueMember = "bolum_id";
            bolumlerform.bolumlerlistbox.DataSource = ds.Tables["Bölüm"];
            bolumlerform.bolumlerlistbox.SelectedIndex = -1;
            tabloform.bolumlerlistbox.DisplayMember = "bolum_adi";
            tabloform.bolumlerlistbox.ValueMember = "bolum_id";
            tabloform.bolumlerlistbox.DataSource = ds.Tables["Bölüm"];
            tabloform.bolumlerlistbox.SelectedIndex = -1;
            otomatikyerlestir.bolumlerlistbox.DisplayMember = "bolum_adi";
            otomatikyerlestir.bolumlerlistbox.ValueMember = "bolum_id";
            otomatikyerlestir.bolumlerlistbox.DataSource = ds.Tables["Bölüm"];
            otomatikyerlestir.bolumlerlistbox.SelectedIndex = -1;
            rapor.bolumlerlistbox.DisplayMember = "bolum_adi";
            rapor.bolumlerlistbox.ValueMember = "bolum_id";
            rapor.bolumlerlistbox.DataSource = ds.Tables["Bölüm"];
            rapor.bolumlerlistbox.SelectedIndex = -1;



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            query = "SELECT Ayarlar.derssaatleri FROM Ayarlar";
            OleDbCommand command = new OleDbCommand(query, con);
            OleDbDataReader DR1 = command.ExecuteReader();
            string saatlervirgullu = "";
            if (DR1.Read())
            {
                saatlervirgullu = DR1.GetValue(0).ToString();
            }
            List<string> saatler = new List<string>();

            string saat = "";
            foreach (char item in saatlervirgullu)
            {
                if (item == ',')
                {
                    saatler.Add(saat);
                    saat = "";
                    
                }
                else
                {
                    saat = saat + item;
                }
            }
            saatler.Add(saat);

            for (int i = 0; i < Connection.ayarlarform.derssaatleri.Rows.Count; i++)
            {
                Connection.ayarlarform.derssaatleri.Rows[i].Cells[0].Value = "";
                Connection.ayarlarform.derssaatleri.Rows[i].Cells[1].Value = "";
            }
            Connection.ayarlarform.derssaatleri.ClearSelection();

            int k = 0;
            for (int i = 0; i < Connection.ayarlarform.derssaatleri.Rows.Count; i++)
            {
                if (saatler[k].ToString() != "25:25")
                {
                    Connection.ayarlarform.derssaatleri.Rows[i].Cells[0].Value = saatler[k].ToString();
                }
                else
                {

                }
                if (saatler[k+1].ToString() != "25:25")
                {
                    Connection.ayarlarform.derssaatleri.Rows[i].Cells[1].Value = saatler[k + 1].ToString();
                }
                k+=2;
            }

            List<string> gunduz = new List<string>();
            List<string> gece = new List<string>();
            string gunduzegitimivirgullu = "";
            string geceegitimivirgullu = "";

            query = "SELECT Ayarlar.gunduzegitimi, Ayarlar.geceegitimi FROM Ayarlar";
            command = new OleDbCommand(query, con);
            DR1 = command.ExecuteReader();
            if (DR1.Read())
            {
                gunduzegitimivirgullu = DR1.GetValue(0).ToString();
                geceegitimivirgullu = DR1.GetValue(1).ToString();
            }

            string indexes = "";
            foreach (char item in gunduzegitimivirgullu)
            {
                if (item == ',')
                {
                    gunduz.Add(indexes);
                    indexes = "";

                }
                else
                {
                    indexes = indexes + item;
                }
            }
            if (indexes.Length != 0 || gunduz.Count != 0)
            {
                gunduz.Add(indexes);
            }



            indexes = "";
            foreach (char item in geceegitimivirgullu)
            {
                if (item == ',')
                {
                    gece.Add(indexes);
                    indexes = "";

                }
                else
                {
                    indexes = indexes + item;
                }
            }
            if (gece.Count != 0 || indexes.Length != 0)
            {
                gece.Add(indexes);
            }

            List<int> gecerowindex = new List<int>();
            List<int> gececolindex = new List<int>();
            if (gece.Count != 0)
            {
                for (int i = 0; i < gece.Count; i++)
                {
                    int indexsayi = 0;
                    indexsayi = gece[i].Length;
                    if (indexsayi == 3)
                    {
                        gececolindex.Add(Convert.ToInt32(gece[i].Substring(2)));
                        gecerowindex.Add(Convert.ToInt32(gece[i].Substring(0, 2)));
                    }
                    else
                    {
                        gececolindex.Add(Convert.ToInt32(gece[i].Substring(1)));
                        gecerowindex.Add(Convert.ToInt32(gece[i].Substring(0, 1)));
                    }

                }
            }
            else
            {

            }

            List<int> gunduzrowindex = new List<int>();
            List<int> gunduzcolindex = new List<int>();

            if (gunduz.Count != 0)
            {
                for (int i = 0; i < gunduz.Count; i++)
                {
                    int indexsayi = 0;
                    indexsayi = gunduz[i].Length;
                    if (indexsayi == 3)
                    {
                        gunduzcolindex.Add(Convert.ToInt32(gunduz[i].Substring(2)));
                        gunduzrowindex.Add(Convert.ToInt32(gunduz[i].Substring(0, 2)));
                    }
                    else
                    {
                        gunduzcolindex.Add(Convert.ToInt32(gunduz[i].Substring(1)));
                        gunduzrowindex.Add(Convert.ToInt32(gunduz[i].Substring(0, 1)));
                    }
                }
            }
            else
            {

            }

            //for (int i = 0; i < gececolindex.Count; i++)
            //{
            //    MessageBox.Show(String.Format("Row: {0} , Col: {1}", gececolindex[i].ToString(), gecerowindex[i].ToString()));
            //}

            //datagridler temizlendi

            for (int i = 0; i < ayarlarform.kryptonDataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < ayarlarform.kryptonDataGridView1.Columns.Count; j++)
                {
                    ayarlarform.kryptonDataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }
            for (int i = 0; i < ayarlarform.kryptonDataGridView3.Rows.Count; i++)
            {
                for (int j = 0; j < ayarlarform.kryptonDataGridView3.Columns.Count; j++)
                {
                    ayarlarform.kryptonDataGridView3.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }

            if (gececolindex.Count != 0)
            {
                for (int i = 0; i < gececolindex.Count; i++)
                {
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#b7dbff");
                    if (ayarlarform.kryptonDataGridView3.Rows[gecerowindex[i]].Cells[gececolindex[i]].Style.BackColor == col)
                    {
                        ayarlarform.kryptonDataGridView3.Rows[gecerowindex[i]].Cells[gececolindex[i]].Style.BackColor = Color.White;
                    }
                    else
                    {
                        ayarlarform.kryptonDataGridView3.Rows[gecerowindex[i]].Cells[gececolindex[i]].Style.BackColor = col;
                    }
                    ayarlarform.kryptonDataGridView3.ClearSelection();
                }
            }
            else
            {
                for (int i = 0; i < ayarlarform.kryptonDataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < ayarlarform.kryptonDataGridView1.Columns.Count; j++)
                    {
                        ayarlarform.kryptonDataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                }
                for (int i = 0; i < ayarlarform.kryptonDataGridView3.Rows.Count; i++)
                {
                    for (int j = 0; j < ayarlarform.kryptonDataGridView3.Columns.Count; j++)
                    {
                        ayarlarform.kryptonDataGridView3.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                }
            }

            if (gunduzcolindex.Count != 0)
            {
                for (int i = 0; i < gunduzcolindex.Count; i++)
                {
                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#b7dbff");
                    if (ayarlarform.kryptonDataGridView1.Rows[gunduzrowindex[i]].Cells[gunduzcolindex[i]].Style.BackColor == col)
                    {
                        ayarlarform.kryptonDataGridView1.Rows[gunduzrowindex[i]].Cells[gunduzcolindex[i]].Style.BackColor = Color.White;
                    }
                    else
                    {
                        ayarlarform.kryptonDataGridView1.Rows[gunduzrowindex[i]].Cells[gunduzcolindex[i]].Style.BackColor = col;
                    }
                    ayarlarform.kryptonDataGridView1.ClearSelection();
                }
            }
            else
            {
                for (int i = 0; i < ayarlarform.kryptonDataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < ayarlarform.kryptonDataGridView1.Columns.Count; j++)
                    {
                        ayarlarform.kryptonDataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                }
                for (int i = 0; i < ayarlarform.kryptonDataGridView3.Rows.Count; i++)
                {
                    for (int j = 0; j < ayarlarform.kryptonDataGridView3.Columns.Count; j++)
                    {
                        ayarlarform.kryptonDataGridView3.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                }
            }

            







            con.Close();
            con.Open();
            query = "select derslik_ismi,derslik_id from Derslik";
            da = new OleDbDataAdapter(query, con);
            ds = new DataSet();
            da.Fill(ds, "Derslik");
            dersliklerform.dersliklistbox.DisplayMember = "derslik_ismi";
            dersliklerform.dersliklistbox.ValueMember = "derslik_id";
            dersliklerform.dersliklistbox.DataSource = ds.Tables["Derslik"];
            dersliklerform.dersliklistbox.SelectedIndex = -1;
            tabloform.dersliklerlistbox.DisplayMember = "derslik_ismi";
            tabloform.dersliklerlistbox.ValueMember = "derslik_id";
            tabloform.dersliklerlistbox.DataSource = ds.Tables["Derslik"];
            tabloform.dersliklerlistbox.SelectedIndex = -1;




            con.Close();
        }

    }
}
