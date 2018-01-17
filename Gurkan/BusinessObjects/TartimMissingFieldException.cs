using System;
using System.Collections.Generic;
using System.Text;

namespace Gurkan
{
    public class TartimMissingFieldException : System.Exception
    {
        private string _missingField;

        public TartimMissingFieldException(string MissingField)
        {
            _missingField = MissingField;
        }

        public string missingField { get { return _missingField; } }
    }
}
