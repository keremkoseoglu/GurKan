using System;
using System.Collections.Generic;
using System.Text;

namespace Gurkan
{
    public class SyncEventArgs : System.EventArgs
    {
        public Common.STATUS status;

        public SyncEventArgs(Common.STATUS S)
        {
            status = S;
        }
    }
}
