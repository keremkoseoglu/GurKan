using System;
using System.Collections.Generic;
using System.Text;

namespace Gurkan
{
    public class MaterialGroup
    {
        private string _matkl, _wgbez_tr, _wgbez_ar;

        public MaterialGroup(string Matkl, string Wgbez_TR, string Wgbez_AR)
        {
            _matkl = Matkl;
            _wgbez_tr = Wgbez_TR;
            _wgbez_ar = Wgbez_AR;
        }

        public string id { get { return _matkl; } }
        public string turkishName { get { return _wgbez_tr; } }
        public string arabicName { get { return _wgbez_ar; } }
    }
}
