using System;
using System.Collections.Generic;
using System.Text;

namespace Gurkan
{
    public class Weight
    {
        public enum UOM { KG, TON };

        private decimal _weight;
        private UOM _uom;

        public Weight()
        {
        }

        public Weight(decimal Value, UOM U)
        {
            setWeight(Value, U);
        }

        public Weight(decimal Value, string Uom)
        {
            setWeight(Value, getUomFromString(Uom));
        }

        public void setWeight(decimal Value, UOM U)
        {
            switch (U)
            {
                case UOM.KG:
                    _weight = Value;
                    break;
                case UOM.TON:
                    _weight = Value * 1000;
                    break;
            }

            _uom = UOM.KG;
        }

        public decimal getWeight()
        {
            return _weight;
        }

        public decimal getWeight(UOM U)
        {
            switch (U)
            {
                case UOM.KG:
                    return getWeight();
                case UOM.TON:
                    return System.Math.Round(getWeight() / 1000);
            }

            return 0;
        }

        public UOM uom
        {
            get { return _uom; }
        }

        public string uomText
        {
            get { return getUomString(_uom); }
        }

        public string weightText
        {
            get
            {
                return Common.getDecimalText(_weight);
            }
        }

        public string weightTextInTons
        {
            get
            {
                return Common.getDecimalText(getWeight(UOM.TON));
            }
        }

        public override string ToString()
        {
            return Common.parseDecimal(_weight) + " " + getUomString(_uom);
        }

        private static string getUomString(UOM U)
        {
            switch (U)
            {
                case UOM.KG:
                    return "KG";
                    break;
                case UOM.TON:
                    return "TON";
                    break;
            }

            return "";
        }

        private static UOM getUomFromString(string S)
        {
            string s = S.ToUpper().Trim();

            switch (s)
            {
                case "KG":
                    return UOM.KG;
                    break;
                case "TON":
                    return UOM.TON;
                    break;
            }

            return UOM.KG;
        }

    }
}
