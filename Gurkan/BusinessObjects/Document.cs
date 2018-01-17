using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Gurkan
{
    public class Document
    {
        private string _number;
        private Weight _weight;
        private Material _material;
        private Counterparty _counterParty;
        private Counterparty _transporter;

        public Document(string Number, Weight W, Material M, Counterparty Party, Counterparty Transporter)
        {
            _number = Number;
            _weight = W;
            _material = M;
            _counterParty = Party;
            _transporter = Transporter;
        }

        public string number
        {
            get { return _number; } 
        }

        public Weight weight
        {
            get { return _weight; }
        }

        public Material material
        {
            get { return _material; }
        }

        public Counterparty counterParty
        {
            get { return _counterParty; }
        }

        public Counterparty transporter { get { return _transporter; } }

        public override string ToString()
        {
            return numberPacked + " :: " + material.ToString() + " :: " + weight.ToString();
        }

        public string numberPacked { get { return Common.pack(number); } }

        public static DataRow getDelivery(string Number)
        {
            Program.sql.connect();
            Program.sql.initializeStoredProcedure("SP_LIKP_GET_SINGLE");
            Program.sql.addStoredProcedureParameter("@VBELN", Number);
            DataTable dt = Program.sql.executeStoredProcedureReader();
            if (dt == null) return null;
            if (dt.Rows.Count <= 0) return null;

            return dt.Rows[0];
        }
    }
}
