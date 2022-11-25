namespace Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı
{
    partial class sinifekle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sinifekle));
            this.kryptonButton2 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonButton1 = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonLabel1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dersliktextbox = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.kryptonLabel2 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.labradiobutton = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.sinifradiobutton = new ComponentFactory.Krypton.Toolkit.KryptonRadioButton();
            this.SuspendLayout();
            // 
            // kryptonButton2
            // 
            this.kryptonButton2.AutoSize = true;
            this.kryptonButton2.Location = new System.Drawing.Point(206, 103);
            this.kryptonButton2.Name = "kryptonButton2";
            this.kryptonButton2.Size = new System.Drawing.Size(124, 38);
            this.kryptonButton2.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kryptonButton2.TabIndex = 22;
            this.kryptonButton2.Values.Image = global::Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Properties.Resources.cross;
            this.kryptonButton2.Values.Text = "İptal";
            this.kryptonButton2.Click += new System.EventHandler(this.kryptonButton2_Click);
            // 
            // kryptonButton1
            // 
            this.kryptonButton1.AutoSize = true;
            this.kryptonButton1.Location = new System.Drawing.Point(12, 103);
            this.kryptonButton1.Name = "kryptonButton1";
            this.kryptonButton1.Size = new System.Drawing.Size(124, 38);
            this.kryptonButton1.StateCommon.Content.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kryptonButton1.TabIndex = 21;
            this.kryptonButton1.Values.Image = global::Ege_Üniversitesi_Öğretmen_ve_Ders_Dağıtım_Programı.Properties.Resources.check;
            this.kryptonButton1.Values.Text = "Ekle";
            this.kryptonButton1.Click += new System.EventHandler(this.kryptonButton1_Click);
            // 
            // kryptonLabel1
            // 
            this.kryptonLabel1.Location = new System.Drawing.Point(10, 32);
            this.kryptonLabel1.Name = "kryptonLabel1";
            this.kryptonLabel1.Size = new System.Drawing.Size(97, 23);
            this.kryptonLabel1.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kryptonLabel1.TabIndex = 23;
            this.kryptonLabel1.Values.Text = "Derslik İsmi";
            // 
            // dersliktextbox
            // 
            this.dersliktextbox.Location = new System.Drawing.Point(113, 29);
            this.dersliktextbox.Name = "dersliktextbox";
            this.dersliktextbox.Size = new System.Drawing.Size(217, 26);
            this.dersliktextbox.StateCommon.Content.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dersliktextbox.TabIndex = 24;
            // 
            // kryptonLabel2
            // 
            this.kryptonLabel2.Location = new System.Drawing.Point(10, 71);
            this.kryptonLabel2.Name = "kryptonLabel2";
            this.kryptonLabel2.Size = new System.Drawing.Size(101, 23);
            this.kryptonLabel2.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kryptonLabel2.TabIndex = 25;
            this.kryptonLabel2.Values.Text = "Derslik Türü";
            // 
            // labradiobutton
            // 
            this.labradiobutton.Location = new System.Drawing.Point(218, 71);
            this.labradiobutton.Name = "labradiobutton";
            this.labradiobutton.Size = new System.Drawing.Size(112, 23);
            this.labradiobutton.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labradiobutton.TabIndex = 26;
            this.labradiobutton.Values.Text = "Laboratuvar";
            // 
            // sinifradiobutton
            // 
            this.sinifradiobutton.Checked = true;
            this.sinifradiobutton.Location = new System.Drawing.Point(113, 71);
            this.sinifradiobutton.Name = "sinifradiobutton";
            this.sinifradiobutton.Size = new System.Drawing.Size(56, 23);
            this.sinifradiobutton.StateCommon.ShortText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sinifradiobutton.TabIndex = 26;
            this.sinifradiobutton.Values.Text = "Sınıf";
            // 
            // sinifekle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(206)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(342, 153);
            this.Controls.Add(this.labradiobutton);
            this.Controls.Add(this.sinifradiobutton);
            this.Controls.Add(this.kryptonLabel2);
            this.Controls.Add(this.dersliktextbox);
            this.Controls.Add(this.kryptonLabel1);
            this.Controls.Add(this.kryptonButton2);
            this.Controls.Add(this.kryptonButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "sinifekle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Derslik Ekle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton2;
        private ComponentFactory.Krypton.Toolkit.KryptonButton kryptonButton1;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox dersliktextbox;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel kryptonLabel2;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton labradiobutton;
        private ComponentFactory.Krypton.Toolkit.KryptonRadioButton sinifradiobutton;
    }
}