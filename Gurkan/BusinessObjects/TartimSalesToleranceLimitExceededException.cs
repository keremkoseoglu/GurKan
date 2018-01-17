using System;
using System.Collections.Generic;
using System.Text;

namespace Gurkan
{
    public class TartimSalesToleranceLimitExceededException : System.Exception
    {
        public enum DIRECTION { UPPER, LOWER };
        private decimal _exceedRate;
        private DIRECTION _direction;

        public TartimSalesToleranceLimitExceededException(decimal ExceedRate)
        {
            _exceedRate = ExceedRate;
            _direction = _exceedRate < 0 ? DIRECTION.LOWER : DIRECTION.UPPER;
        }

        public decimal exceedRate { get { return System.Math.Round(_exceedRate); } }
        public DIRECTION direction { get { return _direction; } }
    }
}
