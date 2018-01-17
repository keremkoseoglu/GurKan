namespace Gurkan
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.imageListMain = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnDara = new System.Windows.Forms.Button();
            this.btnFree = new System.Windows.Forms.Button();
            this.btnReprint = new System.Windows.Forms.Button();
            this.btnSal2 = new System.Windows.Forms.Button();
            this.btnSal1 = new System.Windows.Forms.Button();
            this.btnPur2 = new System.Windows.Forms.Button();
            this.btnPur1 = new System.Windows.Forms.Button();
            this.btnEnt = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // imageListMain
            // 
            this.imageListMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListMain.ImageStream")));
            this.imageListMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListMain.Images.SetKeyName(0, "s_s_ledg.gif");
            this.imageListMain.Images.SetKeyName(1, "s_s_ledy.gif");
            this.imageListMain.Images.SetKeyName(2, "s_s_ledr.gif");
            this.imageListMain.Images.SetKeyName(3, "s_s_ledi.gif");
            this.imageListMain.Images.SetKeyName(4, "s_b_genr.gif");
            this.imageListMain.Images.SetKeyName(5, "s_imalre.gif");
            this.imageListMain.Images.SetKeyName(6, "s_s_wstr.gif");
            this.imageListMain.Images.SetKeyName(7, "s_b_test.gif");
            this.imageListMain.Images.SetKeyName(8, "s_b_prnt.gif");
            this.imageListMain.Images.SetKeyName(9, "s_b_chck.gif");
            this.imageListMain.Images.SetKeyName(10, "s_dagoch.gif");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEnt);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnTest);
            this.groupBox1.Location = new System.Drawing.Point(230, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 115);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Teknik";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnPur2);
            this.groupBox2.Controls.Add(this.btnPur1);
            this.groupBox2.Location = new System.Drawing.Point(230, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(212, 91);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Satýnalma Süreçleri";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnSal2);
            this.groupBox3.Controls.Add(this.btnSal1);
            this.groupBox3.Location = new System.Drawing.Point(9, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(209, 91);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Satýþ Süreçleri";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnDara);
            this.groupBox4.Controls.Add(this.btnFree);
            this.groupBox4.Controls.Add(this.btnReprint);
            this.groupBox4.Location = new System.Drawing.Point(6, 109);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(212, 115);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bakým";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 315);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(448, 22);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(71, 17);
            this.lblStatus.Text = "Aktif Kantar: ";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox3.Image = global::Gurkan.Properties.Resources.outlook;
            this.pictureBox3.Location = new System.Drawing.Point(132, 230);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(173, 79);
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Gurkan.Properties.Resources.guris_logo;
            this.pictureBox2.Location = new System.Drawing.Point(6, 230);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 50);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // btnDara
            // 
            this.btnDara.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDara.ImageIndex = 10;
            this.btnDara.ImageList = this.imageListMain;
            this.btnDara.Location = new System.Drawing.Point(6, 77);
            this.btnDara.Name = "btnDara";
            this.btnDara.Size = new System.Drawing.Size(197, 23);
            this.btnDara.TabIndex = 6;
            this.btnDara.Text = "Dara Tartýmý";
            this.btnDara.UseVisualStyleBackColor = true;
            this.btnDara.Click += new System.EventHandler(this.btnDara_Click);
            // 
            // btnFree
            // 
            this.btnFree.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFree.ImageIndex = 9;
            this.btnFree.ImageList = this.imageListMain;
            this.btnFree.Location = new System.Drawing.Point(6, 48);
            this.btnFree.Name = "btnFree";
            this.btnFree.Size = new System.Drawing.Size(197, 23);
            this.btnFree.TabIndex = 5;
            this.btnFree.Text = "Serbest Tartým";
            this.btnFree.UseVisualStyleBackColor = true;
            this.btnFree.Click += new System.EventHandler(this.btnFree_Click);
            // 
            // btnReprint
            // 
            this.btnReprint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReprint.ImageIndex = 8;
            this.btnReprint.ImageList = this.imageListMain;
            this.btnReprint.Location = new System.Drawing.Point(6, 19);
            this.btnReprint.Name = "btnReprint";
            this.btnReprint.Size = new System.Drawing.Size(197, 23);
            this.btnReprint.TabIndex = 4;
            this.btnReprint.Text = "Yazdýr / Güncelle / Sil";
            this.btnReprint.UseVisualStyleBackColor = true;
            this.btnReprint.Click += new System.EventHandler(this.btnReprint_Click);
            // 
            // btnSal2
            // 
            this.btnSal2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSal2.ImageIndex = 5;
            this.btnSal2.ImageList = this.imageListMain;
            this.btnSal2.Location = new System.Drawing.Point(6, 48);
            this.btnSal2.Name = "btnSal2";
            this.btnSal2.Size = new System.Drawing.Size(197, 23);
            this.btnSal2.TabIndex = 1;
            this.btnSal2.Text = "Dolu Tartým";
            this.btnSal2.UseVisualStyleBackColor = true;
            this.btnSal2.Click += new System.EventHandler(this.btnSal2_Click);
            // 
            // btnSal1
            // 
            this.btnSal1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSal1.ImageIndex = 6;
            this.btnSal1.ImageList = this.imageListMain;
            this.btnSal1.Location = new System.Drawing.Point(6, 19);
            this.btnSal1.Name = "btnSal1";
            this.btnSal1.Size = new System.Drawing.Size(197, 23);
            this.btnSal1.TabIndex = 0;
            this.btnSal1.Text = "Boþ Tartým";
            this.btnSal1.UseVisualStyleBackColor = true;
            this.btnSal1.Click += new System.EventHandler(this.btnSal1_Click);
            // 
            // btnPur2
            // 
            this.btnPur2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPur2.ImageIndex = 5;
            this.btnPur2.ImageList = this.imageListMain;
            this.btnPur2.Location = new System.Drawing.Point(6, 19);
            this.btnPur2.Name = "btnPur2";
            this.btnPur2.Size = new System.Drawing.Size(197, 23);
            this.btnPur2.TabIndex = 2;
            this.btnPur2.Text = "Dolu Tartým";
            this.btnPur2.UseVisualStyleBackColor = true;
            this.btnPur2.Click += new System.EventHandler(this.btnPur2_Click);
            // 
            // btnPur1
            // 
            this.btnPur1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPur1.ImageIndex = 6;
            this.btnPur1.ImageList = this.imageListMain;
            this.btnPur1.Location = new System.Drawing.Point(6, 48);
            this.btnPur1.Name = "btnPur1";
            this.btnPur1.Size = new System.Drawing.Size(197, 23);
            this.btnPur1.TabIndex = 3;
            this.btnPur1.Text = "Boþ Tartým";
            this.btnPur1.UseVisualStyleBackColor = true;
            this.btnPur1.Click += new System.EventHandler(this.btnPur1_Click);
            // 
            // btnEnt
            // 
            this.btnEnt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEnt.ImageIndex = 3;
            this.btnEnt.ImageList = this.imageListMain;
            this.btnEnt.Location = new System.Drawing.Point(6, 77);
            this.btnEnt.Name = "btnEnt";
            this.btnEnt.Size = new System.Drawing.Size(197, 23);
            this.btnEnt.TabIndex = 9;
            this.btnEnt.Text = "Entegrasyon Durumu";
            this.btnEnt.UseVisualStyleBackColor = true;
            this.btnEnt.Click += new System.EventHandler(this.btnEnt_Click);
            // 
            // button1
            // 
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 4;
            this.button1.ImageList = this.imageListMain;
            this.button1.Location = new System.Drawing.Point(6, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Senkronizasyonu Yürüt";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTest
            // 
            this.btnTest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTest.ImageIndex = 7;
            this.btnTest.ImageList = this.imageListMain;
            this.btnTest.Location = new System.Drawing.Point(6, 19);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(197, 23);
            this.btnTest.TabIndex = 7;
            this.btnTest.Text = "Sistemi Test Et";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 337);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "Güriþ Kantar Programý";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.ImageList imageListMain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnPur2;
        private System.Windows.Forms.Button btnPur1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnSal2;
        private System.Windows.Forms.Button btnSal1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnReprint;
        private System.Windows.Forms.Button btnFree;
        private System.Windows.Forms.Button btnDara;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.Button btnEnt;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

