namespace Gurkan
{
    partial class FormWeight1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWeight1));
            Gurkan.PlateNumber plateNumber1 = new Gurkan.PlateNumber();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbDocument = new System.Windows.Forms.ComboBox();
            this.btnPlate = new System.Windows.Forms.Button();
            this.ilMain = new System.Windows.Forms.ImageList(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.cmbParty = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPartyNameAR = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMaterialTextAR = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtTransporterNameAR = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTransporter = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtFree = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.weightMain = new Gurkan.UcWeight();
            this.plateMain = new Gurkan.UcPlate();
            this.txtMubel = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtOpera = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDrive = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Plaka";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 57);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Belge";
            // 
            // cmbDocument
            // 
            this.cmbDocument.FormattingEnabled = true;
            this.cmbDocument.Location = new System.Drawing.Point(135, 44);
            this.cmbDocument.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbDocument.Name = "cmbDocument";
            this.cmbDocument.Size = new System.Drawing.Size(339, 28);
            this.cmbDocument.TabIndex = 2;
            this.cmbDocument.SelectedIndexChanged += new System.EventHandler(this.cmbDocument_SelectedIndexChanged);
            // 
            // btnPlate
            // 
            this.btnPlate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPlate.ImageIndex = 3;
            this.btnPlate.ImageList = this.ilMain;
            this.btnPlate.Location = new System.Drawing.Point(317, 7);
            this.btnPlate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPlate.Name = "btnPlate";
            this.btnPlate.Size = new System.Drawing.Size(157, 27);
            this.btnPlate.TabIndex = 1;
            this.btnPlate.Text = "Bul";
            this.btnPlate.UseVisualStyleBackColor = true;
            this.btnPlate.Click += new System.EventHandler(this.btnPlate_Click);
            // 
            // ilMain
            // 
            this.ilMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMain.ImageStream")));
            this.ilMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMain.Images.SetKeyName(0, "s_f_save.gif");
            this.ilMain.Images.SetKeyName(1, "s_b_prnt.gif");
            this.ilMain.Images.SetKeyName(2, "s_gispan.gif");
            this.ilMain.Images.SetKeyName(3, "s_b_srch.gif");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Muhatap";
            // 
            // cmbParty
            // 
            this.cmbParty.FormattingEnabled = true;
            this.cmbParty.Location = new System.Drawing.Point(135, 82);
            this.cmbParty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbParty.Name = "cmbParty";
            this.cmbParty.Size = new System.Drawing.Size(339, 28);
            this.cmbParty.TabIndex = 3;
            this.cmbParty.SelectedIndexChanged += new System.EventHandler(this.cmbParty_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(484, 90);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Arapça";
            // 
            // txtPartyNameAR
            // 
            this.txtPartyNameAR.Location = new System.Drawing.Point(555, 86);
            this.txtPartyNameAR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPartyNameAR.Name = "txtPartyNameAR";
            this.txtPartyNameAR.Size = new System.Drawing.Size(354, 26);
            this.txtPartyNameAR.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Malzeme";
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(135, 127);
            this.cmbMaterial.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(339, 28);
            this.cmbMaterial.TabIndex = 5;
            this.cmbMaterial.SelectedIndexChanged += new System.EventHandler(this.cmbMaterial_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(484, 137);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Arapça";
            // 
            // txtMaterialTextAR
            // 
            this.txtMaterialTextAR.Location = new System.Drawing.Point(555, 132);
            this.txtMaterialTextAR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMaterialTextAR.Name = "txtMaterialTextAR";
            this.txtMaterialTextAR.Size = new System.Drawing.Size(354, 26);
            this.txtMaterialTextAR.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 217);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Gel.Alan";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(135, 212);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(339, 26);
            this.txtFrom.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(484, 217);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Git.Alan";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(555, 212);
            this.txtTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(354, 26);
            this.txtTo.TabIndex = 10;
            // 
            // txtTransporterNameAR
            // 
            this.txtTransporterNameAR.Location = new System.Drawing.Point(555, 172);
            this.txtTransporterNameAR.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTransporterNameAR.Name = "txtTransporterNameAR";
            this.txtTransporterNameAR.Size = new System.Drawing.Size(354, 26);
            this.txtTransporterNameAR.TabIndex = 8;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(484, 177);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 20);
            this.label9.TabIndex = 19;
            this.label9.Text = "Arapça";
            // 
            // cmbTransporter
            // 
            this.cmbTransporter.FormattingEnabled = true;
            this.cmbTransporter.Location = new System.Drawing.Point(135, 172);
            this.cmbTransporter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbTransporter.Name = "cmbTransporter";
            this.cmbTransporter.Size = new System.Drawing.Size(339, 28);
            this.cmbTransporter.TabIndex = 7;
            this.cmbTransporter.SelectedIndexChanged += new System.EventHandler(this.cmbTransporter_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 177);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 20);
            this.label10.TabIndex = 17;
            this.label10.Text = "Nakliyeci";
            // 
            // txtFree
            // 
            this.txtFree.Location = new System.Drawing.Point(135, 254);
            this.txtFree.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtFree.Name = "txtFree";
            this.txtFree.Size = new System.Drawing.Size(774, 26);
            this.txtFree.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 260);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 20);
            this.label11.TabIndex = 22;
            this.label11.Text = "Açýklama";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.ImageIndex = 0;
            this.btnSave.ImageList = this.ilMain;
            this.btnSave.Location = new System.Drawing.Point(659, 338);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(122, 32);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExit
            // 
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.ImageKey = "s_gispan.gif";
            this.btnExit.ImageList = this.ilMain;
            this.btnExit.Location = new System.Drawing.Point(787, 338);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(122, 32);
            this.btnExit.TabIndex = 16;
            this.btnExit.Text = "Çýkýþ";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // weightMain
            // 
            this.weightMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.weightMain.Location = new System.Drawing.Point(13, 326);
            this.weightMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.weightMain.Name = "weightMain";
            this.weightMain.Size = new System.Drawing.Size(440, 44);
            this.weightMain.TabIndex = 14;
            this.weightMain.weight = null;
            this.weightMain.weightTaken += new Gurkan.UcWeight.UcWeightEventDelegate(this.weightMain_weightTaken);
            // 
            // plateMain
            // 
            this.plateMain.Location = new System.Drawing.Point(135, 9);
            this.plateMain.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.plateMain.Name = "plateMain";
            plateNumber1.plateNumber = "";
            this.plateMain.plateNumber = plateNumber1;
            this.plateMain.Size = new System.Drawing.Size(172, 28);
            this.plateMain.TabIndex = 0;
            // 
            // txtMubel
            // 
            this.txtMubel.Location = new System.Drawing.Point(555, 44);
            this.txtMubel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMubel.Name = "txtMubel";
            this.txtMubel.Size = new System.Drawing.Size(226, 26);
            this.txtMubel.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(478, 47);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "Muh.Blg.";
            // 
            // txtOpera
            // 
            this.txtOpera.Location = new System.Drawing.Point(555, 290);
            this.txtOpera.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtOpera.Name = "txtOpera";
            this.txtOpera.Size = new System.Drawing.Size(354, 26);
            this.txtOpera.TabIndex = 13;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(484, 295);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "Operatör";
            // 
            // txtDrive
            // 
            this.txtDrive.Location = new System.Drawing.Point(135, 290);
            this.txtDrive.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtDrive.Name = "txtDrive";
            this.txtDrive.Size = new System.Drawing.Size(339, 26);
            this.txtDrive.TabIndex = 12;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 295);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(60, 20);
            this.label14.TabIndex = 27;
            this.label14.Text = "Sürücü";
            // 
            // FormWeight1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 376);
            this.Controls.Add(this.txtOpera);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtDrive);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtMubel);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.weightMain);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtFree);
            this.Controls.Add(this.txtTransporterNameAR);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cmbTransporter);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtMaterialTextAR);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbMaterial);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPartyNameAR);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbParty);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnPlate);
            this.Controls.Add(this.cmbDocument);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.plateMain);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormWeight1";
            this.Text = "Ýlk Tartým";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UcPlate plateMain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbDocument;
        private System.Windows.Forms.Button btnPlate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbParty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPartyNameAR;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbMaterial;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMaterialTextAR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtTransporterNameAR;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbTransporter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtFree;
        private System.Windows.Forms.Label label11;
        private UcWeight weightMain;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ImageList ilMain;
        private System.Windows.Forms.TextBox txtMubel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtOpera;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtDrive;
        private System.Windows.Forms.Label label14;
    }
}