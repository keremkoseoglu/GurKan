namespace Gurkan
{
    partial class FormReprint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReprint));
            Gurkan.PlateNumber plateNumber1 = new Gurkan.PlateNumber();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.ilMain = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cmbScenario = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.date2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.date1 = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgMain = new System.Windows.Forms.DataGridView();
            this.BITTI = new System.Windows.Forms.DataGridViewImageColumn();
            this.SAPAK = new System.Windows.Forms.DataGridViewImageColumn();
            this.SUREC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ERDA1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TRAID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NAME1_TR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NETAG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAKTX_TR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnPrint2 = new System.Windows.Forms.Button();
            this.ucPlate1 = new Gurkan.UcPlate();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.ucPlate1);
            this.groupBox1.Controls.Add(this.cmbScenario);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.date2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.date1);
            this.groupBox1.Location = new System.Drawing.Point(13, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(784, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Veri Seçimi";
            // 
            // button1
            // 
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.ImageIndex = 3;
            this.button1.ImageList = this.ilMain;
            this.button1.Location = new System.Drawing.Point(479, 103);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(298, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "Bul";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ilMain
            // 
            this.ilMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMain.ImageStream")));
            this.ilMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMain.Images.SetKeyName(0, "s_f_save.gif");
            this.ilMain.Images.SetKeyName(1, "s_b_prnt.gif");
            this.ilMain.Images.SetKeyName(2, "s_gispan.gif");
            this.ilMain.Images.SetKeyName(3, "s_b_srch.gif");
            this.ilMain.Images.SetKeyName(4, "s_b_dele.gif");
            this.ilMain.Images.SetKeyName(5, "s_s_ledg.gif");
            this.ilMain.Images.SetKeyName(6, "s_s_ledy.gif");
            this.ilMain.Images.SetKeyName(7, "s_b_chng.gif");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Plaka";
            // 
            // cmbScenario
            // 
            this.cmbScenario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScenario.FormattingEnabled = true;
            this.cmbScenario.Items.AddRange(new object[] {
            "(Hepsi)",
            "Satýnalma",
            "Satýþ"});
            this.cmbScenario.Location = new System.Drawing.Point(107, 67);
            this.cmbScenario.Name = "cmbScenario";
            this.cmbScenario.Size = new System.Drawing.Size(298, 28);
            this.cmbScenario.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Süreç";
            // 
            // date2
            // 
            this.date2.Location = new System.Drawing.Point(478, 33);
            this.date2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(298, 26);
            this.date2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(431, 38);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "-";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tarih Aralýðý";
            // 
            // date1
            // 
            this.date1.Location = new System.Drawing.Point(107, 33);
            this.date1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(298, 26);
            this.date1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgMain);
            this.groupBox2.Location = new System.Drawing.Point(13, 184);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 209);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tartým Listesi";
            // 
            // dgMain
            // 
            this.dgMain.AllowUserToAddRows = false;
            this.dgMain.AllowUserToDeleteRows = false;
            this.dgMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BITTI,
            this.SAPAK,
            this.SUREC,
            this.ERDA1,
            this.TRAID,
            this.NAME1_TR,
            this.NETAG,
            this.MAKTX_TR});
            this.dgMain.Location = new System.Drawing.Point(12, 25);
            this.dgMain.MultiSelect = false;
            this.dgMain.Name = "dgMain";
            this.dgMain.ReadOnly = true;
            this.dgMain.Size = new System.Drawing.Size(766, 175);
            this.dgMain.TabIndex = 5;
            // 
            // BITTI
            // 
            this.BITTI.HeaderText = "Bitti";
            this.BITTI.Name = "BITTI";
            this.BITTI.ReadOnly = true;
            this.BITTI.Width = 32;
            // 
            // SAPAK
            // 
            this.SAPAK.HeaderText = "Aktarýldý";
            this.SAPAK.Name = "SAPAK";
            this.SAPAK.ReadOnly = true;
            this.SAPAK.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SAPAK.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SAPAK.Width = 32;
            // 
            // SUREC
            // 
            this.SUREC.HeaderText = "Süreç";
            this.SUREC.Name = "SUREC";
            this.SUREC.ReadOnly = true;
            // 
            // ERDA1
            // 
            this.ERDA1.HeaderText = "Tarih";
            this.ERDA1.Name = "ERDA1";
            this.ERDA1.ReadOnly = true;
            // 
            // TRAID
            // 
            this.TRAID.HeaderText = "Plaka";
            this.TRAID.Name = "TRAID";
            this.TRAID.ReadOnly = true;
            // 
            // NAME1_TR
            // 
            this.NAME1_TR.HeaderText = "Muhatap";
            this.NAME1_TR.Name = "NAME1_TR";
            this.NAME1_TR.ReadOnly = true;
            // 
            // NETAG
            // 
            this.NETAG.HeaderText = "Aðýrlýk";
            this.NETAG.Name = "NETAG";
            this.NETAG.ReadOnly = true;
            // 
            // MAKTX_TR
            // 
            this.MAKTX_TR.HeaderText = "Malzeme";
            this.MAKTX_TR.Name = "MAKTX_TR";
            this.MAKTX_TR.ReadOnly = true;
            // 
            // btnExit
            // 
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.ImageKey = "s_gispan.gif";
            this.btnExit.ImageList = this.ilMain;
            this.btnExit.Location = new System.Drawing.Point(669, 410);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(122, 32);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Çýkýþ";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Enabled = false;
            this.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint.ImageIndex = 1;
            this.btnPrint.ImageList = this.ilMain;
            this.btnPrint.Location = new System.Drawing.Point(285, 409);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(122, 32);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "Ýrsaliye";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.ImageIndex = 4;
            this.btnDelete.ImageList = this.ilMain;
            this.btnDelete.Location = new System.Drawing.Point(541, 409);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 32);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Enabled = false;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.ImageIndex = 7;
            this.btnEdit.ImageList = this.ilMain;
            this.btnEdit.Location = new System.Drawing.Point(413, 409);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(122, 32);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Düzenle";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnPrint2
            // 
            this.btnPrint2.Enabled = false;
            this.btnPrint2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrint2.ImageIndex = 1;
            this.btnPrint2.ImageList = this.ilMain;
            this.btnPrint2.Location = new System.Drawing.Point(157, 409);
            this.btnPrint2.Name = "btnPrint2";
            this.btnPrint2.Size = new System.Drawing.Size(122, 32);
            this.btnPrint2.TabIndex = 10;
            this.btnPrint2.Text = "Tartým Fiþi";
            this.btnPrint2.UseVisualStyleBackColor = true;
            this.btnPrint2.Click += new System.EventHandler(this.btnPrint2_Click);
            // 
            // ucPlate1
            // 
            this.ucPlate1.Location = new System.Drawing.Point(107, 103);
            this.ucPlate1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucPlate1.Name = "ucPlate1";
            plateNumber1.plateNumber = "";
            this.ucPlate1.plateNumber = plateNumber1;
            this.ucPlate1.Size = new System.Drawing.Size(115, 28);
            this.ucPlate1.TabIndex = 3;
            // 
            // FormReprint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 454);
            this.Controls.Add(this.btnPrint2);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormReprint";
            this.Text = "Tekrar Yazdýrma";
            this.Load += new System.EventHandler(this.FormReprint_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker date2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date1;
        private System.Windows.Forms.Label label4;
        private UcPlate ucPlate1;
        private System.Windows.Forms.ComboBox cmbScenario;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgMain;
        private System.Windows.Forms.ImageList ilMain;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DataGridViewImageColumn BITTI;
        private System.Windows.Forms.DataGridViewImageColumn SAPAK;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUREC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ERDA1;
        private System.Windows.Forms.DataGridViewTextBoxColumn TRAID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NAME1_TR;
        private System.Windows.Forms.DataGridViewTextBoxColumn NETAG;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAKTX_TR;
        private System.Windows.Forms.Button btnPrint2;
    }
}