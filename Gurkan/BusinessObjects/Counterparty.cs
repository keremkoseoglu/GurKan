using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Gurkan
{
    public class Counterparty
    {
        public enum TYPE { CLIENT, VENDOR };
        public enum VENDOR_TYPE { VENDOR, TRANSPORTER };

        private string _id;
        private string _name_tr, _name_ar, _addre_tr, _addre_ar;
        private TYPE _type;
        private bool _vendo, _trans; // Sadece satýcý ise

        public Counterparty(TYPE T, string ID, bool IgnoreMissingCounterparty)
        {
            DataTable dt = new DataTable();
            _id = ID;
            _type = T;

            switch (_type)
            {
                case TYPE.CLIENT:
                    Program.sql.initializeStoredProcedure("SP_KNA1_GET_SINGLE");
                    Program.sql.addStoredProcedureParameter("@KUNNR", _id);
                    dt = Program.sql.executeStoredProcedureReader();
                    break;
                case TYPE.VENDOR:
                    Program.sql.initializeStoredProcedure("SP_LFA1_GET_SINGLE");
                    Program.sql.addStoredProcedureParameter("@LIFNR", _id);
                    dt = Program.sql.executeStoredProcedureReader();
                    break;
            }

            if (dt == null || dt.Rows.Count < 1)
            {
                if (!IgnoreMissingCounterparty) throw new Exception("Muhatap sistemde tanýmlý deðil");
                return;
            }
            _name_tr = dt.Rows[0]["NAME1_TR"].ToString();
            _name_ar = dt.Rows[0]["NAME1_AR"].ToString();

            if (_type == TYPE.VENDOR)
            {
                _vendo = dt.Rows[0]["VENDO"].ToString() == "X";
                _trans = dt.Rows[0]["TRANS"].ToString() == "X";
            }
            else
            {
                _vendo = false;
                _trans = false;
                _addre_tr = dt.Rows[0]["ADDRE_TR"].ToString();
                _addre_ar = dt.Rows[0]["ADDRE_AR"].ToString();
            }
        }

        public Counterparty(TYPE T, string ID, string TurkishName, string ArabicName, string TurkishAddress, string ArabicAddress)
        {
            _type = T;
            _id = ID;
            _name_tr = TurkishName;
            _name_ar = ArabicName;
            _vendo = false;
            _trans = false;
            _addre_tr = TurkishAddress;
            _addre_ar = ArabicAddress;
        }

        public Counterparty(TYPE T, string ID, string TurkishName, string ArabicName, bool UsableAsVendor, bool UsableAsTransporter)
        {
            _type = T;
            _id = ID;
            _name_tr = TurkishName;
            _name_ar = ArabicName;
            _vendo = UsableAsVendor;
            _trans = UsableAsTransporter;
        }

        public string id { get { return _id; } }
        public string idPacked { get { return Common.pack(_id); } }
        public string turkishName { get { return _name_tr; } }
        public string arabicName { get { return _name_ar; } }
        public bool usableAsVendor
        {
            get
            {
                if (_type != TYPE.VENDOR) return false;
                return _vendo;
            }
        }

        public bool usableAsTransporter
        {
            get
            {
                if (_type != TYPE.VENDOR) return false;
                return _trans;
            }
        }
        public string turkishAddress { get { return _addre_tr; } }
        public string arabicAddress { get { return _addre_ar; } }

        public override string ToString()
        {
            string ret = turkishName + " (" + Common.pack(id) + ")";
            if (arabicName != null && arabicName.Length > 0) ret += " - " + arabicName;
            return ret;
        }

        public static Counterparty[] getAll(TYPE T)
        {
            Counterparty[] ret;

            string key = (T == TYPE.CLIENT ? "KUNNR" : "LIFNR");
            string tab = (T == TYPE.CLIENT ? "KNA1" : "LFA1");

            Program.sql.connect();
            DataTable dt = Program.sql.selectData("SELECT * FROM " + tab + " ORDER BY NAME1_TR");
            if (dt == null) return null;
            if (dt.Rows.Count <= 0) return null;

            ret = new Counterparty[dt.Rows.Count];
            for (int n = 0; n < dt.Rows.Count; n++)
            {
                if (T == TYPE.CLIENT)
                {
                    ret[n] = new Counterparty(T, dt.Rows[n][key].ToString(), dt.Rows[n]["NAME1_TR"].ToString(), dt.Rows[n]["NAME1_AR"].ToString(), dt.Rows[n]["ADDRE_TR"].ToString(), dt.Rows[n]["ADDRE_AR"].ToString());
                }
                else
                {
                    ret[n] = new Counterparty(T, dt.Rows[n][key].ToString(), dt.Rows[n]["NAME1_TR"].ToString(), dt.Rows[n]["NAME1_AR"].ToString(), dt.Rows[n]["VENDO"].ToString() == "X", dt.Rows[n]["TRANS"].ToString() == "X");
                }
            }

            return ret;
        }

        public static Counterparty[] getAllVendors(VENDOR_TYPE V)
        {
            Counterparty[] cnt = getAll(TYPE.VENDOR);

            ArrayList al = new ArrayList();
            for (int n = 0; n < cnt.Length; n++)
            {
                bool valid = true;

                if (V == VENDOR_TYPE.VENDOR && !cnt[n].usableAsVendor) valid = false;
                if (V == VENDOR_TYPE.TRANSPORTER && !cnt[n].usableAsTransporter) valid = false;

                if (valid) al.Add(cnt[n]);
            }

            if (al.Count <= 0) return null;

            Counterparty[] ret = new Counterparty[al.Count];
            for (int n = 0; n < al.Count; n++)
            {
                ret[n] = (Counterparty)al[n];
            }

            return ret;
        }


    }
}
