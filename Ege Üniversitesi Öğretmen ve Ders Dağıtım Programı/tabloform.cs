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
    public partial class tabloform : Form
    {
        public tabloform()
        {
            InitializeComponent();
        }


        private void kryptonButton4_Click(object sender, EventArgs e)
        {
            Connection.otomatikyerlestir.ShowDialog();
        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            Connection.tamamlanmakontrol.ShowDialog();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            Connection.rapor.ShowDialog();
        }


        private void tabloform_Load(object sender, EventArgs e)
        {
            for (int i = 1; i < 16; i++)
            {
                kryptonDataGridView1.Rows.Add();
            }
            for (int i = 0; i < this.kryptonDataGridView1.Rows.Count; i++)
            {
                this.kryptonDataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            kryptonDataGridView1.ClearSelection();
        }

        private void kryptonDataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < kryptonDataGridView1.RowCount; i++)
            {
                if (kryptonDataGridView1.Rows[kryptonDataGridView1.CurrentCell.RowIndex].Cells[kryptonDataGridView1.CurrentCell.ColumnIndex] == kryptonDataGridView1.Rows[i].Cells[0])
                {
                    MessageBox.Show("Saatleri ayarlamak için ayarlar formuna gidin !");
                    kryptonDataGridView1.ClearSelection();
                    kryptonDataGridView1.Rows[kryptonDataGridView1.CurrentCell.RowIndex].Cells[kryptonDataGridView1.CurrentCell.ColumnIndex].Style.BackColor = Color.White;
                    break;
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
                }
            }
            
            
        }

        private void kryptonListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
            if (bolumlerlistbox.SelectedIndex != -1)
            {
                seciliderslabel.Text = bolumlerlistbox.GetItemText(bolumlerlistbox.SelectedItem);

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

                        query = "SELECT Ders.ders_id, Ders.ders_ismi FROM Ders INNER JOIN Bölüm_ders ON Ders.ders_id = Bölüm_ders.ders_id WHERE(((Bölüm_ders.bolum_id) =" + bolumlerlistbox.SelectedValue.ToString() + "))";

                        OleDbDataAdapter da = new OleDbDataAdapter(query, con);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "Ders");
                        Connection.tabloform.derslerlistbox.DisplayMember = "ders_ismi";
                        Connection.tabloform.derslerlistbox.ValueMember = "ders_id";
                        Connection.tabloform.derslerlistbox.DataSource = ds.Tables["Ders"];

                        

                        con.Close();
                        dersismilabel.Text = derslerlistbox.GetItemText(derslerlistbox.SelectedItem);
                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                    }
                }
            }
            else
            {
                dersismilabel.Text = "";
                derslerlistbox.DataSource = null;
                seciliderslabel.Text = "";
            }
        }

        private void kryptonListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dersismilabel.Text = derslerlistbox.GetItemText(derslerlistbox.SelectedItem);
        }
    }
}
