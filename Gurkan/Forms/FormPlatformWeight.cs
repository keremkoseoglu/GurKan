using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Gurkan
{
    public partial class FormPlatformWeight : Form
    {
        public FormPlatformWeight()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void weightMain_weightTaken(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            Steelyard sy = new Steelyard(Program.config.KantarID, Program.sql);
            sy.weight = weightMain.weight;
            sy.savePlatformWeight();
            btnSave.Enabled = true;
        }
    }
}