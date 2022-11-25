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
    public partial class dersliklerform : Form
    {
        public dersliklerform()
        {
            InitializeComponent();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Dersliği silmek istediğinizden emin misiniz ?", "Derslik sil", MessageBoxButtons.OKCancel);
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
                        query = "DELETE Derslik.* FROM Derslik WHERE(((Derslik.derslik_id) ="+dersliklistbox.SelectedValue+"))"; 
                        OleDbCommand cmd = new OleDbCommand(query, con);
                        cmd.ExecuteNonQuery();

                        con.Close();

                        
                        
                        MessageBox.Show("Derslik başarılı bir şekilde silindi !");

                        

                    }
                    catch (OleDbException ex)
                    {
                        MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                    }
                }

                Connection.VerileriTazele();
                if (dersliklistbox.Items.Count == 0)
                {
                    kryptonButton2.Enabled = false;
                    sinifradiobutton.Checked = false;
                    sinifradiobutton.Enabled = false;
                    labradiobutton.Checked = false;
                    labradiobutton.Enabled = false;
                    kryptonDataGridView1.Enabled = false;
                }

                //kryptonButton2.Enabled = false;
                //sinifradiobutton.Enabled = false;
                //labradiobutton.Enabled = false;

                //kryptonDataGridView1.Enabled = false;
                //for (int i = 0; i < kryptonDataGridView1.Rows.Count; i++)
                //{
                //    for (int j = 0; j < kryptonDataGridView1.Columns.Count; j++)
                //    {
                //        kryptonDataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                //    }
                //}
                //kryptonDataGridView1.ClearSelection();
            }
            else
            {

            }
        }

        private void siniflistbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dersliklistbox.SelectedIndex != -1)
            {
                if (dersliklistbox.Items.Count == 0)
                {
                    for (int i = 0; i < Connection.dersliklerform.kryptonDataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < Connection.dersliklerform.kryptonDataGridView1.Columns.Count; j++)
                        {
                            Connection.dersliklerform.kryptonDataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                        }
                    }
                    sinifradiobutton.Enabled = false;
                    labradiobutton.Enabled = false;
                    kryptonButton2.Enabled = false;
                    kryptonDataGridView1.Enabled = false;
                }
                else
                {
                    for (int i = 0; i < Connection.dersliklerform.kryptonDataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < Connection.dersliklerform.kryptonDataGridView1.Columns.Count; j++)
                        {
                            Connection.dersliklerform.kryptonDataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                        }
                    }
                    sinifradiobutton.Enabled = true;
                    labradiobutton.Enabled = true;
                    kryptonButton2.Enabled = true;
                    kryptonDataGridView1.Enabled = true;
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
                            string derslikboszamanvirgullu = "";


                            query = "SELECT Derslik.derslik_türü, Derslik.derslik_boszaman FROM Derslik WHERE (((Derslik.derslik_id)=" + dersliklistbox.SelectedValue + "));";
                            OleDbCommand command = new OleDbCommand(query, con);
                            OleDbDataReader DR1 = command.ExecuteReader();

                            if (DR1.Read())
                            {
                                if (DR1.GetBoolean(0) == true)
                                {
                                    labradiobutton.Checked = true;
                                }
                                else
                                {
                                    sinifradiobutton.Checked = true;
                                }
                                derslikboszamanvirgullu = DR1.GetValue(1).ToString();
                            }

                            query = "";


                            List<string> boszaman = new List<string>();
                            string indexes = "";
                            foreach (char item in derslikboszamanvirgullu)
                            {
                                if (item == ',')
                                {
                                    boszaman.Add(indexes);
                                    indexes = "";

                                }
                                else
                                {
                                    indexes = indexes + item;
                                }
                            }
                            if (boszaman.Count != 0 || indexes.Length != 0)
                            {
                                boszaman.Add(indexes);
                            }

                            List<int> rowindex = new List<int>();
                            List<int> colindex = new List<int>();
                            if (boszaman.Count != 0)
                            {
                                for (int i = 0; i < boszaman.Count; i++)
                                {
                                    int indexsayi = 0;
                                    indexsayi = boszaman[i].Length;
                                    if (indexsayi == 3)
                                    {
                                        colindex.Add(Convert.ToInt32(boszaman[i].Substring(2)));
                                        rowindex.Add(Convert.ToInt32(boszaman[i].Substring(0, 2)));
                                    }
                                    else
                                    {
                                        colindex.Add(Convert.ToInt32(boszaman[i].Substring(1)));
                                        rowindex.Add(Convert.ToInt32(boszaman[i].Substring(0, 1)));
                                    }

                                }
                            }
                            else
                            {

                            }

                            if (colindex.Count != 0)
                            {
                                for (int i = 0; i < colindex.Count; i++)
                                {
                                    System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#b7dbff");
                                    if (Connection.dersliklerform.kryptonDataGridView1.Rows[rowindex[i]].Cells[colindex[i]].Style.BackColor == col)
                                    {
                                        Connection.dersliklerform.kryptonDataGridView1.Rows[rowindex[i]].Cells[colindex[i]].Style.BackColor = Color.White;
                                    }
                                    else
                                    {
                                        Connection.dersliklerform.kryptonDataGridView1.Rows[rowindex[i]].Cells[colindex[i]].Style.BackColor = col;
                                    }
                                    Connection.dersliklerform.kryptonDataGridView1.ClearSelection();
                                }
                            }
                            else
                            {
                                for (int i = 0; i < Connection.dersliklerform.kryptonDataGridView1.Rows.Count; i++)
                                {
                                    for (int j = 0; j < Connection.dersliklerform.kryptonDataGridView1.Columns.Count; j++)
                                    {
                                        Connection.dersliklerform.kryptonDataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                                    }
                                }
                            }




                            con.Close();

                        }
                        catch (OleDbException ex)
                        {
                            MessageBox.Show("Veritabanına bağlanırken hata oluştu !" + ex.Message);
                        }

                    }
                }

            }
            else
            {
                for (int i = 0; i < Connection.dersliklerform.kryptonDataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < Connection.dersliklerform.kryptonDataGridView1.Columns.Count; j++)
                    {
                        Connection.dersliklerform.kryptonDataGridView1.Rows[i].Cells[j].Style.BackColor = Color.White;
                    }
                }
                kryptonButton2.Enabled = false;
                kryptonDataGridView1.Enabled = false;
                sinifradiobutton.Enabled = false;
                labradiobutton.Enabled = false;
                sinifradiobutton.Checked = false;
                labradiobutton.Checked = false;
            }

        }

        private void kryptonButton1_Click(object sender, EventArgs e)
        {
            sinifekle sinifekle = new sinifekle();
            sinifekle.ShowDialog();
        }




        private void kryptonDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
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

            if (Connection.DBPath == null)
            {
                //burada ders ismine göre veri girilecek(veritabanı olmadan!)

            }
            else
            {
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

                    query = "UPDATE Derslik SET Derslik.derslik_boszaman ='" + indexler + "' WHERE Derslik.derslik_id ="+dersliklistbox.SelectedValue.ToString()+"";
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

        private void dersliklerform_Load(object sender, EventArgs e)
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

        private void sinifradiobutton_CheckedChanged(object sender, EventArgs e)
        {
            if (dersliklistbox.SelectedIndex != -1)
            {
                if (dersliklistbox.Items.Count != 0)
                {
                    if (Connection.DBPath == null)
                    {
                        //burada bölüm ismine göre veri girilecek(veritabanı olmadan!)

                    }
                    else
                    {
                        try
                        {
                            OleDbConnection con = new OleDbConnection();
                            string query;
                            con = Connection.GetConnection();
                            con.Open();


                            query = "UPDATE Derslik SET Derslik.derslik_türü = False WHERE(((Derslik.derslik_id) = " + dersliklistbox.SelectedValue + "))";
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
            
            


        }

        private void labradiobutton_CheckedChanged(object sender, EventArgs e)
        {
            if (dersliklistbox.SelectedIndex != -1)
            {
                if (dersliklistbox.Items.Count != 0)
                {
                    if (Connection.DBPath == null)
                    {
                        //burada bölüm ismine göre veri girilecek(veritabanı olmadan!)

                    }
                    else
                    {
                        try
                        {
                            OleDbConnection con = new OleDbConnection();
                            string query;
                            con = Connection.GetConnection();
                            con.Open();


                            query = "UPDATE Derslik SET Derslik.derslik_türü = True WHERE(((Derslik.derslik_id) = " + dersliklistbox.SelectedValue + "))";
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
            
            
        }




    }
}
