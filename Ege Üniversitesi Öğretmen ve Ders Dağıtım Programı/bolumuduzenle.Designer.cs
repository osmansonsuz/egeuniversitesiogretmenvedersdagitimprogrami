namespace Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı
{
    partial class bolumuduzenle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bolumuduzenle));
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.ikinciogretimradio = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.orgunegitimradio = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.bolumtextbox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.SuspendLayout();
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.AutoSize = true;
            this.kryptonButton2.Location = new System.Drawing.Point(191, 112);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(124, 38);
            this.kryptonButton2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kryptonButton2.TabIndex = 26;
            this.kryptonButton2.Values.Image = global::Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Properties.Resources.cross;
            this.kryptonButton2.Values.Text = "İptal";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.AutoSize = true;
            this.kryptonButton1.Location = new System.Drawing.Point(12, 112);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(124, 38);
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kryptonButton1.TabIndex = 25;
            this.kryptonButton1.Values.Image = global::Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Properties.Resources.check;
            this.kryptonButton1.Values.Text = "Onayla";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // ikinciogretimradio
            // 
            this.ikinciogretimradio.Location = new System.Drawing.Point(77, 70);
            this.ikinciogretimradio.Name = "ikinciogretimradio";
            this.ikinciogretimradio.Size = new System.Drawing.Size(125, 23);
            this.ikinciogretimradio.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ikinciogretimradio.TabIndex = 23;
            this.ikinciogretimradio.Values.Text = "İkinci Öğretim";
            // 
            // orgunegitimradio
            // 
            this.orgunegitimradio.Location = new System.Drawing.Point(77, 44);
            this.orgunegitimradio.Name = "orgunegitimradio";
            this.orgunegitimradio.Size = new System.Drawing.Size(120, 23);
            this.orgunegitimradio.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.orgunegitimradio.TabIndex = 24;
            this.orgunegitimradio.Values.Text = "Örgün Eğitim";
            // 
            // bolumtextbox
            // 
            this.bolumtextbox.Location = new System.Drawing.Point(77, 12);
            this.bolumtextbox.Name = "bolumtextbox";
            this.bolumtextbox.Size = new System.Drawing.Size(217, 26);
            this.bolumtextbox.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bolumtextbox.TabIndex = 22;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(12, 12);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(59, 23);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kryptonLabel2.TabIndex = 21;
            this.kryptonLabel2.Values.Text = "Bölüm";
            // 
            // bolumuduzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(327, 162);
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.kryptonButton1);
            this.Controls.Add(this.ikinciogretimradio);
            this.Controls.Add(this.orgunegitimradio);
            this.Controls.Add(this.bolumtextbox);
            this.Controls.Add(this.kryptonLabel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "bolumuduzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bölüm Düzenle";
            this.Load += new System.EventHandler(this.bolumuduzenle_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        public ComponentFactory.Krypton.Toolkit.KryptonRadioButton ikinciogretimradio;
        public ComponentFactory.Krypton.Toolkit.KryptonRadioButton orgunegitimradio;
        public ComponentFactory.Krypton.Toolkit.KryptonTextBox bolumtextbox;
    }
}