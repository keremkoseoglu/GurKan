using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gurkan
{
    public partial class FormFreeWeight : Form
    {
        private Tartim tartim;

        public FormFreeWeight()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void weightMain_weightTaken(object sender, EventArgs e)
        {
            tartim = new Tartim();
            tartim.scenario = Tartim.SCENARIO.FREE;
            tartim.firstWeightDate = System.DateTime.Now;
            tartim.firstWeight = weightMain.weight;

            txtPlatform.Text = tartim.platformWeight.getWeight().ToString();
            txtNet.Text = tartim.netWeight.getWeight().ToString();

            btnPrint.Enabled = true;
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (tartim == null) return;

            btnPrint.Enabled = false;

            PrintoutWeight pw = new PrintoutWeight();
            pw.print(tartim);

            btnPrint.Enabled = true;
        }


    }
}