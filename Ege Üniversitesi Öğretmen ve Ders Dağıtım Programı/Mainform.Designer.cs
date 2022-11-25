namespace Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı
{
    partial class Mainform
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.savetofilebutton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.readfromfilebutton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.quitbutton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.bolumlerbutton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ayarlarbutton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.dersliklerbutton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.tablobutton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ogretmenlerbutton = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.headerpanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.mdipanel = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.headerpanel)).BeginInit();
            this.headerpanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mdipanel)).BeginInit();
            this.SuspendLayout();
            // 
            // savetofilebutton
            // 
            this.savetofilebutton.AutoSize = true;
            this.savetofilebutton.Location = new System.Drawing.Point(1231, 12);
            this.savetofilebutton.Name = "savetofilebutton";
            this.savetofilebutton.Size = new System.Drawing.Size(146, 53);
            this.savetofilebutton.TabIndex = 1;
            this.savetofilebutton.Values.Image = global::Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Properties.Resources.floppy_disk__1_;
            this.savetofilebutton.Values.Text = "Veritabanı Oluştur";
            this.savetofilebutton.Click += new System.EventHandler(this.savetofilebutton_Click);
            // 
            // readfromfilebutton
            // 
            this.readfromfilebutton.AutoSize = true;
            this.readfromfilebutton.Location = new System.Drawing.Point(1383, 12);
            this.readfromfilebutton.Name = "readfromfilebutton";
            this.readfromfilebutton.Size = new System.Drawing.Size(146, 53);
            this.readfromfilebutton.TabIndex = 5;
            this.readfromfilebutton.Values.Image = global::Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Properties.Resources.folder__1_;
            this.readfromfilebutton.Values.Text = "Veritabanı Oku";
            this.readfromfilebutton.Click += new System.EventHandler(this.readfromfilebutton_Click);
            // 
            // quitbutton
            // 
            this.quitbutton.AutoSize = true;
            this.quitbutton.Location = new System.Drawing.Point(1746, 12);
            this.quitbutton.Name = "quitbutton";
            this.quitbutton.Size = new System.Drawing.Size(146, 53);
            this.quitbutton.TabIndex = 1;
            this.quitbutton.Values.Image = global::Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Properties.Resources.logout;
            this.quitbutton.Values.Text = "Çıkış Yap";
            this.quitbutton.Click += new System.EventHandler(this.quitbutton_Click);
            // 
            // bolumlerbutton
            // 
            this.bolumlerbutton.AutoSize = true;
            this.bolumlerbutton.Location = new System.Drawing.Point(164, 12);
            this.bolumlerbutton.Name = "bolumlerbutton";
            this.bolumlerbutton.Size = new System.Drawing.Size(146, 53);
            this.bolumlerbutton.TabIndex = 0;
            this.bolumlerbutton.Values.Image = global::Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Properties.Resources.book__2_;
            this.bolumlerbutton.Values.Text = "Bölümler";
            this.bolumlerbutton.Click += new System.EventHandler(this.bolumlerbutton_Click);
            // 
            // ayarlarbutton
            // 
            this.ayarlarbutton.AutoSize = true;
            this.ayarlarbutton.Location = new System.Drawing.Point(468, 12);
            this.ayarlarbutton.Name = "ayarlarbutton";
            this.ayarlarbutton.Size = new System.Drawing.Size(146, 53);
            this.ayarlarbutton.TabIndex = 0;
            this.ayarlarbutton.Values.Image = global::Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Properties.Resources.settings__1_;
            this.ayarlarbutton.Values.Text = "Ayarlar";
            this.ayarlarbutton.Click += new System.EventHandler(this.ayarlarbutton_Click);
            // 
            // dersliklerbutton
            // 
            this.dersliklerbutton.AutoSize = true;
            this.dersliklerbutton.Location = new System.Drawing.Point(316, 12);
            this.dersliklerbutton.Name = "dersliklerbutton";
            this.dersliklerbutton.Size = new System.Drawing.Size(146, 53);
            this.dersliklerbutton.TabIndex = 0;
            this.dersliklerbutton.Values.Image = global::Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Properties.Resources.flask__1_;
            this.dersliklerbutton.Values.Text = "Derslikler";
            this.dersliklerbutton.Click += new System.EventHandler(this.dersliklerbutton_Click);
            // 
            // tablobutton
            // 
            this.tablobutton.AutoSize = true;
            this.tablobutton.Location = new System.Drawing.Point(620, 12);
            this.tablobutton.Name = "tablobutton";
            this.tablobutton.Size = new System.Drawing.Size(146, 53);
            this.tablobutton.TabIndex = 0;
            this.tablobutton.Values.Image = global::Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Properties.Resources.table__1_;
            this.tablobutton.Values.Text = "Tablo";
            this.tablobutton.Click += new System.EventHandler(this.tablobutton_Click);
            // 
            // ogretmenlerbutton
            // 
            this.ogretmenlerbutton.AutoSize = true;
            this.ogretmenlerbutton.Location = new System.Drawing.Point(12, 12);
            this.ogretmenlerbutton.Name = "ogretmenlerbutton";
            this.ogretmenlerbutton.Size = new System.Drawing.Size(145, 53);
            this.ogretmenlerbutton.TabIndex = 0;
            this.ogretmenlerbutton.Values.Image = global::Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Properties.Resources.id_card__3_;
            this.ogretmenlerbutton.Values.Text = "Öğretmenler";
            this.ogretmenlerbutton.Click += new System.EventHandler(this.ogretmenlerbutton_Click);
            // 
            // headerpanel
            // 
            this.headerpanel.AutoSize = true;
            this.headerpanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.headerpanel.Controls.Add(this.tablobutton);
            this.headerpanel.Controls.Add(this.ogretmenlerbutton);
            this.headerpanel.Controls.Add(this.quitbutton);
            this.headerpanel.Controls.Add(this.ayarlarbutton);
            this.headerpanel.Controls.Add(this.dersliklerbutton);
            this.headerpanel.Controls.Add(this.bolumlerbutton);
            this.headerpanel.Controls.Add(this.savetofilebutton);
            this.headerpanel.Controls.Add(this.readfromfilebutton);
            this.headerpanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerpanel.Location = new System.Drawing.Point(0, 0);
            this.headerpanel.Name = "headerpanel";
            this.headerpanel.Size = new System.Drawing.Size(1904, 68);
            this.headerpanel.TabIndex = 8;
            // 
            // mdipanel
            // 
            this.mdipanel.AutoSize = true;
            this.mdipanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mdipanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdipanel.Location = new System.Drawing.Point(0, 68);
            this.mdipanel.Name = "mdipanel";
            this.mdipanel.Size = new System.Drawing.Size(1904, 973);
            this.mdipanel.TabIndex = 10;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "Veritabanını Seçin";
            this.openFileDialog1.Filter = "Access Veritabanı (*.accdb)|*.accdb|Access Veritabanı(*.mdb)|*.mdb";
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.mdipanel);
            this.Controls.Add(this.headerpanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MinimumSize = new System.Drawing.Size(1057, 640);
            this.Name = "Mainform";
            this.Text = "Öğretmen ve Ders Dağıtım Programı 1.3 ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Mainform_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.headerpanel)).EndInit();
            this.headerpanel.ResumeLayout(false);
            this.headerpanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mdipanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton savetofilebutton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton readfromfilebutton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton quitbutton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton bolumlerbutton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton ayarlarbutton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton dersliklerbutton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton tablobutton;
        private ComponentFactory.Krypton.Toolkit.KryptonButton ogretmenlerbutton;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel headerpanel;
        public ComponentFactory.Krypton.Toolkit.KryptonPanel mdipanel;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

