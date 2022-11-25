using Microsoft.Reporting.WinForms;
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
    public partial class rapor : Form
    {
        public rapor()
        {
            InitializeComponent();
        }

        

        private void kryptonRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listboxheader.Text = "Bölümler";
            bolumlerlistbox.Visible = true;
            ogretmenlerlistbox.Visible = false;
            ogretmenlerlistbox.SelectedIndex = -1;
            bolumlerlistbox.SelectedIndex = -1;
            kryptonButton1.Enabled = false;
        }

        private void kryptonRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            listboxheader.Text = "Bölümler";
            bolumlerlistbox.Visible = true;
            ogretmenlerlistbox.Visible = false;
            ogretmenlerlistbox.SelectedIndex = -1;
            bolumlerlistbox.SelectedIndex = -1;
            kryptonButton1.Enabled = false;
        }

       

        private void kryptonRadioButton7_CheckedChanged(object sender, EventArgs e)
        {
            listboxheader.Text = "Öğretmenler";
            bolumlerlistbox.Visible = false;
            ogretmenlerlistbox.Visible = true;
            ogretmenlerlistbox.SelectedIndex = -1;
            bolumlerlistbox.SelectedIndex = -1;
            kryptonButton1.Enabled = false;
        }

        private void kryptonRadioButton8_CheckedChanged(object sender, EventArgs e)
        {
            listboxheader.Text = "Öğretmenler";
            bolumlerlistbox.Visible = false;
            ogretmenlerlistbox.Visible = true;
            ogretmenlerlistbox.SelectedIndex = -1;
            bolumlerlistbox.SelectedIndex = -1;
            kryptonButton1.Enabled = false;
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void kryptonListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ogretmenlerlistbox.SelectedIndex != -1)
            {
                kryptonButton1.Enabled = true;
            }
            else
            {
                kryptonButton1.Enabled = false;
            }
        }

        private void bolumlerlistbox_SelectedValueChanged(object sender, EventArgs e)
        {
            
        }


        private void bolumlerlistbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bolumlerlistbox.SelectedIndex != -1)
            {
                kryptonButton1.Enabled = true;
            }
            else
            {
                kryptonButton1.Enabled = false;
            }
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            if (kryptonRadioButton3.Checked)
            {
                OleDbConnection con = new OleDbConnection();
                con = Connection.GetConnection();
                con.Open();
                string query = "SELECT Bölüm.bolum_adi, Ders.ders_ismi, Ders.ders_no, Ders.ders_teorik, Ders.ders_uygulama, Öğretmen.ogr_adsoyad, Öğretmen.ogr_ekbilgi\r\nFROM (Bölüm INNER JOIN (Ders INNER JOIN Bölüm_ders ON Ders.ders_id = Bölüm_ders.ders_id) ON Bölüm.bolum_id = Bölüm_ders.bolum_id) INNER JOIN Öğretmen ON Ders.ogr_id = Öğretmen.ogr_id\r\nWHERE (((Bölüm_ders.bolum_id)=" + bolumlerlistbox.SelectedValue.ToString() + "));";
                OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                DataSet1 ds = new DataSet1();
                da.Fill(ds, "DataTable1");

                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                Connection.raporcikti.reportViewer1.LocalReport.ReportEmbeddedResource = "Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Report1.rdlc";
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Clear();
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Add(datasource);

                con.Close();
                Connection.raporcikti.no = Convert.ToInt32(bolumlerlistbox.SelectedValue);
                Connection.raporcikti.ogretmenmi = false;
                Connection.raporcikti.report = 2;
                Connection.raporcikti.previousbutton.Enabled = true;
                Connection.raporcikti.nextbutton.Enabled = true;

            }
            else if (kryptonRadioButton1.Checked)
            {
                OleDbConnection con = new OleDbConnection();
                con = Connection.GetConnection();
                con.Open();
                string query = "SELECT Bölüm.bolum_adi, Ders.ders_ismi, Ders.ders_no, Ders.ders_teorik, Ders.ders_uygulama, Öğretmen.ogr_adsoyad, Öğretmen.ogr_ekbilgi\r\nFROM (Bölüm INNER JOIN (Ders INNER JOIN Bölüm_ders ON Ders.ders_id = Bölüm_ders.ders_id) ON Bölüm.bolum_id = Bölüm_ders.bolum_id) INNER JOIN Öğretmen ON Ders.ogr_id = Öğretmen.ogr_id\r\nWHERE (((Bölüm_ders.bolum_id)=" + bolumlerlistbox.SelectedValue.ToString() + "));";
                OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                DataSet1 ds = new DataSet1();
                da.Fill(ds, "DataTable1");

                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                Connection.raporcikti.reportViewer1.LocalReport.ReportEmbeddedResource = "Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Report5.rdlc";
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Clear();
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Add(datasource);

                con.Close();
                Connection.raporcikti.no = Convert.ToInt32(bolumlerlistbox.SelectedValue);
                Connection.raporcikti.ogretmenmi = false;
                Connection.raporcikti.report = 5;
                Connection.raporcikti.previousbutton.Enabled = true;
                Connection.raporcikti.nextbutton.Enabled = true;
            }
            else if (kryptonRadioButton4.Checked)
            {
                OleDbConnection con = new OleDbConnection();
                con = Connection.GetConnection();
                con.Open();
                string query = "SELECT Bölüm.bolum_adi, Ders.ders_ismi, Ders.ders_no, Ders.ders_teorik, Ders.ders_uygulama, Öğretmen.ogr_adsoyad, Öğretmen.ogr_ekbilgi\r\nFROM (Bölüm INNER JOIN (Ders INNER JOIN Bölüm_ders ON Ders.ders_id = Bölüm_ders.ders_id) ON Bölüm.bolum_id = Bölüm_ders.bolum_id) INNER JOIN Öğretmen ON Ders.ogr_id = Öğretmen.ogr_id\r\nWHERE (((Bölüm_ders.bolum_id)=" + bolumlerlistbox.SelectedValue.ToString() +"));";
                OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                DataSet1 ds = new DataSet1();
                da.Fill(ds, "DataTable1");

                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                Connection.raporcikti.reportViewer1.LocalReport.ReportEmbeddedResource = "Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Report1.rdlc";
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Clear();
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Add(datasource);

                con.Close();
                Connection.raporcikti.no = Convert.ToInt32(bolumlerlistbox.SelectedValue);
                Connection.raporcikti.ogretmenmi = false;
                Connection.raporcikti.report = 1;
                Connection.raporcikti.previousbutton.Enabled = true;
                Connection.raporcikti.nextbutton.Enabled = true;

            }
            else if (kryptonRadioButton7.Checked)
            {
                OleDbConnection con = new OleDbConnection();
                con = Connection.GetConnection();
                con.Open();
                string query = "SELECT Öğretmen.ogr_adsoyad, Öğretmen.ogr_ekbilgi, Ders.ders_ismi, Ders.ders_teorik, Ders.ders_uygulama, Ders.ders_no, Bölüm.bolum_adi\r\nFROM (Ders INNER JOIN (Bölüm INNER JOIN Bölüm_ders ON Bölüm.bolum_id = Bölüm_ders.bolum_id) ON Ders.ders_id = Bölüm_ders.ders_id) INNER JOIN Öğretmen ON Ders.ogr_id = Öğretmen.ogr_id\r\nWHERE (((Öğretmen.ogr_id)="+ogretmenlerlistbox.SelectedValue.ToString()+"));";
                OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                DataSet2 ds = new DataSet2();
                da.Fill(ds, "DataTable1");

                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                Connection.raporcikti.reportViewer1.LocalReport.ReportEmbeddedResource = "Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Report3.rdlc";
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Clear();
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Add(datasource);

                con.Close();
                Connection.raporcikti.no = Convert.ToInt32(ogretmenlerlistbox.SelectedValue);
                Connection.raporcikti.ogretmenmi = true;
                Connection.raporcikti.report = 3;
                Connection.raporcikti.previousbutton.Enabled = true;
                Connection.raporcikti.nextbutton.Enabled = true;

            }
            else if (kryptonRadioButton8.Checked)
            {
                OleDbConnection con = new OleDbConnection();
                con = Connection.GetConnection();
                con.Open();
                string query = "SELECT Öğretmen.ogr_adsoyad, Öğretmen.ogr_ekbilgi, Ders.ders_ismi, Ders.ders_teorik, Ders.ders_uygulama, Ders.ders_no, Bölüm.bolum_adi\r\nFROM (Ders INNER JOIN (Bölüm INNER JOIN Bölüm_ders ON Bölüm.bolum_id = Bölüm_ders.bolum_id) ON Ders.ders_id = Bölüm_ders.ders_id) INNER JOIN Öğretmen ON Ders.ogr_id = Öğretmen.ogr_id\r\nWHERE (((Öğretmen.ogr_id)=" + ogretmenlerlistbox.SelectedValue.ToString() + "));";
                OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                DataSet2 ds = new DataSet2();
                da.Fill(ds, "DataTable1");

                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                Connection.raporcikti.reportViewer1.LocalReport.ReportEmbeddedResource = "Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Report4.rdlc";
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Clear();
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Add(datasource);

                con.Close();
                Connection.raporcikti.no = Convert.ToInt32(ogretmenlerlistbox.SelectedValue);
                Connection.raporcikti.ogretmenmi = true;
                Connection.raporcikti.report = 4;
                Connection.raporcikti.previousbutton.Enabled = true;
                Connection.raporcikti.nextbutton.Enabled = true;
            }
            else if (kryptonRadioButton2.Checked)
            {
                OleDbConnection con = new OleDbConnection();
                con = Connection.GetConnection();
                con.Open();
                string query = "SELECT Öğretmen.ogr_adsoyad, Öğretmen.ogr_ekbilgi, Ders.ders_ismi, Ders.ders_teorik, Ders.ders_uygulama, Ders.ders_no, Bölüm.bolum_adi\r\nFROM (Ders INNER JOIN (Bölüm INNER JOIN Bölüm_ders ON Bölüm.bolum_id = Bölüm_ders.bolum_id) ON Ders.ders_id = Bölüm_ders.ders_id) INNER JOIN Öğretmen ON Ders.ogr_id = Öğretmen.ogr_id\r\nWHERE (((Öğretmen.ogr_id)=" + ogretmenlerlistbox.SelectedValue.ToString() + "));";
                OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                DataSet2 ds = new DataSet2();
                da.Fill(ds, "DataTable1");

                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                Connection.raporcikti.reportViewer1.LocalReport.ReportEmbeddedResource = "Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Report6.rdlc";
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Clear();
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Add(datasource);

                con.Close();
                Connection.raporcikti.no = Convert.ToInt32(ogretmenlerlistbox.SelectedValue);
                Connection.raporcikti.ogretmenmi = true;
                Connection.raporcikti.report = 6;
                Connection.raporcikti.previousbutton.Enabled = true;
                Connection.raporcikti.nextbutton.Enabled = true;
            }
            Connection.raporcikti.ShowDialog();
            
        }

        private void kryptonRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listboxheader.Text = "Bölümler";
            bolumlerlistbox.Visible = true;
            ogretmenlerlistbox.Visible = false;
            ogretmenlerlistbox.SelectedIndex = -1;
            bolumlerlistbox.SelectedIndex = -1;
            kryptonButton1.Enabled = false;
        }

        private void kryptonRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listboxheader.Text = "Öğretmenler";
            bolumlerlistbox.Visible = false;
            ogretmenlerlistbox.Visible = true;
            ogretmenlerlistbox.SelectedIndex = -1;
            bolumlerlistbox.SelectedIndex = -1;
            kryptonButton1.Enabled = false;
        }
    }
}
