using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Gurkan
{
    public partial class UcWeight : UserControl
    {
        public delegate void UcWeightEventDelegate(object sender, EventArgs e);
        public event UcWeightEventDelegate weightTaken;

        private Weight _weight;

        public UcWeight()
        {
            InitializeComponent();

            if (Program.steelyard != null) Program.steelyard.weightCaptured += new Steelyard.WeightCapturedDelegate(steelyard_weightCaptured);
        }

        private void btnWeight_Click(object sender, EventArgs e)
        {
            btnWeight.Enabled = false;

            if (Program.steelyard.testMode)
            {
                txtWeight.Enabled = true;
                btnWeight.Enabled = true;

                if (weight.getWeight() != 0) weightTaken(this, e);
            }
            else
            {
                Program.steelyard.getWeight();
            }
        }

        void steelyard_weightCaptured(object sender, SteelyardWeightCapturedEventArgs e)
        {
            weight = e.weight;
            weightTaken(this, e);
            btnWeight.Enabled = true;
        }

        public Weight weight
        {
            get 
            {
                if (Program.steelyard == null) return null;

                if (Program.steelyard.testMode)
                {
                    _weight = new Weight();
                    _weight.setWeight(decimal.Parse(txtWeight.Text), Weight.UOM.KG);
                    return _weight;
                }
                else
                {
                    return _weight;
                }
            }
            set
            {
                _weight = value;
                if (_weight == null) { txtWeight.Text = "0"; return; }
                txtWeight.Text = _weight.getWeight().ToString();
            }
        }
    }
}
