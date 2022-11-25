using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı
{
    public partial class otomatikyerlestir : Form
    {
        public otomatikyerlestir()
        {
            InitializeComponent();
        }

        private void kryptonButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void otomatikyerlestir_Load(object sender, EventArgs e)
        {

        }

        private void bolumlerlistbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (bolumlerlistbox.SelectedItems.Count != 0)
            {
                kryptonButton4.Enabled = true;
            }
            else
            {
                kryptonButton4.Enabled = false;
            }
        }
    }
}
