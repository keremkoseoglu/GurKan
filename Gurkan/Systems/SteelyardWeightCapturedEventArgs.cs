using System;
using System.Collections.Generic;
using System.Text;

namespace Gurkan
{
    public class SteelyardWeightCapturedEventArgs : System.EventArgs
    {
        private Weight _weight;

        public SteelyardWeightCapturedEventArgs(Weight W)
        {
            _weight = W;
        }

        public Weight weight
        {
            get
            {
                return _weight;
            }
        }
    }
}
