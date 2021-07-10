namespace KelimeTahminOyunuForm
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioBtnInsBilg = new System.Windows.Forms.RadioButton();
            this.radioBtnBilgInsn = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioBtnKartezyen = new System.Windows.Forms.RadioButton();
            this.radioBtnSirali = new System.Windows.Forms.RadioButton();
            this.btnBaslat = new System.Windows.Forms.Button();
            this.listBoxGirilenKelime = new System.Windows.Forms.ListBox();
            this.txtKelimeGiris = new System.Windows.Forms.TextBox();
            this.btnKelimeGir = new System.Windows.Forms.Button();
            this.btnDurdur = new System.Windows.Forms.Button();
            this.timerDakika = new System.Windows.Forms.Timer(this.components);
            this.labelSure = new System.Windows.Forms.Label();
            this.timerSaniye = new System.Windows.Forms.Timer(this.components);
            this.timerSalise = new System.Windows.Forms.Timer(this.components);
            this.listBoxPuan = new System.Windows.Forms.ListBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loading_bar = new System.Windows.Forms.ProgressBar();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioBtnInsBilg);
            this.groupBox1.Controls.Add(this.radioBtnBilgInsn);
            this.groupBox1.Location = new System.Drawing.Point(12, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 71);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Oyun Türü";
            // 
            // radioBtnInsBilg
            // 
            this.radioBtnInsBilg.AutoSize = true;
            this.radioBtnInsBilg.Cursor = System.Windows.Forms.Cursors.Default;
            this.radioBtnInsBilg.Location = new System.Drawing.Point(7, 44);
            this.radioBtnInsBilg.Name = "radioBtnInsBilg";
            this.radioBtnInsBilg.Size = new System.Drawing.Size(104, 17);
            this.radioBtnInsBilg.TabIndex = 1;
            this.radioBtnInsBilg.TabStop = true;
            this.radioBtnInsBilg.Text = "İnsan - Bilgisayar";
            this.radioBtnInsBilg.UseVisualStyleBackColor = true;
            this.radioBtnInsBilg.CheckedChanged += new System.EventHandler(this.radioBtnInsBilg_CheckedChanged);
            // 
            // radioBtnBilgInsn
            // 
            this.radioBtnBilgInsn.AutoSize = true;
            this.radioBtnBilgInsn.Location = new System.Drawing.Point(7, 20);
            this.radioBtnBilgInsn.Name = "radioBtnBilgInsn";
            this.radioBtnBilgInsn.Size = new System.Drawing.Size(104, 17);
            this.radioBtnBilgInsn.TabIndex = 0;
            this.radioBtnBilgInsn.TabStop = true;
            this.radioBtnBilgInsn.Text = "Bilgisayar - İnsan";
            this.radioBtnBilgInsn.UseVisualStyleBackColor = true;
            this.radioBtnBilgInsn.CheckedChanged += new System.EventHandler(this.radioBtnBilgInsn_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioBtnKartezyen);
            this.groupBox2.Controls.Add(this.radioBtnSirali);
            this.groupBox2.Location = new System.Drawing.Point(190, 29);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(184, 71);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Oyun Modu";
            // 
            // radioBtnKartezyen
            // 
            this.radioBtnKartezyen.AutoSize = true;
            this.radioBtnKartezyen.Cursor = System.Windows.Forms.Cursors.Default;
            this.radioBtnKartezyen.Location = new System.Drawing.Point(7, 44);
            this.radioBtnKartezyen.Name = "radioBtnKartezyen";
            this.radioBtnKartezyen.Size = new System.Drawing.Size(96, 17);
            this.radioBtnKartezyen.TabIndex = 1;
            this.radioBtnKartezyen.TabStop = true;
            this.radioBtnKartezyen.Text = "Kartezyen Mod";
            this.radioBtnKartezyen.UseVisualStyleBackColor = true;
            // 
            // radioBtnSirali
            // 
            this.radioBtnSirali.AutoSize = true;
            this.radioBtnSirali.Location = new System.Drawing.Point(7, 20);
            this.radioBtnSirali.Name = "radioBtnSirali";
            this.radioBtnSirali.Size = new System.Drawing.Size(71, 17);
            this.radioBtnSirali.TabIndex = 0;
            this.radioBtnSirali.TabStop = true;
            this.radioBtnSirali.Text = "Sıralı Mod";
            this.radioBtnSirali.UseVisualStyleBackColor = true;
            // 
            // btnBaslat
            // 
            this.btnBaslat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBaslat.Location = new System.Drawing.Point(12, 106);
            this.btnBaslat.Name = "btnBaslat";
            this.btnBaslat.Size = new System.Drawing.Size(362, 43);
            this.btnBaslat.TabIndex = 2;
            this.btnBaslat.Text = "Oyunu Başlat";
            this.btnBaslat.UseVisualStyleBackColor = true;
            this.btnBaslat.Click += new System.EventHandler(this.btnBaslat_Click);
            // 
            // listBoxGirilenKelime
            // 
            this.listBoxGirilenKelime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBoxGirilenKelime.FormattingEnabled = true;
            this.listBoxGirilenKelime.ItemHeight = 16;
            this.listBoxGirilenKelime.Location = new System.Drawing.Point(12, 181);
            this.listBoxGirilenKelime.Name = "listBoxGirilenKelime";
            this.listBoxGirilenKelime.Size = new System.Drawing.Size(244, 84);
            this.listBoxGirilenKelime.TabIndex = 3;
            // 
            // txtKelimeGiris
            // 
            this.txtKelimeGiris.Location = new System.Drawing.Point(12, 155);
            this.txtKelimeGiris.Name = "txtKelimeGiris";
            this.txtKelimeGiris.Size = new System.Drawing.Size(244, 20);
            this.txtKelimeGiris.TabIndex = 4;
            this.txtKelimeGiris.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtKelimeGiris_KeyDown);
            // 
            // btnKelimeGir
            // 
            this.btnKelimeGir.Location = new System.Drawing.Point(261, 153);
            this.btnKelimeGir.Name = "btnKelimeGir";
            this.btnKelimeGir.Size = new System.Drawing.Size(112, 23);
            this.btnKelimeGir.TabIndex = 5;
            this.btnKelimeGir.Text = "Kelime Gir";
            this.btnKelimeGir.UseVisualStyleBackColor = true;
            this.btnKelimeGir.Click += new System.EventHandler(this.btnKelimeGir_Click);
            // 
            // btnDurdur
            // 
            this.btnDurdur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDurdur.Location = new System.Drawing.Point(11, 106);
            this.btnDurdur.Name = "btnDurdur";
            this.btnDurdur.Size = new System.Drawing.Size(362, 43);
            this.btnDurdur.TabIndex = 6;
            this.btnDurdur.Text = "Oyunu Bitir";
            this.btnDurdur.UseVisualStyleBackColor = true;
            this.btnDurdur.Visible = false;
            this.btnDurdur.Click += new System.EventHandler(this.btnDurdur_Click);
            // 
            // timerDakika
            // 
            this.timerDakika.Tick += new System.EventHandler(this.timerDakika_Tick);
            // 
            // labelSure
            // 
            this.labelSure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.labelSure.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSure.ForeColor = System.Drawing.Color.Black;
            this.labelSure.Location = new System.Drawing.Point(11, 279);
            this.labelSure.Name = "labelSure";
            this.labelSure.Size = new System.Drawing.Size(363, 23);
            this.labelSure.TabIndex = 7;
            this.labelSure.Text = "Süre:";
            this.labelSure.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timerSaniye
            // 
            this.timerSaniye.Tick += new System.EventHandler(this.timerSaniye_Tick);
            // 
            // timerSalise
            // 
            this.timerSalise.Tick += new System.EventHandler(this.timerSalise_Tick);
            // 
            // listBoxPuan
            // 
            this.listBoxPuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.listBoxPuan.FormattingEnabled = true;
            this.listBoxPuan.ItemHeight = 16;
            this.listBoxPuan.Location = new System.Drawing.Point(261, 181);
            this.listBoxPuan.Name = "listBoxPuan";
            this.listBoxPuan.Size = new System.Drawing.Size(113, 84);
            this.listBoxPuan.TabIndex = 8;
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(261, 154);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(112, 23);
            this.btnEkle.TabIndex = 9;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.menuStrip1.BackColor = System.Drawing.Color.Gainsboro;
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(386, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // sMenuItem
            // 
            this.sMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.sMenuItem.Name = "sMenuItem";
            this.sMenuItem.Size = new System.Drawing.Size(96, 20);
            this.sMenuItem.Text = "Sözlük Değiştir";
            this.sMenuItem.Click += new System.EventHandler(this.sMenuItem_Click);
            // 
            // loading_bar
            // 
            this.loading_bar.Location = new System.Drawing.Point(11, 279);
            this.loading_bar.Name = "loading_bar";
            this.loading_bar.Size = new System.Drawing.Size(362, 23);
            this.loading_bar.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(386, 309);
            this.Controls.Add(this.loading_bar);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.listBoxPuan);
            this.Controls.Add(this.labelSure);
            this.Controls.Add(this.btnDurdur);
            this.Controls.Add(this.btnKelimeGir);
            this.Controls.Add(this.txtKelimeGiris);
            this.Controls.Add(this.listBoxGirilenKelime);
            this.Controls.Add(this.btnBaslat);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Kelime Tahmin Oyunu";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioBtnInsBilg;
        private System.Windows.Forms.RadioButton radioBtnBilgInsn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioBtnKartezyen;
        private System.Windows.Forms.RadioButton radioBtnSirali;
        private System.Windows.Forms.Button btnBaslat;
        private System.Windows.Forms.ListBox listBoxGirilenKelime;
        private System.Windows.Forms.TextBox txtKelimeGiris;
        private System.Windows.Forms.Button btnKelimeGir;
        private System.Windows.Forms.Button btnDurdur;
        private System.Windows.Forms.Timer timerDakika;
        private System.Windows.Forms.Label labelSure;
        private System.Windows.Forms.Timer timerSaniye;
        private System.Windows.Forms.Timer timerSalise;
        private System.Windows.Forms.ListBox listBoxPuan;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sMenuItem;
        private System.Windows.Forms.ProgressBar loading_bar;
    }
}

