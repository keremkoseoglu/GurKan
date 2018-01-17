using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gurkan
{
    public partial class FormMain : Form
    {
        
        public FormMain()
        {
            InitializeComponent();
            lblStatus.Text = "Aktif Kantar: " + Program.steelyard.ToString();
            this.Text = Program.appName;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {

            Program.frmTest = new FormTest();
            Program.frmTest.Show();
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.syncThread.Abort();
            Application.Exit();
        }

        public void setIntegrationStatus(Common.STATUS S)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    switch (S)
                    {
                        case Common.STATUS.GRAY:
                            btnEnt.Image = imageListMain.Images[3];
                            break;
                        case Common.STATUS.GREEN:
                            btnEnt.Image = imageListMain.Images[0];
                            break;
                        case Common.STATUS.RED:
                            btnEnt.Image = imageListMain.Images[2];
                            break;
                        case Common.STATUS.YELLOW:
                            btnEnt.Image = imageListMain.Images[1];
                            break;
                        case Common.STATUS.WORKING:
                            btnEnt.Image = imageListMain.Images[4];
                            break;
                    }
                }));
            }
            else
            {
                switch (S)
                {
                    case Common.STATUS.GRAY:
                        btnEnt.Image = imageListMain.Images[3];
                        break;
                    case Common.STATUS.GREEN:
                        btnEnt.Image = imageListMain.Images[0];
                        break;
                    case Common.STATUS.RED:
                        btnEnt.Image = imageListMain.Images[2];
                        break;
                    case Common.STATUS.YELLOW:
                        btnEnt.Image = imageListMain.Images[1];
                        break;
                    case Common.STATUS.WORKING:
                        btnEnt.Image = imageListMain.Images[4];
                        break;
                }
            }



            Application.DoEvents();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            Program.sync.doSyncManual();
            button1.Enabled = true;
        }

        private void btnSal1_Click(object sender, EventArgs e)
        {
            displayFormWeight1(Tartim.SCENARIO.SALES);
        }

        private void btnSal2_Click(object sender, EventArgs e)
        {
            displayFormWeight2(Tartim.SCENARIO.SALES);
        }

        private void btnEnt_Click(object sender, EventArgs e)
        {
            Program.logger.displayLog();
        }

        private void btnDara_Click(object sender, EventArgs e)
        {
            if (Program.frmPlatformWeight == null || Program.frmPlatformWeight.Visible == false)
            {
                Program.frmPlatformWeight = new FormPlatformWeight();
                try { Program.frmPlatformWeight.Show(); } catch { }
            }
        }

        private void btnFree_Click(object sender, EventArgs e)
        {
            if (Program.frmFreeWeight == null || Program.frmFreeWeight.Visible == false)
            {
                Program.frmFreeWeight = new FormFreeWeight();
                try { Program.frmFreeWeight.Show(); } catch { }
            }
        }

        private void btnPur2_Click(object sender, EventArgs e)
        {
            displayFormWeight1(Tartim.SCENARIO.PURCHASING);
        }

        private void displayFormWeight1(Tartim.SCENARIO S)
        {
            if (Program.frmW1 == null || Program.frmW1.Visible == false)
            {
                Program.frmW1 = new FormWeight1(S);
                Program.frmW1.Show();
            }
        }

        private void displayFormWeight2(Tartim.SCENARIO S)
        {
            try
            {
                if (Program.frmW2 == null || Program.frmW2.Visible == false)
                {
                    Program.frmW2 = new FormWeight2(S);
                    Program.frmW2.Show();
                }
            } catch { }
        }

        private void btnPur1_Click(object sender, EventArgs e)
        {
            displayFormWeight2(Tartim.SCENARIO.PURCHASING);
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            if (Program.frmReprint == null || Program.frmReprint.Visible == false)
            {
                Program.frmReprint = new FormReprint();
                Program.frmReprint.Show();
            }
        }

        public Image deliveryLogo { get { return pictureBox2.Image; } }


    }
}