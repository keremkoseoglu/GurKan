using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Gurkan
{
    public class Material
    {
        public enum SALES_LIMIT_EXCEED_ACTION { WARNING, ERROR };

        private string _matnr;
        private string _maktx_tr, _maktx_ar;
        private bool _sella;
        private MaterialGroup _mg;

        private bool _lolic, _uplic;
        private int _lolim, _uplim;
        private string _lolia, _uplia;

        public Material(string Matnr)
        {
            _matnr = Matnr;

            Program.sql.initializeStoredProcedure("SP_MARA_GET_SINGLE");
            Program.sql.addStoredProcedureParameter("@MATNR", _matnr);
            DataTable dt = Program.sql.executeStoredProcedureReader();

            if (dt == null || dt.Rows.Count < 1) throw new Exception("Malzeme sistemde tanýmlý deðil");
            _maktx_tr = dt.Rows[0]["MAKTX_TR"].ToString();
            _maktx_ar = dt.Rows[0]["MAKTX_AR"].ToString();
            _sella = dt.Rows[0]["SELLA"].ToString() == "X";

            _mg = new MaterialGroup(dt.Rows[0]["MATKL"].ToString(), dt.Rows[0]["WGBEZ_TR"].ToString(), dt.Rows[0]["WGBEZ_AR"].ToString());

            _lolic = dt.Rows[0]["LOLIC"].ToString() == "X";
            try { _lolim = (int)dt.Rows[0]["LOLIM"]; } catch { }
            _lolia = dt.Rows[0]["LOLIA"].ToString();

            _uplic = dt.Rows[0]["UPLIC"].ToString() == "X";
            try { _uplim = (int)dt.Rows[0]["UPLIM"]; } catch { }
            _uplia = dt.Rows[0]["UPLIA"].ToString();
        }

        public Material(string Matnr, string Maktx_TR, string Maktx_AR, MaterialGroup MG, bool Sellable)
        {
            _matnr = Matnr;
            _maktx_tr = Maktx_TR;
            _maktx_ar = Maktx_AR;
            _mg = MG;
            _sella = Sellable;
        }

        public string id { get { return _matnr; } }
        public string turkishName { get { return _maktx_tr; } }
        public string arabicName { get { return _maktx_ar; } }
        public MaterialGroup materialGroup { get { return _mg; } }
        public bool sellable { get { return _sella; } }

        public bool lowSalesLimitMustBeControlled { get { return _lolic; } }
        public int lowSalesLimitRate { get { return _lolim; } }
        public SALES_LIMIT_EXCEED_ACTION lowSalesLimitExceedAction { get { return _lolia == "E" ? SALES_LIMIT_EXCEED_ACTION.ERROR : SALES_LIMIT_EXCEED_ACTION.WARNING; } }

        public bool highSalesLimitMustBeControlled { get { return _uplic; } }
        public int highSalesLimitRate { get { return _uplim; } }
        public SALES_LIMIT_EXCEED_ACTION highSalesLimitExceedAction { get { return _uplia == "E" ? SALES_LIMIT_EXCEED_ACTION.ERROR : SALES_LIMIT_EXCEED_ACTION.WARNING; } }

        public override string ToString()
        {
            string ret = turkishName + " (" + Common.pack(id) + ")";
            if (arabicName != null && arabicName.Length > 0) ret += " - " + arabicName;
            return ret;
        }

        public static Material[] getAll(Tartim.SCENARIO S)
        {
            Material[] ret;
            DataTable dt = new DataTable();

            Program.sql.connect();

            switch (S)
            {
                case Tartim.SCENARIO.PURCHASING:
                    Program.sql.initializeStoredProcedure("SP_MARA_GET_PURCHASEABLES");
                    dt = Program.sql.executeStoredProcedureReader();
                    break;
                case Tartim.SCENARIO.SALES:
                    Program.sql.initializeStoredProcedure("SP_MARA_GET_SELLABLES");
                    dt = Program.sql.executeStoredProcedureReader();
                    break;
            }

            if (dt == null) return null;
            if (dt.Rows.Count <= 0) return null;

            ret = new Material[dt.Rows.Count];
            for (int n = 0; n < dt.Rows.Count; n++)
            {
                ret[n] = new Material(dt.Rows[n]["MATNR"].ToString(), dt.Rows[n]["MAKTX_TR"].ToString(), dt.Rows[n]["MAKTX_AR"].ToString(), new MaterialGroup(dt.Rows[0]["MATKL"].ToString(), dt.Rows[0]["WGBEZ_TR"].ToString(), dt.Rows[0]["WGBEZ_AR"].ToString()), dt.Rows[n]["SELLA"].ToString() == "X");
            }

            return ret;
        }
    }
}
