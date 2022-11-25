using ComponentFactory.Krypton.Toolkit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı
{
    public partial class ayarlarform : Form
    {
        public ayarlarform()
        {
            InitializeComponent();
        }



        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            if (Connection.DBPath == null)
            {
                MessageBox.Show("Veri eklemek için öncelikle veritabanı oluştur butonundan veritabanı oluşturmanız veya veritabanı seçmeniz gerekmektedir.");

            }
            else
            {
                try
                {
                    var indexler = new System.Text.StringBuilder();
                    for (int i = 0; i < 8; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (indexler.Length == 0)
                            {
                                indexler.Append(i.ToString() + j.ToString());
                            }
                            else
                            {
                                indexler.Append("," + i.ToString() + j.ToString());
                            }

                        }
                    }

                    OleDbConnection con = new OleDbConnection();
                    string query;
                    con = Connection.GetConnection();
                    con.Open();

                    query = "UPDATE Ayarlar SET Ayarlar.gunduzegitimi ='" + indexler + "'";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();


                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                }

            }

            if (Connection.DBPath == null)
            {
                //burada ders ismine göre veri girilecek(veritabanı olmadan!)

            }
            else
            {
                try
                {
                    var indexler = new System.Text.StringBuilder();
                    for (int i = 8; i < kryptonDataGridView3.RowCount; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (indexler.Length == 0)
                            {
                                indexler.Append(i.ToString() + j.ToString());
                            }
                            else
                            {
                                indexler.Append("," + i.ToString() + j.ToString());
                            }
                        }
                    }


                    OleDbConnection con = new OleDbConnection();
                    string query;
                    con = Connection.GetConnection();
                    con.Open();

                    query = "UPDATE Ayarlar SET Ayarlar.geceegitimi ='" + indexler + "'";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    Connection.VerileriTazele();

                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                }

            }

        }

        private void ayarlarform_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 16; i++)
            {
                kryptonDataGridView1.Rows.Add();

            }
            for (int i = 1; i < 16; i++)
            {
                derssaatleri.Rows.Add();

            }
            for (int i = 1; i < 16; i++)
            {
                kryptonDataGridView3.Rows.Add();

            }
            kryptonDataGridView1.ClearSelection();
            derssaatleri.ClearSelection();
            kryptonDataGridView3.ClearSelection();
            for (int i = 0; i < this.kryptonDataGridView1.Rows.Count; i++)
            {
                this.kryptonDataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            for (int i = 0; i < this.derssaatleri.Rows.Count; i++)
            {
                this.derssaatleri.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            for (int i = 0; i < this.kryptonDataGridView3.Rows.Count; i++)
            {
                this.kryptonDataGridView3.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }



        private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            

            if (Connection.DBPath == null)
            {
                MessageBox.Show("Veri eklemek için öncelikle veritabanı oluştur butonundan veritabanı oluşturmanız veya veritabanı seçmeniz gerekmektedir.");
            }
            else
            {
                System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#b7dbff");
                if (kryptonDataGridView1.Rows[kryptonDataGridView1.CurrentCell.RowIndex].Cells[kryptonDataGridView1.CurrentCell.ColumnIndex].Style.BackColor == col)
                {
                    kryptonDataGridView1.Rows[kryptonDataGridView1.CurrentCell.RowIndex].Cells[kryptonDataGridView1.CurrentCell.ColumnIndex].Style.BackColor = Color.White;
                }
                else
                {
                    kryptonDataGridView1.Rows[kryptonDataGridView1.CurrentCell.RowIndex].Cells[kryptonDataGridView1.CurrentCell.ColumnIndex].Style.BackColor = col;
                }
                kryptonDataGridView1.ClearSelection();
                try
                {
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
                                }
                                else
                                {
                                    indexler.Append("," + i.ToString() + j.ToString());
                                }
                            }
                        }
                    }

                    OleDbConnection con = new OleDbConnection();
                    string query;
                    con = Connection.GetConnection();
                    con.Open();

                    query = "UPDATE Ayarlar SET Ayarlar.gunduzegitimi ='" + indexler + "'";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    Connection.VerileriTazele();

                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                }

            }
        }

        private void kryptonButton3_Click(object sender, EventArgs e)
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

                    query = "UPDATE Ayarlar SET Ayarlar.gunduzegitimi =''";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();


                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                }

            }


            if (Connection.DBPath == null)
            {
                //burada ders ismine göre veri girilecek(veritabanı olmadan!)

            }
            else
            {
                try
                {
                    
                    OleDbConnection con = new OleDbConnection();
                    string query;
                    con = Connection.GetConnection();
                    con.Open();

                    query = "UPDATE Ayarlar SET Ayarlar.geceegitimi =''";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    Connection.VerileriTazele();

                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                }

            }
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            string saatler = "25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25,25:25";
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

                    query = "UPDATE Ayarlar SET Ayarlar.derssaatleri ='" + saatler + "'";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    Connection.VerileriTazele();

                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                }

            }
        }

        private void kryptonRadioButton1_Click(object sender, EventArgs e)
        {
            kryptonDataGridView3.Visible = false;
            kryptonDataGridView1.Visible = true;
            kryptonDataGridView1.ClearSelection();
            kryptonDataGridView3.ClearSelection();
        }

        private void kryptonRadioButton2_Click(object sender, EventArgs e)
        {
            kryptonDataGridView1.Visible = false;
            kryptonDataGridView3.Visible = true;
            kryptonDataGridView1.ClearSelection();
            kryptonDataGridView3.ClearSelection();
        }

        private void kryptonDataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#b7dbff");
            if (kryptonDataGridView3.Rows[kryptonDataGridView3.CurrentCell.RowIndex].Cells[kryptonDataGridView3.CurrentCell.ColumnIndex].Style.BackColor == col)
            {
                kryptonDataGridView3.Rows[kryptonDataGridView3.CurrentCell.RowIndex].Cells[kryptonDataGridView3.CurrentCell.ColumnIndex].Style.BackColor = Color.White;
            }
            else
            {
                kryptonDataGridView3.Rows[kryptonDataGridView3.CurrentCell.RowIndex].Cells[kryptonDataGridView3.CurrentCell.ColumnIndex].Style.BackColor = col;
            }
            kryptonDataGridView3.ClearSelection();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            string saatler = "08:30,09:15,09:30,10:15,10:30,11:15,11:30,12:15,13:00,13:45,14:00,14:45,15:00,15:45,16:00,16:45,17:00,17:45,18:00,18:45,19:00,19:45,20:00,20:45,21:00,21:45,22:00,22:45,23:00,23:45";
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

                    query = "UPDATE Ayarlar SET Ayarlar.derssaatleri ='" + saatler + "'";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    Connection.VerileriTazele();

                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                }

            }


        }

        private void derssaatleri_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var saatler = new System.Text.StringBuilder();
            for (int i = 0; i < derssaatleri.RowCount; i++)
            {
                if (derssaatleri.Rows[i].Cells[0].Value != "" && derssaatleri.Rows[i].Cells[0].Value != null)
                {
                    saatler.Append(derssaatleri.Rows[i].Cells[0].Value + ",");

                }
                else
                {
                    saatler.Append("25:25,");

                }
                if (derssaatleri.Rows[i].Cells[1].Value != "" && derssaatleri.Rows[i].Cells[1].Value != null)
                {
                    if (i == derssaatleri.RowCount-1)
                    {
                        saatler.Append(derssaatleri.Rows[i].Cells[1].Value);
                    }
                    else
                    {
                        saatler.Append(derssaatleri.Rows[i].Cells[1].Value + ",");
                    }
                }
                else
                {
                    if (i == derssaatleri.RowCount-1)
                    {
                        saatler.Append("25:25");
                    }
                    else
                    {
                        saatler.Append("25:25,");
                    }
                }
            }
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

                    query = "UPDATE Ayarlar SET Ayarlar.derssaatleri ='" + saatler + "'";
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();

                    Connection.VerileriTazele();

                }
                catch (OleDbException ex)
                {
                    MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                }

            }
        }
    }
}
