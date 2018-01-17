using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Gurkan
{
    public partial class UcPlate : UserControl
    {
        private PlateNumber _plateNumber;

        public UcPlate()
        {
            InitializeComponent();
            _plateNumber = new PlateNumber();
        }
        
        public UcPlate(string Plate)
        {
            plateNumber = new PlateNumber(Plate);
        }

        public PlateNumber plateNumber
        {
            get
            {
                _plateNumber.plateNumber = txtPlate.Text;
                txtPlate.Text = _plateNumber.plateNumber;
                return _plateNumber;
            }

            set
            {
                _plateNumber = value;
                txtPlate.Text = _plateNumber.plateNumber;
            }
        }


    }
}
