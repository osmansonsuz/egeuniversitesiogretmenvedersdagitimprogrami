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
using Microsoft.Reporting.WinForms;

namespace Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı
{
    public partial class raporcikti : Form
    {
        public raporcikti()
        {
            InitializeComponent();
        }

        public int no;
        public bool ogretmenmi;
        public int report;
        private void raporcikti_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            if (ogretmenmi == true)
            {
                OleDbConnection con = new OleDbConnection();
                con = Connection.GetConnection();
                con.Open();
                string query = "SELECT Min(Öğretmen.ogr_id) FROM Öğretmen";
                OleDbCommand command = new OleDbCommand(query, con);
                OleDbDataReader DR1 = command.ExecuteReader();
                int min = 0;
                if (DR1.Read())
                {
                    min = DR1.GetInt32(0);

                }
                if (min == no)
                {
                    previousbutton.Enabled = false;
                }
                else
                {
                    previousbutton.Enabled = true;
                }
            }
            else
            {
                OleDbConnection con = new OleDbConnection();
                con = Connection.GetConnection();
                con.Open();
                string query = "SELECT Min(Bölüm.bolum_id) FROM Bölüm";
                OleDbCommand command = new OleDbCommand(query, con);
                OleDbDataReader DR1 = command.ExecuteReader();
                int min = 0;
                if (DR1.Read())
                {
                    min = DR1.GetInt32(0);

                }
                if (min == no)
                {
                    previousbutton.Enabled = false;
                }
                else
                {
                    previousbutton.Enabled = true;
                }
            }
            if (ogretmenmi == true)
            {
                OleDbConnection con = new OleDbConnection();
                con = Connection.GetConnection();
                con.Open();
                string query = "SELECT Max(Öğretmen.ogr_id) FROM Öğretmen";
                OleDbCommand command = new OleDbCommand(query, con);
                OleDbDataReader DR1 = command.ExecuteReader();
                int max = 0;
                if (DR1.Read())
                {
                    max = DR1.GetInt32(0);

                }
                if (max == no)
                {
                    nextbutton.Enabled = false;
                }
                else
                {
                    nextbutton.Enabled = true;
                }
            }
            else
            {
                OleDbConnection con = new OleDbConnection();
                con = Connection.GetConnection();
                con.Open();
                string query = "SELECT Max(Bölüm.bolum_id) FROM Bölüm";
                OleDbCommand command = new OleDbCommand(query, con);
                OleDbDataReader DR1 = command.ExecuteReader();
                int max = 0;
                if (DR1.Read())
                {
                    max = DR1.GetInt32(0);

                }
                if (max == no)
                {
                    nextbutton.Enabled = false;
                }
                else
                {
                    nextbutton.Enabled = true;
                }
            }
        }

        private void previousbutton_Click(object sender, EventArgs e)
        {
            if (ogretmenmi == true)
            {
                OleDbConnection con = new OleDbConnection();
                con = Connection.GetConnection();
                con.Open();
                string query = "SELECT Max(Öğretmen.ogr_id)\r\nFROM Öğretmen\r\nWHERE (((Öğretmen.ogr_id)<"+no+"));";
                OleDbCommand command = new OleDbCommand(query, con);
                OleDbDataReader DR1 = command.ExecuteReader();
                if (DR1.Read())
                {
                    no = DR1.GetInt32(0);
                    
                }
                query = "SELECT Min(Öğretmen.ogr_id) FROM Öğretmen";
                command = new OleDbCommand(query, con);
                DR1 = command.ExecuteReader();
                int min=0;
                if (DR1.Read())
                {
                    min = DR1.GetInt32(0);

                }
                
                query = "SELECT Öğretmen.ogr_adsoyad, Öğretmen.ogr_ekbilgi, Ders.ders_ismi, Ders.ders_teorik, Ders.ders_uygulama, Ders.ders_no, Bölüm.bolum_adi\r\nFROM (Ders INNER JOIN (Bölüm INNER JOIN Bölüm_ders ON Bölüm.bolum_id = Bölüm_ders.bolum_id) ON Ders.ders_id = Bölüm_ders.ders_id) INNER JOIN Öğretmen ON Ders.ogr_id = Öğretmen.ogr_id\r\nWHERE (((Öğretmen.ogr_id)=" + no + "));";
                OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                DataSet2 ds = new DataSet2();
                da.Fill(ds, "DataTable1");

                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                Connection.raporcikti.reportViewer1.LocalReport.ReportEmbeddedResource = "Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Report"+report+".rdlc";
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Clear();
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Add(datasource);

                con.Close();
                if (min == no)
                {
                    previousbutton.Enabled = false;
                    
                }
                else
                {
                    previousbutton.Enabled = true;
                }
                nextbutton.Enabled = true;
                this.reportViewer1.RefreshReport();
            }
            else
            {
                OleDbConnection con = new OleDbConnection();
                con = Connection.GetConnection();
                con.Open();
                string query = "SELECT Max(Bölüm.bolum_id) AS İfade1 FROM Bölüm WHERE(((Bölüm.bolum_id) < "+no+"));";
                OleDbCommand command = new OleDbCommand(query, con);
                OleDbDataReader DR1 = command.ExecuteReader();
                if (DR1.Read())
                {
                    no = DR1.GetInt32(0);

                }
                query = "SELECT Min(Bölüm.bolum_id) FROM Bölüm";
                command = new OleDbCommand(query, con);
                DR1 = command.ExecuteReader();
                int min = 0;
                if (DR1.Read())
                {
                    min = DR1.GetInt32(0);

                }
                
                query = "SELECT Bölüm.bolum_adi, Ders.ders_ismi, Ders.ders_no, Ders.ders_teorik, Ders.ders_uygulama, Öğretmen.ogr_adsoyad, Öğretmen.ogr_ekbilgi\r\nFROM (Bölüm INNER JOIN (Ders INNER JOIN Bölüm_ders ON Ders.ders_id = Bölüm_ders.ders_id) ON Bölüm.bolum_id = Bölüm_ders.bolum_id) INNER JOIN Öğretmen ON Ders.ogr_id = Öğretmen.ogr_id\r\nWHERE (((Bölüm_ders.bolum_id)=" +no+"));";
                OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                DataSet2 ds = new DataSet2();
                da.Fill(ds, "DataTable1");

                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                Connection.raporcikti.reportViewer1.LocalReport.ReportEmbeddedResource = "Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Report" + report + ".rdlc";
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Clear();
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Add(datasource);

                con.Close();
                if (min == no)
                {
                    previousbutton.Enabled = false;
                    
                }
                else
                {
                    previousbutton.Enabled = true;
                }
                nextbutton.Enabled = true;
                this.reportViewer1.RefreshReport();
            }
        }

        private void nextbutton_Click(object sender, EventArgs e)
        {
            if (ogretmenmi == true)
            {
                OleDbConnection con = new OleDbConnection();
                con = Connection.GetConnection();
                con.Open();
                string query = "SELECT Min(Öğretmen.ogr_id)\r\nFROM Öğretmen\r\nWHERE (((Öğretmen.ogr_id)>" + no + "));";
                OleDbCommand command = new OleDbCommand(query, con);
                OleDbDataReader DR1 = command.ExecuteReader();
                if (DR1.Read())
                {
                    no = DR1.GetInt32(0);

                }
                query = "SELECT Max(Öğretmen.ogr_id) FROM Öğretmen";
                command = new OleDbCommand(query, con);
                DR1 = command.ExecuteReader();
                int max = 0;
                if (DR1.Read())
                {
                    max = DR1.GetInt32(0);

                }

                query = "SELECT Öğretmen.ogr_adsoyad, Öğretmen.ogr_ekbilgi, Ders.ders_ismi, Ders.ders_teorik, Ders.ders_uygulama, Ders.ders_no, Bölüm.bolum_adi\r\nFROM (Ders INNER JOIN (Bölüm INNER JOIN Bölüm_ders ON Bölüm.bolum_id = Bölüm_ders.bolum_id) ON Ders.ders_id = Bölüm_ders.ders_id) INNER JOIN Öğretmen ON Ders.ogr_id = Öğretmen.ogr_id\r\nWHERE (((Öğretmen.ogr_id)=" + no + "));";
                OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                DataSet2 ds = new DataSet2();
                da.Fill(ds, "DataTable1");

                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                Connection.raporcikti.reportViewer1.LocalReport.ReportEmbeddedResource = "Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Report" + report + ".rdlc";
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Clear();
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Add(datasource);

                con.Close();
                if (max == no)
                {
                    nextbutton.Enabled = false;

                }
                else
                {
                    nextbutton.Enabled = true;
                }
                previousbutton.Enabled = true;
                this.reportViewer1.RefreshReport();
            }
            else
            {
                OleDbConnection con = new OleDbConnection();
                con = Connection.GetConnection();
                con.Open();
                string query = "SELECT Min(Bölüm.bolum_id) AS İfade1 FROM Bölüm WHERE(((Bölüm.bolum_id) > " + no + "));";
                OleDbCommand command = new OleDbCommand(query, con);
                OleDbDataReader DR1 = command.ExecuteReader();
                if (DR1.Read())
                {
                    no = DR1.GetInt32(0);

                }
                query = "SELECT Max(Bölüm.bolum_id) FROM Bölüm";
                command = new OleDbCommand(query, con);
                DR1 = command.ExecuteReader();
                int max = 0;
                if (DR1.Read())
                {
                    max= DR1.GetInt32(0);

                }

                query = "SELECT Bölüm.bolum_adi, Ders.ders_ismi, Ders.ders_no, Ders.ders_teorik, Ders.ders_uygulama, Öğretmen.ogr_adsoyad, Öğretmen.ogr_ekbilgi\r\nFROM (Bölüm INNER JOIN (Ders INNER JOIN Bölüm_ders ON Ders.ders_id = Bölüm_ders.ders_id) ON Bölüm.bolum_id = Bölüm_ders.bolum_id) INNER JOIN Öğretmen ON Ders.ogr_id = Öğretmen.ogr_id\r\nWHERE (((Bölüm_ders.bolum_id)=" + no + "));";
                OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                DataSet2 ds = new DataSet2();
                da.Fill(ds, "DataTable1");

                ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                Connection.raporcikti.reportViewer1.LocalReport.ReportEmbeddedResource = "Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Report" + report + ".rdlc";
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Clear();
                Connection.raporcikti.reportViewer1.LocalReport.DataSources.Add(datasource);

                con.Close();
                if (max == no)
                {
                    nextbutton.Enabled = false;
                    
                }
                else
                {
                    nextbutton.Enabled = true;
                }
                previousbutton.Enabled = true;
                this.reportViewer1.RefreshReport();
            }
        }
    }
}
