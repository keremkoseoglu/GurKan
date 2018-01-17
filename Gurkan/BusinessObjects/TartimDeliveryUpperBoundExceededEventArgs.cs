using System;
using System.Collections.Generic;
using System.Text;

namespace Gurkan
{
    public class TartimDeliveryUpperBoundExceededEventArgs : System.EventArgs
    {
        private decimal _exceedRate;

        public TartimDeliveryUpperBoundExceededEventArgs(decimal ExceedRate)
        {
            _exceedRate = ExceedRate;
        }

        public decimal exceedRate { get { return System.Math.Round(_exceedRate); } }
    }
}
