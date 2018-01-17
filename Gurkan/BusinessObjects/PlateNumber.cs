using System;
using System.Collections.Generic;
using System.Text;

namespace Gurkan
{
    public class PlateNumber
    {
        private string _plate;

        public PlateNumber()
        {
            plateNumber = "";
        }

        public PlateNumber(string Plate)
        {
            plateNumber = Plate;
        }

        public string plateNumber
        {
            get
            {
                return _plate;
            }

            set
            {
                _plate = value;
                formatPlateNumber();
            }
        }

        private void formatPlateNumber()
        {
            _plate = _plate.ToUpper();
            _plate = _plate.Replace(" ", "");
        }

        public override string ToString()
        {
            return plateNumber;
        }
    }
}
